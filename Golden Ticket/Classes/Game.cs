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


﻿using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using Golden_Ticket.Properties;

namespace Golden_Ticket.Classes
{
    /// <summary>
    /// Handles game settings and status.
    /// </summary>
    public class Game
    {
        // Events raised by class
        public event EventHandler ExecutablePresenceChanged;
        public event EventHandler GamePathChanged;
        public event EventHandler PatchStatusChanged;

        // Folder where TPW/STP is stored
        public string GamePath
        {
            get => Settings.Default.GamePath;
            set
            {
                // Saves this value to application settings
                // If not yet specified, UI can choose how to proceed (folder browser?)
                Settings.Default.GamePath = value ?? throw new ArgumentNullException();
                GamePathChanged?.Invoke(this, new EventArgs());
                SaveDirectory();
            }
        }

        // x86 software uses the 32 bit registry hive on x64 Windows
        // Check the correct hive for the architecture
        private static string RegPath => Environment.Is64BitOperatingSystem
            ? "Software\\Wow6432Node\\Bullfrog Productions Ltd\\Theme Park World"
            : "Software\\Bullfrog Productions Ltd\\Theme Park World";

        // If patched, a file is dropped into the TPW/STP directory
        public bool IsPatched => File.Exists(GamePath + "\\patchedByGoldenTicket");
        // Check known Gold Edition files to get result
        // TODO: Test this function. I do not have the Gold Edition.
        public bool IsGoldEdition => (File.Exists(GamePath + "\\data\\levels\\fantasy\\sideshow\\_puzzle_24.wad") && File.Exists(GamePath + "\\data\\levels\\hallow\\rides\\_devil_18.wad") && File.Exists(GamePath + "\\data\\levels\\jungle\\rides\\_snake_1.wad") && File.Exists(GamePath + "\\data\\levels\\space\\features\\_pulsar_29.wad"));
        public bool IsGameDirWritable => IsDirWritable(GamePath); // Try writing to game directory
        public bool IsTpwPresent => File.Exists(GamePath + "\\tp.exe"); // Check for TPW/STP executable
        // TODO: Is there a better way of getting the version? Also test.
        public string Version => GetGameVersionFromReg(); // Gets the version of the game from the registry
        
        /// <summary>
        /// Tries to populate game path. If specified already, use application settings, else try to get it ourselves.
        /// </summary>
        public Game() => GamePath = GetInstallLocationFromSettings() ?? GetInstallLocationFromReg();

        /// <summary>
        /// Handles game settings and status.
        /// User has specified game path.
        /// </summary>
        /// <param name="path">Path to the TPW/STP installation.</param>
        public Game(string path) { GamePath = path; }

        private string GetGameVersionFromReg()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(RegPath))
                {
                    // Returns null if not present - UI must handle this!
                    return key?.GetValue("Version").ToString();
                }
            }
            catch (Exception) { return null; }
        }

        private string GetInstallLocationFromReg()
        {
            try
            {
                // Get 32 bit registry on x86 and x64
                // App paths stores known application names
                using (RegistryKey key = Environment.Is64BitOperatingSystem
                    ? Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\App Paths\\TP.exe")
                    : Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\App Paths\\TP.exe"))
                {
                    return key?.GetValue("Path").ToString();
                }
            }
            // Return nothing if it doesn't exist
            catch (Exception) { return null; }
        }

        // If the folder was located previously by Golden Ticket, keep using that
        private string GetInstallLocationFromSettings() => !string.IsNullOrWhiteSpace(Settings.Default.GamePath)
            ? Settings.Default.GamePath : null;

        /// <summary>
        /// Starts the main executable in the game path.
        /// </summary>
        public void StartGame() => Process.Start(GamePath + "\\tp.exe");

        /// <summary>
        /// Saves the location of the TPW/STP folder.
        /// </summary>
        private void SaveDirectory()
        {
            Settings.Default.Save();
        }

        /// <summary>
        /// Gets whether a specified directory can be written to.
        /// </summary>
        /// <param name="dir"></param>
        /// <returns>True if the file could be written successfully, false if not.</returns>
        private bool IsDirWritable(string dir)
        {
            // There's no way of figuring out if we can write to the directory -- So let's try to make a blank file!
            try { File.Create(dir + "\\GTPermTest.GT").Close(); }
            catch (UnauthorizedAccessException) { return false; }

            File.Delete(dir + "\\GTPermTest.GT");
            return true;
        }
    }
}