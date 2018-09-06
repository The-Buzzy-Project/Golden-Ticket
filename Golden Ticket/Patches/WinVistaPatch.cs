using Golden_Ticket.Properties;

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
