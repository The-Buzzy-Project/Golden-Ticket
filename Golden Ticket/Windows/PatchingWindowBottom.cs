using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Golden_Ticket.Windows
{
    public partial class PatchingWindowBottom : Form
    {
        PatchingWindow patchingWindow = new PatchingWindow();

        public PatchingWindowBottom()
        {
            InitializeComponent();
        }

        private void PatchingWindowBottom_Load(object sender, EventArgs e)
        {
            //These are properties you could also set in the Designer
            this.Opacity = 0.5F;
            this.BackColor = Color.Black; //for example

            patchingWindow.FormBorderStyle = FormBorderStyle.None;
            patchingWindow.BackColor = Color.Black; //Choose any colour that does not appear in your controls
            patchingWindow.TransparencyKey = patchingWindow.BackColor;
            patchingWindow.ShowInTaskbar = false;

            //You have to do this in code:
            this.AddOwnedForm(patchingWindow);
            patchingWindow.Show();
        }

        private void AlignForms(object sender, System.EventArgs e)
        {
            patchingWindow.Location = this.PointToScreen(Point.Empty);
            patchingWindow.Size = this.ClientSize;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(patchingWindow.Visible == false)
            {
                this.Close();
            }
        }
    }
}
