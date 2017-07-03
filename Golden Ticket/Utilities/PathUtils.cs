using System;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

public class PathUtils
{
    static string gtDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Golden Ticket";
    static string gtDownloadsFolder = gtDocumentsFolder + "\\Downloads";
    static string gtTempFolder = gtDocumentsFolder + "\\Temp";

    public string goldenTicketDocumentsFolder
    {
        get { return gtDocumentsFolder; }
        protected set { }
    }
    public string goldenTicketDownloadsFolder
    {
        get { return gtDownloadsFolder; }
        protected set { }
    }
    public string goldenTicketTempFolder
    {
        get { return gtTempFolder; }
        protected set { }
    }

    public string GetLauncherDir()
    {
        return Application.StartupPath;
    }

    public bool InstallDirPermissionsAreCorrect()
    {
        // There's no way of figuring out if we can write to the directory -- So let's try to make a blank file!
        try
        {
            File.Create(Application.StartupPath + "\\GTPermTest.GT").Close();
        }
        catch (UnauthorizedAccessException)
        {
            return false;
        }
        File.Delete(Application.StartupPath + "\\GTPermTest.GT");
        return true;
    }

    public bool RunPermissionFix()
    {
        Process process = Process.Start(Application.StartupPath + "\\PermissionFix.exe");
        while (!process.HasExited)
        {
            return false;
        }
        return true; // It finished running!
    }


    public void CheckLauncherFolders()
    {
        // Goals of this:
        //      Make sure 'Golden Ticket' folder exists in 'Documents'. If not, create it.
        //          Make sure 'Downloads' folder exists in 'Golden Ticket'. If not, create it.
        //          Make sure the 'Temp' folder exists in 'Golden Ticket'. If not, create it, and make it hidden.

        if(!Directory.Exists(goldenTicketDocumentsFolder))
        {
            // 'Golden Ticket' folder doesn't exist in the 'Documents' folder. Create it!
            Directory.CreateDirectory(goldenTicketDocumentsFolder);
        }

        if (!Directory.Exists(goldenTicketDownloadsFolder))
        {
            // 'Downloads' folder doesn't exist in the 'Golden Ticket' folder. Create it!
            Directory.CreateDirectory(goldenTicketDownloadsFolder);
        }

        if (!Directory.Exists(goldenTicketTempFolder))
        {
            // 'Temp' folder doesn't exist in the 'Golden Ticket' folder. Create it!
            Directory.CreateDirectory(goldenTicketTempFolder);
            // Make it hidden
            DirectoryInfo di = new DirectoryInfo(goldenTicketTempFolder);
            // For sanity, check if it's already hidden. If it isn't, hide it.
            if ((di.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
            {
                //Add Hidden flag    
                di.Attributes |= FileAttributes.Hidden;
            }
        }
        return; // All done!
    }

}