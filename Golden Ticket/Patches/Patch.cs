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
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Golden_Ticket.Classes;
using Microsoft.VisualBasic.Devices;
using Exception = System.Exception;

namespace Golden_Ticket.Patches
{
    /// <summary>
    /// Downloads, installs and reports progress on a patch for TPW/STP.
    /// </summary>
    public abstract class Patch : Downloadable, IEquatable<Patch>
    {
        public event EventHandler<AsyncCompletedEventArgs> InstallComplete; // Fires when installation finishes
        public event EventHandler<InstallEventArgs> InstallProgressChanged; // Fires manually when an operation has completed

        protected abstract string ExtractedFolderName { get; } // The folder inside the zip
        protected virtual string GetExtractedContentPath =>
            Path.Combine(ExtractionPath, ExtractedFolderName); // Full path to the extracted zip

        protected virtual string ExtractionPath { get; } =
            Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()); // Extract to a randomly named folder in temp folder
        public abstract string Name { get; } // Friendly name of patch

        /// <summary>
        /// Installs the patch to the directory specified.
        /// </summary>
        /// <param name="installDir">The directory to install to.</param>
        /// <param name="cancel">Token to determine if we should cancel the procedure.</param>
        public virtual async void InstallAsync(string installDir, CancellationToken cancel)
        {
            try
            {
                await Task.Run(() =>
                {
                    cancel.ThrowIfCancellationRequested();
                    ExtractZip(SavePath, ExtractionPath);
                    cancel.ThrowIfCancellationRequested();
                    Backup(installDir);
                    cancel.ThrowIfCancellationRequested();
                }, cancel);
                InstallProgressChanged?.Invoke(this, new InstallEventArgs(50));
                await Task.Run(() =>
                {
                    MoveFilesToGame(GetExtractedContentPath, installDir);
                    cancel.ThrowIfCancellationRequested();
                }, cancel);
                InstallComplete?.Invoke(this, new AsyncCompletedEventArgs(null, false, this));
            }
            catch (OperationCanceledException e) { InstallComplete?.Invoke(this, new AsyncCompletedEventArgs(e, true, this));}
            catch (Exception e) { InstallComplete?.Invoke(this, new AsyncCompletedEventArgs(e, false, this)); }
        }

        /// <summary>
        /// Extracts a zip file to the chosen directory.
        /// </summary>
        /// <param name="location">Location of the zip to be extracted.</param>
        /// <param name="extractPath">Where the zip should be extracted to.</param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="InvalidDataException"></exception>
        protected virtual void ExtractZip(string location, string extractPath) =>
            ZipFile.ExtractToDirectory(location, extractPath);

        /// <summary>
        /// Moves all files and folders to the specified location, overwriting existing files.
        /// </summary>
        /// <param name="location">Location of the files and folders to be moved.</param>
        /// <param name="installDir">Location to move the files to.</param>
        protected virtual void MoveFilesToGame(string location, string installDir) =>
            new Computer().FileSystem.CopyDirectory(location, installDir, true);

        /// <summary>
        /// Delete the extracted folder.
        /// </summary>
        protected new void Cleanup()
        {
            if (ExtractedFolderName != null)
                try
                {
                    Directory.Delete(ExtractionPath, true);
                } catch (Exception) { }
        }

        protected virtual void Backup(string installDir)
        {
            var skipDirectory = GetExtractedContentPath.Length;
            // because we don't want it to be prefixed by a slash
            // if dirPath like "C:\MyFolder", rather than "C:\MyFolder\"
            if (!ExtractedFolderName.EndsWith("" + Path.DirectorySeparatorChar)) skipDirectory++;
            foreach (string s in Directory.EnumerateFiles(GetExtractedContentPath, "*", SearchOption.AllDirectories)
                .Select(f => f.Substring(skipDirectory)))
            {
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(installDir, @"Backup.GT", s)));
                    File.Copy(Path.Combine(installDir, s), Path.Combine(installDir, @"Backup.GT", s), true);
                }
                catch (Exception)
                {
                    // For now, silently fail
                }
            }
        }

        public bool Equals(Patch other) { return other?.SavePath == SavePath; }
    }

    public class InstallEventArgs : EventArgs
    {
        public int Progress { get; }

        public InstallEventArgs(int progress) => Progress = progress;
    }
}
