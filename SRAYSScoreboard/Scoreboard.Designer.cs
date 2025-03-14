// Copyright (c) 2023 Faisal Vishram, Silver Rays Swim Club

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
    partial class Scoreboard
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
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.labelTime = new System.Windows.Forms.Label();
            this.labelEvent = new System.Windows.Forms.Label();
            this.contextMenuSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelTime1 = new System.Windows.Forms.Label();
            this.labelPlace1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelName1 = new System.Windows.Forms.Label();
            this.labelName2 = new System.Windows.Forms.Label();
            this.labelTime2 = new System.Windows.Forms.Label();
            this.labelPlace2 = new System.Windows.Forms.Label();
            this.labelName3 = new System.Windows.Forms.Label();
            this.labelTime3 = new System.Windows.Forms.Label();
            this.labelPlace3 = new System.Windows.Forms.Label();
            this.labelName4 = new System.Windows.Forms.Label();
            this.labelTime4 = new System.Windows.Forms.Label();
            this.labelPlace4 = new System.Windows.Forms.Label();
            this.labelName5 = new System.Windows.Forms.Label();
            this.labelTime5 = new System.Windows.Forms.Label();
            this.labelPlace5 = new System.Windows.Forms.Label();
            this.labelName6 = new System.Windows.Forms.Label();
            this.labelTime6 = new System.Windows.Forms.Label();
            this.labelPlace6 = new System.Windows.Forms.Label();
            this.labelName7 = new System.Windows.Forms.Label();
            this.labelTime7 = new System.Windows.Forms.Label();
            this.labelPlace7 = new System.Windows.Forms.Label();
            this.labelName8 = new System.Windows.Forms.Label();
            this.labelTime8 = new System.Windows.Forms.Label();
            this.labelPlace8 = new System.Windows.Forms.Label();
            this.labelName9 = new System.Windows.Forms.Label();
            this.labelTime9 = new System.Windows.Forms.Label();
            this.labelPlace9 = new System.Windows.Forms.Label();
            this.labelName10 = new System.Windows.Forms.Label();
            this.labelTime10 = new System.Windows.Forms.Label();
            this.labelPlace10 = new System.Windows.Forms.Label();
            this.contextMenuSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.PortName = "COM5";
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.Color.Black;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelTime.Location = new System.Drawing.Point(1714, 9);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(134, 55);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "Time";
            // 
            // labelEvent
            // 
            this.labelEvent.AutoSize = true;
            this.labelEvent.BackColor = System.Drawing.Color.Black;
            this.labelEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEvent.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelEvent.Location = new System.Drawing.Point(19, 9);
            this.labelEvent.Name = "labelEvent";
            this.labelEvent.Size = new System.Drawing.Size(152, 55);
            this.labelEvent.TabIndex = 1;
            this.labelEvent.Text = "Event";
            // 
            // contextMenuSettings
            // 
            this.contextMenuSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuSettings,
            this.toolStripMenuExit});
            this.contextMenuSettings.Name = "contextMenuSettings";
            this.contextMenuSettings.Size = new System.Drawing.Size(117, 48);
            // 
            // toolStripMenuSettings
            // 
            this.toolStripMenuSettings.Name = "toolStripMenuSettings";
            this.toolStripMenuSettings.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuSettings.Text = "Settings";
            this.toolStripMenuSettings.Click += new System.EventHandler(this.toolStripMenuSettings_Click);
            // 
            // toolStripMenuExit
            // 
            this.toolStripMenuExit.Name = "toolStripMenuExit";
            this.toolStripMenuExit.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuExit.Text = "Exit";
            this.toolStripMenuExit.Click += new System.EventHandler(this.toolStripMenuExit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.448695F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.63522F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.448695F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.467386F));
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelTime1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelPlace1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelName1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelName2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelTime2, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelPlace2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelName3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelTime3, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelPlace3, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelName4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelTime4, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelPlace4, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelName5, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelTime5, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelPlace5, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelName6, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelTime6, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelPlace6, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelName7, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelTime7, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelPlace7, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelName8, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelTime8, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelPlace8, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelName9, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.labelTime9, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.labelPlace9, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.labelName10, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.labelTime10, 3, 10);
            this.tableLayoutPanel1.Controls.Add(this.labelPlace10, 2, 10);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(19, 84);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1873, 945);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label14.Location = new System.Drawing.Point(3, 850);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 39);
            this.label14.TabIndex = 31;
            this.label14.Text = "10";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label13.Location = new System.Drawing.Point(3, 765);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 39);
            this.label13.TabIndex = 30;
            this.label13.Text = "9";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label12.Location = new System.Drawing.Point(3, 680);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 39);
            this.label12.TabIndex = 29;
            this.label12.Text = "8";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label11.Location = new System.Drawing.Point(3, 595);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 39);
            this.label11.TabIndex = 28;
            this.label11.Text = "7";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label10.Location = new System.Drawing.Point(3, 510);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 39);
            this.label10.TabIndex = 27;
            this.label10.Text = "6";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label9.Location = new System.Drawing.Point(3, 425);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 39);
            this.label9.TabIndex = 26;
            this.label9.Text = "5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label8.Location = new System.Drawing.Point(3, 340);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 39);
            this.label8.TabIndex = 25;
            this.label8.Text = "4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label7.Location = new System.Drawing.Point(3, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 39);
            this.label7.TabIndex = 24;
            this.label7.Text = "3";
            // 
            // labelTime1
            // 
            this.labelTime1.AutoSize = true;
            this.labelTime1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime1.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelTime1.Location = new System.Drawing.Point(1698, 85);
            this.labelTime1.Name = "labelTime1";
            this.labelTime1.Size = new System.Drawing.Size(119, 39);
            this.labelTime1.TabIndex = 19;
            this.labelTime1.Text = "Time1";
            // 
            // labelPlace1
            // 
            this.labelPlace1.AutoSize = true;
            this.labelPlace1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlace1.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelPlace1.Location = new System.Drawing.Point(1540, 85);
            this.labelPlace1.Name = "labelPlace1";
            this.labelPlace1.Size = new System.Drawing.Size(129, 39);
            this.labelPlace1.TabIndex = 18;
            this.labelPlace1.Text = "Place1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(1698, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 39);
            this.label4.TabIndex = 15;
            this.label4.Text = "Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(161, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 39);
            this.label2.TabIndex = 13;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 39);
            this.label1.TabIndex = 12;
            this.label1.Text = "Lane";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(1540, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 39);
            this.label3.TabIndex = 14;
            this.label3.Text = "Place";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label5.Location = new System.Drawing.Point(3, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 39);
            this.label5.TabIndex = 16;
            this.label5.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label6.Location = new System.Drawing.Point(3, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 39);
            this.label6.TabIndex = 20;
            this.label6.Text = "2";
            // 
            // labelName1
            // 
            this.labelName1.AutoSize = true;
            this.labelName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName1.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelName1.Location = new System.Drawing.Point(161, 85);
            this.labelName1.Name = "labelName1";
            this.labelName1.Size = new System.Drawing.Size(134, 39);
            this.labelName1.TabIndex = 17;
            this.labelName1.Text = "Name1";
            // 
            // labelName2
            // 
            this.labelName2.AutoSize = true;
            this.labelName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName2.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelName2.Location = new System.Drawing.Point(161, 170);
            this.labelName2.Name = "labelName2";
            this.labelName2.Size = new System.Drawing.Size(134, 39);
            this.labelName2.TabIndex = 21;
            this.labelName2.Text = "Name2";
            // 
            // labelTime2
            // 
            this.labelTime2.AutoSize = true;
            this.labelTime2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime2.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelTime2.Location = new System.Drawing.Point(1698, 170);
            this.labelTime2.Name = "labelTime2";
            this.labelTime2.Size = new System.Drawing.Size(119, 39);
            this.labelTime2.TabIndex = 23;
            this.labelTime2.Text = "Time2";
            // 
            // labelPlace2
            // 
            this.labelPlace2.AutoSize = true;
            this.labelPlace2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlace2.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelPlace2.Location = new System.Drawing.Point(1540, 170);
            this.labelPlace2.Name = "labelPlace2";
            this.labelPlace2.Size = new System.Drawing.Size(129, 39);
            this.labelPlace2.TabIndex = 22;
            this.labelPlace2.Text = "Place2";
            // 
            // labelName3
            // 
            this.labelName3.AutoSize = true;
            this.labelName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName3.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelName3.Location = new System.Drawing.Point(161, 255);
            this.labelName3.Name = "labelName3";
            this.labelName3.Size = new System.Drawing.Size(134, 39);
            this.labelName3.TabIndex = 21;
            this.labelName3.Text = "Name3";
            // 
            // labelTime3
            // 
            this.labelTime3.AutoSize = true;
            this.labelTime3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime3.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelTime3.Location = new System.Drawing.Point(1698, 255);
            this.labelTime3.Name = "labelTime3";
            this.labelTime3.Size = new System.Drawing.Size(119, 39);
            this.labelTime3.TabIndex = 23;
            this.labelTime3.Text = "Time3";
            // 
            // labelPlace3
            // 
            this.labelPlace3.AutoSize = true;
            this.labelPlace3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlace3.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelPlace3.Location = new System.Drawing.Point(1540, 255);
            this.labelPlace3.Name = "labelPlace3";
            this.labelPlace3.Size = new System.Drawing.Size(129, 39);
            this.labelPlace3.TabIndex = 22;
            this.labelPlace3.Text = "Place3";
            // 
            // labelName4
            // 
            this.labelName4.AutoSize = true;
            this.labelName4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName4.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelName4.Location = new System.Drawing.Point(161, 340);
            this.labelName4.Name = "labelName4";
            this.labelName4.Size = new System.Drawing.Size(134, 39);
            this.labelName4.TabIndex = 21;
            this.labelName4.Text = "Name4";
            // 
            // labelTime4
            // 
            this.labelTime4.AutoSize = true;
            this.labelTime4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime4.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelTime4.Location = new System.Drawing.Point(1698, 340);
            this.labelTime4.Name = "labelTime4";
            this.labelTime4.Size = new System.Drawing.Size(119, 39);
            this.labelTime4.TabIndex = 23;
            this.labelTime4.Text = "Time4";
            // 
            // labelPlace4
            // 
            this.labelPlace4.AutoSize = true;
            this.labelPlace4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlace4.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelPlace4.Location = new System.Drawing.Point(1540, 340);
            this.labelPlace4.Name = "labelPlace4";
            this.labelPlace4.Size = new System.Drawing.Size(129, 39);
            this.labelPlace4.TabIndex = 22;
            this.labelPlace4.Text = "Place4";
            // 
            // labelName5
            // 
            this.labelName5.AutoSize = true;
            this.labelName5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName5.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelName5.Location = new System.Drawing.Point(161, 425);
            this.labelName5.Name = "labelName5";
            this.labelName5.Size = new System.Drawing.Size(134, 39);
            this.labelName5.TabIndex = 21;
            this.labelName5.Text = "Name5";
            // 
            // labelTime5
            // 
            this.labelTime5.AutoSize = true;
            this.labelTime5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime5.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelTime5.Location = new System.Drawing.Point(1698, 425);
            this.labelTime5.Name = "labelTime5";
            this.labelTime5.Size = new System.Drawing.Size(119, 39);
            this.labelTime5.TabIndex = 23;
            this.labelTime5.Text = "Time5";
            // 
            // labelPlace5
            // 
            this.labelPlace5.AutoSize = true;
            this.labelPlace5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlace5.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelPlace5.Location = new System.Drawing.Point(1540, 425);
            this.labelPlace5.Name = "labelPlace5";
            this.labelPlace5.Size = new System.Drawing.Size(129, 39);
            this.labelPlace5.TabIndex = 22;
            this.labelPlace5.Text = "Place5";
            // 
            // labelName6
            // 
            this.labelName6.AutoSize = true;
            this.labelName6.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName6.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelName6.Location = new System.Drawing.Point(161, 510);
            this.labelName6.Name = "labelName6";
            this.labelName6.Size = new System.Drawing.Size(134, 39);
            this.labelName6.TabIndex = 21;
            this.labelName6.Text = "Name6";
            // 
            // labelTime6
            // 
            this.labelTime6.AutoSize = true;
            this.labelTime6.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime6.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelTime6.Location = new System.Drawing.Point(1698, 510);
            this.labelTime6.Name = "labelTime6";
            this.labelTime6.Size = new System.Drawing.Size(119, 39);
            this.labelTime6.TabIndex = 23;
            this.labelTime6.Text = "Time6";
            // 
            // labelPlace6
            // 
            this.labelPlace6.AutoSize = true;
            this.labelPlace6.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlace6.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelPlace6.Location = new System.Drawing.Point(1540, 510);
            this.labelPlace6.Name = "labelPlace6";
            this.labelPlace6.Size = new System.Drawing.Size(129, 39);
            this.labelPlace6.TabIndex = 22;
            this.labelPlace6.Text = "Place6";
            // 
            // labelName7
            // 
            this.labelName7.AutoSize = true;
            this.labelName7.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName7.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelName7.Location = new System.Drawing.Point(161, 595);
            this.labelName7.Name = "labelName7";
            this.labelName7.Size = new System.Drawing.Size(134, 39);
            this.labelName7.TabIndex = 21;
            this.labelName7.Text = "Name7";
            // 
            // labelTime7
            // 
            this.labelTime7.AutoSize = true;
            this.labelTime7.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime7.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelTime7.Location = new System.Drawing.Point(1698, 595);
            this.labelTime7.Name = "labelTime7";
            this.labelTime7.Size = new System.Drawing.Size(119, 39);
            this.labelTime7.TabIndex = 23;
            this.labelTime7.Text = "Time7";
            // 
            // labelPlace7
            // 
            this.labelPlace7.AutoSize = true;
            this.labelPlace7.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlace7.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelPlace7.Location = new System.Drawing.Point(1540, 595);
            this.labelPlace7.Name = "labelPlace7";
            this.labelPlace7.Size = new System.Drawing.Size(129, 39);
            this.labelPlace7.TabIndex = 22;
            this.labelPlace7.Text = "Place7";
            // 
            // labelName8
            // 
            this.labelName8.AutoSize = true;
            this.labelName8.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName8.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelName8.Location = new System.Drawing.Point(161, 680);
            this.labelName8.Name = "labelName8";
            this.labelName8.Size = new System.Drawing.Size(134, 39);
            this.labelName8.TabIndex = 21;
            this.labelName8.Text = "Name8";
            // 
            // labelTime8
            // 
            this.labelTime8.AutoSize = true;
            this.labelTime8.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime8.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelTime8.Location = new System.Drawing.Point(1698, 680);
            this.labelTime8.Name = "labelTime8";
            this.labelTime8.Size = new System.Drawing.Size(119, 39);
            this.labelTime8.TabIndex = 23;
            this.labelTime8.Text = "Time8";
            // 
            // labelPlace8
            // 
            this.labelPlace8.AutoSize = true;
            this.labelPlace8.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlace8.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelPlace8.Location = new System.Drawing.Point(1540, 680);
            this.labelPlace8.Name = "labelPlace8";
            this.labelPlace8.Size = new System.Drawing.Size(129, 39);
            this.labelPlace8.TabIndex = 22;
            this.labelPlace8.Text = "Place8";
            // 
            // labelName9
            // 
            this.labelName9.AutoSize = true;
            this.labelName9.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName9.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelName9.Location = new System.Drawing.Point(161, 765);
            this.labelName9.Name = "labelName9";
            this.labelName9.Size = new System.Drawing.Size(134, 39);
            this.labelName9.TabIndex = 21;
            this.labelName9.Text = "Name9";
            // 
            // labelTime9
            // 
            this.labelTime9.AutoSize = true;
            this.labelTime9.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime9.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelTime9.Location = new System.Drawing.Point(1698, 765);
            this.labelTime9.Name = "labelTime9";
            this.labelTime9.Size = new System.Drawing.Size(119, 39);
            this.labelTime9.TabIndex = 23;
            this.labelTime9.Text = "Time9";
            // 
            // labelPlace9
            // 
            this.labelPlace9.AutoSize = true;
            this.labelPlace9.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlace9.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelPlace9.Location = new System.Drawing.Point(1540, 765);
            this.labelPlace9.Name = "labelPlace9";
            this.labelPlace9.Size = new System.Drawing.Size(129, 39);
            this.labelPlace9.TabIndex = 22;
            this.labelPlace9.Text = "Place9";
            // 
            // labelName10
            // 
            this.labelName10.AutoSize = true;
            this.labelName10.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName10.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelName10.Location = new System.Drawing.Point(161, 850);
            this.labelName10.Name = "labelName10";
            this.labelName10.Size = new System.Drawing.Size(154, 39);
            this.labelName10.TabIndex = 21;
            this.labelName10.Text = "Name10";
            // 
            // labelTime10
            // 
            this.labelTime10.AutoSize = true;
            this.labelTime10.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime10.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelTime10.Location = new System.Drawing.Point(1698, 850);
            this.labelTime10.Name = "labelTime10";
            this.labelTime10.Size = new System.Drawing.Size(139, 39);
            this.labelTime10.TabIndex = 23;
            this.labelTime10.Text = "Time10";
            // 
            // labelPlace10
            // 
            this.labelPlace10.AutoSize = true;
            this.labelPlace10.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlace10.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.labelPlace10.Location = new System.Drawing.Point(1540, 850);
            this.labelPlace10.Name = "labelPlace10";
            this.labelPlace10.Size = new System.Drawing.Size(149, 39);
            this.labelPlace10.TabIndex = 22;
            this.labelPlace10.Text = "Place10";
            // 
            // Scoreboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ContextMenuStrip = this.contextMenuSettings;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.labelEvent);
            this.Controls.Add(this.labelTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Scoreboard";
            this.ShowIcon = false;
            this.Text = "SRAYS Scoreboard";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Scoreboard_FormClosed);
            this.Load += new System.EventHandler(this.Scoreboard_Load);
            this.contextMenuSettings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelEvent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelTime1;
        private System.Windows.Forms.Label labelPlace1;
        private System.Windows.Forms.Label labelName1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelName2;
        private System.Windows.Forms.Label labelPlace2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelTime2;
        private System.Windows.Forms.Label labelTime3;
        private System.Windows.Forms.Label labelPlace3;
        private System.Windows.Forms.Label labelName3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelTime4;
        private System.Windows.Forms.Label labelPlace4;
        private System.Windows.Forms.Label labelName4;
        private System.Windows.Forms.Label labelTime5;
        private System.Windows.Forms.Label labelPlace5;
        private System.Windows.Forms.Label labelName5;
        private System.Windows.Forms.Label labelTime6;
        private System.Windows.Forms.Label labelPlace6;
        private System.Windows.Forms.Label labelName6;
        private System.Windows.Forms.Label labelTime7;
        private System.Windows.Forms.Label labelPlace7;
        private System.Windows.Forms.Label labelName7;
        private System.Windows.Forms.Label labelTime8;
        private System.Windows.Forms.Label labelPlace8;
        private System.Windows.Forms.Label labelName8;
        private System.Windows.Forms.Label labelTime9;
        private System.Windows.Forms.Label labelPlace9;
        private System.Windows.Forms.Label labelName9;
        private System.Windows.Forms.Label labelTime10;
        private System.Windows.Forms.Label labelPlace10;
        private System.Windows.Forms.Label labelName10;
        private System.Windows.Forms.ContextMenuStrip contextMenuSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuExit;
    }
}
