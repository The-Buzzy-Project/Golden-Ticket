using Golden_Ticket.Properties;

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
