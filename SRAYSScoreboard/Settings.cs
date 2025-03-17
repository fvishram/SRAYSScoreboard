﻿﻿﻿﻿﻿﻿﻿﻿﻿// Copyright (c) 2025 Faisal Vishram, Silver Rays Swim Club

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
        /// Gets or sets whether to use lane numbering 0-9 instead of 1-10.
        /// </summary>
        public bool UseLaneNumberingZeroToNine { get; private set; }

        /// <summary>
        /// Gets or sets the screen saver display option.
        /// </summary>
        public string ScreenSaverDisplayOption { get; private set; }

        /// <summary>
        /// Gets or sets the inactivity timer in minutes.
        /// </summary>
        public int ScreenSaverInactivityMinutes { get; private set; }

        /// <summary>
        /// Gets or sets whether manual activation with F3 is enabled.
        /// </summary>
        public bool ScreenSaverManualActivation { get; private set; }

        /// <summary>
        /// Gets or sets whether the screen saver should exit when data is received.
        /// </summary>
        public bool ScreenSaverExitOnData { get; private set; }

        /// <summary>
        /// Gets or sets whether the screen saver should exit on any key press.
        /// </summary>
        public bool ScreenSaverExitOnKeyPress { get; private set; }
        
        /// <summary>
        /// Gets or sets whether the screen saver should exit on mouse movement.
        /// </summary>
        public bool ScreenSaverExitOnMouseMove { get; private set; }

        /// <summary>
        /// Gets or sets the logo path for the screen saver.
        /// </summary>
        public string ScreenSaverLogoPath { get; private set; }

        /// <summary>
        /// Gets or sets the scrolling message for the screen saver.
        /// </summary>
        public string ScreenSaverScrollingMessage { get; private set; }
        
        /// <summary>
        /// Gets or sets the background color for the screen saver.
        /// </summary>
        public Color ScreenSaverBackgroundColor { get; private set; }

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

            // Load lane numbering setting
            UseLaneNumberingZeroToNine = Properties.Settings.Default.UseLaneNumberingZeroToNine;
            checkBoxZeroToNine.Checked = UseLaneNumberingZeroToNine;

            // Load screen saver settings
            ScreenSaverDisplayOption = Properties.Settings.Default.ScreenSaverDisplayOption;
            ScreenSaverInactivityMinutes = Properties.Settings.Default.ScreenSaverInactivityMinutes;
            ScreenSaverManualActivation = Properties.Settings.Default.ScreenSaverManualActivation;
            ScreenSaverExitOnData = Properties.Settings.Default.ScreenSaverExitOnData;
            ScreenSaverExitOnKeyPress = Properties.Settings.Default.ScreenSaverExitOnKeyPress;
            ScreenSaverLogoPath = Properties.Settings.Default.ScreenSaverLogoPath;
            ScreenSaverScrollingMessage = Properties.Settings.Default.ScreenSaverScrollingMessage;
            ScreenSaverBackgroundColor = Properties.Settings.Default.ScreenSaverBackgroundColor;

            // Set the screen saver display option radio buttons
            switch (ScreenSaverDisplayOption)
            {
                case "AsciiArt":
                    radioButtonAsciiArt.Checked = true;
                    break;
                case "BlankScreen":
                    radioButtonBlankScreen.Checked = true;
                    break;
                case "Logo":
                    radioButtonLogo.Checked = true;
                    break;
                case "ScrollingMessage":
                    radioButtonScrollingMessage.Checked = true;
                    break;
                default:
                    radioButtonAsciiArt.Checked = true;
                    break;
            }

            // Set the inactivity timer
            numericUpDownInactivityMinutes.Value = ScreenSaverInactivityMinutes;

            // Set the manual activation checkbox
            checkBoxManualActivation.Checked = ScreenSaverManualActivation;

            // Set the exit on data checkbox
            checkBoxExitOnData.Checked = ScreenSaverExitOnData;

            // Set the exit on key press checkbox
            checkBoxExitOnKeyPress.Checked = ScreenSaverExitOnKeyPress;
            
            // Load the exit on mouse move setting
            ScreenSaverExitOnMouseMove = Properties.Settings.Default.ScreenSaverExitOnMouseMove;
            checkBoxExitOnMouseMove.Checked = ScreenSaverExitOnMouseMove;

            // Set the logo path
            textBoxLogoPath.Text = ScreenSaverLogoPath;

            // Set the scrolling message
            textBoxScrollingMessage.Text = ScreenSaverScrollingMessage;

            // Update the visibility of the logo path and scrolling message controls
            UpdateScreenSaverOptionControls();
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

            // Add each available port to the combo box
            foreach (string port in availablePorts)
            {
                comboBoxCOMPort.Items.Add(port);
            }

            // Select the current COM port if it exists
            if (!string.IsNullOrEmpty(COMPort) && comboBoxCOMPort.Items.Contains(COMPort))
            {
                comboBoxCOMPort.SelectedItem = COMPort;
            }
            else if (comboBoxCOMPort.Items.Count > 0)
            {
                // Select the first port if the current port doesn't exist
                comboBoxCOMPort.SelectedIndex = 0;
            }
            
            // Set the form title to indicate this is for COM port selection
            this.Text = "SRAYS Scoreboard - Select COM Port for Timing System";
            
            // If no ports are available, show a message
            if (availablePorts.Length == 0)
            {
                MessageBox.Show("No COM ports detected. Please connect your timing system and click 'Refresh Ports'.", 
                    "No COM Ports Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            
            // Save the lane numbering setting
            UseLaneNumberingZeroToNine = checkBoxZeroToNine.Checked;
            Properties.Settings.Default.UseLaneNumberingZeroToNine = UseLaneNumberingZeroToNine;

            // Save the screen saver settings
            // Determine which display option is selected
            if (radioButtonAsciiArt.Checked)
                ScreenSaverDisplayOption = "AsciiArt";
            else if (radioButtonBlankScreen.Checked)
                ScreenSaverDisplayOption = "BlankScreen";
            else if (radioButtonLogo.Checked)
                ScreenSaverDisplayOption = "Logo";
            else if (radioButtonScrollingMessage.Checked)
                ScreenSaverDisplayOption = "ScrollingMessage";

            ScreenSaverInactivityMinutes = (int)numericUpDownInactivityMinutes.Value;
            ScreenSaverManualActivation = checkBoxManualActivation.Checked;
            ScreenSaverExitOnData = checkBoxExitOnData.Checked;
            ScreenSaverExitOnKeyPress = checkBoxExitOnKeyPress.Checked;
            ScreenSaverExitOnMouseMove = checkBoxExitOnMouseMove.Checked;
            ScreenSaverLogoPath = textBoxLogoPath.Text;
            ScreenSaverScrollingMessage = textBoxScrollingMessage.Text;

            Properties.Settings.Default.ScreenSaverDisplayOption = ScreenSaverDisplayOption;
            Properties.Settings.Default.ScreenSaverInactivityMinutes = ScreenSaverInactivityMinutes;
            Properties.Settings.Default.ScreenSaverManualActivation = ScreenSaverManualActivation;
            Properties.Settings.Default.ScreenSaverExitOnData = ScreenSaverExitOnData;
            Properties.Settings.Default.ScreenSaverExitOnKeyPress = ScreenSaverExitOnKeyPress;
            Properties.Settings.Default.ScreenSaverExitOnMouseMove = ScreenSaverExitOnMouseMove;
            Properties.Settings.Default.ScreenSaverLogoPath = ScreenSaverLogoPath;
            Properties.Settings.Default.ScreenSaverScrollingMessage = ScreenSaverScrollingMessage;
            Properties.Settings.Default.ScreenSaverBackgroundColor = ScreenSaverBackgroundColor;

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

        /// <summary>
        /// Handles the checkbox change for lane numbering configuration.
        /// </summary>
        private void checkBoxZeroToNine_CheckedChanged(object sender, EventArgs e)
        {
            // Update the lane numbering setting
            UseLaneNumberingZeroToNine = checkBoxZeroToNine.Checked;
            Properties.Settings.Default.UseLaneNumberingZeroToNine = UseLaneNumberingZeroToNine;
            
            // Auto-apply the change to all scoreboards
            ApplyChangesToScoreboards();
        }

        /// <summary>
        /// Handles the radio button change for screen saver display options.
        /// </summary>
        private void radioButtonScreenSaverOption_CheckedChanged(object sender, EventArgs e)
        {
            UpdateScreenSaverOptionControls();
        }

        /// <summary>
        /// Updates the visibility of the logo path and scrolling message controls based on the selected display option.
        /// </summary>
        private void UpdateScreenSaverOptionControls()
        {
            // Hide all option-specific controls first
            labelLogoPath.Visible = false;
            textBoxLogoPath.Visible = false;
            buttonSelectLogo.Visible = false;
            labelScrollingMessage.Visible = false;
            textBoxScrollingMessage.Visible = false;

            // Show the controls for the selected option
            if (radioButtonLogo.Checked)
            {
                labelLogoPath.Visible = true;
                textBoxLogoPath.Visible = true;
                buttonSelectLogo.Visible = true;
            }
            else if (radioButtonScrollingMessage.Checked)
            {
                labelScrollingMessage.Visible = true;
                textBoxScrollingMessage.Visible = true;
            }
        }

        /// <summary>
        /// Handles the button click for selecting a logo file.
        /// </summary>
        private void buttonSelectLogo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All Files|*.*";
                openFileDialog.Title = "Select Logo Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxLogoPath.Text = openFileDialog.FileName;
                }
            }
        }
        
        /// <summary>
        /// Handles the Screen Saver Background Color button click event.
        /// </summary>
        private void buttonScreenSaverBackgroundColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Use the current color as the initial color
                colorDialog.Color = ScreenSaverBackgroundColor;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Update the screen saver background color
                    ScreenSaverBackgroundColor = colorDialog.Color;
                    Properties.Settings.Default.ScreenSaverBackgroundColor = ScreenSaverBackgroundColor;
                    
                    // Save the setting
                    Properties.Settings.Default.Save();
                    
                    // Show a confirmation message
                    MessageBox.Show("Screen saver background color updated.", 
                        "Color Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
