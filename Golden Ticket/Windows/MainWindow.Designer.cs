namespace Golden_Ticket
{
    partial class MainWindow
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
            this.LauncherProgressBar = new System.Windows.Forms.ProgressBar();
            this.LauncherStartup = new System.ComponentModel.BackgroundWorker();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.launchButton = new System.Windows.Forms.Button();
            this.buildLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LauncherProgressBar
            // 
            this.LauncherProgressBar.Location = new System.Drawing.Point(12, 443);
            this.LauncherProgressBar.Name = "LauncherProgressBar";
            this.LauncherProgressBar.Size = new System.Drawing.Size(359, 31);
            this.LauncherProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.LauncherProgressBar.TabIndex = 0;
            // 
            // LauncherStartup
            // 
            this.LauncherStartup.WorkerReportsProgress = true;
            this.LauncherStartup.WorkerSupportsCancellation = true;
            this.LauncherStartup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LauncherStartup_DoWork);
            this.LauncherStartup.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.LauncherStartup_ProgressChanged);
            this.LauncherStartup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LauncherStartup_RunWorkerCompleted);
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(13, 424);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(67, 13);
            this.ProgressLabel.TabIndex = 1;
            this.ProgressLabel.Text = "Starting up...";
            // 
            // launchButton
            // 
            this.launchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launchButton.Location = new System.Drawing.Point(584, 443);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(86, 31);
            this.launchButton.TabIndex = 2;
            this.launchButton.Text = "Play!";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // buildLabel
            // 
            this.buildLabel.AutoSize = true;
            this.buildLabel.Location = new System.Drawing.Point(599, 9);
            this.buildLabel.Name = "buildLabel";
            this.buildLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buildLabel.Size = new System.Drawing.Size(71, 13);
            this.buildLabel.TabIndex = 3;
            this.buildLabel.Text = "x.x.xxxx.xxxxx";
            this.buildLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 486);
            this.Controls.Add(this.buildLabel);
            this.Controls.Add(this.launchButton);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.LauncherProgressBar);
            this.DoubleBuffered = true;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Golden Ticket (BETA)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar LauncherProgressBar;
        private System.ComponentModel.BackgroundWorker LauncherStartup;
        public System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.Label buildLabel;
    }
}

