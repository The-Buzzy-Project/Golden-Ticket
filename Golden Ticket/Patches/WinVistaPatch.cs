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


﻿using Golden_Ticket.Properties;

namespace Golden_Ticket.Patches
{
    /// <inheritdoc/>
    /// <summary>
    /// This patch is for Windows Vista and 7. The patch does not seem to be available so it is not offered here.
    /// </summary>
    public class WinVistaPatch : Patch
    {
        protected override string DownloadUrl { get; } // Path to the patch
        protected override string ExtractedFolderName { get; } // The folder inside the zip
        public override string Name => Resources.Patch_WinVista_Name; // Get friendly name from resource
    }
}
