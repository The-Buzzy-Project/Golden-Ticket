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
            this.SuspendLayout();
            // 
            // CurrentVersionLabel
            // 
            this.CurrentVersionLabel.AutoSize = true;
            this.CurrentVersionLabel.Location = new System.Drawing.Point(90, 18);
            this.CurrentVersionLabel.Name = "CurrentVersionLabel";
            this.CurrentVersionLabel.Size = new System.Drawing.Size(105, 13);
            this.CurrentVersionLabel.TabIndex = 0;
            this.CurrentVersionLabel.Text = "Current version: x.x.x";
            // 
            // NewVersionLabel
            // 
            this.NewVersionLabel.AutoSize = true;
            this.NewVersionLabel.Location = new System.Drawing.Point(96, 40);
            this.NewVersionLabel.Name = "NewVersionLabel";
            this.NewVersionLabel.Size = new System.Drawing.Size(93, 13);
            this.NewVersionLabel.TabIndex = 1;
            this.NewVersionLabel.Text = "New version: x.x.x";
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.Location = new System.Drawing.Point(12, 131);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(260, 23);
            this.DownloadProgressBar.TabIndex = 2;
            // 
            // UpdateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 172);
            this.ControlBox = false;
            this.Controls.Add(this.DownloadProgressBar);
            this.Controls.Add(this.NewVersionLabel);
            this.Controls.Add(this.CurrentVersionLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updating Golden Ticket...";
            this.Load += new System.EventHandler(this.UpdateWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CurrentVersionLabel;
        private System.Windows.Forms.Label NewVersionLabel;
        private System.Windows.Forms.ProgressBar DownloadProgressBar;
    }
}