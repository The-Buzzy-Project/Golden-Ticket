using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Golden_Ticket.Utilities
{
    /// <summary>
    /// Performs tasks related to permissions (well, one really).
    /// </summary>
    public static class Permissions
    {
        /// <summary>
        /// Runs this process elevated with an administrator token.
        /// </summary>
        /// <param name="arguments">Arguments and switches to be passed to the new process.</param>
        /// <remarks>Does not seem to work when running the application from a network share.</remarks>
        public static void RunElevated(string arguments = null)
        {
            ProcessStartInfo elevatedProcess = new ProcessStartInfo
            {
                UseShellExecute = true,
                Arguments = arguments ?? "",
                WorkingDirectory = Environment.CurrentDirectory,
                FileName = Application.ExecutablePath,
                Verb = "runas"
            };
            Process.Start(elevatedProcess);
        }
    }
}
