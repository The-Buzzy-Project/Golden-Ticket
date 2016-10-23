#region License
// ====================================================
// Golden Ticket Copyright(C) 2016 The Buzzy Project
// This program comes with ABSOLUTELY NO WARRANTY; This is free software,
// and you are welcome to redistribute it under certain conditions; See
// file LICENSE, which is part of this source code package, for details.
// ====================================================
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Golden_Ticket
{
    public partial class MainWindow : Form
    {
        // DON'T TOUCH THIS, RYAN
        public MainWindow()
        {
            // RYAN, I'M NOT KIDDING.
            // YOU DON'T EVEN KNOW WHAT THIS METHOD DOES
            // GO SLEEP OR SOMETHING INSTEAD OF MESSING WITH THIS
            InitializeComponent();
        }


        // Program start
        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Make MainPanel semi-transparent grey
            MainPanel.BackColor = Color.FromArgb(125, 128, 128, 128);
            // Do same to the buttons
            PlayButton.BackColor = Color.FromArgb(150, 128, 128, 128);
            OptionsButton.BackColor = Color.FromArgb(150, 128, 128, 128);

            // Display launcher version in the title of the window
            this.Text = Application.ProductName + " - " + Application.ProductVersion;

            /* THE BELOW STEPS OF THE LAUNCHER STARTING SHOULD BE IN ORDER OF WHICH THEY'RE TO BE EXECUTED!
             *
             * - Check if we're installed to the game directory
             *      - If we're installed in the game directory, continue
             *          - If we're not, give user an error and close program.
             *          
             * - Check launcher version from Github from the JSON file
             * 
             * - Check if directory permissions are correct
             *      - If they're not, restart as admin and fix it
             * 
             * - Check if game is patched
             *      - If it is, check patch version from Github from the JSON file
             *          - If it's not, prompt user with a series of dialog boxes about patching the game
             * 
             * TL;DR: Check if in game directory, check directory permissions, check launcher version,
             *                          check if game is patched, then patch version.
             *
             */

            StartLauncher.RunWorkerAsync();
        }

        void FixGameDirectoryPermissions()
        {
            /* Set permissions of game directory to be read/write enabled without administrator access.
             * 
             * Doing this will initially require admin privileges. By doing this to the directory, the
             * launcher will be able to make any modifications to the game it needs to without needing
             * to be run ad administrator every time it runs.
             * 
             * Although this DOES pose a potential security risk to the end user, it's the only
             * workaround which will work reliably.
             * 
             * NOTE: Notify user on first launch about the security risk involved.
             */
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Try to launch game
                System.Diagnostics.Process.Start(Application.StartupPath + "\tp.exe");
            }
            catch (FileNotFoundException FNFE)
            {
                // Can't find the executable, show error.
                MessageBox.Show("Game executable not found! (" + FNFE.FileName +")");
            }
            //finally
            //{
                // Write to the debug log eventually...
            //}
        }

        private void StartLauncher_DoWork(object sender, DoWorkEventArgs e)
        {
            int permFixTries = 0;
            // Check if in game directory
            Utilities.GameDirectory.isInGameDirectory();
            StartLauncher.ReportProgress(15);
            if (Utilities.GameDirectory.inGameDirectory == true)
            {
                // Change StatusLabel in a thread safe way to inform user of current operation...
                StatusLabel.Invoke((MethodInvoker)delegate
                {
                    StatusLabel.Text = "Checking launcher version...";
                });
                StartLauncher.ReportProgress(25);
                // We are. Let's do an update check of the launcher!
                Utilities.Updater.Check(Utilities.GameDirectory.launcherIsDebugging, "launcherVersion");
                StartLauncher.ReportProgress(50);
                // Check if directory permissions allow us to modify as we please without administrator access
                Utilities.GameDirectory.permissionsAreCorrect();
                StartLauncher.ReportProgress(75);
                // Did the method return true? Are permissions correct?
                if(Utilities.GameDirectory.permsAreCorrect == true)
                {
                    // Yes, yes it did. Permissions are correct.
                    if(System.IO.File.Exists(Application.StartupPath + "\\GTpermCheck"))
                    {
                        try
                        {
                            System.IO.File.Delete(Application.StartupPath + "\\GTpermCheck"); // Try to delete file
                        }
                        catch
                        {
                            MessageBox.Show("Unknown error while checking file permissions!");
                            Application.Exit(); // Crash and burn so we know where exactly we need to look for a problem.
                        }
                        // Continue as normal

                    }
                }
                else if(Utilities.GameDirectory.permsAreCorrect == false)
                {
                    // Ask user if they want to fix the permissions
                    DialogResult result = MessageBox.Show("This can be fixed by changing the permissions as an administrator. Would you like to do so?", "Cannot modify game directory!", MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes)
                    {
                        // User agreed to change permissions. Let's go!
                        Utilities.GameDirectory.fixPermissions();
                        // WARNING: THIS COULD POSSIBLY BE AN INFINITE LOOP!
                        while(Utilities.GameDirectory.permsAreCorrect == false) // If it's false, keep trying to change permissions.
                        {
                            if(permFixTries >= 3)
                            {
                                MessageBox.Show("Could not fix permissions! Aborting!");
                                Application.Exit();
                                break;
                            }
                            else
                            {
                                permFixTries += 1; // For each try, increase this by 1.
                                Utilities.GameDirectory.fixPermissions();
                            }
                        }
                    }
                    else if(result == DialogResult.No)
                    {
                        // User gave up on life and doesn't want to fix permissions. User can go cry in a corner.
                        MessageBox.Show("Permissions will not be changed. No patching will be able to take place. It is reccomended you do NOT try to launch the game.");
                        // Disable buttons
                        PlayButton.Invoke((MethodInvoker)delegate
                        {
                            PlayButton.Enabled = false;
                        });
                        OptionsButton.Invoke((MethodInvoker)delegate
                        {
                            OptionsButton.Enabled = false;
                        });
                        // Update status label
                        StatusLabel.Invoke((MethodInvoker)delegate
                        {
                            StatusLabel.Text = "User declined to fix folder permissions!";
                        });
                    }
                }
            }
            else
            {
                // Disable buttons
                PlayButton.Invoke((MethodInvoker)delegate
                {
                    PlayButton.Enabled = false;
                });
                OptionsButton.Invoke((MethodInvoker)delegate
                {
                    OptionsButton.Enabled = false;
                });
                // Update status label
                StatusLabel.Invoke((MethodInvoker)delegate
                {
                    StatusLabel.Text = "Error!";
                });
            }
        }

        private void StartLauncher_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MainProgressbar.Value = e.ProgressPercentage;
        }
    }
}
