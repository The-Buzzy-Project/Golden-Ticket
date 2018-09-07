using System;
using System.Net;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Golden_Ticket.Classes;
using Golden_Ticket.Properties;

namespace Golden_Ticket.Windows
{
    /// <summary>
    /// Gets and displays progress for updates to Golden Ticket.
    /// </summary>
    public partial class UpdateWindow : Form
    {
        private readonly CancellationTokenSource _cancel = new CancellationTokenSource();
        // TODO: Document this form.
        private Update UpdateData { get; }

        public UpdateWindow(Update update)
        {
            UpdateData = update;
            InitializeComponent();
        }

        private void UpdateWindow_Load(object sender, EventArgs e)
        {
            CurrentVersionLabel.Text = "Current version: " + UpdateData.LauncherVersion;
            NewVersionLabel.Text = "New version: " + UpdateData.NewVersion;
            DownloadUpdate();
        }

        void DownloadUpdate()
        {
            UpdateData.FileProgressChanged += client_DownloadProgressChanged;
            UpdateData.FileDownloaded += client_DownloadFileCompleted;
            UpdateData.Download(_cancel.Token);
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Start the installer
            try
            {
                UpdateData.Install();
                // Close the launcher
                Application.Exit();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "There was a problem installing this update. If the problem persists, try manually downloading it from:" +
                    Environment.NewLine + Environment.NewLine + Resources.UpdateChecker_Url,
                    "Update Failed to Install", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;

            DownloadProgressBar.Value = e.ProgressPercentage;
        }
    }
}