using System.Diagnostics;
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
