/*   This file is part of Golden Ticket.
*
*    Golden Ticket is free software: you can redistribute it and/or modify
*    it under the terms of the GNU General Public License as published by
*    the Free Software Foundation, either version 2 of the License, or
*    (at your option) any later version.
*
*    Golden Ticket is distributed in the hope that it will be useful,
*    but WITHOUT ANY WARRANTY; without even the implied warranty of
*    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
*    GNU General Public License for more details.
*
*    You should have received a copy of the GNU General Public License
*    along with Golden Ticket.  If not, see <https://www.gnu.org/licenses/>.
*/


﻿using System;
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