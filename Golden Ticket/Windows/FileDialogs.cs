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
