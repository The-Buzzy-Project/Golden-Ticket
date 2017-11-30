namespace Golden_Ticket.Windows
{
    partial class UpdateWindowBottom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.updaterTitleBar = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // updaterTitleBar
            // 
            this.updaterTitleBar.BackColor = System.Drawing.Color.Black;
            this.updaterTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.updaterTitleBar.Location = new System.Drawing.Point(0, 0);
            this.updaterTitleBar.Name = "updaterTitleBar";
            this.updaterTitleBar.Size = new System.Drawing.Size(280, 28);
            this.updaterTitleBar.TabIndex = 4;
            // 
            // UpdateWindowBottom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(280, 168);
            this.Controls.Add(this.updaterTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateWindowBottom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateWindowBottom";
            this.Load += new System.EventHandler(this.UpdateWindowBottom_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel updaterTitleBar;
    }
}