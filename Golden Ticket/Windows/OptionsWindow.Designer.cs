namespace Golden_Ticket.Windows
{
    partial class OptionsWindow
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
            this.optionsLabel = new System.Windows.Forms.Label();
            this.gameLocationLabelLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gameDirButton = new System.Windows.Forms.Button();
            this.gameLocationLabel = new System.Windows.Forms.Label();
            this.optionsExitButton = new System.Windows.Forms.Button();
            this.launcherVersionLabel = new System.Windows.Forms.Label();
            this.sysInfoBox = new System.Windows.Forms.GroupBox();
            this.osLabel = new System.Windows.Forms.Label();
            this.archLabel = new System.Windows.Forms.Label();
            this.cpuLabel = new System.Windows.Forms.Label();
            this.gpuLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ramLabel = new System.Windows.Forms.Label();
            this.specsExportButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.sysInfoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionsLabel
            // 
            this.optionsLabel.AutoSize = true;
            this.optionsLabel.BackColor = System.Drawing.Color.Transparent;
            this.optionsLabel.ForeColor = System.Drawing.Color.White;
            this.optionsLabel.Location = new System.Drawing.Point(252, 9);
            this.optionsLabel.Name = "optionsLabel";
            this.optionsLabel.Size = new System.Drawing.Size(43, 13);
            this.optionsLabel.TabIndex = 0;
            this.optionsLabel.Text = "Options";
            // 
            // gameLocationLabelLabel
            // 
            this.gameLocationLabelLabel.AutoSize = true;
            this.gameLocationLabelLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameLocationLabelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameLocationLabelLabel.ForeColor = System.Drawing.Color.White;
            this.gameLocationLabelLabel.Location = new System.Drawing.Point(6, 29);
            this.gameLocationLabelLabel.Name = "gameLocationLabelLabel";
            this.gameLocationLabelLabel.Size = new System.Drawing.Size(82, 13);
            this.gameLocationLabelLabel.TabIndex = 1;
            this.gameLocationLabelLabel.Text = "Game Location:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.launcherVersionLabel);
            this.groupBox1.Controls.Add(this.gameLocationLabel);
            this.groupBox1.Controls.Add(this.gameDirButton);
            this.groupBox1.Controls.Add(this.gameLocationLabelLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 240);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game/Launcher Info";
            // 
            // gameDirButton
            // 
            this.gameDirButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.gameDirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameDirButton.ForeColor = System.Drawing.Color.White;
            this.gameDirButton.Location = new System.Drawing.Point(234, 24);
            this.gameDirButton.Name = "gameDirButton";
            this.gameDirButton.Size = new System.Drawing.Size(26, 23);
            this.gameDirButton.TabIndex = 2;
            this.gameDirButton.Text = "...";
            this.gameDirButton.UseVisualStyleBackColor = true;
            this.gameDirButton.Click += new System.EventHandler(this.gameDirButton_Click);
            // 
            // gameLocationLabel
            // 
            this.gameLocationLabel.AutoEllipsis = true;
            this.gameLocationLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameLocationLabel.ForeColor = System.Drawing.Color.White;
            this.gameLocationLabel.Location = new System.Drawing.Point(84, 29);
            this.gameLocationLabel.Name = "gameLocationLabel";
            this.gameLocationLabel.Size = new System.Drawing.Size(144, 13);
            this.gameLocationLabel.TabIndex = 3;
            this.gameLocationLabel.Text = "Beep boop...";
            // 
            // optionsExitButton
            // 
            this.optionsExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.optionsExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionsExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsExitButton.ForeColor = System.Drawing.Color.White;
            this.optionsExitButton.Location = new System.Drawing.Point(520, 3);
            this.optionsExitButton.Name = "optionsExitButton";
            this.optionsExitButton.Size = new System.Drawing.Size(23, 25);
            this.optionsExitButton.TabIndex = 8;
            this.optionsExitButton.Text = "X";
            this.optionsExitButton.UseVisualStyleBackColor = true;
            this.optionsExitButton.Click += new System.EventHandler(this.launcherExitButton_Click);
            // 
            // launcherVersionLabel
            // 
            this.launcherVersionLabel.AutoSize = true;
            this.launcherVersionLabel.ForeColor = System.Drawing.Color.White;
            this.launcherVersionLabel.Location = new System.Drawing.Point(6, 224);
            this.launcherVersionLabel.Name = "launcherVersionLabel";
            this.launcherVersionLabel.Size = new System.Drawing.Size(50, 13);
            this.launcherVersionLabel.TabIndex = 4;
            this.launcherVersionLabel.Text = "Ver. x.x.x";
            // 
            // sysInfoBox
            // 
            this.sysInfoBox.Controls.Add(this.specsExportButton);
            this.sysInfoBox.Controls.Add(this.ramLabel);
            this.sysInfoBox.Controls.Add(this.gpuLabel);
            this.sysInfoBox.Controls.Add(this.cpuLabel);
            this.sysInfoBox.Controls.Add(this.archLabel);
            this.sysInfoBox.Controls.Add(this.osLabel);
            this.sysInfoBox.ForeColor = System.Drawing.Color.White;
            this.sysInfoBox.Location = new System.Drawing.Point(285, 55);
            this.sysInfoBox.Name = "sysInfoBox";
            this.sysInfoBox.Size = new System.Drawing.Size(249, 237);
            this.sysInfoBox.TabIndex = 9;
            this.sysInfoBox.TabStop = false;
            this.sysInfoBox.Text = "System Info";
            // 
            // osLabel
            // 
            this.osLabel.AutoSize = true;
            this.osLabel.Location = new System.Drawing.Point(6, 24);
            this.osLabel.Name = "osLabel";
            this.osLabel.Size = new System.Drawing.Size(94, 13);
            this.osLabel.TabIndex = 0;
            this.osLabel.Text = "OS: Please Wait...";
            // 
            // archLabel
            // 
            this.archLabel.AutoSize = true;
            this.archLabel.Location = new System.Drawing.Point(6, 39);
            this.archLabel.Name = "archLabel";
            this.archLabel.Size = new System.Drawing.Size(101, 13);
            this.archLabel.TabIndex = 1;
            this.archLabel.Text = "Arch: Please Wait...";
            // 
            // cpuLabel
            // 
            this.cpuLabel.AutoEllipsis = true;
            this.cpuLabel.Location = new System.Drawing.Point(6, 54);
            this.cpuLabel.Name = "cpuLabel";
            this.cpuLabel.Size = new System.Drawing.Size(237, 23);
            this.cpuLabel.TabIndex = 2;
            this.cpuLabel.Text = "CPU: Please Wait...";
            // 
            // gpuLabel
            // 
            this.gpuLabel.AutoEllipsis = true;
            this.gpuLabel.Location = new System.Drawing.Point(6, 69);
            this.gpuLabel.Name = "gpuLabel";
            this.gpuLabel.Size = new System.Drawing.Size(237, 23);
            this.gpuLabel.TabIndex = 3;
            this.gpuLabel.Text = "GPU: Please Wait...";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // ramLabel
            // 
            this.ramLabel.AutoSize = true;
            this.ramLabel.Location = new System.Drawing.Point(6, 84);
            this.ramLabel.Name = "ramLabel";
            this.ramLabel.Size = new System.Drawing.Size(103, 13);
            this.ramLabel.TabIndex = 4;
            this.ramLabel.Text = "RAM: Please Wait...";
            // 
            // specsExportButton
            // 
            this.specsExportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.specsExportButton.Location = new System.Drawing.Point(6, 208);
            this.specsExportButton.Name = "specsExportButton";
            this.specsExportButton.Size = new System.Drawing.Size(237, 23);
            this.specsExportButton.TabIndex = 5;
            this.specsExportButton.Text = "Export to .txt file";
            this.specsExportButton.UseVisualStyleBackColor = true;
            this.specsExportButton.Visible = false;
            this.specsExportButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // OptionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 307);
            this.Controls.Add(this.sysInfoBox);
            this.Controls.Add(this.optionsExitButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.optionsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OptionsWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OptionsWindow";
            this.Load += new System.EventHandler(this.OptionsWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.sysInfoBox.ResumeLayout(false);
            this.sysInfoBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label optionsLabel;
        private System.Windows.Forms.Label gameLocationLabelLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button gameDirButton;
        private System.Windows.Forms.Label gameLocationLabel;
        private System.Windows.Forms.Button optionsExitButton;
        private System.Windows.Forms.Label launcherVersionLabel;
        private System.Windows.Forms.GroupBox sysInfoBox;
        private System.Windows.Forms.Label osLabel;
        private System.Windows.Forms.Label archLabel;
        private System.Windows.Forms.Label cpuLabel;
        private System.Windows.Forms.Label gpuLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label ramLabel;
        private System.Windows.Forms.Button specsExportButton;
    }
}