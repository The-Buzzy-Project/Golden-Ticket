using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Golden_Ticket.Classes;
using Golden_Ticket.Patches;
using Golden_Ticket.Properties;
using Golden_Ticket.Utilities;

namespace Golden_Ticket.Windows
{
    /// <summary>
    /// Gets, installs and reports on a list of patches specified by the caller.
    /// </summary>
    public partial class PatchingWindow : Form
    {
        // TODO: Document this form.
        private Game TpwGame { get; }
        private Patch[] Patches { get; }
        private Dictionary<Patch, int> DownloadProgress = new Dictionary<Patch, int>();
        private Dictionary<Patch, int> InstallProgress = new Dictionary<Patch, int>();
        private Dictionary<Patch, CancellationTokenSource> CancelTokens = new Dictionary<Patch, CancellationTokenSource>();
        private Dictionary<Patch, Label> Labels = new Dictionary<Patch, Label>();

        public PatchingWindow(Game game, params Patch[] patches)
        {
            // TODO: Additional testing for elevated process.
            TpwGame = game;
            Patches = patches;
            InitializeComponent();
            if (!game.IsGameDirWritable)
            {
                // This prompt only shows if UAC is active
                // If it's not, we can't elevate
                if (!MachineInfo.IsAdministrator && MachineInfo.IsUacEnabled)
                {
                    if (MessageBox.Show(
                            "Your game folder does not appear to be writable. Would you like to try relaunching as an administrator?",
                            "Could Not Install Patches", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) ==
                        DialogResult.Yes)
                    {
                        Permissions.RunElevated("/i");
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Your game folder does not appear to be writable. Ensure that you have write access to your Theme Park World folder and try again.",
                        "Could Not Install Patches", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Close immediately
                // TODO: Fix flicker.
                Load -= DownloadingPatchWindow_Load;
                Load += (s, e) => Close();
            }
        }

        private void DownloadingPatchWindow_Load(object sender, EventArgs e)
        {
            // Add progress labels to table
            patchesTable.SuspendLayout();
            foreach (Patch patch in Patches)
            {
                StartDownload(patch);
            }
            patchesTable.ResumeLayout();
        }

        private void StartDownload(Patch patch)
        {
            AddPatchLabelToTable(patch);
            // Get event handlers for progress and success
            patch.FileProgressChanged += DownloadProgressChanged;
            patch.FileDownloaded += DownloadFileCompleted;
            DownloadProgress.Add(patch, 0);
            InstallProgress.Add(patch, 0);
            CancelTokens.Add(patch, new CancellationTokenSource());
            // Starts the download
            patch.Download(CancelTokens[patch].Token);
        }

        private void StartInstall(Patch patch)
        {
            SetLabelText(patch, GetInstallLabelText(patch));
            patch.InstallProgressChanged += InstallProgressChanged;
            patch.InstallComplete += InstallCompleted;
            patch.InstallAsync(TpwGame.GamePath, CancelTokens[patch].Token);
        }

        #region Create/set label
        private Label CreatePatchLabel(Patch patch) => new Label()
        {
            AutoSize = true,
            FlatStyle = FlatStyle.System,
            Margin = new Padding(3, 0, 3, 0),
            Text = GetDownloadLabelText(patch)
        };

        private void AddPatchLabelToTable(Patch patch)
        {
            Label label = CreatePatchLabel(patch);
            patchesTable.RowStyles.Insert(1, new RowStyle(SizeType.AutoSize));
            patchesTable.Controls.Add(label, 0, 1);
            Labels.Add(patch, label);
        }

        private void SetLabelText(Patch patch, string text)
        {
            Label label = GetLabel(patch);
            if (label != null) label.Text = text;
        }

        private Label GetLabel(Patch patch)
        {
            Labels.TryGetValue(patch, out Label label);
            return label;
        }

        private string GetDownloadLabelText(Patch patch) => string.Format(Resources.Patcher_DownloadingIndeterminate, patch.Name);
        private string GetDownloadLabelText(Patch patch, double progress) => string.Format(
            Resources.Patcher_Downloading, patch.Name,
            Math.Round(progress, 0, MidpointRounding.AwayFromZero).ToString(CultureInfo.CurrentCulture));

        private static string GetInstallLabelText(Patch patch) =>
            string.Format(Resources.Patcher_InstallingIndeterminate, patch.Name);

        private static string GetInstallLabelText(Patch patch, int progress) =>
            string.Format(Resources.Patcher_Installing, patch.Name, progress);
        #endregion

        #region Download event handlers
        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            UpdateDownloadProgress((Patch)e.UserState, e.BytesReceived, e.TotalBytesToReceive);
        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Patch patch = (Patch)e.UserState;
            if (e.Error == null)
            {
                if (e.Cancelled)
                {
                    DownloadProgress[patch] = 100;
                    UpdateProgressBar();
                }
                else
                {
                    DownloadProgress[patch] = 100;
                    UpdateProgressBar();
                    StartInstall(patch);
                }
            }
            else
            {
                TaskFailed(patch, e.Error.Message);
            }
        }
        #endregion

        #region Install event handlers
        private void InstallProgressChanged(object sender, InstallEventArgs e)
        {
            Patch patch = (Patch) sender;
            SetLabelText(patch, GetInstallLabelText(patch, e.Progress));
            InstallProgress[patch] = e.Progress;
            UpdateProgressBar();
        }
        
        private void InstallCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Patch patch = (Patch) sender;
            InstallProgress[patch] = 100;
            UpdateProgressBar();
            SetLabelText(patch, string.Format(Resources.Patcher_Success, patch.Name));
        }
        #endregion

        private void TaskFailed(Patch patch, string reason)
        {
            DownloadProgress[patch] = 100;
            InstallProgress[patch] = 100;
            UpdateProgressBar();
            Label label = GetLabel(patch);
            label.Text = string.Format(Resources.Patcher_Failed, patch.Name);
            label.Cursor = Cursors.Help;
            ToolTip toolTip = new ToolTip()
            {
                ToolTipIcon = ToolTipIcon.Error,
                IsBalloon = true,
                ToolTipTitle = "The patch failed to install"
            };
            toolTip.SetToolTip(label, reason);
        }

        private void AllTasksComplete()
        {
            patchingTitleLabel.Text = "Finished.";
            cancelButton.Tag = "close";
            cancelButton.Text = Resources.Button_Close;
        }

        #region Download progress helpers
        private void UpdateDownloadProgress(Patch patch, long bytesReceived, long bytesTotal)
        {
            int percentage = GetDownloadProgress(bytesReceived, bytesTotal);
            DownloadProgress[patch] = percentage;
            UpdateProgressBar();
            SetLabelText(patch, GetDownloadLabelText(patch, percentage));
        }

        private int GetDownloadProgress(long bytesReceived, long bytesTotal) =>
            (bytesTotal != -1) ? (int) (((double) bytesReceived / bytesTotal) * 100) : 0;
#endregion

        private void UpdateProgressBar()
        {
            int progress = 0;
            
            foreach (int i in DownloadProgress.Values)
            {
                progress += i;
            }

            foreach (int i in InstallProgress.Values)
            {
                progress += i;
            }
            
            PatchingProgressbar.Value = (progress / DownloadProgress.Count) / 2;
            if (progress == 100 * (DownloadProgress.Count * 2))
            {
                AllTasksComplete();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if ((string) cancelButton.Tag == "close")
            {
                Close();
            }
            else
            {
                foreach (Patch patch in Patches)
                {
                    CancelTokens[patch].Cancel();
                }
            }
            
        }
    }
}
