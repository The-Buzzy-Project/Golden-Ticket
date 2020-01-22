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


﻿using System.Collections.Generic;
using Golden_Ticket.Patches;

namespace Golden_Ticket.Utilities
{
    /// <summary>
    /// Gets a list of patches appropriate for this system.
    /// </summary>
    public static class PatchList
    {
        /// <summary>
        /// Returns the patch list for this system.
        /// </summary>
        /// <returns>List of patches as array.</returns>
        /// <remarks>
        /// Interestingly, Windows versions after 8 misreport their version number if the application doesn't report compatibility with those newer Windows versions.
        /// Make sure the manifest is set up right.
        /// </remarks>
        public static Patch[] GetPatches()
        {
            // Use the Windows build to determine version
            // Unsure if this is the best way, but it seems the most consistent
            int winVer = MachineInfo.WindowsBuild;
            List<Patch> patches = new List<Patch> { new GenericPatch() };

            if (winVer >= 6000 && winVer <= 7601)
            {
                // Patch for Vista/7
                // Disabled as it does not seem to exist on the server
                //patches.Add(new WinVistaPatch());
            }

            if (winVer > 7601)
            {
                // Patch for 8/8.1/10+
                patches.Add(new Win8Patch());
            }

            return patches.ToArray();
        }
    }
}
