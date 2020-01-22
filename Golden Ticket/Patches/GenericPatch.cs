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
    /// This patch applies to all platforms.
    /// </summary>
    public class GenericPatch : Patch
    {
        protected override string ExtractedFolderName { get; } = "Generic-Patch-Files-master"; // The folder inside the zip
        public override string Name { get; } = Resources.Patch_Generic_Name; // Friendly name for patch

        protected override string DownloadUrl => Resources.Patch_Generic_Url; // Path to the patch
        // For testing - the Linux kernel
        //protected override string DownloadUrl => Resources.Patch_FakePatch_Url;
    }
}
