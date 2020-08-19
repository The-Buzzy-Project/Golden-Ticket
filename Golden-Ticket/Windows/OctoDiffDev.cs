using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octodiff;
using Octodiff.Core;

namespace Golden_Ticket
{

    // THIS IS A DEVELOPER TOOL AND SHOULD NOT BE VISIBLE TO THE USER

    public partial class OctoDiffDev : Form
    {
        public OctoDiffDev()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            createSigs();
        }

        private void createSigs()
        {
            // Clear the console of any text
            diffConsole.Text = "";
            // Automatically add trailing slashes to textbox
            string filepath = inputpathBox.Text + "\\";
            DirectoryInfo d = new DirectoryInfo(filepath);

            // We're using 'try' in order to prevent a meltdown if something happens
            try
            {
                foreach (var file in d.GetFiles("*.*")) // Get all files in dir regardless of file type
                {
                    ;
                    // Path to the file we're working on making a sig for
                    var signatureBaseFilePath = Path.Combine(filepath, file.Name); // Individual file

                    // Destination of the signature for current file
                    var signatureFilePath = outputpathBox.Text + "\\" + file.Name + ".octosig";
                    var signatureOutputDirectory = Path.GetDirectoryName(signatureFilePath);

                    // Automatically create output dir if it doesn't exist
                    if (!Directory.Exists(signatureOutputDirectory))
                        Directory.CreateDirectory(signatureOutputDirectory);

                    // Build the signature file
                    var signatureBuilder = new SignatureBuilder();
                    using (var basisStream = new FileStream(signatureBaseFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    using (var signatureStream = new FileStream(signatureFilePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                    {
                        signatureBuilder.Build(basisStream, new SignatureWriter(signatureStream));
                    }

                    // Let dev/user know what files we just generated and their location. Basically debugging here.
                    diffConsole.Text = diffConsole.Text + Environment.NewLine + signatureFilePath;
                }
            }
            catch(Exception e)
            {
                // Something happened, please don't crash
                MessageBox.Show(e.ToString());
            }

            



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Wee flashing lights
            if (goawayLabel.Visible == true)
            {
                goawayLabel.Visible = false;
            }
            else{
                goawayLabel.Visible = true;
            }
        }
    }
}
