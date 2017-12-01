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
    public partial class OptionsWindowBottom : Form
    {
        OptionsWindow optionsWindow = new OptionsWindow();

        public OptionsWindowBottom()
        {
            InitializeComponent();
        }

        private void OptionsWindowBottom_Load(object sender, EventArgs e)
        {
            //These are properties you could also set in the Designer
            this.Opacity = 0.5F;
            this.BackColor = Color.Black; //for example

            optionsWindow.FormBorderStyle = FormBorderStyle.None;
            optionsWindow.BackColor = Color.Black; //Choose any colour that does not appear in your controls
            optionsWindow.TransparencyKey = optionsWindow.BackColor;
            optionsWindow.ShowInTaskbar = false;

            //You have to do this in code:
            this.AddOwnedForm(optionsWindow);
            optionsWindow.Show();
            timer1.Enabled = true;
        }

        private void AlignForms(object sender, System.EventArgs e)
        {
            optionsWindow.Location = this.PointToScreen(Point.Empty);
            optionsWindow.Size = this.ClientSize;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(optionsWindow.Visible == false)
            {
                this.Close();
            }
        }
    }
}
