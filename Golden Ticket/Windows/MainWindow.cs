using Golden_Ticket.Utilities;
using Golden_Ticket.Windows;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Golden_Ticket
{
    public partial class MainWindow : Form
    {
        Point lastLocation;
        bool mouseDown;
        
        bool isDebug = false;

        public int errorCode;
        bool needsPatching;

        // Classes we'll need to use
        PathUtils pathUtils = new PathUtils(); // Need to do this if accessing a different file of code
        NotifyUser notifyUser = new NotifyUser();
        GameInfo gameInfo = new GameInfo();
        MachineInfo machineInfo = new MachineInfo();
        Errors errors = new Errors();
        UpdateChecker updateChecker = new UpdateChecker();
        OptionsWindow optionsWindow = new OptionsWindow();

        // Strings we're going to use later
        string gameDirectory;
        string launcherDirectory;
        // End strings


        public MainWindow() // Don't fricken touch this
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            launcherTitleLabel.Text = this.Text;
            ThemeLauncher();
            if(isDebug == true)
            {
                MessageBox.Show("Debug mode");
            }
            else
            {

            // Check for updates
            updateChecker.checkForUpdate(this);

            if(updateChecker.errorWhileChecking == true)
            {
                notifyUser.Notify(this, "Could not check for updates!",
                                    "An unexpected error occurred while checking for updates. Golden Ticket will not be able to notify you of new updates."
                                    + Environment.NewLine + Environment.NewLine + "Below is the error. Please screenshot this message box and report it to the developer by creating a new Issue on GitHub."
                                    + Environment.NewLine + Environment.NewLine + updateChecker.exForReporting,
                                    MessageBoxIcon.Warning, MessageBoxButtons.OK);
            }

            // If there wasn't an update, we can start.

            // Do all our shit in a BackgroundWorker so we don't freeze the UI
            launchButton.Enabled = false;
            LauncherStartup.RunWorkerAsync();
            }
        }


        private void LauncherStartup_DoWork(object sender, DoWorkEventArgs e)
        {

            for (int i = 0; i < 100; i++) // The code needs to go in here so that we can get progress reports
            {
                CleanupTempFolder(); // Let's clean the temp folder like we should
                StartupStep1(); // Begin step 1
                LauncherStartup.ReportProgress(i); // Report progress
                if (LauncherStartup.CancellationPending) { e.Cancel = true; return; } // Check if we need to cancel
                StartupStep2(); // Begin step 2
                LauncherStartup.ReportProgress(i); // Report progress
                if (LauncherStartup.CancellationPending) { e.Cancel = true; return; } // Check if we need to cancel
                StartupStep3(); // Begin step 3
                LauncherStartup.ReportProgress(i); // Report progress
                if (LauncherStartup.CancellationPending) { e.Cancel = true; return; } // Check if we need to cancel
                StartupStep4();
                LauncherStartup.ReportProgress(i); // Report progress
                if (LauncherStartup.CancellationPending) { e.Cancel = true; return; } // Check if we need to cancel
                if(needsPatching == true)
                {
                    // We need to patch. Let's go run step 5.
                    LauncherStartup.ReportProgress(i);
                    StartupStep5(); // We need to patch. Go to step 5.
                    LauncherStartup.ReportProgress(i);
                }
                else
                {
                    // Launcher doesn't need patching. We're finished.
                    LauncherStartup.ReportProgress(i);
                }

            }

            // Launcher startup has finished
            LauncherStartup.ReportProgress(100);
        }

        void CleanupTempFolder()
        {
            if (Directory.Exists(pathUtils.goldenTicketTempFolder))
            {
                clearFolder(pathUtils.goldenTicketTempFolder);
            }
            else
            {
                return;
            }
        }

        private void clearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                clearFolder(di.FullName);
                di.Delete();
            }
        }

        void StartupStep1()
        {
            // Step 1: Check install directory!

            // Get install location for the game
            gameDirectory = gameInfo.GetInstallLocationFromReg();
            // Get location the launcher is running from
            launcherDirectory = pathUtils.GetLauncherDir();
            // Compare the two

            // Fix Issue #6 -- Launcher is sad if the game directory and reg location have mismatch case.
            // Instead of using a straight 'if (string != string)', use 'string.Equals' so that we can ignore case.
            if (!launcherDirectory.Equals(gameDirectory, StringComparison.OrdinalIgnoreCase))
            {
                // Launcher isn't running in the game directory. Freak out!
                errorCode = 1;
                LauncherStartup.CancelAsync();
            }
            return; // We're good, step 2 please!
        }

        void StartupStep2()
        {
            // We need to make changes to allow us to modify the game folder without admin rights...
            // But before doing so, let's try to create a file in the game directory. If it gets
            // an UnauthorizedAccess exception, then we'll run PermissionFix.

            bool dirPermsCorrect = pathUtils.InstallDirPermissionsAreCorrect();

            if(dirPermsCorrect == false)
            {
                // Permissions aren't correct. We need to tell the user and let him/her choose if they want us to fix that.

                DialogResult userAnswer;

                userAnswer = MessageBox.Show(this, "It appears that Golden Ticket does not have the necessary permissions to make" +
                                                " changes to the game. We can fix this by using our open source tool 'PermissionFix'." +
                                                Environment.NewLine + Environment.NewLine + "Clicking 'Yes' will allow us to make" +
                                                " these changes. A UAC request will popup afterwards. Please select 'Yes' on it."
                                                + Environment.NewLine + Environment.NewLine + "Clicking 'No' below will not allow the" +
                                                " launcher to continue in it's attempt to make the game compatible!",
                                                "Cannot make changes to the game!",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(userAnswer == DialogResult.No)
                {
                    // User declined to run PermissionFix
                    errorCode = 2;
                    LauncherStartup.CancelAsync();
                }
                else
                {
                    // User said yes to running PermissionFix!
                    Process process = Process.Start(Application.StartupPath + "\\PermissionFix.exe");
                    while (!process.HasExited)
                    {
                        // Sleep for 1/4th a second and wait for PermissionFix to run...
                        Thread.Sleep(250);
                    }
                    return; // PermissionFix ran!
                }
            }
            return; // End of step 2!
        }

        void StartupStep3()
        {
            // Let's make sure that Golden Ticket's own folders exist

            pathUtils.CheckLauncherFolders();
            // Shouldn't need to return -- The method above already does this.
            // But just in case...
            return;
        }

        void StartupStep4()
        {
            // This is where we detect if the game is already patched or not
            bool isPatched = gameInfo.GameIsPatched();
            if(isPatched == false)
            {
                // Game isn't patcched. We need to go to step 5.
                needsPatching = true;
                return;
            }
            else
            {
                // Game is already patched. We're done.
                needsPatching = false;
                return;
            }
        }

        void StartupStep5()
        {
            // FIXME: This somehow broke after themeing. All of this will run but it isn't passed
            // to the patching window for some reason. Currently all below code has been modified
            // and moved to the patching window itself to 'fix' it for now.


            /*
             * This is going to get a little hectic...
             * 
             * Things which need to be done here (in order)
             * - We need to determine the user's OS. Is it Vista/7? Or is it Windows 8(.1)/10?
             * - We need to download the correct patch to our Golden Ticket 'Downloads' folder
             * -- FIXME: We should verify the MD5 of the zip before trying to use it
             * - Unzip all files to the Golden Ticket 'Temp' folder
             * -- FIXME: We should verify the MD5 of all individual files before trying to use them
             * - Place all files from our 'Temp' directory in the game installation directory
             */

            string winVer = machineInfo.WindowsVersion();

            if (winVer.Contains("Windows Vista") || winVer.Contains("Windows 7"))
            {
                // Patch for Vista/7
                PatchingWindowBottom patchingWindowBottom = new PatchingWindowBottom();
                PatchingWindow patchingWindow = new PatchingWindow();
                patchingWindow.patchToDownload = 1;
                patchingWindowBottom.ShowDialog(this);
                return; // ShowDialog has closed. We're done.
            }

            if (winVer.Contains("Windows 8") || winVer.Contains("Windows 8.1") || winVer.Contains("Windows 10"))
            {
                // Patch for 8/8.1/10
                PatchingWindowBottom patchingWindowBottom = new PatchingWindowBottom();
                PatchingWindow patchingWindow = new PatchingWindow();
                patchingWindow.patchToDownload = 2;
                patchingWindowBottom.ShowDialog(this);
                return; // ShowDialog has closed. We're done.
            }

            // Just in case there's some freak accident where this doesn't return ANY of our expected Windows versions, let's flip out!
            if (!winVer.Contains("Windows Vista") & !winVer.Contains("Windows 7") & !winVer.Contains("Windows 8")
                & !winVer.Contains("Windows 8.1") & !winVer.Contains("Windows 10"))
            {
                // Set error code to 3 and stop the launcher
                errorCode = 3;
                LauncherStartup.CancelAsync();
            }

        }

        private void LauncherStartup_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This is purely to keep the user informed via the progressbar and label
            // This will NOT work unless 'LauncherStartup.ReportProgress(i);' is called
            // every once in a while in the DoWork block!
            LauncherProgressBar.Value = e.ProgressPercentage;
            ProgressLabel.Text = "Starting up..." + LauncherProgressBar.Value.ToString() + "%";
        }


        private void LauncherStartup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled == true)
            {
                LauncherProgressBar.Style = ProgressBarStyle.Continuous;
                errors.ReportCorrectErrorCodeToUser(errorCode, this);
                //ProgressLabel.Text = "The developer is stupid and screwed up the launcher! (Error " + errorCode + ")";
                if(errors.errorNumber == 0)
                {
                    ProgressLabel.Text = "An unknown error has occurred! Please report! (Error 0)";
                }

                if(errors.errorNumber == 1)
                {
                    ProgressLabel.Text = "Launcher not installed to game directory! (Error 1)";
                }

                if(errors.errorNumber == 2)
                {
                    ProgressLabel.Text = "User declined to run PermissionFix! (Error 2)";
                }

                if(errors.errorNumber == 3)
                {
                    string reportedWinVer = machineInfo.WindowsVersion();
                    ProgressLabel.Text = "Unexpected Windows version (Error 3 -- " + reportedWinVer + ")";
                }

                if(errors.errorNumber == 4)
                {
                    ProgressLabel.Text = "Unexpected error while applying patch (Error 4)";
                }
            }
            else
            {
                // Stop the progressbar from going back to a marquee after finishing
                LauncherProgressBar.Style = ProgressBarStyle.Continuous;
                //notifyUser.Notify(this, "Startup finished!",
                //                  "Golden Ticket has finished starting!",
                //                MessageBoxIcon.Information,
                //              MessageBoxButtons.OK);
                launchButton.Enabled = true;
                ProgressLabel.Text = "Game is ready to launch...";
            }
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Attempt to start game
                Process.Start(gameDirectory + "\\tp.exe");
                Application.Exit();
            }
            catch(Exception ex)
            {
                // Unexpected error. Why can't we launch the game?
                notifyUser.Notify(this, "Unable to start game!",
                                    "Unfortunately, we've run into an unexpected error and were unable to launch the game." +
                                    Environment.NewLine + "Please screenshot this message box and send it to the developer."+
                                    Environment.NewLine + Environment.NewLine + ex.ToString(),
                                    MessageBoxIcon.Error, MessageBoxButtons.OK);
            }
        }
        void ThemeLauncher()
        {
            panel1.BackColor = System.Drawing.Color.FromArgb(125, 0, 0, 0);
            panel2.BackColor = System.Drawing.Color.FromArgb(125, 0, 0, 0);
        }

        private void launcherExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }









        /*
         * -----------------------------------
         * |   Custom Window Dragging Code   |
         * -----------------------------------
         */



        // This allows dragging from the panel itself

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown) {
            this.Location = new Point(
                (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

            this.Update();
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }



        // This allows dragging even if you do it on the window title/label

        private void launcherTitleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void launcherTitleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void launcherTitleLabel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            OptionsWindowBottom optionsWindowBottom = new OptionsWindowBottom();
            optionsWindowBottom.ShowDialog();
        }
    }
}
