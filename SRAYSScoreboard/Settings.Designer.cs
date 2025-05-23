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
            this.labelLaneNumbering = new System.Windows.Forms.Label();
            this.checkBoxZeroToNine = new System.Windows.Forms.CheckBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
            // buttonOK
            this.buttonOK.Location = new System.Drawing.Point(223, 289);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            
            // buttonCancel
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(304, 289);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            
            // tabControl
            this.tabControl.Controls.Add(this.tabPageConnection);
            this.tabControl.Controls.Add(this.tabPageColors);
            this.tabControl.Controls.Add(this.tabPagePoolConfig);
            this.tabControl.Controls.Add(this.tabPageScreenSaver);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(367, 271);
            this.tabControl.TabIndex = 2;
            
            // tabPageConnection
            this.tabPageConnection.Controls.Add(this.buttonRefreshPorts);
            this.tabPageConnection.Controls.Add(this.comboBoxCOMPort);
            this.tabPageConnection.Controls.Add(this.labelCOMPort);
            this.tabPageConnection.Location = new System.Drawing.Point(4, 22);
            this.tabPageConnection.Name = "tabPageConnection";
            this.tabPageConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConnection.Size = new System.Drawing.Size(359, 245);
            this.tabPageConnection.TabIndex = 0;
            this.tabPageConnection.Text = "Connection";
            this.tabPageConnection.UseVisualStyleBackColor = true;
            
            // tabPageColors
            this.tabPageColors.Controls.Add(this.buttonLaneLabelsColor);
            this.tabPageColors.Controls.Add(this.buttonPlaceLabelsColor);
            this.tabPageColors.Controls.Add(this.buttonTimeLabelsColor);
            this.tabPageColors.Controls.Add(this.buttonNameLabelsColor);
            this.tabPageColors.Controls.Add(this.buttonColumnHeadersColor);
            this.tabPageColors.Controls.Add(this.buttonHeaderLabelsColor);
            this.tabPageColors.Controls.Add(this.buttonTextColor);
            this.tabPageColors.Controls.Add(this.buttonBackgroundColor);
            this.tabPageColors.Controls.Add(this.buttonResetColors);
            this.tabPageColors.Controls.Add(this.labelLaneLabelsColor);
            this.tabPageColors.Controls.Add(this.labelPlaceLabelsColor);
            this.tabPageColors.Controls.Add(this.labelTimeLabelsColor);
            this.tabPageColors.Controls.Add(this.labelNameLabelsColor);
            this.tabPageColors.Controls.Add(this.labelColumnHeadersColor);
            this.tabPageColors.Controls.Add(this.labelHeaderLabelsColor);
            this.tabPageColors.Controls.Add(this.labelTextColor);
            this.tabPageColors.Controls.Add(this.labelBackgroundColor);
            this.tabPageColors.Location = new System.Drawing.Point(4, 22);
            this.tabPageColors.Name = "tabPageColors";
            this.tabPageColors.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageColors.Size = new System.Drawing.Size(359, 245);
            this.tabPageColors.TabIndex = 1;
            this.tabPageColors.Text = "Colors";
            this.tabPageColors.UseVisualStyleBackColor = true;
            
            // tabPagePoolConfig
            this.tabPagePoolConfig.Controls.Add(this.checkBoxZeroToNine);
            this.tabPagePoolConfig.Controls.Add(this.labelLaneNumbering);
            this.tabPagePoolConfig.Controls.Add(this.radioButton10Lanes);
            this.tabPagePoolConfig.Controls.Add(this.radioButton8Lanes);
            this.tabPagePoolConfig.Controls.Add(this.labelPoolLanes);
            this.tabPagePoolConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPagePoolConfig.Name = "tabPagePoolConfig";
            this.tabPagePoolConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePoolConfig.Size = new System.Drawing.Size(359, 245);
            this.tabPagePoolConfig.TabIndex = 2;
            this.tabPagePoolConfig.Text = "Pool Configuration";
            this.tabPagePoolConfig.UseVisualStyleBackColor = true;
            
            // buttonRefreshPorts
            this.buttonRefreshPorts.Location = new System.Drawing.Point(201, 39);
            this.buttonRefreshPorts.Name = "buttonRefreshPorts";
            this.buttonRefreshPorts.Size = new System.Drawing.Size(75, 23);
            this.buttonRefreshPorts.TabIndex = 2;
            this.buttonRefreshPorts.Text = "Refresh";
            this.buttonRefreshPorts.UseVisualStyleBackColor = true;
            this.buttonRefreshPorts.Click += new System.EventHandler(this.buttonRefreshPorts_Click);
            
            // comboBoxCOMPort
            this.comboBoxCOMPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCOMPort.FormattingEnabled = true;
            this.comboBoxCOMPort.Location = new System.Drawing.Point(74, 41);
            this.comboBoxCOMPort.Name = "comboBoxCOMPort";
            this.comboBoxCOMPort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCOMPort.TabIndex = 1;
            
            // labelCOMPort
            this.labelCOMPort.AutoSize = true;
            this.labelCOMPort.Location = new System.Drawing.Point(14, 44);
            this.labelCOMPort.Name = "labelCOMPort";
            this.labelCOMPort.Size = new System.Drawing.Size(54, 13);
            this.labelCOMPort.TabIndex = 0;
            this.labelCOMPort.Text = "COM Port:";
            
            // buttonResetColors
            this.buttonResetColors.Location = new System.Drawing.Point(282, 216);
            this.buttonResetColors.Name = "buttonResetColors";
            this.buttonResetColors.Size = new System.Drawing.Size(75, 23);
            this.buttonResetColors.TabIndex = 16;
            this.buttonResetColors.Text = "Reset All";
            this.buttonResetColors.UseVisualStyleBackColor = true;
            this.buttonResetColors.Click += new System.EventHandler(this.buttonResetColors_Click);
            
            // labelBackgroundColor
            this.labelBackgroundColor.AutoSize = true;
            this.labelBackgroundColor.Location = new System.Drawing.Point(14, 18);
            this.labelBackgroundColor.Name = "labelBackgroundColor";
            this.labelBackgroundColor.Size = new System.Drawing.Size(92, 13);
            this.labelBackgroundColor.TabIndex = 0;
            this.labelBackgroundColor.Text = "Background Color";
            
            // buttonBackgroundColor
            this.buttonBackgroundColor.Location = new System.Drawing.Point(201, 13);
            this.buttonBackgroundColor.Name = "buttonBackgroundColor";
            this.buttonBackgroundColor.Size = new System.Drawing.Size(75, 23);
            this.buttonBackgroundColor.TabIndex = 8;
            this.buttonBackgroundColor.Text = "Change...";
            this.buttonBackgroundColor.UseVisualStyleBackColor = true;
            this.buttonBackgroundColor.Click += new System.EventHandler(this.buttonBackgroundColor_Click);
            
            // labelTextColor
            this.labelTextColor.AutoSize = true;
            this.labelTextColor.Location = new System.Drawing.Point(14, 47);
            this.labelTextColor.Name = "labelTextColor";
            this.labelTextColor.Size = new System.Drawing.Size(55, 13);
            this.labelTextColor.TabIndex = 1;
            this.labelTextColor.Text = "Text Color";
            
            // buttonTextColor
            this.buttonTextColor.Location = new System.Drawing.Point(201, 42);
            this.buttonTextColor.Name = "buttonTextColor";
            this.buttonTextColor.Size = new System.Drawing.Size(75, 23);
            this.buttonTextColor.TabIndex = 9;
            this.buttonTextColor.Text = "Change...";
            this.buttonTextColor.UseVisualStyleBackColor = true;
            this.buttonTextColor.Click += new System.EventHandler(this.buttonTextColor_Click);
            
            // labelHeaderLabelsColor
            this.labelHeaderLabelsColor.AutoSize = true;
            this.labelHeaderLabelsColor.Location = new System.Drawing.Point(14, 76);
            this.labelHeaderLabelsColor.Name = "labelHeaderLabelsColor";
            this.labelHeaderLabelsColor.Size = new System.Drawing.Size(104, 13);
            this.labelHeaderLabelsColor.TabIndex = 2;
            this.labelHeaderLabelsColor.Text = "Header Labels Color";
            
            // buttonHeaderLabelsColor
            this.buttonHeaderLabelsColor.Location = new System.Drawing.Point(201, 71);
            this.buttonHeaderLabelsColor.Name = "buttonHeaderLabelsColor";
            this.buttonHeaderLabelsColor.Size = new System.Drawing.Size(75, 23);
            this.buttonHeaderLabelsColor.TabIndex = 10;
            this.buttonHeaderLabelsColor.Text = "Change...";
            this.buttonHeaderLabelsColor.UseVisualStyleBackColor = true;
            this.buttonHeaderLabelsColor.Click += new System.EventHandler(this.buttonHeaderLabelsColor_Click);
            
            // labelColumnHeadersColor
            this.labelColumnHeadersColor.AutoSize = true;
            this.labelColumnHeadersColor.Location = new System.Drawing.Point(14, 105);
            this.labelColumnHeadersColor.Name = "labelColumnHeadersColor";
            this.labelColumnHeadersColor.Size = new System.Drawing.Size(112, 13);
            this.labelColumnHeadersColor.TabIndex = 3;
            this.labelColumnHeadersColor.Text = "Column Headers Color";
            
            // buttonColumnHeadersColor
            this.buttonColumnHeadersColor.Location = new System.Drawing.Point(201, 100);
            this.buttonColumnHeadersColor.Name = "buttonColumnHeadersColor";
            this.buttonColumnHeadersColor.Size = new System.Drawing.Size(75, 23);
            this.buttonColumnHeadersColor.TabIndex = 11;
            this.buttonColumnHeadersColor.Text = "Change...";
            this.buttonColumnHeadersColor.UseVisualStyleBackColor = true;
            this.buttonColumnHeadersColor.Click += new System.EventHandler(this.buttonColumnHeadersColor_Click);
            
            // labelNameLabelsColor
            this.labelNameLabelsColor.AutoSize = true;
            this.labelNameLabelsColor.Location = new System.Drawing.Point(14, 134);
            this.labelNameLabelsColor.Name = "labelNameLabelsColor";
            this.labelNameLabelsColor.Size = new System.Drawing.Size(97, 13);
            this.labelNameLabelsColor.TabIndex = 4;
            this.labelNameLabelsColor.Text = "Name Labels Color";
            
            this.tabControl.SuspendLayout();
            this.tabPageConnection.SuspendLayout();
            this.tabPageColors.SuspendLayout();
            this.tabPagePoolConfig.SuspendLayout();
            this.SuspendLayout();
            
            // Form settings
            // Settings
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
            this.radioButton8Lanes.CheckedChanged += new System.EventHandler(this.radioButton8Lanes_CheckedChanged);
            
            this.radioButton10Lanes.AutoSize = true;
            this.radioButton10Lanes.Checked = true;
            this.radioButton10Lanes.Location = new System.Drawing.Point(146, 39);
            this.radioButton10Lanes.Name = "radioButton10Lanes";
            this.radioButton10Lanes.Size = new System.Drawing.Size(37, 17);
            this.radioButton10Lanes.TabIndex = 2;
            this.radioButton10Lanes.TabStop = true;
            this.radioButton10Lanes.Text = "10";
            this.radioButton10Lanes.UseVisualStyleBackColor = true;
            this.radioButton10Lanes.CheckedChanged += new System.EventHandler(this.radioButton10Lanes_CheckedChanged);
            
            // Lane numbering option
            this.labelLaneNumbering.AutoSize = true;
            this.labelLaneNumbering.Location = new System.Drawing.Point(14, 70);
            this.labelLaneNumbering.Name = "labelLaneNumbering";
            this.labelLaneNumbering.Size = new System.Drawing.Size(94, 13);
            this.labelLaneNumbering.TabIndex = 3;
            this.labelLaneNumbering.Text = "Lane Numbering:";
            
            this.checkBoxZeroToNine.AutoSize = true;
            this.checkBoxZeroToNine.Location = new System.Drawing.Point(109, 69);
            this.checkBoxZeroToNine.Name = "checkBoxZeroToNine";
            this.checkBoxZeroToNine.Size = new System.Drawing.Size(151, 17);
            this.checkBoxZeroToNine.TabIndex = 4;
            this.checkBoxZeroToNine.Text = "Use 0-9 instead of 1-10";
            this.checkBoxZeroToNine.UseVisualStyleBackColor = true;
            this.checkBoxZeroToNine.CheckedChanged += new System.EventHandler(this.checkBoxZeroToNine_CheckedChanged);
            
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
            
            // tabPageScreenSaver
            this.tabPageScreenSaver = new System.Windows.Forms.TabPage();
            this.tabPageScreenSaver.Controls.Add(this.groupBoxDisplayOptions);
            this.tabPageScreenSaver.Controls.Add(this.groupBoxActivation);
            this.tabPageScreenSaver.Controls.Add(this.groupBoxBehavior);
            this.tabPageScreenSaver.Controls.Add(this.textBoxScrollingMessage);
            this.tabPageScreenSaver.Controls.Add(this.labelScrollingMessage);
            this.tabPageScreenSaver.Controls.Add(this.buttonSelectLogo);
            this.tabPageScreenSaver.Controls.Add(this.labelLogoPath);
            this.tabPageScreenSaver.Controls.Add(this.textBoxLogoPath);
            this.tabPageScreenSaver.Location = new System.Drawing.Point(4, 22);
            this.tabPageScreenSaver.Name = "tabPageScreenSaver";
            this.tabPageScreenSaver.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScreenSaver.Size = new System.Drawing.Size(359, 245);
            this.tabPageScreenSaver.TabIndex = 3;
            this.tabPageScreenSaver.Text = "Screen Saver";
            this.tabPageScreenSaver.UseVisualStyleBackColor = true;
            
            // groupBoxDisplayOptions
            this.groupBoxDisplayOptions = new System.Windows.Forms.GroupBox();
            this.groupBoxDisplayOptions.Location = new System.Drawing.Point(14, 14);
            this.groupBoxDisplayOptions.Name = "groupBoxDisplayOptions";
            this.groupBoxDisplayOptions.Size = new System.Drawing.Size(330, 70);
            this.groupBoxDisplayOptions.TabIndex = 0;
            this.groupBoxDisplayOptions.Text = "Display Options";
            
            // radioButtonAsciiArt
            this.radioButtonAsciiArt = new System.Windows.Forms.RadioButton();
            this.radioButtonAsciiArt.AutoSize = true;
            this.radioButtonAsciiArt.Checked = true;
            this.radioButtonAsciiArt.Location = new System.Drawing.Point(15, 20);
            this.radioButtonAsciiArt.Name = "radioButtonAsciiArt";
            this.radioButtonAsciiArt.Size = new System.Drawing.Size(125, 17);
            this.radioButtonAsciiArt.TabIndex = 0;
            this.radioButtonAsciiArt.TabStop = true;
            this.radioButtonAsciiArt.Text = "Swimming ASCII Art";
            this.radioButtonAsciiArt.UseVisualStyleBackColor = true;
            this.radioButtonAsciiArt.CheckedChanged += new System.EventHandler(this.radioButtonScreenSaverOption_CheckedChanged);
            this.groupBoxDisplayOptions.Controls.Add(this.radioButtonAsciiArt);
            
            // radioButtonBlankScreen
            this.radioButtonBlankScreen = new System.Windows.Forms.RadioButton();
            this.radioButtonBlankScreen.AutoSize = true;
            this.radioButtonBlankScreen.Location = new System.Drawing.Point(15, 43);
            this.radioButtonBlankScreen.Name = "radioButtonBlankScreen";
            this.radioButtonBlankScreen.Size = new System.Drawing.Size(91, 17);
            this.radioButtonBlankScreen.TabIndex = 1;
            this.radioButtonBlankScreen.Text = "Blank Screen";
            this.radioButtonBlankScreen.UseVisualStyleBackColor = true;
            this.radioButtonBlankScreen.CheckedChanged += new System.EventHandler(this.radioButtonScreenSaverOption_CheckedChanged);
            this.groupBoxDisplayOptions.Controls.Add(this.radioButtonBlankScreen);
            
            // radioButtonLogo
            this.radioButtonLogo = new System.Windows.Forms.RadioButton();
            this.radioButtonLogo.AutoSize = true;
            this.radioButtonLogo.Location = new System.Drawing.Point(146, 20);
            this.radioButtonLogo.Name = "radioButtonLogo";
            this.radioButtonLogo.Size = new System.Drawing.Size(85, 17);
            this.radioButtonLogo.TabIndex = 2;
            this.radioButtonLogo.Text = "Display Logo";
            this.radioButtonLogo.UseVisualStyleBackColor = true;
            this.radioButtonLogo.CheckedChanged += new System.EventHandler(this.radioButtonScreenSaverOption_CheckedChanged);
            this.groupBoxDisplayOptions.Controls.Add(this.radioButtonLogo);
            
            // radioButtonScrollingMessage
            this.radioButtonScrollingMessage = new System.Windows.Forms.RadioButton();
            this.radioButtonScrollingMessage.AutoSize = true;
            this.radioButtonScrollingMessage.Location = new System.Drawing.Point(146, 43);
            this.radioButtonScrollingMessage.Name = "radioButtonScrollingMessage";
            this.radioButtonScrollingMessage.Size = new System.Drawing.Size(115, 17);
            this.radioButtonScrollingMessage.TabIndex = 3;
            this.radioButtonScrollingMessage.Text = "Scrolling Message";
            this.radioButtonScrollingMessage.UseVisualStyleBackColor = true;
            this.radioButtonScrollingMessage.CheckedChanged += new System.EventHandler(this.radioButtonScreenSaverOption_CheckedChanged);
            this.groupBoxDisplayOptions.Controls.Add(this.radioButtonScrollingMessage);
            
            // groupBoxActivation
            this.groupBoxActivation = new System.Windows.Forms.GroupBox();
            this.groupBoxActivation.Location = new System.Drawing.Point(14, 90);
            this.groupBoxActivation.Name = "groupBoxActivation";
            this.groupBoxActivation.Size = new System.Drawing.Size(330, 70);
            this.groupBoxActivation.TabIndex = 1;
            this.groupBoxActivation.Text = "Activation";
            
            // labelInactivityTimer
            this.labelInactivityTimer = new System.Windows.Forms.Label();
            this.labelInactivityTimer.AutoSize = true;
            this.labelInactivityTimer.Location = new System.Drawing.Point(15, 22);
            this.labelInactivityTimer.Name = "labelInactivityTimer";
            this.labelInactivityTimer.Size = new System.Drawing.Size(82, 13);
            this.labelInactivityTimer.TabIndex = 0;
            this.labelInactivityTimer.Text = "Activate after:";
            this.groupBoxActivation.Controls.Add(this.labelInactivityTimer);
            
            // numericUpDownInactivityMinutes
            this.numericUpDownInactivityMinutes = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownInactivityMinutes.Location = new System.Drawing.Point(103, 20);
            this.numericUpDownInactivityMinutes.Name = "numericUpDownInactivityMinutes";
            this.numericUpDownInactivityMinutes.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownInactivityMinutes.TabIndex = 1;
            this.numericUpDownInactivityMinutes.Value = new decimal(new int[] { 5, 0, 0, 0 });
            this.numericUpDownInactivityMinutes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDownInactivityMinutes.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            this.groupBoxActivation.Controls.Add(this.numericUpDownInactivityMinutes);
            
            // labelMinutes
            this.labelMinutes = new System.Windows.Forms.Label();
            this.labelMinutes.AutoSize = true;
            this.labelMinutes.Location = new System.Drawing.Point(159, 22);
            this.labelMinutes.Name = "labelMinutes";
            this.labelMinutes.Size = new System.Drawing.Size(43, 13);
            this.labelMinutes.TabIndex = 2;
            this.labelMinutes.Text = "minutes";
            this.groupBoxActivation.Controls.Add(this.labelMinutes);
            
            // checkBoxManualActivation
            this.checkBoxManualActivation = new System.Windows.Forms.CheckBox();
            this.checkBoxManualActivation.AutoSize = true;
            this.checkBoxManualActivation.Checked = true;
            this.checkBoxManualActivation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxManualActivation.Location = new System.Drawing.Point(15, 45);
            this.checkBoxManualActivation.Name = "checkBoxManualActivation";
            this.checkBoxManualActivation.Size = new System.Drawing.Size(187, 17);
            this.checkBoxManualActivation.TabIndex = 3;
            this.checkBoxManualActivation.Text = "Allow manual activation with F3";
            this.checkBoxManualActivation.UseVisualStyleBackColor = true;
            this.groupBoxActivation.Controls.Add(this.checkBoxManualActivation);
            
            // groupBoxBehavior
            this.groupBoxBehavior = new System.Windows.Forms.GroupBox();
            this.groupBoxBehavior.Location = new System.Drawing.Point(14, 166);
            this.groupBoxBehavior.Name = "groupBoxBehavior";
            this.groupBoxBehavior.Size = new System.Drawing.Size(330, 70);
            this.groupBoxBehavior.TabIndex = 2;
            this.groupBoxBehavior.Text = "Behavior";
            
            // buttonScreenSaverBackgroundColor
            this.buttonScreenSaverBackgroundColor = new System.Windows.Forms.Button();
            this.buttonScreenSaverBackgroundColor.Location = new System.Drawing.Point(269, 14);
            this.buttonScreenSaverBackgroundColor.Name = "buttonScreenSaverBackgroundColor";
            this.buttonScreenSaverBackgroundColor.Size = new System.Drawing.Size(75, 23);
            this.buttonScreenSaverBackgroundColor.TabIndex = 8;
            this.buttonScreenSaverBackgroundColor.Text = "BG Color...";
            this.buttonScreenSaverBackgroundColor.UseVisualStyleBackColor = true;
            this.buttonScreenSaverBackgroundColor.Click += new System.EventHandler(this.buttonScreenSaverBackgroundColor_Click);
            this.tabPageScreenSaver.Controls.Add(this.buttonScreenSaverBackgroundColor);
            
            // checkBoxExitOnData
            this.checkBoxExitOnData = new System.Windows.Forms.CheckBox();
            this.checkBoxExitOnData.AutoSize = true;
            this.checkBoxExitOnData.Checked = true;
            this.checkBoxExitOnData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExitOnData.Location = new System.Drawing.Point(15, 20);
            this.checkBoxExitOnData.Name = "checkBoxExitOnData";
            this.checkBoxExitOnData.Size = new System.Drawing.Size(223, 17);
            this.checkBoxExitOnData.TabIndex = 0;
            this.checkBoxExitOnData.Text = "Exit when data received from timing system";
            this.checkBoxExitOnData.UseVisualStyleBackColor = true;
            this.groupBoxBehavior.Controls.Add(this.checkBoxExitOnData);
            
            // checkBoxExitOnKeyPress
            this.checkBoxExitOnKeyPress = new System.Windows.Forms.CheckBox();
            this.checkBoxExitOnKeyPress.AutoSize = true;
            this.checkBoxExitOnKeyPress.Checked = true;
            this.checkBoxExitOnKeyPress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExitOnKeyPress.Location = new System.Drawing.Point(15, 43);
            this.checkBoxExitOnKeyPress.Name = "checkBoxExitOnKeyPress";
            this.checkBoxExitOnKeyPress.Size = new System.Drawing.Size(140, 17);
            this.checkBoxExitOnKeyPress.TabIndex = 1;
            this.checkBoxExitOnKeyPress.Text = "Exit on any key press";
            this.checkBoxExitOnKeyPress.UseVisualStyleBackColor = true;
            this.groupBoxBehavior.Controls.Add(this.checkBoxExitOnKeyPress);
            
            // Logo path controls
            this.labelLogoPath = new System.Windows.Forms.Label();
            this.labelLogoPath.AutoSize = true;
            this.labelLogoPath.Location = new System.Drawing.Point(14, 90);
            this.labelLogoPath.Name = "labelLogoPath";
            this.labelLogoPath.Size = new System.Drawing.Size(61, 13);
            this.labelLogoPath.TabIndex = 3;
            this.labelLogoPath.Text = "Logo Path:";
            this.labelLogoPath.Visible = false;
            
            this.textBoxLogoPath = new System.Windows.Forms.TextBox();
            this.textBoxLogoPath.Location = new System.Drawing.Point(81, 87);
            this.textBoxLogoPath.Name = "textBoxLogoPath";
            this.textBoxLogoPath.Size = new System.Drawing.Size(182, 20);
            this.textBoxLogoPath.TabIndex = 4;
            this.textBoxLogoPath.Visible = false;
            
            this.buttonSelectLogo = new System.Windows.Forms.Button();
            this.buttonSelectLogo.Location = new System.Drawing.Point(269, 85);
            this.buttonSelectLogo.Name = "buttonSelectLogo";
            this.buttonSelectLogo.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectLogo.TabIndex = 5;
            this.buttonSelectLogo.Text = "Browse...";
            this.buttonSelectLogo.UseVisualStyleBackColor = true;
            this.buttonSelectLogo.Visible = false;
            this.buttonSelectLogo.Click += new System.EventHandler(this.buttonSelectLogo_Click);
            
            // Scrolling message controls
            this.labelScrollingMessage = new System.Windows.Forms.Label();
            this.labelScrollingMessage.AutoSize = true;
            this.labelScrollingMessage.Location = new System.Drawing.Point(14, 116);
            this.labelScrollingMessage.Name = "labelScrollingMessage";
            this.labelScrollingMessage.Size = new System.Drawing.Size(53, 13);
            this.labelScrollingMessage.TabIndex = 6;
            this.labelScrollingMessage.Text = "Message:";
            this.labelScrollingMessage.Visible = false;
            
            this.textBoxScrollingMessage = new System.Windows.Forms.TextBox();
            this.textBoxScrollingMessage.Location = new System.Drawing.Point(81, 113);
            this.textBoxScrollingMessage.Name = "textBoxScrollingMessage";
            this.textBoxScrollingMessage.Size = new System.Drawing.Size(263, 20);
            this.textBoxScrollingMessage.TabIndex = 7;
            this.textBoxScrollingMessage.Text = "Welcome to Silver Rays Swim Club";
            this.textBoxScrollingMessage.Visible = false;

            this.tabControl.ResumeLayout(false);
            this.tabPageConnection.ResumeLayout(false);
            this.tabPageConnection.PerformLayout();
            this.tabPageColors.ResumeLayout(false);
            this.tabPageColors.PerformLayout();
            this.tabPagePoolConfig.ResumeLayout(false);
            this.tabPagePoolConfig.PerformLayout();
            this.tabPageScreenSaver.ResumeLayout(false);
            this.tabPageScreenSaver.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInactivityMinutes)).BeginInit();
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
        private System.Windows.Forms.CheckBox checkBoxZeroToNine;
        private System.Windows.Forms.Label labelLaneNumbering;
        private System.Windows.Forms.TabPage tabPageScreenSaver;
        private System.Windows.Forms.GroupBox groupBoxDisplayOptions;
        private System.Windows.Forms.RadioButton radioButtonAsciiArt;
        private System.Windows.Forms.RadioButton radioButtonBlankScreen;
        private System.Windows.Forms.RadioButton radioButtonLogo;
        private System.Windows.Forms.RadioButton radioButtonScrollingMessage;
        private System.Windows.Forms.GroupBox groupBoxActivation;
        private System.Windows.Forms.Label labelInactivityTimer;
        private System.Windows.Forms.NumericUpDown numericUpDownInactivityMinutes;
        private System.Windows.Forms.Label labelMinutes;
        private System.Windows.Forms.CheckBox checkBoxManualActivation;
        private System.Windows.Forms.GroupBox groupBoxBehavior;
        private System.Windows.Forms.CheckBox checkBoxExitOnData;
        private System.Windows.Forms.CheckBox checkBoxExitOnKeyPress;
        private System.Windows.Forms.TextBox textBoxScrollingMessage;
        private System.Windows.Forms.Label labelScrollingMessage;
        private System.Windows.Forms.Button buttonSelectLogo;
        private System.Windows.Forms.Label labelLogoPath;
        private System.Windows.Forms.TextBox textBoxLogoPath;
    }
}
