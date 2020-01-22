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


﻿using System;
using System.Net;
using Newtonsoft.Json.Linq;
using Golden_Ticket.Windows;
using System.Windows.Forms;

namespace Golden_Ticket.Utilities
{
    public class UpdateChecker
    {
        public bool errorWhileChecking;
        public Exception exForReporting;

#pragma warning disable CS0414 // Field is assigned but never used
        string launcherVersion = "0.2.1";
#pragma warning restore CS0414 // Field is assigned but never used
        string jsonVersion;
        string downloadURL;

        NotifyUser notifyUser = new NotifyUser();

        public string JsonVersion { get => jsonVersion; protected set { } }

        public string LauncherVersion { get => launcherVersion; protected set { } }

        public string DownloadURL { get => downloadURL; protected set { } }

        public void checkForUpdate(IWin32Window window)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    // Variable 'json' is set via downloading file from Github
                    var json = wc.DownloadString("https://raw.githubusercontent.com/The-Buzzy-Project/Golden-Ticket/master/version.json");

                    // Create an object to get our values from
                    JObject o = JObject.Parse(json);

                    // Get the version from json
                    jsonVersion = (string)o["number"];

                    // Get download URL
                    downloadURL = (string)o["url"];

                    if(launcherVersion != jsonVersion)
                    {
                        // We have an update available!
                        UpdateWindowBottom updateWindow = new UpdateWindowBottom();
                        updateWindow.ShowDialog(window);
                    }
                    else
                    {
                        return;
                    }

                }
                catch(Exception e)
                {
                    errorWhileChecking = true;
                    exForReporting = e;
                    return;
                }

            }
        }

    }
}
