namespace Golden_Ticket.Windows
{
    partial class PatcherWindow
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
            this.gameverLabel = new System.Windows.Forms.Label();
            this.gameDirLabel = new System.Windows.Forms.Label();
            this.osLabel = new System.Windows.Forms.Label();
            this.dontbedumbLabel = new System.Windows.Forms.Label();
            this.wrongInfoButton = new System.Windows.Forms.Button();
            this.rightInfoButton = new System.Windows.Forms.Button();
            this.setupPanel0 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.osInfoLabel = new System.Windows.Forms.Label();
            this.gameDirInfoLabel = new System.Windows.Forms.Label();
            this.gameVerInfoLabel = new System.Windows.Forms.Label();
            this.bgwGetNeededInfo = new System.ComponentModel.BackgroundWorker();
            this.setupPanel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bgwVerifyVanillaFiles = new System.ComponentModel.BackgroundWorker();
            this.setupPanel0.SuspendLayout();
            this.setupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameverLabel
            // 
            this.gameverLabel.AutoSize = true;
            this.gameverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameverLabel.Location = new System.Drawing.Point(112, 59);
            this.gameverLabel.Name = "gameverLabel";
            this.gameverLabel.Size = new System.Drawing.Size(84, 13);
            this.gameverLabel.TabIndex = 0;
            this.gameverLabel.Text = "Game version";
            // 
            // gameDirLabel
            // 
            this.gameDirLabel.AutoSize = true;
            this.gameDirLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameDirLabel.Location = new System.Drawing.Point(109, 121);
            this.gameDirLabel.Name = "gameDirLabel";
            this.gameDirLabel.Size = new System.Drawing.Size(92, 13);
            this.gameDirLabel.TabIndex = 1;
            this.gameDirLabel.Text = "Game directory";
            // 
            // osLabel
            // 
            this.osLabel.AutoSize = true;
            this.osLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.osLabel.Location = new System.Drawing.Point(103, 183);
            this.osLabel.Name = "osLabel";
            this.osLabel.Size = new System.Drawing.Size(106, 13);
            this.osLabel.TabIndex = 2;
            this.osLabel.Text = "Operating System";
            // 
            // dontbedumbLabel
            // 
            this.dontbedumbLabel.AutoSize = true;
            this.dontbedumbLabel.Location = new System.Drawing.Point(91, 262);
            this.dontbedumbLabel.Name = "dontbedumbLabel";
            this.dontbedumbLabel.Size = new System.Drawing.Size(130, 13);
            this.dontbedumbLabel.TabIndex = 3;
            this.dontbedumbLabel.Text = "Is this information correct?";
            // 
            // wrongInfoButton
            // 
            this.wrongInfoButton.Location = new System.Drawing.Point(12, 278);
            this.wrongInfoButton.Name = "wrongInfoButton";
            this.wrongInfoButton.Size = new System.Drawing.Size(75, 23);
            this.wrongInfoButton.TabIndex = 4;
            this.wrongInfoButton.Text = "No";
            this.wrongInfoButton.UseVisualStyleBackColor = true;
            // 
            // rightInfoButton
            // 
            this.rightInfoButton.Location = new System.Drawing.Point(225, 278);
            this.rightInfoButton.Name = "rightInfoButton";
            this.rightInfoButton.Size = new System.Drawing.Size(75, 23);
            this.rightInfoButton.TabIndex = 5;
            this.rightInfoButton.Text = "Yes";
            this.rightInfoButton.UseVisualStyleBackColor = true;
            this.rightInfoButton.Click += new System.EventHandler(this.rightInfoButton_Click);
            // 
            // setupPanel0
            // 
            this.setupPanel0.Controls.Add(this.label1);
            this.setupPanel0.Controls.Add(this.osInfoLabel);
            this.setupPanel0.Controls.Add(this.gameDirInfoLabel);
            this.setupPanel0.Controls.Add(this.gameVerInfoLabel);
            this.setupPanel0.Controls.Add(this.gameverLabel);
            this.setupPanel0.Controls.Add(this.rightInfoButton);
            this.setupPanel0.Controls.Add(this.gameDirLabel);
            this.setupPanel0.Controls.Add(this.wrongInfoButton);
            this.setupPanel0.Controls.Add(this.osLabel);
            this.setupPanel0.Controls.Add(this.dontbedumbLabel);
            this.setupPanel0.Location = new System.Drawing.Point(0, 0);
            this.setupPanel0.Name = "setupPanel0";
            this.setupPanel0.Size = new System.Drawing.Size(312, 313);
            this.setupPanel0.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.MaximumSize = new System.Drawing.Size(300, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "Hi! Before the game can be patched, we need to verify some info.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // osInfoLabel
            // 
            this.osInfoLabel.AutoSize = true;
            this.osInfoLabel.Location = new System.Drawing.Point(56, 208);
            this.osInfoLabel.MinimumSize = new System.Drawing.Size(200, 0);
            this.osInfoLabel.Name = "osInfoLabel";
            this.osInfoLabel.Size = new System.Drawing.Size(200, 13);
            this.osInfoLabel.TabIndex = 8;
            this.osInfoLabel.Text = "Please wait...";
            this.osInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameDirInfoLabel
            // 
            this.gameDirInfoLabel.AutoSize = true;
            this.gameDirInfoLabel.Location = new System.Drawing.Point(56, 150);
            this.gameDirInfoLabel.MinimumSize = new System.Drawing.Size(200, 0);
            this.gameDirInfoLabel.Name = "gameDirInfoLabel";
            this.gameDirInfoLabel.Size = new System.Drawing.Size(200, 13);
            this.gameDirInfoLabel.TabIndex = 7;
            this.gameDirInfoLabel.Text = "Please wait...";
            this.gameDirInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameVerInfoLabel
            // 
            this.gameVerInfoLabel.AutoSize = true;
            this.gameVerInfoLabel.Location = new System.Drawing.Point(56, 86);
            this.gameVerInfoLabel.MinimumSize = new System.Drawing.Size(200, 0);
            this.gameVerInfoLabel.Name = "gameVerInfoLabel";
            this.gameVerInfoLabel.Size = new System.Drawing.Size(200, 13);
            this.gameVerInfoLabel.TabIndex = 6;
            this.gameVerInfoLabel.Text = "Please wait...";
            this.gameVerInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bgwGetNeededInfo
            // 
            this.bgwGetNeededInfo.WorkerReportsProgress = true;
            this.bgwGetNeededInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGetNeededInfo_DoWork);
            this.bgwGetNeededInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwGetNeededInfo_RunWorkerCompleted);
            // 
            // setupPanel1
            // 
            this.setupPanel1.Controls.Add(this.progressBar1);
            this.setupPanel1.Controls.Add(this.label2);
            this.setupPanel1.Location = new System.Drawing.Point(318, 0);
            this.setupPanel1.Name = "setupPanel1";
            this.setupPanel1.Size = new System.Drawing.Size(312, 313);
            this.setupPanel1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 130);
            this.label2.MaximumSize = new System.Drawing.Size(300, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 52);
            this.label2.TabIndex = 0;
            this.label2.Text = "Great! Let\'s go ahead and verify you have a vanilla (unmodified) game installatio" +
    "n.\r\n\r\nThis may take a minute.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 290);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(306, 11);
            this.progressBar1.TabIndex = 1;
            // 
            // bgwVerifyVanillaFiles
            // 
            this.bgwVerifyVanillaFiles.WorkerReportsProgress = true;
            this.bgwVerifyVanillaFiles.WorkerSupportsCancellation = true;
            this.bgwVerifyVanillaFiles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwVerifyVanillaFiles_DoWork);
            // 
            // PatcherWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 530);
            this.Controls.Add(this.setupPanel1);
            this.Controls.Add(this.setupPanel0);
            this.Name = "PatcherWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Golden Ticket -Patching";
            this.Load += new System.EventHandler(this.PatcherWindow_Load);
            this.Shown += new System.EventHandler(this.PatcherWindow_Shown);
            this.setupPanel0.ResumeLayout(false);
            this.setupPanel0.PerformLayout();
            this.setupPanel1.ResumeLayout(false);
            this.setupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label gameverLabel;
        private System.Windows.Forms.Label gameDirLabel;
        private System.Windows.Forms.Label osLabel;
        private System.Windows.Forms.Label dontbedumbLabel;
        private System.Windows.Forms.Button wrongInfoButton;
        private System.Windows.Forms.Button rightInfoButton;
        private System.Windows.Forms.Panel setupPanel0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label osInfoLabel;
        private System.Windows.Forms.Label gameDirInfoLabel;
        private System.Windows.Forms.Label gameVerInfoLabel;
        private System.ComponentModel.BackgroundWorker bgwGetNeededInfo;
        private System.Windows.Forms.Panel setupPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker bgwVerifyVanillaFiles;
    }
}