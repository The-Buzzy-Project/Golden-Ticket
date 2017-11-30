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
            this.panel1 = new System.Windows.Forms.Panel();
            this.optionsButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.launcherExitButton = new System.Windows.Forms.Button();
            this.launcherTitleLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LauncherProgressBar
            // 
            this.LauncherProgressBar.Location = new System.Drawing.Point(12, 30);
            this.LauncherProgressBar.Name = "LauncherProgressBar";
            this.LauncherProgressBar.Size = new System.Drawing.Size(359, 17);
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
            this.ProgressLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProgressLabel.ForeColor = System.Drawing.Color.White;
            this.ProgressLabel.Location = new System.Drawing.Point(12, 14);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(67, 13);
            this.ProgressLabel.TabIndex = 1;
            this.ProgressLabel.Text = "Starting up...";
            // 
            // launchButton
            // 
            this.launchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launchButton.ForeColor = System.Drawing.Color.White;
            this.launchButton.Location = new System.Drawing.Point(653, 5);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(86, 23);
            this.launchButton.TabIndex = 2;
            this.launchButton.Text = "Play!";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.optionsButton);
            this.panel1.Controls.Add(this.launchButton);
            this.panel1.Controls.Add(this.LauncherProgressBar);
            this.panel1.Controls.Add(this.ProgressLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 406);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 59);
            this.panel1.TabIndex = 3;
            // 
            // optionsButton
            // 
            this.optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionsButton.ForeColor = System.Drawing.Color.White;
            this.optionsButton.Location = new System.Drawing.Point(653, 32);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(86, 23);
            this.optionsButton.TabIndex = 5;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.launcherExitButton);
            this.panel2.Controls.Add(this.launcherTitleLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(751, 31);
            this.panel2.TabIndex = 4;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // button1
            // 
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(696, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 25);
            this.button1.TabIndex = 6;
            this.button1.Text = "-";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // launcherExitButton
            // 
            this.launcherExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.launcherExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launcherExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launcherExitButton.ForeColor = System.Drawing.Color.White;
            this.launcherExitButton.Location = new System.Drawing.Point(725, 3);
            this.launcherExitButton.Name = "launcherExitButton";
            this.launcherExitButton.Size = new System.Drawing.Size(23, 25);
            this.launcherExitButton.TabIndex = 5;
            this.launcherExitButton.Text = "X";
            this.launcherExitButton.UseVisualStyleBackColor = true;
            this.launcherExitButton.Click += new System.EventHandler(this.launcherExitButton_Click);
            // 
            // launcherTitleLabel
            // 
            this.launcherTitleLabel.AutoSize = true;
            this.launcherTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.launcherTitleLabel.ForeColor = System.Drawing.Color.White;
            this.launcherTitleLabel.Location = new System.Drawing.Point(9, 9);
            this.launcherTitleLabel.Name = "launcherTitleLabel";
            this.launcherTitleLabel.Size = new System.Drawing.Size(74, 13);
            this.launcherTitleLabel.TabIndex = 5;
            this.launcherTitleLabel.Text = "Golden Ticket";
            this.launcherTitleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.launcherTitleLabel_MouseDown);
            this.launcherTitleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.launcherTitleLabel_MouseMove);
            this.launcherTitleLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.launcherTitleLabel_MouseUp);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Golden_Ticket.Properties.Resources.coasterblurred;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(751, 465);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Golden Ticket (PRERELEASE)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar LauncherProgressBar;
        public System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label launcherTitleLabel;
        private System.Windows.Forms.Button launcherExitButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button optionsButton;
        public System.ComponentModel.BackgroundWorker LauncherStartup;
    }
}

