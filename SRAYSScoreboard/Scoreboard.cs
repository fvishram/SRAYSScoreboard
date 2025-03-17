﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿// Copyright (c) 2025 Faisal Vishram, Silver Rays Swim Club

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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRAYSScoreboard
{
    /// <summary>
    /// The main form of the application that displays the scoreboard interface.
    /// This form connects to the Omega ARES 21 timing system via a serial port
    /// and displays real-time swimming competition data.
    /// </summary>
    public partial class Scoreboard : Form
    {
        /// <summary>Handler for processing data from the timing system</summary>
        private AresDataHandler scoreboardData = new AresDataHandler();
        
        /// <summary>Reference to the OBS scoreboard form</summary>
        private OBSScoreboard obsScoreboard;
        
        /// <summary>Reference to the Settings form</summary>
        private Settings settingsForm;
        
        /// <summary>Collection of labels for displaying swimmer times</summary>
        private List<Label> timeLabels = new List<Label>();
        
        /// <summary>Collection of labels for displaying swimmer names</summary>
        private List<Label> nameLabels = new List<Label>();
        
        /// <summary>Collection of labels for displaying swimmer places</summary>
        private List<Label> placeLabels = new List<Label>();
        
        /// <summary>Flag indicating whether to use lane numbering 0-9 instead of 1-10</summary>
        private bool useLaneNumberingZeroToNine = false;
        
        /// <summary>Timer for tracking inactivity for screen saver activation</summary>
        private Timer inactivityTimer;
        
        /// <summary>Reference to the screen saver form</summary>
        private ScreenSaver screenSaverForm;
        
        /// <summary>Flag indicating whether the screen saver is currently active</summary>
        private bool screenSaverActive = false;
        
        /// <summary>
        /// Initializes a new instance of the Scoreboard form.
        /// </summary>
        public Scoreboard()
        {
            InitializeComponent();

            // Initialize the label collections for easier updating
            timeLabels.AddRange(new List<Label>() {labelTime1, labelTime2, labelTime3, labelTime4, labelTime5, labelTime6, labelTime7, labelTime8, labelTime9, labelTime10});
            nameLabels.AddRange(new List<Label>() { labelName1, labelName2, labelName3, labelName4, labelName5, labelName6, labelName7, labelName8, labelName9, labelName10 });
            placeLabels.AddRange(new List<Label>() { labelPlace1, labelPlace2, labelPlace3, labelPlace4, labelPlace5, labelPlace6, labelPlace7, labelPlace8, labelPlace9, labelPlace10 });
            
            // Apply the pool configuration based on saved settings
            UpdatePoolLaneVisibility(Properties.Settings.Default.PoolLaneCount);
            
            // Set up keyboard handling for the form
            this.KeyPreview = true;
            this.KeyDown += Scoreboard_KeyDown;
            
            // Set up mouse handling for inactivity tracking
            this.MouseMove += Scoreboard_MouseMove;
            this.MouseClick += Scoreboard_MouseClick;
            
            // Initialize the inactivity timer
            inactivityTimer = new Timer();
            inactivityTimer.Tick += InactivityTimer_Tick;
            
            // Load screen saver settings and start the timer if enabled
            UpdateScreenSaverSettings();
            
            // Set up the serial port data received event handler
            serialPort.DataReceived += SerialPort_DataReceived;
        }
        
        /// <summary>
        /// Handles data received from the serial port. This event is triggered when
        /// the timing system sends data to the application.
        /// </summary>
        /// <remarks>
        /// CRITICAL: The Omega ARES 21 timing system uses a binary protocol (Venus ERTD) that requires
        /// character-by-character processing. It is essential to read the data as a char array and process
        /// it directly with the processInput method rather than using string-based methods.
        /// 
        /// Using string-based methods can cause data corruption or loss due to:
        /// 1. Character encoding issues with control characters in the protocol
        /// 2. Buffering behavior differences between string and char array processing
        /// 3. Timing-sensitive protocol requirements that need immediate character processing
        /// 
        /// Always maintain this implementation to ensure reliable communication with the timing system.
        /// </remarks>
        /// <param name="sender">The source of the event (SerialPort)</param>
        /// <param name="e">Event data</param>
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                // IMPORTANT: Read as char array and process directly with processInput
                // Do NOT convert to string first as this can cause data corruption with the binary protocol
                char[] readData = sp.ReadExisting().ToCharArray();
                scoreboardData.processInput(readData);
                SafeUpdateScoreboard();
                
                // Notify the screen saver that data has been received
                if (screenSaverActive && screenSaverForm != null && !screenSaverForm.IsDisposed)
                {
                    screenSaverForm.OnDataReceived();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in serial port data received event handler: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Updates the scoreboard display with the current data.
        /// This method is called from a background thread, so it uses Invoke to update the UI.
        /// </summary>
        private void SafeUpdateScoreboard()
        {
            try
            {
                // Check if we need to invoke to the UI thread
                if (this.InvokeRequired)
                {
                    // Invoke to the UI thread
                    this.Invoke(new Action(SafeUpdateScoreboard));
                    return;
                }
                
                // Update the event name and heat number
                labelEventName.Text = scoreboardData.EventName;
                labelHeatNumber.Text = scoreboardData.HeatNumber;
                
                // Update the swimmer data
                for (int i = 0; i < 10; i++)
                {
                    // Get the display index (0-9)
                    int displayIndex = i;
                    
                    // Get the data index (0-9)
                    int dataIndex = GetDataIndexForDisplayIndex(displayIndex + 1);
                    
                    // Check if the data index is valid
                    if (dataIndex >= 0 && dataIndex < 10)
                    {
                        // Update the swimmer name
                        nameLabels[displayIndex].Text = scoreboardData.SwimmerNames[dataIndex];
                        
                        // Update the swimmer time
                        timeLabels[displayIndex].Text = scoreboardData.SwimmerTimes[dataIndex];
                        
                        // Update the swimmer place
                        placeLabels[displayIndex].Text = scoreboardData.SwimmerPlaces[dataIndex];
                    }
                }
                
                // Update the OBS scoreboard if it exists
                if (obsScoreboard != null)
                {
                    obsScoreboard.UpdateScoreboard(scoreboardData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating scoreboard: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Applies settings from the settings form to the scoreboard.
        /// </summary>
        /// <param name="formSettings">The settings form with the new settings</param>
        public void ApplySettings(Settings formSettings)
        {
            try
            {
                // Apply COM port settings
                if (!string.IsNullOrEmpty(formSettings.COMPort))
                {
                    // Close the port if it's open
                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                    }
                    
                    // Update the port name
                    serialPort.PortName = formSettings.COMPort;
                    
                    // Try to open the new port
                    if (Array.Exists(System.IO.Ports.SerialPort.GetPortNames(), port => port == serialPort.PortName))
                    {
                        serialPort.Open();
                    }
                    else
                    {
                        MessageBox.Show($"COM port {serialPort.PortName} not found. Please check your connection and settings.", 
                            "Port Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                
                // Apply color settings
                this.BackColor = formSettings.BackgroundColor;
                tableLayoutPanel1.BackColor = formSettings.BackgroundColor;
                
                // Apply individual color settings
                ApplyHeaderLabelsColor(formSettings.HeaderLabelsColor);
                ApplyColumnHeadersColor(formSettings.ColumnHeadersColor);
                ApplyNameLabelsColor(formSettings.NameLabelsColor);
                ApplyTimeLabelsColor(formSettings.TimeLabelsColor);
                ApplyPlaceLabelsColor(formSettings.PlaceLabelsColor);
                ApplyLaneLabelsColor(formSettings.LaneLabelsColor);
                
                // Apply pool configuration
                UpdatePoolLaneVisibility(formSettings.PoolLaneCount);
                
                // Apply lane numbering setting
                useLaneNumberingZeroToNine = formSettings.UseLaneNumberingZeroToNine;
                UpdateLaneNumbering();
                
                // Update screen saver settings
                UpdateScreenSaverSettings();
                
                // Update the OBS scoreboard if it exists
                if (obsScoreboard != null)
                {
                    // Apply color settings to the OBS scoreboard
                    obsScoreboard.ApplyColorSettings(
                        formSettings.BackgroundColor,
                        formSettings.HeaderLabelsColor,
                        formSettings.ColumnHeadersColor,
                        formSettings.NameLabelsColor,
                        formSettings.TimeLabelsColor,
                        formSettings.PlaceLabelsColor,
                        formSettings.LaneLabelsColor
                    );
                    
                    // Update pool lane visibility
                    obsScoreboard.UpdatePoolLaneVisibility(formSettings.PoolLaneCount);
                    
                    // Update lane numbering
                    obsScoreboard.UpdateLaneNumbering(formSettings.UseLaneNumberingZeroToNine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying settings: {ex.Message}", 
                    "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Updates the visibility of lane rows based on the pool configuration.
        /// </summary>
        /// <param name="laneCount">The number of lanes in the pool</param>
        private void UpdatePoolLaneVisibility(int laneCount)
        {
            try
            {
                // Validate the lane count
                if (laneCount < 4 || laneCount > 10)
                {
                    Console.WriteLine($"Invalid lane count: {laneCount}. Using default of 8 lanes.");
                    laneCount = 8;
                }
                
                // Update the visibility of each lane row
                for (int i = 0; i < 10; i++)
                {
                    // Get the lane number (1-based)
                    int laneNumber = i + 1;
                    
                    // Set visibility based on whether the lane number is within the lane count
                    bool isVisible = laneNumber <= laneCount;
                    
                    // Update the visibility of the lane labels
                    switch (laneNumber)
                    {
                        case 1:
                            labelLane1.Visible = isVisible;
                            labelName1.Visible = isVisible;
                            labelTime1.Visible = isVisible;
                            labelPlace1.Visible = isVisible;
                            break;
                        case 2:
                            labelLane2.Visible = isVisible;
                            labelName2.Visible = isVisible;
                            labelTime2.Visible = isVisible;
                            labelPlace2.Visible = isVisible;
                            break;
                        case 3:
                            labelLane3.Visible = isVisible;
                            labelName3.Visible = isVisible;
                            labelTime3.Visible = isVisible;
                            labelPlace3.Visible = isVisible;
                            break;
                        case 4:
                            labelLane4.Visible = isVisible;
                            labelName4.Visible = isVisible;
                            labelTime4.Visible = isVisible;
                            labelPlace4.Visible = isVisible;
                            break;
                        case 5:
                            labelLane5.Visible = isVisible;
                            labelName5.Visible = isVisible;
                            labelTime5.Visible = isVisible;
                            labelPlace5.Visible = isVisible;
                            break;
                        case 6:
                            labelLane6.Visible = isVisible;
                            labelName6.Visible = isVisible;
                            labelTime6.Visible = isVisible;
                            labelPlace6.Visible = isVisible;
                            break;
                        case 7:
                            labelLane7.Visible = isVisible;
                            labelName7.Visible = isVisible;
                            labelTime7.Visible = isVisible;
                            labelPlace7.Visible = isVisible;
                            break;
                        case 8:
                            labelLane8.Visible = isVisible;
                            labelName8.Visible = isVisible;
                            labelTime8.Visible = isVisible;
                            labelPlace8.Visible = isVisible;
                            break;
                        case 9:
                            labelLane9.Visible = isVisible;
                            labelName9.Visible = isVisible;
                            labelTime9.Visible = isVisible;
                            labelPlace9.Visible = isVisible;
                            break;
                        case 10:
                            labelLane10.Visible = isVisible;
                            labelName10.Visible = isVisible;
                            labelTime10.Visible = isVisible;
                            labelPlace10.Visible = isVisible;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating pool lane visibility: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Updates the lane numbering based on the lane numbering setting.
        /// </summary>
        private void UpdateLaneNumbering()
        {
            try
            {
                // Update the lane labels based on the lane numbering setting
                if (useLaneNumberingZeroToNine)
                {
                    // Use 0-9 lane numbering
                    labelLane1.Text = "0";
                    labelLane2.Text = "1";
                    labelLane3.Text = "2";
                    labelLane4.Text = "3";
                    labelLane5.Text = "4";
                    labelLane6.Text = "5";
                    labelLane7.Text = "6";
                    labelLane8.Text = "7";
                    labelLane9.Text = "8";
                    labelLane10.Text = "9";
                }
                else
                {
                    // Use 1-10 lane numbering
                    labelLane1.Text = "1";
                    labelLane2.Text = "2";
                    labelLane3.Text = "3";
                    labelLane4.Text = "4";
                    labelLane5.Text = "5";
                    labelLane6.Text = "6";
                    labelLane7.Text = "7";
                    labelLane8.Text = "8";
                    labelLane9.Text = "9";
                    labelLane10.Text = "10";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating lane numbering: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Gets the data index for the specified display index.
        /// This is used to map between the display lane number and the data lane number.
        /// </summary>
        /// <param name="displayIndex">The display index (0-9)</param>
        /// <returns>The data index (0-9)</returns>
        private int GetDataIndexForDisplayIndex(int displayIndex)
        {
            try
            {
                if (!useLaneNumberingZeroToNine)
                {
                    // Standard 1-10 numbering: display index matches data index
                    return displayIndex - 1;
                }
                else
                {
                    // 0-9 numbering: need to remap
                    if (displayIndex == 0)
                    {
                        // Lane 0 should show lane 10 data (index 9)
                        return 9;
                    }
                    else
                    {
                        // Lanes 1-9 should show lanes 1-9 data (indices 0-8)
                        return displayIndex - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting data index for display index: {ex.Message}");
                return displayIndex - 1;
            }
        }
        /// <summary>
        /// Applies the specified color to all header labels.
        /// </summary>
        /// <param name="color">The color to apply</param>
        private void ApplyHeaderLabelsColor(Color color)
        {
            try
            {
                // Apply the color to the event name and heat labels
                labelEventName.ForeColor = color;
                labelHeatNumber.ForeColor = color;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error applying header labels color: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Applies the specified color to all column header labels.
        /// </summary>
        /// <param name="color">The color to apply</param>
        private void ApplyColumnHeadersColor(Color color)
        {
            try
            {
                // Apply the color to the column header labels
                labelLaneHeader.ForeColor = color;
                labelNameHeader.ForeColor = color;
                labelTimeHeader.ForeColor = color;
                labelPlaceHeader.ForeColor = color;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error applying column headers color: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Applies the specified color to all name labels.
        /// </summary>
        /// <param name="color">The color to apply</param>
        private void ApplyNameLabelsColor(Color color)
        {
            try
            {
                // Apply the color to all name labels
                foreach (Label label in nameLabels)
                {
                    label.ForeColor = color;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error applying name labels color: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Applies the specified color to all time labels.
        /// </summary>
        /// <param name="color">The color to apply</param>
        private void ApplyTimeLabelsColor(Color color)
        {
            try
            {
                // Apply the color to all time labels
                foreach (Label label in timeLabels)
                {
                    label.ForeColor = color;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error applying time labels color: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Applies the specified color to all place labels.
        /// </summary>
        /// <param name="color">The color to apply</param>
        private void ApplyPlaceLabelsColor(Color color)
        {
            try
            {
                // Apply the color to all place labels
                foreach (Label label in placeLabels)
                {
                    label.ForeColor = color;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error applying place labels color: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Applies the specified color to all lane labels.
        /// </summary>
        /// <param name="color">The color to apply</param>
        private void ApplyLaneLabelsColor(Color color)
        {
            try
            {
                // Apply the color to all lane labels
                labelLane1.ForeColor = color;
                labelLane2.ForeColor = color;
                labelLane3.ForeColor = color;
                labelLane4.ForeColor = color;
                labelLane5.ForeColor = color;
                labelLane6.ForeColor = color;
                labelLane7.ForeColor = color;
                labelLane8.ForeColor = color;
                labelLane9.ForeColor = color;
                labelLane10.ForeColor = color;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error applying lane labels color: {ex.Message}");
            }
        }
        /// <summary>
        /// Sets the reference to the OBS scoreboard form.
        /// This allows the main form to update the OBS form when settings change.
        /// </summary>
        /// <param name="obsForm">The OBS scoreboard form</param>
        public void SetOBSScoreboard(OBSScoreboard obsForm)
        {
            obsScoreboard = obsForm;
        }
        
        /// <summary>
        /// Sets the reference to the Settings form.
        /// </summary>
        /// <param name="settings">The Settings form</param>
        public void SetSettingsForm(Settings settings)
        {
            settingsForm = settings;
        }
        
        /// <summary>
        /// Gets the data handler used by this scoreboard.
        /// This allows other forms to access the same data.
        /// </summary>
        /// <returns>The AresDataHandler instance</returns>
        public AresDataHandler GetDataHandler()
        {
            return scoreboardData;
        }
        
        /// <summary>
        /// Handles the form load event. Attempts to open the serial port connection to the timing system
        /// and loads any saved color settings.
        /// If the port cannot be opened (e.g., if the timing system is not connected), it logs the error
        /// but allows the application to continue running.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void Scoreboard_Load(object sender, EventArgs e)
        {
            try
            {
                // Get available COM ports
                string[] availablePorts = System.IO.Ports.SerialPort.GetPortNames();
                
                // Set default window title
                this.Text = "SRAYS Scoreboard";
                
                // Check if we have a saved COM port setting
                if (!string.IsNullOrEmpty(Properties.Settings.Default.COMPort))
                {
                    serialPort.PortName = Properties.Settings.Default.COMPort;
                    
                    // Check if the port exists before trying to open it
                    if (Array.Exists(availablePorts, port => port == serialPort.PortName))
                    {
                        serialPort.Open();
                        this.Text = $"SRAYS Scoreboard - Connected to {serialPort.PortName}";
                    }
                    else
                    {
                        // Port doesn't exist, but we'll continue without it
                        Console.WriteLine($"Warning: COM port {serialPort.PortName} not found. Continuing without timing system connection.");
                        
                        // Update the window title to indicate the port isn't connected
                        this.Text = $"SRAYS Scoreboard - Timing System Not Connected";
                        
                        // Add a tooltip to the form to provide additional information
                        ToolTip toolTip = new ToolTip();
                        string availablePortsText = availablePorts.Length > 0 ? 
                            $"Available ports: {string.Join(", ", availablePorts)}" : 
                            "No COM ports detected";
                        toolTip.SetToolTip(this, $"Press F2 to open settings and configure the COM port. {availablePortsText}");
                    }
                }
                else
                {
                    // No COM port configured, continue without it
                    Console.WriteLine("No COM port configured. Continuing without timing system connection.");
                    
                    // Update the window title to indicate the port isn't connected
                    this.Text = $"SRAYS Scoreboard - Timing System Not Connected";
                    
                    // Add a tooltip to the form to provide additional information
                    ToolTip toolTip = new ToolTip();
                    string availablePortsText = availablePorts.Length > 0 ? 
                        $"Available ports: {string.Join(", ", availablePorts)}" : 
                        "No COM ports detected";
                    toolTip.SetToolTip(this, $"Press F2 to open settings and configure the COM port. {availablePortsText}");
                }
            }
            catch (Exception ex)
            {
                // Log the error but continue without the timing system
                Console.WriteLine($"Error opening serial port: {ex.Message}");
                this.Text = $"SRAYS Scoreboard - Error Connecting to Timing System";
            }
            
            // Load saved color settings
            LoadColorSettings();
            
            // Load lane numbering setting
            useLaneNumberingZeroToNine = Properties.Settings.Default.UseLaneNumberingZeroToNine;
            UpdateLaneNumbering();
        }
        
        /// <summary>
        /// Shows the settings form.
        /// </summary>
        private void ShowSettingsForm()
        {
            if (settingsForm != null)
            {
                try
                {
                    // Refresh the COM ports list
                    settingsForm.RefreshComPorts();
                    
                    // Show the settings form
                    settingsForm.Show();
                    
                    // Bring it to the front
                    settingsForm.BringToFront();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error showing settings form: {ex.Message}", 
                        "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Settings form is not available. Please try again later.", 
                    "Settings Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        /// <summary>
        /// Handles the form's KeyDown event.
        /// Shows the settings form when F2 is pressed.
        /// </summary>
        private void Scoreboard_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Reset inactivity timer on any key press
                ResetInactivityTimer();
                
                // Show settings form when F2 is pressed
                if (e.KeyCode == Keys.F2)
                {
                    ShowSettingsForm();
                    e.Handled = true;
                }
                // Manually activate screen saver when F3 is pressed
                else if (e.KeyCode == Keys.F3)
                {
                    if (Properties.Settings.Default.ScreenSaverManualActivation)
                    {
                        ActivateScreenSaver();
                        e.Handled = true;
                    }
                }
                // Close application when Escape is pressed
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                    e.Handled = true;
                }
                // Mark other key events as not handled
                else
                {
                    e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                // Log the error and show a message
                Console.WriteLine($"Error in KeyDown event handler: {ex.Message}");
                MessageBox.Show($"An error occurred while processing keyboard input: {ex.Message}", 
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }
        
        /// <summary>
        /// Updates the screen saver settings based on the application settings.
        /// </summary>
        private void UpdateScreenSaverSettings()
        {
            try
            {
                // Stop the timer if it's running
                if (inactivityTimer.Enabled)
                {
                    inactivityTimer.Stop();
                }
                
                // Get the inactivity timeout from settings
                int inactivityMinutes = Properties.Settings.Default.ScreenSaverInactivityMinutes;
                
                // Set the timer interval (convert minutes to milliseconds)
                inactivityTimer.Interval = inactivityMinutes * 60 * 1000;
                
                // Start the timer if the inactivity timeout is greater than 0
                if (inactivityMinutes > 0)
                {
                    inactivityTimer.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating screen saver settings: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Resets the inactivity timer.
        /// </summary>
        private void ResetInactivityTimer()
        {
            try
            {
                // Only reset if the timer is enabled
                if (inactivityTimer.Enabled)
                {
                    inactivityTimer.Stop();
                    inactivityTimer.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error resetting inactivity timer: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Handles the inactivity timer tick event.
        /// </summary>
        private void InactivityTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Stop the timer
                inactivityTimer.Stop();
                
                // Activate the screen saver
                ActivateScreenSaver();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in inactivity timer tick: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Handles the mouse move event.
        /// </summary>
        private void Scoreboard_MouseMove(object sender, MouseEventArgs e)
        {
            // Reset the inactivity timer
            ResetInactivityTimer();
        }
        
        /// <summary>
        /// Handles the mouse click event.
        /// </summary>
        private void Scoreboard_MouseClick(object sender, MouseEventArgs e)
        {
            // Reset the inactivity timer
            ResetInactivityTimer();
        }
        
        /// <summary>
        /// Activates the screen saver.
        /// </summary>
        private void ActivateScreenSaver()
        {
            try
            {
                // Only activate if not already active
                if (!screenSaverActive)
                {
                    // Create a new screen saver form if it doesn't exist
                    if (screenSaverForm == null || screenSaverForm.IsDisposed)
                    {
                        screenSaverForm = new ScreenSaver();
                        
                        // Handle the form closed event
                        screenSaverForm.FormClosed += (s, args) => 
                        {
                            // Reset the screen saver active flag
                            screenSaverActive = false;
                            
                            // Restart the inactivity timer
                            ResetInactivityTimer();
                        };
                    }
                    
                    // Load the screen saver settings
                    screenSaverForm.LoadSettings();
                    
                    // Set the screen saver active flag
                    screenSaverActive = true;
                    
                    // Show the screen saver
                    screenSaverForm.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error activating screen saver: {ex.Message}");
                
                // Reset the screen saver active flag
                screenSaverActive = false;
                
                // Restart the inactivity timer
                ResetInactivityTimer();
            }
        }
        
        /// <summary>
        /// Deactivates the screen saver.
        /// </summary>
        private void DeactivateScreenSaver()
        {
            try
            {
                // Only deactivate if active
                if (screenSaverActive && screenSaverForm != null && !screenSaverForm.IsDisposed)
                {
                    // Close the screen saver form
                    screenSaverForm.Close();
                    
                    // Reset the screen saver active flag
                    screenSaverActive = false;
                    
                    // Restart the inactivity timer
                    ResetInactivityTimer();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deactivating screen saver: {ex.Message}");
                
                // Reset the screen saver active flag
                screenSaverActive = false;
                
                // Restart the inactivity timer
                ResetInactivityTimer();
            }
        }
        
        /// <summary>
        /// Loads and applies any saved color settings.
        /// </summary>
        private void LoadColorSettings()
        {
            try
            {
                // Load background color if it has been saved
                if (Properties.Settings.Default.BackgroundColor != Color.Empty)
                {
                    this.BackColor = Properties.Settings.Default.BackgroundColor;
                    tableLayoutPanel1.BackColor = Properties.Settings.Default.BackgroundColor;
                }
                
                // Check if we have individual color settings
                bool hasIndividualColors = 
                    Properties.Settings.Default.HeaderLabelsColor != Color.Empty ||
                    Properties.Settings.Default.ColumnHeadersColor != Color.Empty ||
                    Properties.Settings.Default.NameLabelsColor != Color.Empty ||
                    Properties.Settings.Default.TimeLabelsColor != Color.Empty ||
                    Properties.Settings.Default.PlaceLabelsColor != Color.Empty ||
                    Properties.Settings.Default.LaneLabelsColor != Color.Empty;
                
                if (hasIndividualColors)
                {
                    // Apply individual color settings
                    if (Properties.Settings.Default.HeaderLabelsColor != Color.Empty)
                    {
                        ApplyHeaderLabelsColor(Properties.Settings.Default.HeaderLabelsColor);
                    }
                    
                    if (Properties.Settings.Default.ColumnHeadersColor != Color.Empty)
                    {
                        ApplyColumnHeadersColor(Properties.Settings.Default.ColumnHeadersColor);
                    }
                    
                    if (Properties.Settings.Default.NameLabelsColor != Color.Empty)
                    {
                        ApplyNameLabelsColor(Properties.Settings.Default.NameLabelsColor);
                    }
                    
                    if (Properties.Settings.Default.TimeLabelsColor != Color.Empty)
                    {
                        ApplyTimeLabelsColor(Properties.Settings.Default.TimeLabelsColor);
                    }
                    
                    if (Properties.Settings.Default.PlaceLabelsColor != Color.Empty)
                    {
                        ApplyPlaceLabelsColor(Properties.Settings.Default.PlaceLabelsColor);
                    }
                    
                    if (Properties.Settings.Default.LaneLabelsColor != Color.Empty)
                    {
                        ApplyLaneLabelsColor(Properties.Settings.Default.LaneLabelsColor);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading color settings: {ex.Message}");
            }
        }
    }
}
