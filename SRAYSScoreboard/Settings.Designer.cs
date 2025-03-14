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
            this.labelCOMPort = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxCOMPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelCOMPort
            // 
            this.labelCOMPort.AutoSize = true;
            this.labelCOMPort.Location = new System.Drawing.Point(14, 38);
            this.labelCOMPort.Name = "labelCOMPort";
            this.labelCOMPort.Size = new System.Drawing.Size(53, 13);
            this.labelCOMPort.TabIndex = 0;
            this.labelCOMPort.Text = "COM Port";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(79, 289);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(88, 19);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxCOMPort
            // 
            this.textBoxCOMPort.Location = new System.Drawing.Point(90, 38);
            this.textBoxCOMPort.Name = "textBoxCOMPort";
            this.textBoxCOMPort.Size = new System.Drawing.Size(105, 20);
            this.textBoxCOMPort.TabIndex = 2;
            this.textBoxCOMPort.Text = "COM5";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 320);
            this.Controls.Add(this.textBoxCOMPort);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelCOMPort);
            this.Name = "Settings";
            this.Text = "Settings";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCOMPort;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxCOMPort;
    }
}
