/*   This file is part of Golden Ticket.
*
*    Golden Ticket is free software: you can redistribute it and/or modify
*    it under the terms of the GNU General Public License as published by
*    the Free Software Foundation, either version 2 of the License, or
*    (at your option) any later version.
*
*    Golden Ticket is distributed in the hope that it will be useful,
*    but WITHOUT ANY WARRANTY; without even the implied warranty of
*    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
*    GNU General Public License for more details.
*
*    You should have received a copy of the GNU General Public License
*    along with Golden Ticket.  If not, see <https://www.gnu.org/licenses/>.
*/


﻿namespace Golden_Ticket.Windows
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
            this.patchingTitleLabel = new System.Windows.Forms.Label();
            this.patchesTable = new System.Windows.Forms.TableLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.patchesTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // PatchingProgressbar
            // 
            this.PatchingProgressbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PatchingProgressbar.Location = new System.Drawing.Point(9, 27);
            this.PatchingProgressbar.Name = "PatchingProgressbar";
            this.PatchingProgressbar.Size = new System.Drawing.Size(304, 14);
            this.PatchingProgressbar.TabIndex = 0;
            // 
            // patchingTitleLabel
            // 
            this.patchingTitleLabel.AutoSize = true;
            this.patchingTitleLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.patchingTitleLabel.Location = new System.Drawing.Point(9, 6);
            this.patchingTitleLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.patchingTitleLabel.Name = "patchingTitleLabel";
            this.patchingTitleLabel.Size = new System.Drawing.Size(74, 15);
            this.patchingTitleLabel.TabIndex = 3;
            this.patchingTitleLabel.Text = "Please wait...";
            // 
            // patchesTable
            // 
            this.patchesTable.AutoSize = true;
            this.patchesTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.patchesTable.ColumnCount = 1;
            this.patchesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.patchesTable.Controls.Add(this.patchingTitleLabel, 0, 0);
            this.patchesTable.Controls.Add(this.PatchingProgressbar, 0, 1);
            this.patchesTable.Controls.Add(this.cancelButton, 0, 2);
            this.patchesTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patchesTable.Location = new System.Drawing.Point(0, 0);
            this.patchesTable.Name = "patchesTable";
            this.patchesTable.Padding = new System.Windows.Forms.Padding(6);
            this.patchesTable.RowCount = 3;
            this.patchesTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.patchesTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.patchesTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.patchesTable.Size = new System.Drawing.Size(322, 119);
            this.patchesTable.TabIndex = 4;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Location = new System.Drawing.Point(238, 68);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // PatchingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(322, 119);
            this.ControlBox = false;
            this.Controls.Add(this.patchesTable);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatchingWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Installing patches...";
            this.Load += new System.EventHandler(this.DownloadingPatchWindow_Load);
            this.patchesTable.ResumeLayout(false);
            this.patchesTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar PatchingProgressbar;
        private System.Windows.Forms.Label patchingTitleLabel;
        private System.Windows.Forms.TableLayoutPanel patchesTable;
        private System.Windows.Forms.Button cancelButton;
    }
}