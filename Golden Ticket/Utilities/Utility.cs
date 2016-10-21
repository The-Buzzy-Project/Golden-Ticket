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

namespace Golden_Ticket.Utilities
{
    
    /* This class contains utilities which are useful to the overall function of the program, and/or
     * are used fairly often. This class is to prevent the headache of writing the same functions
     * over and over again, making coding the launcher a lot easier.
     */
    public class Utility
    {
        /* This method will prompt the user with a dialog box to restart the launcher with Administrator
         * privliges so we may perform actions which can't normally happen without these permissions
         * 
         * NOTE: This method requires ONE paramater: A method which will run after the launcher restarts.
         */
        public void RestartAsAdministrator(Action runAfterRestart)
        {
            // Store the method we want to run after the restart somewhere that'll stick through the restart
        }
    }
}
