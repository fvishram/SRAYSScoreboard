﻿// Copyright (c) 2025 Faisal Vishram, Silver Rays Swim Club

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace SRAYSScoreboard
{
    partial class Settings
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageConnection = new System.Windows.Forms.TabPage();
            this.tabPageColors = new System.Windows.Forms.TabPage();
            this.tabPagePoolConfig = new System.Windows.Forms.TabPage();
            this.buttonRefreshPorts = new System.Windows.Forms.Button();
            this.comboBoxCOMPort = new System.Windows.Forms.ComboBox();
            this.labelCOMPort = new System.Windows.Forms.Label();
            this.buttonResetColors = new System.Windows.Forms.Button();
            this.labelBackgroundColor = new System.Windows.Forms.Label();
            this.buttonBackgroundColor = new System.Windows.Forms.Button();
            this.labelTextColor = new System.Windows.Forms.Label();
            this.buttonTextColor = new System.Windows.Forms.Button();
            this.labelHeaderLabelsColor = new System.Windows.Forms.Label();
            this.buttonHeaderLabelsColor = new System.Windows.Forms.Button();
            this.labelColumnHeadersColor = new System.Windows.Forms.Label();
            this.buttonColumnHeadersColor = new System.Windows.Forms.Button();
            this.labelNameLabelsColor = new System.Windows.Forms.Label();
            this.buttonNameLabelsColor = new System.Windows.Forms.Button();
            this.labelTimeLabelsColor = new System.Windows.Forms.Label();
            this.buttonTimeLabelsColor = new System.Windows.Forms.Button();
            this.labelPlaceLabelsColor = new System.Windows.Forms.Label();
            this.buttonPlaceLabelsColor = new System.Windows.Forms.Button();
            this.labelLaneLabelsColor = new System.Windows.Forms.Label();
            this.buttonLaneLabelsColor = new System.Windows.Forms.Button();
            this.labelPoolLanes = new System.Windows.Forms.Label();
            this.radioButton8Lanes = new System.Windows.Forms.RadioButton();
            this.radioButton10Lanes = new System.Windows.Forms.RadioButton();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tabControl.SuspendLayout();
            this.tabPageConnection.SuspendLayout();
            this.tabPageColors.SuspendLayout();
            this.tabPagePoolConfig.SuspendLayout();
            this.SuspendLayout();
            
            // Form settings
            this.AcceptButton = this.buttonOK;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(391, 324);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scoreboard Settings";
            
            // Pool configuration tab
            this.labelPoolLanes.AutoSize = true;
            this.labelPoolLanes.Location = new System.Drawing.Point(14, 41);
            this.labelPoolLanes.Name = "labelPoolLanes";
            this.labelPoolLanes.Size = new System.Drawing.Size(89, 13);
            this.labelPoolLanes.TabIndex = 0;
            this.labelPoolLanes.Text = "Number of Lanes:";
            
            this.radioButton8Lanes.AutoSize = true;
            this.radioButton8Lanes.Location = new System.Drawing.Point(109, 39);
            this.radioButton8Lanes.Name = "radioButton8Lanes";
            this.radioButton8Lanes.Size = new System.Drawing.Size(31, 17);
            this.radioButton8Lanes.TabIndex = 1;
            this.radioButton8Lanes.Text = "8";
            this.radioButton8Lanes.UseVisualStyleBackColor = true;
            
            this.radioButton10Lanes.AutoSize = true;
            this.radioButton10Lanes.Checked = true;
            this.radioButton10Lanes.Location = new System.Drawing.Point(146, 39);
            this.radioButton10Lanes.Name = "radioButton10Lanes";
            this.radioButton10Lanes.Size = new System.Drawing.Size(37, 17);
            this.radioButton10Lanes.TabIndex = 2;
            this.radioButton10Lanes.TabStop = true;
            this.radioButton10Lanes.Text = "10";
            this.radioButton10Lanes.UseVisualStyleBackColor = true;
            
            // Color labels
            this.labelTimeLabelsColor.AutoSize = true;
            this.labelTimeLabelsColor.Location = new System.Drawing.Point(14, 163);
            this.labelTimeLabelsColor.Name = "labelTimeLabelsColor";
            this.labelTimeLabelsColor.Size = new System.Drawing.Size(94, 13);
            this.labelTimeLabelsColor.TabIndex = 5;
            this.labelTimeLabelsColor.Text = "Time Labels Color";
            
            this.labelPlaceLabelsColor.AutoSize = true;
            this.labelPlaceLabelsColor.Location = new System.Drawing.Point(14, 192);
            this.labelPlaceLabelsColor.Name = "labelPlaceLabelsColor";
            this.labelPlaceLabelsColor.Size = new System.Drawing.Size(98, 13);
            this.labelPlaceLabelsColor.TabIndex = 6;
            this.labelPlaceLabelsColor.Text = "Place Labels Color";
            
            this.labelLaneLabelsColor.AutoSize = true;
            this.labelLaneLabelsColor.Location = new System.Drawing.Point(14, 221);
            this.labelLaneLabelsColor.Name = "labelLaneLabelsColor";
            this.labelLaneLabelsColor.Size = new System.Drawing.Size(95, 13);
            this.labelLaneLabelsColor.TabIndex = 7;
            this.labelLaneLabelsColor.Text = "Lane Labels Color";
            
            // Color buttons
            this.buttonNameLabelsColor.Location = new System.Drawing.Point(201, 129);
            this.buttonNameLabelsColor.Name = "buttonNameLabelsColor";
            this.buttonNameLabelsColor.Size = new System.Drawing.Size(75, 23);
            this.buttonNameLabelsColor.TabIndex = 12;
            this.buttonNameLabelsColor.Text = "Change...";
            this.buttonNameLabelsColor.UseVisualStyleBackColor = true;
            this.buttonNameLabelsColor.Click += new System.EventHandler(this.buttonNameLabelsColor_Click);
            
            this.buttonTimeLabelsColor.Location = new System.Drawing.Point(201, 158);
            this.buttonTimeLabelsColor.Name = "buttonTimeLabelsColor";
            this.buttonTimeLabelsColor.Size = new System.Drawing.Size(75, 23);
            this.buttonTimeLabelsColor.TabIndex = 13;
            this.buttonTimeLabelsColor.Text = "Change...";
            this.buttonTimeLabelsColor.UseVisualStyleBackColor = true;
            this.buttonTimeLabelsColor.Click += new System.EventHandler(this.buttonTimeLabelsColor_Click);
            
            this.buttonPlaceLabelsColor.Location = new System.Drawing.Point(201, 187);
            this.buttonPlaceLabelsColor.Name = "buttonPlaceLabelsColor";
            this.buttonPlaceLabelsColor.Size = new System.Drawing.Size(75, 23);
            this.buttonPlaceLabelsColor.TabIndex = 14;
            this.buttonPlaceLabelsColor.Text = "Change...";
            this.buttonPlaceLabelsColor.UseVisualStyleBackColor = true;
            this.buttonPlaceLabelsColor.Click += new System.EventHandler(this.buttonPlaceLabelsColor_Click);
            
            this.buttonLaneLabelsColor.Location = new System.Drawing.Point(201, 216);
            this.buttonLaneLabelsColor.Name = "buttonLaneLabelsColor";
            this.buttonLaneLabelsColor.Size = new System.Drawing.Size(75, 23);
            this.buttonLaneLabelsColor.TabIndex = 15;
            this.buttonLaneLabelsColor.Text = "Change...";
            this.buttonLaneLabelsColor.UseVisualStyleBackColor = true;
            this.buttonLaneLabelsColor.Click += new System.EventHandler(this.buttonLaneLabelsColor_Click);
            
            this.tabControl.ResumeLayout(false);
            this.tabPageConnection.ResumeLayout(false);
            this.tabPageConnection.PerformLayout();
            this.tabPageColors.ResumeLayout(false);
            this.tabPageColors.PerformLayout();
            this.tabPagePoolConfig.ResumeLayout(false);
            this.tabPagePoolConfig.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageConnection;
        private System.Windows.Forms.TabPage tabPageColors;
        private System.Windows.Forms.TabPage tabPagePoolConfig;
        private System.Windows.Forms.Button buttonRefreshPorts;
        private System.Windows.Forms.ComboBox comboBoxCOMPort;
        private System.Windows.Forms.Label labelCOMPort;
        private System.Windows.Forms.Button buttonResetColors;
        private System.Windows.Forms.Label labelBackgroundColor;
        private System.Windows.Forms.Button buttonBackgroundColor;
        private System.Windows.Forms.Label labelTextColor;
        private System.Windows.Forms.Button buttonTextColor;
        private System.Windows.Forms.Label labelHeaderLabelsColor;
        private System.Windows.Forms.Button buttonHeaderLabelsColor;
        private System.Windows.Forms.Label labelColumnHeadersColor;
        private System.Windows.Forms.Button buttonColumnHeadersColor;
        private System.Windows.Forms.Label labelNameLabelsColor;
        private System.Windows.Forms.Button buttonNameLabelsColor;
        private System.Windows.Forms.Label labelTimeLabelsColor;
        private System.Windows.Forms.Button buttonTimeLabelsColor;
        private System.Windows.Forms.Label labelPlaceLabelsColor;
        private System.Windows.Forms.Button buttonPlaceLabelsColor;
        private System.Windows.Forms.Label labelLaneLabelsColor;
        private System.Windows.Forms.Button buttonLaneLabelsColor;
        private System.Windows.Forms.Label labelPoolLanes;
        private System.Windows.Forms.RadioButton radioButton8Lanes;
        private System.Windows.Forms.RadioButton radioButton10Lanes;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}
