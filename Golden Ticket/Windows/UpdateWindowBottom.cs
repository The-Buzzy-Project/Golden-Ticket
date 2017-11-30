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
    public partial class UpdateWindowBottom : Form
    {
        UpdateWindow updateWindow = new UpdateWindow();

        public UpdateWindowBottom()
        {
            InitializeComponent();
        }

        private void UpdateWindowBottom_Load(object sender, EventArgs e)
        {
            //These are properties you could also set in the Designer
        this.Opacity = 0.5F;
        this.BackColor = Color.Black; //for example

        updateWindow.FormBorderStyle = FormBorderStyle.None;
        updateWindow.BackColor = Color.Black; //Choose any colour that does not appear in your controls
        updateWindow.TransparencyKey = updateWindow.BackColor;
        updateWindow.ShowInTaskbar = false;

            //You have to do this in code:
            this.AddOwnedForm(updateWindow);
            updateWindow.Show();
        }

        private void AlignForms(object sender, System.EventArgs e)
        {
            updateWindow.Location = this.PointToScreen(Point.Empty);
            updateWindow.Size = this.ClientSize;
        }
    }
}
