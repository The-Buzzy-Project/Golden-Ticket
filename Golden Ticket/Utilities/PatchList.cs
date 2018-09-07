using System.Collections.Generic;
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
