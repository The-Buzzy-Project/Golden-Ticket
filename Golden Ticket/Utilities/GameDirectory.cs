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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Golden_Ticket.Utilities
{
    class GameDirectory
    {
        static bool isDebugging = false;
        public static bool launcherIsDebugging { get; protected set; }

        public static bool inGameDirectory { get; protected set; }

        // Do a few checks which *should* mean we're installed to the game's directory
        // Probably could also just do a registry check against our path, but whatever.
        public static bool isInGameDirectory()
        {
            // Check if we're debugging. If we are, this will change "isDebugging" to "true".
            changeDebugBool();
            // This will update "launcherIsDebugging" to whatever "isDebugging" is set to.
            // This makes it so we can't set the debugging status from anywhere else in the program.
            launcherIsDebugging = isDebugging;

            // Check if parent directory is default[ish] folder name
            DirectoryInfo installDir = new DirectoryInfo(".");
            string installDirName = installDir.Name;
            if (installDirName != "SimTheme Park" || installDirName != "Sim Theme Park")
            {
                // We're in the correct directory!
                inGameDirectory = true;
                MessageBox.Show("Game installed to correct directory");
                return true;
            }
            else
            {
                // Our parent directory isn't what we expected, return false!
                inGameDirectory = false;
                MessageBox.Show("Launcher isn't installed in game directory! Please reinstall Golden Ticket.");
                Application.Exit();
                return false;
            }

        }

        public static bool permissionsAreCorrect()
        {
            return false;
        }

        // This only runs if we're in "Debug" release mode.
        [Conditional("DEBUG")]
        static void changeDebugBool()
        {
            isDebugging = true;
        }
    }
}
