using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Golden_Ticket.Utilities
{
    public class Startup
    {
        // Do a few checks which *should* mean we're installed to the game's directory
        // Probably could also just do a registry check against our path, but whatever.
        public bool isInGameDirectory()
        {
            // Check if parent directory is default[ish] folder name
            string installedDir = Application.StartupPath;
            string parentDir = Directory.GetParent(installedDir).Name;
            if(parentDir == "SimTheme Park" || parentDir == "Sim Theme Park")
            {
                // Our parent directory is what we expected, continue.
                // CHECK LAUNCHER VERSION

            }
            else
            {
                // Our parent directory isn't what we expected, return false!
                return false;
            }

            return false;
        }
    }
}
