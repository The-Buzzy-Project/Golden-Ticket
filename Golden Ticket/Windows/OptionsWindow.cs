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
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Golden_Ticket.Utilities;
using Golden_Ticket.Classes;
using Golden_Ticket.Properties;

namespace Golden_Ticket.Windows
{
    public partial class OptionsWindow : Form
    {
        // TODO: Document this form.
        private Game TpwGame { get; }
        private string _cpuName;
        private string _winVer;
        private string _gpuName;
        private string _arch;
        private ulong _ramSize;

        public OptionsWindow(Game game)
        {
            TpwGame = game;
            InitializeComponent();
        }

        private void OptionsWindow_Load(object sender, EventArgs e)
        {
            launcherVersionLabel.Text = "Ver. " + Application.ProductVersion;
            gameLocationTextBox.Text = TpwGame.GamePath;
            AutoUpdateCheckBox.Checked = Settings.Default.CheckForUpdatesOnStart;

            nameLabel.Text = $"{Application.ProductName} {Application.ProductVersion}";
            descriptionLabel.Text = "Enables Theme Park World to run on modern versions of Windows.";
            backgroundWorker1.RunWorkerAsync();
        }

        private void gameDirButton_Click(object sender, EventArgs e)
        {
            gameLocationTextBox.Text = FileDialogs.GetTpwFolder() ?? gameLocationTextBox.Text;
        }
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _cpuName = MachineInfo.ProcessorName;
            _arch = MachineInfo.Arch;
            _winVer = MachineInfo.WindowsVersion;
            _gpuName = MachineInfo.GpuName;
            _ramSize = MachineInfo.TotalMemory;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // TODO: Switch to async tasks so everything appears when it's ready.
            osLabel.Text = _winVer;
            archLabel.Text = _arch;
            gpuLabel.Text = _gpuName;
            cpuLabel.Text = _cpuName;
            ramLabel.Text = MachineInfo.FormatBytesUnsafe(_ramSize);
            specsExportButton.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                AddExtension = true,
                AutoUpgradeEnabled = true,
                CheckPathExists = true,
                DefaultExt = "txt",
                FileName = "SystemSpecs",
                Filter = "Text files (*.txt)|*.txt",
                InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString()
            };
            while (true)
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllLines(sfd.FileName, MachineInfo.ToFileOutput());
                        break;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("The text file could not be written. The chosen folder may be read-only.",
                            Resources.SpecsExport_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Unknown error while exporting system specs. Please show this to the developer." +
                            Environment.NewLine + Environment.NewLine + ex, Resources.SpecsExport_Error_Title,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                return;
            }

            if (MessageBox.Show("Your system specs were successfully exported to a text file."
                               + Environment.NewLine + "Location: " + sfd.FileName
                               + Environment.NewLine + "Would you like to open the folder?", "System Specs were exported!",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Process.Start(Path.GetDirectoryName(sfd.FileName));
            }
        }

        private void btnOK_Click(object sender, EventArgs e) { Save(); Close(); }

        /// <summary>
        /// Saves all settings to the application settings database.
        /// </summary>
        private void Save()
        {
            TpwGame.GamePath = gameLocationTextBox.Text; // Path to game
            Settings.Default.CheckForUpdatesOnStart = AutoUpdateCheckBox.Checked; // Check for updates on application launch
            Settings.Default.Save();
        }
    }
}
