/*
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