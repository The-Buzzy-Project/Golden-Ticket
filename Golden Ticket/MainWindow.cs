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

namespace Golden_Ticket
{
    public partial class MainWindow : Form
    {
        // Let us access the Utility class
        Utilities.Utility Util;
        
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
            /* THE BELOW STEPS OF THE LAUNCHER STARTING SHOULD BE IN ORDER OF WHICH THEY'RE TO BE EXECUTED!
             *
             * - Check if we're installed to the game directory
             *      - If we're installed in the game directory, continue
             *          - If we're not, give user an error and close program.
             *          
             * - Check launcher version from Github from the JSON file
             * 
             * - Check if game is patched
             *      - If it is, check patch version from Github from the JSON file
             *          - If it's not, prompt user with a series of dialog boxes about patching the game
             * 
             * TL;DR: Check if in game directory, check directory permissions, check launcher version,
             *                          check if game is patched, then patch version.
             *
             */
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
    }
}
