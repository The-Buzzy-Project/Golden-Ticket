using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Golden_Ticket.Windows
{
    public partial class PatcherWindow : Form
    {

        // Let us use the MachineInfo class
        MachineInfo machineInfo = new MachineInfo();
        GameInfo gameInfo = new GameInfo();

        // Here we can store info that bgwGetNeededInfo requires for function
        // Do it this way so it's not trying to modify UI, let us handle that

        string osVersion;
        public bool isNewFangled; // Are we Win8+? Used for the patching process. If false, we're Vista/7.
        bool couldntGetOS; // If false, scream.

        string gameInstallDir; // This is taken from the registry, so it should always be correct
                               // I'D LIKE SUPPORT FOR CHANGING THE REG KEY SO WE CAN MOVE THE GAME DIR IN THE LAUNCHER
        string gameVer; // This is taken from the registry




        public PatcherWindow()
        {
            InitializeComponent();
        }

        // This will let us make changes BEFORE we show the form to the user
        private void PatcherWindow_Load(object sender, EventArgs e)
        {
            // Disable buttons for now, since we don't have any info loaded yet
            wrongInfoButton.Enabled = false;
            rightInfoButton.Enabled = false;
        }

        // This will execute code AFTER the form is on screen
        private void PatcherWindow_Shown(object sender, EventArgs e)
        {
            // Run the background worker
            bgwGetNeededInfo.RunWorkerAsync();
        }

        private void bgwGetNeededInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get our info about the machine and game via the registry
            osVersion = machineInfo.WindowsVersion();

            // Determine isNewFangled for future use in the patching process
            if(osVersion.Contains("Windows 8") || osVersion.Contains("Windows 8.1") || osVersion.Contains("Windows 10"))
            {
                // We're running Windows 8+
                isNewFangled = true;
            }
            else
            {
                if(osVersion.Contains("Windows Vista") || osVersion.Contains("Windows 7"))
                {
                    // We're running Windows Vista or Windows 7
                    isNewFangled = false;
                }
                else
                {
                    // Just in case there's some freak accident where this doesn't return ANY of our expected Windows versions, let's flip out!
                    if (!osVersion.Contains("Windows Vista") & !osVersion.Contains("Windows 7") & !osVersion.Contains("Windows 8")
                        & !osVersion.Contains("Windows 8.1") & !osVersion.Contains("Windows 10"))
                    {
                        // We couldn't get the OS. Set to true so we can tell the user once we're done mucking around in here.
                        couldntGetOS = true;

                        Application.Exit();
                    }
                }
            }

            // Get game install dir and version
            gameInstallDir = gameInfo.GetInstallLocationFromReg();
            gameVer = gameInfo.GetGameVersionFromReg();
        }

        private void bgwGetNeededInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Error checking
            if (couldntGetOS == true)
            {
                // We don't know what OS version we have for some reason. We need to stop and notify the user.
                MessageBox.Show("Hey! We couldn't figure out what version of Windows you're running. Because of that, there's no way to" +
                    "find out which patch your computer needs." + Environment.NewLine + "Eventually, you'll be able to manually" +
                    "select your OS when this happens, but that hasn't been programmed in yet. Just let the developer know this happened so" +
                    "it can get fixed.", "Couldn't get Windows version!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.Exit(); // Gonna close Golden Ticket so we don't mess something up
            }



            ///
            /// It *seems* that haven't hit any snags. It's off to the races!
            ///

            // Update labels with info we got from bgwGetNeededInfo
            osInfoLabel.Text = osVersion;
            gameDirInfoLabel.Text = gameInstallDir;
            gameVerInfoLabel.Text = gameVer;

            // User can see the info, let them decide.
            wrongInfoButton.Enabled = true;
            rightInfoButton.Enabled = true;
        }
    }
}
