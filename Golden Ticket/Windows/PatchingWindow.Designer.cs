namespace Golden_Ticket.Windows
{
    partial class PatchingWindow
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
            this.PatchingProgressbar = new System.Windows.Forms.ProgressBar();
            this.downloadPercentageLabel = new System.Windows.Forms.Label();
            this.bytesLabel = new System.Windows.Forms.Label();
            this.ApplyPatchWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // PatchingProgressbar
            // 
            this.PatchingProgressbar.Location = new System.Drawing.Point(12, 43);
            this.PatchingProgressbar.Name = "PatchingProgressbar";
            this.PatchingProgressbar.Size = new System.Drawing.Size(536, 23);
            this.PatchingProgressbar.TabIndex = 0;
            // 
            // downloadPercentageLabel
            // 
            this.downloadPercentageLabel.AutoSize = true;
            this.downloadPercentageLabel.BackColor = System.Drawing.Color.Transparent;
            this.downloadPercentageLabel.Location = new System.Drawing.Point(270, 9);
            this.downloadPercentageLabel.Name = "downloadPercentageLabel";
            this.downloadPercentageLabel.Size = new System.Drawing.Size(21, 13);
            this.downloadPercentageLabel.TabIndex = 1;
            this.downloadPercentageLabel.Text = "0%";
            // 
            // bytesLabel
            // 
            this.bytesLabel.AutoSize = true;
            this.bytesLabel.Location = new System.Drawing.Point(268, 27);
            this.bytesLabel.Name = "bytesLabel";
            this.bytesLabel.Size = new System.Drawing.Size(24, 13);
            this.bytesLabel.TabIndex = 2;
            this.bytesLabel.Text = "0/0";
            // 
            // ApplyPatchWorker
            // 
            this.ApplyPatchWorker.WorkerReportsProgress = true;
            this.ApplyPatchWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ApplyPatchWorker_DoWork);
            this.ApplyPatchWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ApplyPatchWorker_ProgressChanged);
            this.ApplyPatchWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ApplyPatchWorker_RunWorkerCompleted);
            // 
            // PatchingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 71);
            this.ControlBox = false;
            this.Controls.Add(this.bytesLabel);
            this.Controls.Add(this.downloadPercentageLabel);
            this.Controls.Add(this.PatchingProgressbar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatchingWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Downloading patch...";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DownloadingPatchWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar PatchingProgressbar;
        private System.Windows.Forms.Label downloadPercentageLabel;
        private System.Windows.Forms.Label bytesLabel;
        private System.ComponentModel.BackgroundWorker ApplyPatchWorker;
    }
}