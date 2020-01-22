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


﻿using System.Diagnostics;
using System.Windows.Forms;

namespace Golden_Ticket.Classes
{
    /// <inheritdoc />
    /// <summary>
    /// Describes an update for Golden Ticket.
    /// </summary>
    public class Update : Downloadable
    {
        protected override string DownloadUrl { get; } // Location of update file
        public string LauncherVersion => Application.ProductVersion; // Gets application version
        public string NewVersion { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="downloadUrl">Remote resource where update file will come from.</param>
        /// <param name="newVersion">Latest version found in the update request.</param>
        public Update(string downloadUrl, string newVersion)
        {
            DownloadUrl = downloadUrl;
            NewVersion = newVersion;
        }

        /// <summary>
        /// Installs the downloaded update - currently executes an installer file.
        /// </summary>
        public void Install()
        {
            // TODO: Installer doesn't work. Create shiny new one for the now portable application?
            // TODO: Check if user can elevate first.
            // Run the installer as an administrator
            // Do not use ShellExec as it doesn't know the temp file extension
            ProcessStartInfo process = new ProcessStartInfo()
            {
                UseShellExecute = false,
                Verb = "runas",
                FileName = SavePath,
                Arguments = "/S"
            };
            Process.Start(process);
        }

        // For now, check if version differs from latest published
        // TODO: More sophisticated update detection.
        public bool IsLaterVersion => LauncherVersion != NewVersion;

        protected override void Cleanup() { } // Don't clean up - we need that update file!
    }
}
