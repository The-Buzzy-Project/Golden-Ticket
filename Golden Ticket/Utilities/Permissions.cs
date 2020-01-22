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
