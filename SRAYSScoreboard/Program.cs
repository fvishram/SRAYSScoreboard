﻿﻿﻿// Copyright (c) 2025 Faisal Vishram, Silver Rays Swim Club

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRAYSScoreboard
{
    /// <summary>
    /// The main program class that serves as the entry point for the application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// This method initializes the Windows Forms application and runs the main Scoreboard form.
        /// It also creates a secondary OBS scoreboard window for streaming.
        /// </summary>
        /// <remarks>
        /// The STAThread attribute indicates that the COM threading model for the application is single-threaded apartment.
        /// This is required for Windows Forms applications.
        /// </remarks>
        [STAThread]
        static void Main()
        {
            // Enable visual styles for the application (modern Windows look and feel)
            Application.EnableVisualStyles();
            
            // Set the default text rendering to be compatible with GDI+
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Create the settings form first
            Settings settingsForm = new Settings();
            settingsForm.StartPosition = FormStartPosition.CenterScreen;
            settingsForm.Text = "SRAYS Scoreboard - Select COM Port for Timing System";
            
            // Create a form to host the COM port selection dialog
            using (Form portSelectionForm = new Form())
            {
                portSelectionForm.Text = "Select COM Port";
                portSelectionForm.StartPosition = FormStartPosition.CenterScreen;
                portSelectionForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                portSelectionForm.MaximizeBox = false;
                portSelectionForm.MinimizeBox = false;
                portSelectionForm.Size = new System.Drawing.Size(400, 200);
                portSelectionForm.ShowIcon = false;
                
                // Create a label with instructions
                Label instructionLabel = new Label();
                instructionLabel.Text = "Please select the COM port for your timing system:";
                instructionLabel.AutoSize = true;
                instructionLabel.Location = new System.Drawing.Point(20, 20);
                
                // Create a ComboBox for COM port selection
                ComboBox comPortComboBox = new ComboBox();
                comPortComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comPortComboBox.Location = new System.Drawing.Point(20, 50);
                comPortComboBox.Width = 200;
                
                // Populate the ComboBox with available COM ports
                string[] availablePorts = System.IO.Ports.SerialPort.GetPortNames();
                foreach (string port in availablePorts)
                {
                    comPortComboBox.Items.Add(port);
                }
                
                // Select the first port if available
                if (comPortComboBox.Items.Count > 0)
                {
                    comPortComboBox.SelectedIndex = 0;
                }
                
                // Create a refresh button
                Button refreshButton = new Button();
                refreshButton.Text = "Refresh";
                refreshButton.Location = new System.Drawing.Point(230, 50);
                refreshButton.Click += (s, e) => {
                    comPortComboBox.Items.Clear();
                    string[] ports = System.IO.Ports.SerialPort.GetPortNames();
                    foreach (string port in ports)
                    {
                        comPortComboBox.Items.Add(port);
                    }
                    if (comPortComboBox.Items.Count > 0)
                    {
                        comPortComboBox.SelectedIndex = 0;
                    }
                };
                
                // Create OK and Cancel buttons
                Button okButton = new Button();
                okButton.Text = "OK";
                okButton.DialogResult = DialogResult.OK;
                okButton.Location = new System.Drawing.Point(200, 100);
                
                Button cancelButton = new Button();
                cancelButton.Text = "Skip";
                cancelButton.DialogResult = DialogResult.Cancel;
                cancelButton.Location = new System.Drawing.Point(280, 100);
                
                // Add controls to the form
                portSelectionForm.Controls.Add(instructionLabel);
                portSelectionForm.Controls.Add(comPortComboBox);
                portSelectionForm.Controls.Add(refreshButton);
                portSelectionForm.Controls.Add(okButton);
                portSelectionForm.Controls.Add(cancelButton);
                
                // Show the form as a dialog
                DialogResult result = portSelectionForm.ShowDialog();
                
                // Process the result
                if (result == DialogResult.OK && comPortComboBox.SelectedItem != null)
                {
                    // Save the selected COM port
                    Properties.Settings.Default.COMPort = comPortComboBox.SelectedItem.ToString();
                    Properties.Settings.Default.Save();
                }
            }
            
            // Create the main scoreboard form
            Scoreboard mainScoreboard = new Scoreboard();
            
            // Create the shared data handler from the main scoreboard
            AresDataHandler dataHandler = mainScoreboard.GetDataHandler();
            
            // Create the OBS scoreboard form with the shared data handler
            OBSScoreboard obsScoreboard = new OBSScoreboard(dataHandler);
            
            // Set up the OBS scoreboard window properties
            obsScoreboard.Text = "SRAYS OBS Scoreboard";
            obsScoreboard.FormBorderStyle = FormBorderStyle.Sizable;
            obsScoreboard.StartPosition = FormStartPosition.Manual;
            obsScoreboard.Location = new System.Drawing.Point(100, 100);
            obsScoreboard.Size = new System.Drawing.Size(960, 540);
            obsScoreboard.TopMost = false;
            
            // Set up form references
            mainScoreboard.SetOBSScoreboard(obsScoreboard);
            mainScoreboard.SetSettingsForm(settingsForm);
            settingsForm.SetScoreboardReferences(mainScoreboard, obsScoreboard);
            
            // Apply initial settings to the main scoreboard
            mainScoreboard.ApplySettings(settingsForm);
            
            // Show the OBS scoreboard window
            obsScoreboard.Show();
            
            // Run the main scoreboard form (this will block until the main form is closed)
            Application.Run(mainScoreboard);
            
            // When the main form is closed, close the other forms as well
            obsScoreboard.Close();
            settingsForm.Close();
        }
    }
}
