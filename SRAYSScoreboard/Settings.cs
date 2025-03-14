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

using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace SRAYSScoreboard
{
    /// <summary>
    /// Settings form for the scoreboard application.
    /// Allows configuration of COM port, colors, and pool lane count.
    /// This form operates independently from the main scoreboard.
    /// </summary>
    public partial class Settings : Form
    {
        /// <summary>
        /// Event raised when settings are applied.
        /// </summary>
        public event EventHandler SettingsApplied;

        /// <summary>
        /// Gets or sets the selected COM port.
        /// </summary>
        public string COMPort { get; private set; }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        public Color BackgroundColor { get; private set; }

        /// <summary>
        /// Gets or sets the text color (legacy setting).
        /// </summary>
        public Color TextColor { get; private set; }

        /// <summary>
        /// Gets or sets the header labels color.
        /// </summary>
        public Color HeaderLabelsColor { get; private set; }

        /// <summary>
        /// Gets or sets the column headers color.
        /// </summary>
        public Color ColumnHeadersColor { get; private set; }

        /// <summary>
        /// Gets or sets the name labels color.
        /// </summary>
        public Color NameLabelsColor { get; private set; }

        /// <summary>
        /// Gets or sets the time labels color.
        /// </summary>
        public Color TimeLabelsColor { get; private set; }

        /// <summary>
        /// Gets or sets the place labels color.
        /// </summary>
        public Color PlaceLabelsColor { get; private set; }

        /// <summary>
        /// Gets or sets the lane labels color.
        /// </summary>
        public Color LaneLabelsColor { get; private set; }

        /// <summary>
        /// Gets or sets the pool lane count.
        /// </summary>
        public int PoolLaneCount { get; private set; }

        /// <summary>
        /// Reference to the main scoreboard form.
        /// </summary>
        private Scoreboard mainScoreboard;

        /// <summary>
        /// Reference to the OBS scoreboard form.
        /// </summary>
        private OBSScoreboard obsScoreboard;

        /// <summary>
        /// Initializes a new instance of the Settings form.
        /// </summary>
        public Settings()
        {
            InitializeComponent();
            LoadSettings();
            PopulateComPorts();
        }

        /// <summary>
        /// Loads the saved settings from the application settings.
        /// </summary>
        private void LoadSettings()
        {
            // Load COM port setting
            COMPort = Properties.Settings.Default.COMPort;

            // Load color settings
            BackgroundColor = Properties.Settings.Default.BackgroundColor;
            TextColor = Properties.Settings.Default.TextColor;
            HeaderLabelsColor = Properties.Settings.Default.HeaderLabelsColor;
            ColumnHeadersColor = Properties.Settings.Default.ColumnHeadersColor;
            NameLabelsColor = Properties.Settings.Default.NameLabelsColor;
            TimeLabelsColor = Properties.Settings.Default.TimeLabelsColor;
            PlaceLabelsColor = Properties.Settings.Default.PlaceLabelsColor;
            LaneLabelsColor = Properties.Settings.Default.LaneLabelsColor;

            // Load pool lane count setting
            PoolLaneCount = Properties.Settings.Default.PoolLaneCount;

            // Set the radio button based on the pool lane count
            if (PoolLaneCount == 8)
            {
                radioButton8Lanes.Checked = true;
            }
            else
            {
                radioButton10Lanes.Checked = true;
            }
        }

        /// <summary>
        /// Populates the COM port combo box with available ports.
        /// </summary>
        private void PopulateComPorts()
        {
            // Clear the combo box
            comboBoxCOMPort.Items.Clear();

            // Get available COM ports
            string[] availablePorts = SerialPort.GetPortNames();

            // Check if COM5 is in the list of available ports
            bool com5Available = Array.Exists(availablePorts, port => port == "COM5");
            
            // If COM5 is not available, add it to the list as the recommended port
            if (!com5Available)
            {
                // Add COM5 as the first item with a special label
                comboBoxCOMPort.Items.Add("COM5 (Recommended for Timing System)");
            }

            // Add each available port to the combo box
            foreach (string port in availablePorts)
            {
                // If this is COM5, add it with a special label
                if (port == "COM5")
                {
                    comboBoxCOMPort.Items.Add("COM5 (Recommended for Timing System)");
                }
                else
                {
                    comboBoxCOMPort.Items.Add(port);
                }
            }

            // Select the current COM port if it exists
            if (!string.IsNullOrEmpty(COMPort))
            {
                // Handle the case where COMPort is "COM5" but the item is "COM5 (Recommended for Timing System)"
                if (COMPort == "COM5")
                {
                    for (int i = 0; i < comboBoxCOMPort.Items.Count; i++)
                    {
                        if (comboBoxCOMPort.Items[i].ToString().StartsWith("COM5"))
                        {
                            comboBoxCOMPort.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else if (comboBoxCOMPort.Items.Contains(COMPort))
                {
                    comboBoxCOMPort.SelectedItem = COMPort;
                }
            }
            else if (comboBoxCOMPort.Items.Count > 0)
            {
                // Select the first port if the current port doesn't exist
                comboBoxCOMPort.SelectedIndex = 0;
            }
            
            // Set the form title to indicate the default port
            this.Text = "Scoreboard Settings - Default Timing System Port: COM5";
        }
        
        /// <summary>
        /// Public method to refresh the COM ports list.
        /// This can be called from other forms when the Settings form is shown.
        /// </summary>
        public void RefreshComPorts()
        {
            PopulateComPorts();
        }

        /// <summary>
        /// Sets the references to the scoreboard forms.
        /// </summary>
        /// <param name="scoreboard">The main scoreboard form</param>
        /// <param name="obsForm">The OBS scoreboard form</param>
        public void SetScoreboardReferences(Scoreboard scoreboard, OBSScoreboard obsForm)
        {
            mainScoreboard = scoreboard;
            obsScoreboard = obsForm;
        }

        /// <summary>
        /// Handles the OK button click event.
        /// </summary>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Save the COM port setting
            if (comboBoxCOMPort.SelectedItem != null)
            {
                COMPort = comboBoxCOMPort.SelectedItem.ToString();
                Properties.Settings.Default.COMPort = COMPort;
            }

            // Save the pool lane count setting
            PoolLaneCount = radioButton8Lanes.Checked ? 8 : 10;
            Properties.Settings.Default.PoolLaneCount = PoolLaneCount;

            // Save all settings
            Properties.Settings.Default.Save();

            // Apply settings to the scoreboard forms if they exist
            if (mainScoreboard != null)
            {
                mainScoreboard.ApplySettings(this);
            }

            // Raise the SettingsApplied event
            SettingsApplied?.Invoke(this, EventArgs.Empty);

            // Hide the form instead of closing it
            this.Hide();
        }

        /// <summary>
        /// Handles the Cancel button click event.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Just hide the form instead of closing it
            this.Hide();
        }

        /// <summary>
        /// Handles the Refresh Ports button click event.
        /// </summary>
        private void buttonRefreshPorts_Click(object sender, EventArgs e)
        {
            // Refresh the list of available COM ports
            PopulateComPorts();
        }

        /// <summary>
        /// Handles the Background Color button click event.
        /// </summary>
        private void buttonBackgroundColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Use the current color as the initial color
                colorDialog.Color = BackgroundColor;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Update the background color
                    BackgroundColor = colorDialog.Color;
                    Properties.Settings.Default.BackgroundColor = BackgroundColor;
                    
                    // Auto-apply the change to all scoreboards
                    ApplyChangesToScoreboards();
                }
            }
        }

        /// <summary>
        /// Handles the Text Color button click event.
        /// </summary>
        private void buttonTextColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Use the current color as the initial color
                colorDialog.Color = TextColor;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Update the text color
                    TextColor = colorDialog.Color;
                    Properties.Settings.Default.TextColor = TextColor;
                    
                    // Auto-apply the change to all scoreboards
                    ApplyChangesToScoreboards();
                }
            }
        }

        /// <summary>
        /// Handles the Header Labels Color button click event.
        /// </summary>
        private void buttonHeaderLabelsColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Use the current color as the initial color
                colorDialog.Color = HeaderLabelsColor;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Update the header labels color
                    HeaderLabelsColor = colorDialog.Color;
                    Properties.Settings.Default.HeaderLabelsColor = HeaderLabelsColor;
                    
                    // Auto-apply the change to all scoreboards
                    ApplyChangesToScoreboards();
                }
            }
        }

        /// <summary>
        /// Handles the Column Headers Color button click event.
        /// </summary>
        private void buttonColumnHeadersColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Use the current color as the initial color
                colorDialog.Color = ColumnHeadersColor;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Update the column headers color
                    ColumnHeadersColor = colorDialog.Color;
                    Properties.Settings.Default.ColumnHeadersColor = ColumnHeadersColor;
                    
                    // Auto-apply the change to all scoreboards
                    ApplyChangesToScoreboards();
                }
            }
        }

        /// <summary>
        /// Handles the Name Labels Color button click event.
        /// </summary>
        private void buttonNameLabelsColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Use the current color as the initial color
                colorDialog.Color = NameLabelsColor;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Update the name labels color
                    NameLabelsColor = colorDialog.Color;
                    Properties.Settings.Default.NameLabelsColor = NameLabelsColor;
                    
                    // Auto-apply the change to all scoreboards
                    ApplyChangesToScoreboards();
                }
            }
        }

        /// <summary>
        /// Handles the Time Labels Color button click event.
        /// </summary>
        private void buttonTimeLabelsColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Use the current color as the initial color
                colorDialog.Color = TimeLabelsColor;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Update the time labels color
                    TimeLabelsColor = colorDialog.Color;
                    Properties.Settings.Default.TimeLabelsColor = TimeLabelsColor;
                    
                    // Auto-apply the change to all scoreboards
                    ApplyChangesToScoreboards();
                }
            }
        }

        /// <summary>
        /// Handles the Place Labels Color button click event.
        /// </summary>
        private void buttonPlaceLabelsColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Use the current color as the initial color
                colorDialog.Color = PlaceLabelsColor;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Update the place labels color
                    PlaceLabelsColor = colorDialog.Color;
                    Properties.Settings.Default.PlaceLabelsColor = PlaceLabelsColor;
                    
                    // Auto-apply the change to all scoreboards
                    ApplyChangesToScoreboards();
                }
            }
        }

        /// <summary>
        /// Handles the Lane Labels Color button click event.
        /// </summary>
        private void buttonLaneLabelsColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Use the current color as the initial color
                colorDialog.Color = LaneLabelsColor;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Update the lane labels color
                    LaneLabelsColor = colorDialog.Color;
                    Properties.Settings.Default.LaneLabelsColor = LaneLabelsColor;
                    
                    // Auto-apply the change to all scoreboards
                    ApplyChangesToScoreboards();
                }
            }
        }

        /// <summary>
        /// Handles the Reset Colors button click event.
        /// </summary>
        private void buttonResetColors_Click(object sender, EventArgs e)
        {
            // Reset to default colors
            BackgroundColor = Color.Black;
            TextColor = SystemColors.HotTrack;
            HeaderLabelsColor = SystemColors.HotTrack;
            ColumnHeadersColor = SystemColors.HotTrack;
            NameLabelsColor = Color.LightSteelBlue;
            TimeLabelsColor = Color.LightSteelBlue;
            PlaceLabelsColor = Color.LightSteelBlue;
            LaneLabelsColor = Color.LightSteelBlue;

            // Update the settings
            Properties.Settings.Default.BackgroundColor = BackgroundColor;
            Properties.Settings.Default.TextColor = TextColor;
            Properties.Settings.Default.HeaderLabelsColor = HeaderLabelsColor;
            Properties.Settings.Default.ColumnHeadersColor = ColumnHeadersColor;
            Properties.Settings.Default.NameLabelsColor = NameLabelsColor;
            Properties.Settings.Default.TimeLabelsColor = TimeLabelsColor;
            Properties.Settings.Default.PlaceLabelsColor = PlaceLabelsColor;
            Properties.Settings.Default.LaneLabelsColor = LaneLabelsColor;

            // Auto-apply the changes to all scoreboards
            ApplyChangesToScoreboards();

            MessageBox.Show("Colors have been reset to default values.", "Reset Colors", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Applies the current settings to all scoreboard forms.
        /// </summary>
        private void ApplyChangesToScoreboards()
        {
            try
            {
                // Save settings to ensure they're persisted
                Properties.Settings.Default.Save();

                // Apply settings to the main scoreboard if it exists
                if (mainScoreboard != null)
                {
                    mainScoreboard.ApplySettings(this);
                }

                // Raise the SettingsApplied event to notify any listeners
                SettingsApplied?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying settings: {ex.Message}", 
                    "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the radio button change for pool lane configuration.
        /// </summary>
        private void radioButton8Lanes_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8Lanes.Checked)
            {
                // Update the pool lane count setting
                PoolLaneCount = 8;
                Properties.Settings.Default.PoolLaneCount = PoolLaneCount;
                
                // Auto-apply the change to all scoreboards
                ApplyChangesToScoreboards();
            }
        }

        /// <summary>
        /// Handles the radio button change for pool lane configuration.
        /// </summary>
        private void radioButton10Lanes_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10Lanes.Checked)
            {
                // Update the pool lane count setting
                PoolLaneCount = 10;
                Properties.Settings.Default.PoolLaneCount = PoolLaneCount;
                
                // Auto-apply the change to all scoreboards
                ApplyChangesToScoreboards();
            }
        }
    }
}
