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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.MainProgressbar = new System.Windows.Forms.ProgressBar();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.StartLauncher = new System.ComponentModel.BackgroundWorker();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Gray;
            this.MainPanel.Controls.Add(this.StatusLabel);
            this.MainPanel.Controls.Add(this.MainProgressbar);
            this.MainPanel.Controls.Add(this.OptionsButton);
            this.MainPanel.Controls.Add(this.PlayButton);
            this.MainPanel.Location = new System.Drawing.Point(0, 324);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(647, 81);
            this.MainPanel.TabIndex = 0;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(12, 20);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(166, 13);
            this.StatusLabel.TabIndex = 3;
            this.StatusLabel.Text = "Status: Checking install location...";
            // 
            // MainProgressbar
            // 
            this.MainProgressbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MainProgressbar.Location = new System.Drawing.Point(12, 36);
            this.MainProgressbar.Name = "MainProgressbar";
            this.MainProgressbar.Size = new System.Drawing.Size(237, 23);
            this.MainProgressbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.MainProgressbar.TabIndex = 2;
            // 
            // OptionsButton
            // 
            this.OptionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsButton.BackColor = System.Drawing.Color.Gray;
            this.OptionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OptionsButton.Location = new System.Drawing.Point(546, 46);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(89, 23);
            this.OptionsButton.TabIndex = 1;
            this.OptionsButton.Text = "Options...";
            this.OptionsButton.UseVisualStyleBackColor = false;
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayButton.BackColor = System.Drawing.Color.Gray;
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayButton.Location = new System.Drawing.Point(546, 11);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(89, 23);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // StartLauncher
            // 
            this.StartLauncher.WorkerReportsProgress = true;
            this.StartLauncher.DoWork += new System.ComponentModel.DoWorkEventHandler(this.StartLauncher_DoWork);
            this.StartLauncher.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.StartLauncher_ProgressChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Golden_Ticket.Properties.Resources.RestoredBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(647, 405);
            this.Controls.Add(this.MainPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(664, 445);
            this.MinimumSize = new System.Drawing.Size(662, 443);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Golden Ticket";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button OptionsButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.ProgressBar MainProgressbar;
        private System.Windows.Forms.Label StatusLabel;
        private System.ComponentModel.BackgroundWorker StartLauncher;
    }
}

