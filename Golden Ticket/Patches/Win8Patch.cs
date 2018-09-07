using Golden_Ticket.Properties;

namespace Golden_Ticket.Patches
{
    /// <inheritdoc/>
    /// <summary>
    /// This patch is for all versions of Windows from 8 onwards.
    /// </summary>
    public class Win8Patch : Patch
    {
        protected override string DownloadUrl => Resources.Patch_Win8_Url; // Path to the patch
        protected override string ExtractedFolderName { get; } = "8-10-Configs-master"; // The folder inside the zip
        public override string Name => Resources.Patch_Win8_Name; // Get friendly name from resource
    }
}
