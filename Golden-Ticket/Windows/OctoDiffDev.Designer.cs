namespace Golden_Ticket
{
    partial class OctoDiffDev
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.inputpathBox = new System.Windows.Forms.TextBox();
            this.outputpathBox = new System.Windows.Forms.TextBox();
            this.goawayLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.diffConsole = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(358, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Diff it";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inputpathBox
            // 
            this.inputpathBox.Location = new System.Drawing.Point(12, 95);
            this.inputpathBox.Name = "inputpathBox";
            this.inputpathBox.Size = new System.Drawing.Size(776, 20);
            this.inputpathBox.TabIndex = 1;
            // 
            // outputpathBox
            // 
            this.outputpathBox.Location = new System.Drawing.Point(12, 254);
            this.outputpathBox.Name = "outputpathBox";
            this.outputpathBox.Size = new System.Drawing.Size(776, 20);
            this.outputpathBox.TabIndex = 2;
            // 
            // goawayLabel
            // 
            this.goawayLabel.AutoSize = true;
            this.goawayLabel.ForeColor = System.Drawing.Color.Red;
            this.goawayLabel.Location = new System.Drawing.Point(285, 36);
            this.goawayLabel.Name = "goawayLabel";
            this.goawayLabel.Size = new System.Drawing.Size(231, 13);
            this.goawayLabel.TabIndex = 3;
            this.goawayLabel.Text = "IF YOU ARE NOT A DEVELOPER, GO AWAY!";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input directory (DOES NOT GO INTO SUBDIRECTORIES)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Signature output dir (NO BACKSPACE AT END)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "(NO BACKSPACE AT END)";
            // 
            // diffConsole
            // 
            this.diffConsole.Location = new System.Drawing.Point(12, 309);
            this.diffConsole.Multiline = true;
            this.diffConsole.Name = "diffConsole";
            this.diffConsole.ReadOnly = true;
            this.diffConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.diffConsole.Size = new System.Drawing.Size(776, 129);
            this.diffConsole.TabIndex = 7;
            // 
            // OctoDiffDev
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.diffConsole);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.goawayLabel);
            this.Controls.Add(this.outputpathBox);
            this.Controls.Add(this.inputpathBox);
            this.Controls.Add(this.button1);
            this.Name = "OctoDiffDev";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox inputpathBox;
        private System.Windows.Forms.TextBox outputpathBox;
        private System.Windows.Forms.Label goawayLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox diffConsole;
    }
}

