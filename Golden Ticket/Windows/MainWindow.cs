using Golden_Ticket.Utilities;
using Golden_Ticket.Windows;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using Golden_Ticket.Classes;
using Golden_Ticket.Properties;

namespace Golden_Ticket
{
    public partial class MainWindow : Form
    {
        // TODO: Clean up this file.
        // TODO: Document this file.
        // TODO: Add UAC shield to patch button when appropriate, remove prompt.
        private Game TpwGame { get; }
        
        public MainWindow(Game game)
        {
            TpwGame = game;
            TpwGame.GamePathChanged += OnGamePathChanged;
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            ThemeLauncher();

            ShowTpwStatus();

            if (Settings.Default.CheckForUpdatesOnStart) CheckForUpdates();
            SetTpwPresent();
        }

        private void SetTpwPresent() => launchButton.Enabled = TpwGame.IsTpwPresent;

        #region Event handlers

        private void OnGamePathChanged(object sender, EventArgs e)
        {
            ShowTpwStatus(); SetTpwPresent();
        }

        #endregion

        #region Game status indicators
        private void ShowTpwStatus()
        {
            ShowPatchStatus(); ShowGoldEditionStatus(); ShowVersionStatus();
        }

        private void ShowPatchStatus()
        {
            patchedLabel.Text = $"{Resources.Patched}: {(TpwGame.IsPatched ? "Yes" : "No")}";
        }

        private void ShowGoldEditionStatus()
        {
            goldEditionLabel.Text = $"{Resources.GoldEdition}: {(TpwGame.IsGoldEdition ? "Yes" : "No")}";
        }

        private void ShowVersionStatus()
        {
            versionLabel.Text = $"{Resources.Version}: {(TpwGame.Version ?? Resources.Unknown)}";
        }
#endregion
                
        void ThemeLauncher()
        {
            // Applies transparency to bottom and centre panels
            // Transparency makes form redrawing VERY slow
            // Might be worth reconsidering the UI or using WPF?
            bottomPanel.BackColor = Color.FromArgb(127, 0, 0, 0);
            mainPanel.BackColor = Color.FromArgb(127, 0, 0, 0);
        }

        #region Button click events

        #region Middle panel

        private void patchButton_Click(object sender, EventArgs e)
        {
            // TODO: Check if TPW/STP executable is present.
            PatchingWindow window = new PatchingWindow(TpwGame, PatchList.GetPatches());
            window.ShowDialog();
        }

        #endregion

        #region Bottom panel

        private void launchButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Attempt to start game
                TpwGame.StartGame();
                Application.Exit();
            }
            catch (Exception ex)
            {
                // Unexpected error. Why can't we launch the game?
                NotifyUser.Notify(this, "Could Not Start Game",
                    "Unfortunately, we've run into an unexpected error and were unable to launch the game." +
                    Environment.NewLine + "Please screenshot this message box and send it to the developer." +
                    Environment.NewLine + Environment.NewLine + ex,
                    MessageBoxIcon.Error, MessageBoxButtons.OK);
            }
        }
        
        private void optionsButton_Click(object sender, EventArgs e)
        {
            using (OptionsWindow optionsWindow = new OptionsWindow(TpwGame))
            {
                optionsWindow.ShowDialog();
            }
        }

        #endregion

        #endregion

        private void CheckForUpdates()
        {
            UpdateChecker updateChecker;
            // Check for updates
            try
            {
                updateChecker = new UpdateChecker();
            }
            catch (WebException)
            {
                NotifyUser.Notify(this, Resources.UpdateChecker_Error_Title,
                    "Golden Ticket was unable to connect to the update server. Updates cannot be installed without a working Internet connection.",
                    MessageBoxIcon.Warning, MessageBoxButtons.OK);
                return;
            }
            catch (Exception e)
            {
                NotifyUser.Notify(this, Resources.UpdateChecker_Error_Title,
                    "An unexpected error occurred while checking for updates. Golden Ticket will not be able to notify you of new updates."
                    + Environment.NewLine + Environment.NewLine +
                    "Below is the error. Please screenshot this message box and report it to the developer by creating a new Issue on GitHub."
                    + Environment.NewLine + Environment.NewLine + e
                    ,
                    MessageBoxIcon.Warning, MessageBoxButtons.OK);
                return;
            }

            if (updateChecker.IsUpdateAvailable)
            {
                if (MessageBox.Show(string.Format(Resources.UpdateChecker_Message, ProductName), Resources.UpdateChecker_Title,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    UpdateWindow updateWindow = new UpdateWindow(updateChecker.LatestVersion);
                    updateWindow.ShowDialog();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(new Microsoft.VisualBasic.Devices.ComputerInfo().OSFullName);
        }
    }
}