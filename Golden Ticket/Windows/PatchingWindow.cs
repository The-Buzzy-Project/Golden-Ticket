using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;

namespace Golden_Ticket.Windows
{
    public partial class PatchingWindow : Form
    {

        bool applyingPatch;
        Exception exForError;
        int errorCode;
        Patches patches = new Patches();
        PathUtils pathUtils = new PathUtils();
        NotifyUser notifyUser = new NotifyUser();
        Errors errors = new Errors();
        GameInfo gameInfo = new GameInfo();
        // 1 == Vista/7
        // 2 == 8/8.1/10
        public int patchToDownload;

        public PatchingWindow()
        {
            InitializeComponent();
        }

        private void DownloadingPatchWindow_Load(object sender, EventArgs e)
        {
            // Keep it fresh in the bedroom
            if (File.Exists(pathUtils.goldenTicketDownloadsFolder + "\\GenericPatch.zip"))
            {
                File.Delete(pathUtils.goldenTicketDownloadsFolder + "\\GenericPatch.zip");
            }

            if(File.Exists(pathUtils.goldenTicketDownloadsFolder + "810Configs.zip"))
            {
                File.Delete(pathUtils.goldenTicketDownloadsFolder + "810Configs.zip");
            }

            if(Directory.Exists(pathUtils.goldenTicketTempFolder + "\\Generic-Patch-Files-master"))
            {
                Directory.Delete(pathUtils.goldenTicketTempFolder + "\\Generic-Patch-Files-master", true);
            }

            if(Directory.Exists(pathUtils.goldenTicketTempFolder + "\\8-10-Configs-master"))
            {
                Directory.Delete(pathUtils.goldenTicketTempFolder + "\\8-10-Configs-master", true);
            }
            // Done with the febreeze!


            // Let's get ready to download the patch zip from Github
            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);

            bytesLabel.Visible = true;
            this.Text = "Downloading patch...";

            // Starts the download

            if(patchToDownload == 1)
            {
                // Download Vista/7 patch
                client.DownloadFileAsync(new Uri("https://github.com/The-Buzzy-Project/Generic-Patch-Files/archive/master.zip"), pathUtils.goldenTicketDownloadsFolder); // OS generic patch files
            }
            else
            {
                if(patchToDownload == 2)
                {
                    // Download Vista/7 patch
                    client.DownloadFileAsync(new Uri("https://github.com/The-Buzzy-Project/Generic-Patch-Files/archive/master.zip"), pathUtils.goldenTicketDownloadsFolder + "\\GenericPatch.zip"); // OS generic patch files
                    // Download 8/8.1/10 graphics configs
                    //client.DownloadFileAsync(new Uri("https://github.com/The-Buzzy-Project/8-10-Configs/archive/master.zip"), pathUtils.goldenTicketDownloadsFolder + "\\810Configs.zip"); // 8/8.1/10 graphics configs
                }
            }
        }

        private void InstallPatch()
        {
                this.Text = "Preparing patch...";
                PatchingProgressbar.Value = 0;
                bytesLabel.Visible = false;
                ApplyPatchWorker.RunWorkerAsync();
                //MessageBox.Show("Install Vista/7");
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (patchToDownload == 2)
            {
                if (!System.IO.File.Exists(pathUtils.goldenTicketDownloadsFolder + "\\810Configs.zip"))
                {
                    WebClient client = new WebClient();
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    client.DownloadFileAsync(new Uri("https://github.com/The-Buzzy-Project/8-10-Configs/archive/master.zip"), pathUtils.goldenTicketDownloadsFolder + "\\810Configs.zip"); // 8/8.1/10 graphics configs
                }
                else
                {
                    InstallPatch();
                }
            }
            else
            {
                InstallPatch();
            }
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;

            //PatchingProgressbar.Value = int.Parse(Math.Truncate(percentage).ToString()); <--- CAUSES A RANDOM ERROR ABOUT PROGRESSBAR VALUE BEING TOO HIGH/LOW
            PatchingProgressbar.Value = e.ProgressPercentage; // Always use e.ProgressPercentage for this!
            downloadPercentageLabel.Text = PatchingProgressbar.Value.ToString() + "%";
            bytesLabel.Text = bytesIn + "/" + totalBytes;
        }

        private void ApplyPatchWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++) // The code needs to go in here so that we can get progress reports
            {
                ApplyPatchStep1();
                ApplyPatchWorker.ReportProgress(i);
                if (ApplyPatchWorker.CancellationPending) { e.Cancel = true; return; } // Check if we need to cancel
                applyingPatch = true;
                ApplyPatchWorker.ReportProgress(i);
                ApplyPatchStep2();
                ApplyPatchWorker.ReportProgress(i);
                if (ApplyPatchWorker.CancellationPending) { e.Cancel = true; return; } // Check if we need to cancel
                return;
            }
        }
        void ApplyPatchStep1()
        {
            // Extract the zip files to our Temp directory
            try
            {
                ZipFile.ExtractToDirectory(pathUtils.goldenTicketDownloadsFolder + "\\GenericPatch.zip", pathUtils.goldenTicketTempFolder);

                if(File.Exists(pathUtils.goldenTicketDownloadsFolder + "\\810Configs.zip"))
                {
                    // It appears we're patching for 8/8.1/10 so let's prepare that as well...
                    ZipFile.ExtractToDirectory(pathUtils.goldenTicketDownloadsFolder + "\\810Configs.zip", pathUtils.goldenTicketTempFolder);
                }
                else
                {
                    // We don't have the 8/8.1/10 configs in the Downloads folder, continue
                    return;
                }

            }
            catch (Exception ex)
            {
                exForError = ex;
                errorCode = 4;
                ApplyPatchWorker.CancelAsync();
            }
        }

        void ApplyPatchStep2()
        {
            string gtTempFolder;
            gtTempFolder = pathUtils.goldenTicketTempFolder;
            string gtGenericPatchDirectory;
            gtGenericPatchDirectory = pathUtils.goldenTicketTempFolder + "\\Generic-Patch-Files-master";
            // Copy all our patch files located in the Temp directory into the game directory
            string gt810ConfigsDirectory;
            gt810ConfigsDirectory = pathUtils.goldenTicketTempFolder + "\\8-10-Configs-master";
            try
            {
                string gameDirectory;
                gameDirectory = gameInfo.GetInstallLocationFromReg();
                foreach (var file in Directory.GetFiles(gtGenericPatchDirectory))
                {
                    File.Copy(file, Path.Combine(gameDirectory, Path.GetFileName(file)), true);
                }

                foreach (var file in Directory.GetFiles(gtGenericPatchDirectory + "\\data"))
                {
                    File.Copy(file, Path.Combine(gameDirectory + "\\data", Path.GetFileName(file)), true);
                }

                if (!Directory.Exists(gameDirectory + "\\data\\tpwfnt"))
                {
                    Directory.CreateDirectory(gameDirectory + "\\data\\tpwfnt");
                }

                foreach (var file in Directory.GetFiles(gtGenericPatchDirectory + "\\data\\tpwfnt"))
                {
                    File.Copy(file, Path.Combine(gameDirectory + "\\data\\tpwfnt", Path.GetFileName(file)), true);
                }

                if (Directory.Exists(gt810ConfigsDirectory))
                {
                    MessageBox.Show("Installing 8/8.1/10 configs");
                    try
                    {
                        foreach (var file in Directory.GetFiles(gt810ConfigsDirectory + "\\data"))
                        {
                            File.Copy(file, Path.Combine(gameDirectory + "\\data", Path.GetFileName(file)), true);
                        }
                    }
                    catch(Exception ex)
                    {
                        notifyUser.Notify(this, "Unexpected error!",
                                            "An unexpected error has occured. Who? What? When? Where? Why? How? Not sure. Screenshot this message box and send it to the developer please."
                                            + Environment.NewLine + Environment.NewLine + ex.ToString(),
                                            MessageBoxIcon.Error, MessageBoxButtons.OK);
                    }
                }
                else
                {
                    // We're not patching for 8/8.1/10 so return. We're done.
                    return;
                }
            }
            catch(Exception ex)
            {
                exForError = ex;
                errorCode = 4;
                ApplyPatchWorker.CancelAsync();
            }
        }

        private void ApplyPatchWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                //LauncherProgressBar.Style = ProgressBarStyle.Continuous;
                errors.ReportCorrectErrorCodeToUser(errorCode, this, exForError);
                //ProgressLabel.Text = "The developer is stupid and screwed up the launcher! (Error " + errorCode + ")";
            }
            else
            {
                this.Text = "Done patching!";
                this.Close();
            }
        }

        private void ApplyPatchWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(applyingPatch == true)
            {
                this.Text = "Applying patch...";
            }
        }
    }
}
