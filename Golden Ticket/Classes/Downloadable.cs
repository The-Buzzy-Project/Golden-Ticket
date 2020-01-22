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
using System.Net;
using System.Security.Cryptography;
using System.Threading;

namespace Golden_Ticket.Classes
{
    /// <summary>
    /// Implements an object that can be downloaded.
    /// </summary>
    public abstract class Downloadable : IDisposable
    {
        protected abstract string DownloadUrl { get; }
        protected WebClient Downloader = new WebClient(); // Async file downloader

        public event DownloadProgressChangedEventHandler FileProgressChanged; // Fires when some data gets transferred
        public event AsyncCompletedEventHandler FileDownloaded; // Fires when file is finished downloading

        protected virtual string SaveName => Path.GetFileName(SavePath); // File name of downloaded file
        public virtual string SavePath { get; } = Path.GetTempFileName(); // Path to a temporary file

        /// <summary>
        /// Downloads the file to SavePath. SavePath can be modified by inheriting classes.
        /// By default, downloads to the temporary folder with a randomly generated file name.
        /// </summary>
        public virtual void Download(CancellationToken cancel)
        {
            // Implement event handlers
            Downloader.DownloadProgressChanged += FileProgressChanged;
            Downloader.DownloadFileCompleted += FileDownloaded;
            cancel.Register(Downloader.CancelAsync);
            // Start download
            Downloader.DownloadFileAsync(new Uri(DownloadUrl), SavePath, this);
        }
        
        // TODO: Get MD5 hash from something (JSON file?).
        public virtual bool VerifyDownload(string expectedHash) => (expectedHash == GetMd5HashOfDownload()); // Checks MD5 hash against known value

        /// <summary>
        /// Calculates the MD5 hash of a file for verification against a known value.
        /// </summary>
        /// <returns>The calculated MD5 hash of the downloaded file.</returns>
        protected virtual string GetMd5HashOfDownload()
        {
            try
            {
                using (Stream stream = File.OpenRead(SavePath))
                {
                    using (MD5 md5 = MD5.Create())
                    {
                        return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty)
                            .ToLowerInvariant();
                    }
                }
            }
            catch (Exception) { return null; }
        }

        protected virtual void Cleanup() => RemoveDownload(); // Delete all temporary files

        // TODO: This should not fail because it's the temp folder, but just in case, error check.
        protected virtual void RemoveDownload() => File.Delete(SavePath);

        protected void DownloadComplete()
        {

        }

        public virtual void Dispose() => Downloader?.Dispose(); // Clean up resources used by downloader

        ~Downloadable()
        {
            // When class is destroyed, clean up after ourselves
            Dispose();
            Cleanup();
        }
    }
}