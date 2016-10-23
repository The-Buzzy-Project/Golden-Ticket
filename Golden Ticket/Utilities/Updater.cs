using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Golden_Ticket.Utilities
{
    class Updater
    {
        public static void Check(bool debugStatus, string whatToCheck)
        {
            if (debugStatus == true)
            {
                // Check for update from "Development" branch on Github (we're debugging)

                // Request the JSON file
                System.Net.WebRequest request = System.Net.HttpWebRequest.Create("https://raw.githubusercontent.com/The-Buzzy-Project/Golden-Ticket/master/versions.json");
                request.Proxy = null;
                System.Net.WebResponse response = request.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
                string json = sr.ReadToEnd(); // Entire contents of our JSON file!

                // Initialize the class
                Versions versions = new Versions();
                JsonConvert.PopulateObject(json, versions); // Populate everything

                // Check what's passed to us in "whatToCheck"
                if (whatToCheck == "launcherVersion")
                {
                    // We're supposed to be checking the version of the launcher. Let's do it!
                    if (versions.launcherVersion != Application.ProductVersion)
                    {
                        // If the JSON version doesn't match our program version, there must be an update!
                        MessageBox.Show("Update available! Your version: " + Application.ProductVersion + " Available: " + versions.launcherVersion);
                    }
                    else
                    {
                        // No update! Both versions match!
                        MessageBox.Show("No need for an update! Your version: " + Application.ProductVersion + " Returned version: " + versions.launcherVersion);
                    }
                }
                // End launcher checking code

                // We checking the Vista patch?
                else if (whatToCheck == "vistaPatchVersion")
                {
                    MessageBox.Show("Not implemented!");
                }
                // No... so the Windows 8 patch!
                else if (whatToCheck == "modernPatchVersion")
                {
                    MessageBox.Show("Not implemented!");
                }
                else
                {
                    MessageBox.Show("Unknown version to check: " + whatToCheck + "!");
                }
            }
            else if (debugStatus == false)
            {
                // Check for update from "master" branch on Github (we're not debugging)

                // Request the JSON file
                System.Net.WebRequest request = System.Net.HttpWebRequest.Create("https://raw.githubusercontent.com/The-Buzzy-Project/Golden-Ticket/master/versions.json");
                request.Proxy = null;
                System.Net.WebResponse response = request.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
                string json = sr.ReadToEnd(); // Entire contents of our JSON file!

                // Initialize the class
                Versions versions = new Versions();
                JsonConvert.PopulateObject(json, versions); // Populate everything

                // Check what's passed to us in "whatToCheck"
                if (whatToCheck == "launcherVersion")
                {
                    // We're supposed to be checking the version of the launcher. Let's do it!
                    if (versions.launcherVersion != Application.ProductVersion)
                    {
                        // If the JSON version doesn't match our program version, there must be an update!
                        MessageBox.Show("Update available! Your version: " + Application.ProductVersion + " Available: " + versions.launcherVersion);
                    }
                    else
                    {
                        // No update! Both versions match!
                        MessageBox.Show("No need for an update! Your version: " + Application.ProductVersion + " Returned version: " + versions.launcherVersion);
                    }
                }
                // End launcher checking code

                // We checking the Vista patch?
                else if (whatToCheck == "vistaPatchVersion")
                {
                    MessageBox.Show("Not implemented!");
                }
                // No... so the Windows 8 patch!
                else if (whatToCheck == "modernPatchVersion")
                {
                    MessageBox.Show("Not implemented!");
                }
                else
                {
                    MessageBox.Show("Unknown version to check: " + whatToCheck + "!");
                }
            }
        }
    }
}
