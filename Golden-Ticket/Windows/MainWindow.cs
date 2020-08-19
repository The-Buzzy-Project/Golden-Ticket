using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Golden_Ticket.Windows;

namespace Golden_Ticket.Windows
{

    // HEY! We gotta talk, man.
    // This window should...PROBABLY have as close to no code logic in it as possible.
    // This window should BASICALLY be a frontend for whatever we're doing. Basically a progress bar.
    // We need to try to do everything in the BACKGROUND, and keep everything clean. Let's try that.

    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            // In theory, by the time this is called, the form is fully loaded.

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PatcherWindow pw = new PatcherWindow();
            pw.ShowDialog();
        }
    }
}
