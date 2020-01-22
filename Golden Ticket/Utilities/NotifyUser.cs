/*   This file is part of Golden Ticket.
*
*    Golden Ticket is free software: you can redistribute it and/or modify
*    it under the terms of the GNU General Public License as published by
*    the Free Software Foundation, either version 2 of the License, or
*    (at your option) any later version.
*
*    Golden Ticket is distributed in the hope that it will be useful,
*    but WITHOUT ANY WARRANTY; without even the implied warranty of
*    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
*    GNU General Public License for more details.
*
*    You should have received a copy of the GNU General Public License
*    along with Golden Ticket.  If not, see <https://www.gnu.org/licenses/>.
*/


﻿/*
 * This Utility is designed to make it easier to present a specific type of
 * MessageBox to the user in the event we need to notify them of something
 * happening such as an error, or just general information.
 */
 
using System.Windows.Forms;

public static class NotifyUser
{
    // TODO: Should I keep this class? Letting MessageBox.Show do the task may be alright.
    /*
     * Valid NotifyUser types:
     *      Question
     *      Info
     *      Error
     *      Warning
     *      
     *      
     *      HOW TO USE
     *       notifyUser.Notify("Startup finished!",
     *                           "Golden Ticket has finished starting!",
     *                           MessageBoxIcon.Information,
     *                           MessageBoxButtons.OK);
     * 
     */

    public static void Notify(IWin32Window thisWindow, string messageBoxTitle, string messageBoxBody, MessageBoxIcon type, MessageBoxButtons buttons)
    {
        MessageBox.Show(thisWindow, messageBoxBody, messageBoxTitle, buttons, type);
    }
}