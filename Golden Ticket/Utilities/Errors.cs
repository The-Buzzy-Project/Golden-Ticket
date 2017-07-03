using Golden_Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

    public class Errors
    {
        public int errorNumber;
    
        NotifyUser notifyUser = new NotifyUser();
        //MainWindow mainWindow = new MainWindow();
        MachineInfo machineInfo = new MachineInfo();
        GameInfo gameInfo = new GameInfo();
        PathUtils pathUtils = new PathUtils();

        public void ReportCorrectErrorCodeToUser(int errorCode, IWin32Window window, Exception ex = null)
        {
            string gameDirectory;
            string launcherDirectory;
            gameDirectory = gameInfo.GetInstallLocationFromReg();
            launcherDirectory = pathUtils.GetLauncherDir();

            // Error 0: Unknown error!
            if (errorCode == 0)
            {
                errorNumber = 0;
                notifyUser.Notify(window, "Error during startup...",
                                    "An unknown error has occurred. Please make a note of what the launcher was doing when this happened" +
                                    " (see text above progress bar right now) and report this to the developer!"
                                    + Environment.NewLine + Environment.NewLine + "Error 0 (Developer screwed up the code probably)",
                                    MessageBoxIcon.Error, MessageBoxButtons.OK);
                //mainWindow.ProgressLabel.Text = "An unknown error has occurred! Please report! (Error 0)";
            }

            // Error 1: Not installed to the game directory
            if (errorCode == 1)
            {
                errorNumber = 1;
                notifyUser.Notify(window, "Error during startup...",
                                    "It seems that Golden Ticket wasn't installed to the game directory!" + Environment.NewLine + Environment.NewLine + "Expected directory: " + gameDirectory + Environment.NewLine + Environment.NewLine + "Directory found: " + launcherDirectory + Environment.NewLine + Environment.NewLine + "Please install into the correct location and try again." + Environment.NewLine + Environment.NewLine + "Error 1 (Launcher not installed to game directory)",
                                    MessageBoxIcon.Error, MessageBoxButtons.OK);
                //mainWindow.ProgressLabel.Text = "Launcher not installed to game directory! (Error 1)";
            }

            // Error 2: User declined letting us run PermissionFix
            if (errorCode == 2)
            {
                errorNumber = 2;
                notifyUser.Notify(window, "Error during startup...",
                                    "You chose to not allow us to run PermissionFix. As such, Golden Ticket can NOT make the changes" +
                                    " needed to allow Sim Theme Park to run on your computer."
                                    + Environment.NewLine + Environment.NewLine + "Launcher patching functionality has been disabled! This can" +
                                    " be fixed by restarting Golden Ticket, and allowing us to run PermissionFix!"
                                    + Environment.NewLine + Environment.NewLine + "Error 2 (User declined to run PermissionFix)"
                                    , MessageBoxIcon.Error, MessageBoxButtons.OK);
                //mainWindow.ProgressLabel.Text = "User declined to run PermissionFix! (Error 2)";
            }

            // Error 3: Registry didn't report a version of Windows we were expecting
            if (errorCode == 3)
            {
                errorNumber = 3;
                string reportedWinVer = machineInfo.WindowsVersion();

                notifyUser.Notify(window, "Could not determine Windows version!",
                    "Unfortunately we were not able to identify which version of Windows you're running."
                    + Environment.NewLine + "This could be caused by a corrupted registry, or you've tampered with"
                    + Environment.NewLine + " the registry in a way which changes what Windows reports it's version as."
                    + Environment.NewLine + "The launcher cannot continue. Please report this to the developer so this issue"
                    + Environment.NewLine + " can be sorted out."
                    + Environment.NewLine + Environment.NewLine + "Unexpected Windows version (Error 3 -- " + reportedWinVer + ")",
                        MessageBoxIcon.Error, MessageBoxButtons.OK);
                //mainWindow.ProgressLabel.Text = "Unexpected Windows version (Error 3 -- " + reportedWinVer + ")";
            }

            // Error 4: Something weird happened while applying the patch. Not sure what. Let's get that reported to us!
            if (errorCode == 4)
            {
                errorNumber = 4;
                notifyUser.Notify(window, "Please screenshot this and send to developer!",
                        "An unexpected error has occured. Below is the error. Please screenshot this error box and send" +
                        " it to the developer."
                        + Environment.NewLine + Environment.NewLine + ex.ToString(),
                        MessageBoxIcon.Error, MessageBoxButtons.OK);
                //mainWindow.ProgressLabel.Text = "Unexpected error while applying patch (Error 4)";
            }
        }
    }