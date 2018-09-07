using System;
using System.Windows.Forms;
using Golden_Ticket.Properties;

namespace Golden_Ticket.Windows
{
    /// <summary>
    /// Reusable file dialogues for common tasks
    /// </summary>
    public static class FileDialogs
    {
        /// <summary>
        /// Folder browser for the TPW/STP folder.
        /// </summary>
        /// <returns>Path to TPW/STP folder, or null if the user cancels.</returns>
        public static string GetTpwFolder()
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog()
            {
                Description = Resources.FolderBrowser_Description,
                ShowNewFolderButton = false,
                SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
            };
            return ofd.ShowDialog() == DialogResult.OK ? ofd.SelectedPath : null;
        }
    }
}
