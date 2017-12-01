namespace Golden_Ticket.Windows
{
    partial class UpdateWindow
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
            this.CurrentVersionLabel = new System.Windows.Forms.Label();
            this.NewVersionLabel = new System.Windows.Forms.Label();
            this.DownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.updaterTitleLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CurrentVersionLabel
            // 
            this.CurrentVersionLabel.AutoSize = true;
            this.CurrentVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.CurrentVersionLabel.ForeColor = System.Drawing.Color.White;
            this.CurrentVersionLabel.Location = new System.Drawing.Point(86, 48);
            this.CurrentVersionLabel.Name = "CurrentVersionLabel";
            this.CurrentVersionLabel.Size = new System.Drawing.Size(105, 13);
            this.CurrentVersionLabel.TabIndex = 0;
            this.CurrentVersionLabel.Text = "Current version: x.x.x";
            // 
            // NewVersionLabel
            // 
            this.NewVersionLabel.AutoSize = true;
            this.NewVersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.NewVersionLabel.ForeColor = System.Drawing.Color.White;
            this.NewVersionLabel.Location = new System.Drawing.Point(92, 70);
            this.NewVersionLabel.Name = "NewVersionLabel";
            this.NewVersionLabel.Size = new System.Drawing.Size(93, 13);
            this.NewVersionLabel.TabIndex = 1;
            this.NewVersionLabel.Text = "New version: x.x.x";
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.Location = new System.Drawing.Point(8, 133);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(260, 23);
            this.DownloadProgressBar.TabIndex = 2;
            // 
            // updaterTitleLabel
            // 
            this.updaterTitleLabel.AutoSize = true;
            this.updaterTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.updaterTitleLabel.ForeColor = System.Drawing.Color.White;
            this.updaterTitleLabel.Location = new System.Drawing.Point(8, 9);
            this.updaterTitleLabel.Name = "updaterTitleLabel";
            this.updaterTitleLabel.Size = new System.Drawing.Size(129, 13);
            this.updaterTitleLabel.TabIndex = 4;
            this.updaterTitleLabel.Text = "Updating Golden Ticket...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 28);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // UpdateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(280, 168);
            this.ControlBox = false;
            this.Controls.Add(this.updaterTitleLabel);
            this.Controls.Add(this.DownloadProgressBar);
            this.Controls.Add(this.CurrentVersionLabel);
            this.Controls.Add(this.NewVersionLabel);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updating Golden Ticket...";
            this.Load += new System.EventHandler(this.UpdateWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CurrentVersionLabel;
        private System.Windows.Forms.Label NewVersionLabel;
        private System.Windows.Forms.ProgressBar DownloadProgressBar;
        private System.Windows.Forms.Label updaterTitleLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}