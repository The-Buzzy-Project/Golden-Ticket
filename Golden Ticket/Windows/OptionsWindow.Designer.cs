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
            this.gameLocationLabelLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gameDirButton = new System.Windows.Forms.Button();
            this.gameLocationTextBox = new System.Windows.Forms.TextBox();
            this.AutoUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.sysInfoBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.osLabel = new System.Windows.Forms.Label();
            this.specsExportButton = new System.Windows.Forms.Button();
            this.archLabel = new System.Windows.Forms.Label();
            this.cpuLabel = new System.Windows.Forms.Label();
            this.ramLabel = new System.Windows.Forms.Label();
            this.gpuLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.aboutBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.creditsLabel = new System.Windows.Forms.Label();
            this.launcherVersionLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.sysInfoBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.aboutBox.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameLocationLabelLabel
            // 
            this.gameLocationLabelLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gameLocationLabelLabel.AutoSize = true;
            this.gameLocationLabelLabel.Location = new System.Drawing.Point(6, 13);
            this.gameLocationLabelLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.gameLocationLabelLabel.Name = "gameLocationLabelLabel";
            this.gameLocationLabelLabel.Size = new System.Drawing.Size(179, 32);
            this.gameLocationLabelLabel.TabIndex = 1;
            this.gameLocationLabelLabel.Text = "Game Location:";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(754, 151);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game/Launcher Info";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.gameLocationLabelLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gameDirButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.gameLocationTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.AutoUpdateCheckBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 38);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(742, 107);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // gameDirButton
            // 
            this.gameDirButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gameDirButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gameDirButton.ForeColor = System.Drawing.Color.White;
            this.gameDirButton.Location = new System.Drawing.Point(586, 6);
            this.gameDirButton.Margin = new System.Windows.Forms.Padding(6);
            this.gameDirButton.Name = "gameDirButton";
            this.gameDirButton.Size = new System.Drawing.Size(150, 46);
            this.gameDirButton.TabIndex = 2;
            this.gameDirButton.Text = "&Browse...";
            this.gameDirButton.Click += new System.EventHandler(this.gameDirButton_Click);
            // 
            // gameLocationTextBox
            // 
            this.gameLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gameLocationTextBox.Location = new System.Drawing.Point(197, 9);
            this.gameLocationTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.gameLocationTextBox.Name = "gameLocationTextBox";
            this.gameLocationTextBox.Size = new System.Drawing.Size(377, 39);
            this.gameLocationTextBox.TabIndex = 3;
            // 
            // AutoUpdateCheckBox
            // 
            this.AutoUpdateCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AutoUpdateCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.AutoUpdateCheckBox, 3);
            this.AutoUpdateCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AutoUpdateCheckBox.Location = new System.Drawing.Point(6, 64);
            this.AutoUpdateCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.AutoUpdateCheckBox.Name = "AutoUpdateCheckBox";
            this.AutoUpdateCheckBox.Size = new System.Drawing.Size(322, 37);
            this.AutoUpdateCheckBox.TabIndex = 4;
            this.AutoUpdateCheckBox.Text = "Check for updates on start";
            this.AutoUpdateCheckBox.UseVisualStyleBackColor = true;
            // 
            // sysInfoBox
            // 
            this.sysInfoBox.Controls.Add(this.tableLayoutPanel2);
            this.sysInfoBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.sysInfoBox.Location = new System.Drawing.Point(6, 6);
            this.sysInfoBox.Margin = new System.Windows.Forms.Padding(6);
            this.sysInfoBox.Name = "sysInfoBox";
            this.sysInfoBox.Padding = new System.Windows.Forms.Padding(6);
            this.sysInfoBox.Size = new System.Drawing.Size(754, 368);
            this.sysInfoBox.TabIndex = 9;
            this.sysInfoBox.TabStop = false;
            this.sysInfoBox.Text = "System Info";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.osLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.specsExportButton, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.archLabel, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.cpuLabel, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.ramLabel, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.gpuLabel, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 38);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(742, 298);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // osLabel
            // 
            this.osLabel.AutoSize = true;
            this.osLabel.Location = new System.Drawing.Point(181, 6);
            this.osLabel.Margin = new System.Windows.Forms.Padding(6);
            this.osLabel.Name = "osLabel";
            this.osLabel.Size = new System.Drawing.Size(115, 32);
            this.osLabel.TabIndex = 0;
            this.osLabel.Text = "Loading...";
            // 
            // specsExportButton
            // 
            this.specsExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.specsExportButton, 2);
            this.specsExportButton.Enabled = false;
            this.specsExportButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.specsExportButton.Location = new System.Drawing.Point(0, 236);
            this.specsExportButton.Margin = new System.Windows.Forms.Padding(0, 16, 0, 16);
            this.specsExportButton.Name = "specsExportButton";
            this.specsExportButton.Size = new System.Drawing.Size(742, 46);
            this.specsExportButton.TabIndex = 5;
            this.specsExportButton.Text = "&Export to .txt file";
            this.specsExportButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // archLabel
            // 
            this.archLabel.AutoSize = true;
            this.archLabel.Location = new System.Drawing.Point(181, 50);
            this.archLabel.Margin = new System.Windows.Forms.Padding(6);
            this.archLabel.Name = "archLabel";
            this.archLabel.Size = new System.Drawing.Size(115, 32);
            this.archLabel.TabIndex = 1;
            this.archLabel.Text = "Loading...";
            // 
            // cpuLabel
            // 
            this.cpuLabel.AutoEllipsis = true;
            this.cpuLabel.AutoSize = true;
            this.cpuLabel.Location = new System.Drawing.Point(181, 94);
            this.cpuLabel.Margin = new System.Windows.Forms.Padding(6);
            this.cpuLabel.Name = "cpuLabel";
            this.cpuLabel.Size = new System.Drawing.Size(115, 32);
            this.cpuLabel.TabIndex = 2;
            this.cpuLabel.Text = "Loading...";
            // 
            // ramLabel
            // 
            this.ramLabel.AutoSize = true;
            this.ramLabel.Location = new System.Drawing.Point(181, 182);
            this.ramLabel.Margin = new System.Windows.Forms.Padding(6);
            this.ramLabel.Name = "ramLabel";
            this.ramLabel.Size = new System.Drawing.Size(115, 32);
            this.ramLabel.TabIndex = 4;
            this.ramLabel.Text = "Loading...";
            // 
            // gpuLabel
            // 
            this.gpuLabel.AutoEllipsis = true;
            this.gpuLabel.AutoSize = true;
            this.gpuLabel.Location = new System.Drawing.Point(181, 138);
            this.gpuLabel.Margin = new System.Windows.Forms.Padding(6);
            this.gpuLabel.Name = "gpuLabel";
            this.gpuLabel.Size = new System.Drawing.Size(115, 32);
            this.gpuLabel.TabIndex = 3;
            this.gpuLabel.Text = "Loading...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 6, 20, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "OS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 6, 20, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Architecture:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 6, 20, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "CPU:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 6, 20, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 32);
            this.label4.TabIndex = 5;
            this.label4.Text = "GPU:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 182);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 6, 20, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 32);
            this.label5.TabIndex = 5;
            this.label5.Text = "RAM:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 720);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(8, 46);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage1.Size = new System.Drawing.Size(766, 666);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Launcher";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.aboutBox);
            this.tabPage2.Controls.Add(this.launcherVersionLabel);
            this.tabPage2.Controls.Add(this.sysInfoBox);
            this.tabPage2.Location = new System.Drawing.Point(8, 46);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage2.Size = new System.Drawing.Size(766, 666);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "About";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // aboutBox
            // 
            this.aboutBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.aboutBox.Controls.Add(this.tableLayoutPanel5);
            this.aboutBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.aboutBox.Location = new System.Drawing.Point(6, 374);
            this.aboutBox.Margin = new System.Windows.Forms.Padding(6);
            this.aboutBox.Name = "aboutBox";
            this.aboutBox.Padding = new System.Windows.Forms.Padding(6);
            this.aboutBox.Size = new System.Drawing.Size(754, 215);
            this.aboutBox.TabIndex = 11;
            this.aboutBox.TabStop = false;
            this.aboutBox.Text = "About";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.nameLabel, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.descriptionLabel, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.creditsLabel, 0, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(6, 38);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(742, 171);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(6, 6);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(6);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(79, 32);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(6, 50);
            this.descriptionLabel.Margin = new System.Windows.Forms.Padding(6);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(136, 32);
            this.descriptionLabel.TabIndex = 1;
            this.descriptionLabel.Text = "Description";
            // 
            // creditsLabel
            // 
            this.creditsLabel.AutoSize = true;
            this.creditsLabel.Location = new System.Drawing.Point(6, 94);
            this.creditsLabel.Margin = new System.Windows.Forms.Padding(6);
            this.creditsLabel.Name = "creditsLabel";
            this.creditsLabel.Size = new System.Drawing.Size(642, 64);
            this.creditsLabel.TabIndex = 2;
            this.creditsLabel.Text = "Developed by Ryan \"geekywalrus\" Woodcock - rejiggered, tweaked and poked by \"Slay" +
    "33D\".";
            // 
            // launcherVersionLabel
            // 
            this.launcherVersionLabel.AutoSize = true;
            this.launcherVersionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.launcherVersionLabel.Location = new System.Drawing.Point(6, 628);
            this.launcherVersionLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.launcherVersionLabel.Name = "launcherVersionLabel";
            this.launcherVersionLabel.Size = new System.Drawing.Size(104, 32);
            this.launcherVersionLabel.TabIndex = 10;
            this.launcherVersionLabel.Text = "Ver. x.x.x";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnOK, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(470, 744);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(12, 0, 12, 12);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(324, 58);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(6, 6);
            this.btnOK.Margin = new System.Windows.Forms.Padding(6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(150, 46);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(168, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 46);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(806, 814);
            this.tableLayoutPanel4.TabIndex = 12;
            // 
            // OptionsWindow
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(806, 814);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.sysInfoBox.ResumeLayout(false);
            this.sysInfoBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.aboutBox.ResumeLayout(false);
            this.aboutBox.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label gameLocationLabelLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button gameDirButton;
        private System.Windows.Forms.GroupBox sysInfoBox;
        private System.Windows.Forms.Label osLabel;
        private System.Windows.Forms.Label archLabel;
        private System.Windows.Forms.Label cpuLabel;
        private System.Windows.Forms.Label gpuLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label ramLabel;
        private System.Windows.Forms.Button specsExportButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label launcherVersionLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox gameLocationTextBox;
        private System.Windows.Forms.CheckBox AutoUpdateCheckBox;
        private System.Windows.Forms.GroupBox aboutBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label creditsLabel;
    }
}