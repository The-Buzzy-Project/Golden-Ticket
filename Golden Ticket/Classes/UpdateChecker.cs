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


﻿using System.Net;
using Golden_Ticket.Properties;
using Newtonsoft.Json.Linq;

namespace Golden_Ticket.Classes
{
    /// <summary>
    /// Checks for updates and retrieves a description of the latest version using JSON.
    /// </summary>
    public class UpdateChecker
    {
        private string UpdateCheckUrl => Resources.UpdateChecker_Url; // Get JSON URL from application resources
        private string Json { get; } // Stores the JSON we downloaded
        public Update LatestVersion { get; } // Description of the latest version of Golden Ticket

        public bool IsUpdateAvailable => LatestVersion.IsLaterVersion; // Check if the JSON version is newer than this one

        /// <summary>
        /// Downloads a description of the latest version and interprets the JSON.
        /// </summary>
        public UpdateChecker()
        {
            Json = GetUpdateJson(UpdateCheckUrl);
            LatestVersion = GetUpdateDetailsFromJson(Json);
        }

        /// <summary>
        /// Downloads the JSON that will be interpreted.
        /// </summary>
        /// <param name="updateCheckUrl">Location of JSON file.</param>
        /// <returns>The remote JSON contents.</returns>
        /// <exception cref="WebException">Thrown if download could not complete successfully, such as if connectivity was lost.</exception>
        private string GetUpdateJson(string updateCheckUrl)
        {
            using (WebClient wc = new WebClient())
            {
                // Variable 'json' is set via downloading file from GitHub
                return wc.DownloadString(updateCheckUrl);
            }
        }

        /// <summary>
        /// Parses the JSON file to get the information we want.
        /// </summary>
        /// <param name="json">The JSON we downloaded earlier.</param>
        /// <returns>An update object describing the latest version.</returns>
        /// <exception cref="Newtonsoft.Json.JsonReaderException">Thrown when <paramref name="json"/> contains invalid JSON.</exception>
        private Update GetUpdateDetailsFromJson(string json)
        {
            // Create an object to get our values from
            JObject o = JObject.Parse(json);

            // Get the version from json
            string jsonVersion = (string)o["number"];

            // Get download URL
            string downloadUrl = (string)o["url"];

            return new Update(downloadUrl, jsonVersion);
        }
    }
}
