// Copyright (c) 2025 Faisal Vishram, Silver Rays Swim Club

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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRAYSScoreboard
{
    /// <summary>
    /// A smaller, resizable form for OBS capture that displays the same scoreboard data.
    /// This form is designed to be captured and overlaid on a live stream.
    /// </summary>
    public partial class OBSScoreboard : Form
    {
        /// <summary>Reference to the main scoreboard data handler</summary>
        private AresDataHandler scoreboardData;
        
        /// <summary>Collection of labels for displaying swimmer times</summary>
        private List<Label> timeLabels = new List<Label>();
        
        /// <summary>Collection of labels for displaying swimmer names</summary>
        private List<Label> nameLabels = new List<Label>();
        
        /// <summary>Collection of labels for displaying swimmer places</summary>
        private List<Label> placeLabels = new List<Label>();
        
        /// <summary>Flag indicating whether to use lane numbering 0-9 instead of 1-10</summary>
        private bool useLaneNumberingZeroToNine = false;
        
        /// <summary>Reference to the screen saver form</summary>
        private ScreenSaver screenSaverForm;
        
        /// <summary>Flag indicating whether the screen saver is currently active</summary>
        private bool screenSaverActive = false;

        /// <summary>
        /// Initializes a new instance of the OBSScoreboard form.
        /// </summary>
        /// <param name="dataHandler">The shared data handler from the main scoreboard</param>
        public OBSScoreboard(AresDataHandler dataHandler)
        {
            InitializeComponent();
            
            // Store reference to the shared data handler
            scoreboardData = dataHandler;
            
            // Initialize the label collections for easier updating
            timeLabels.AddRange(new List<Label>() { labelTime1, labelTime2, labelTime3, labelTime4, labelTime5, labelTime6, labelTime7, labelTime8, labelTime9, labelTime10 });
            nameLabels.AddRange(new List<Label>() { labelName1, labelName2, labelName3, labelName4, labelName5, labelName6, labelName7, labelName8, labelName9, labelName10 });
            placeLabels.AddRange(new List<Label>() { labelPlace1, labelPlace2, labelPlace3, labelPlace4, labelPlace5, labelPlace6, labelPlace7, labelPlace8, labelPlace9, labelPlace10 });
            
            // Set up the update timer
            Timer updateTimer = new Timer();
            updateTimer.Interval = 100; // Update 10 times per second
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }
        
        /// <summary>
        /// Activates the screen saver for the OBS scoreboard.
        /// </summary>
        public void ActivateScreenSaver()
        {
            // Only activate if not already active
            if (!screenSaverActive)
            {
                try
                {
                    // Create a new screen saver form if needed
                    if (screenSaverForm == null || screenSaverForm.IsDisposed)
                    {
                        screenSaverForm = new ScreenSaver();
                    }
                    
                    // Load the screen saver settings
                    screenSaverForm.LoadSettings();
                    
                    // Show the screen saver
                    screenSaverForm.Show();
                    
                    // Set the active flag
                    screenSaverActive = true;
                    
                    // Handle the form closed event
                    screenSaverForm.FormClosed += (s, e) => {
                        screenSaverActive = false;
                    };
                }
                catch (Exception ex)
                {
                    // Log the error but continue
                    Console.WriteLine($"Error activating OBS screen saver: {ex.Message}");
                    screenSaverActive = false;
                }
            }
        }
        
        /// <summary>
        /// Deactivates the screen saver for the OBS scoreboard.
        /// </summary>
        public void DeactivateScreenSaver()
        {
            if (screenSaverActive && screenSaverForm != null && !screenSaverForm.IsDisposed)
            {
                try
                {
                    // Close the screen saver form
                    screenSaverForm.Close();
                    
                    // Set the active flag
                    screenSaverActive = false;
                }
                catch (Exception ex)
                {
                    // Log the error but continue
                    Console.WriteLine($"Error deactivating OBS screen saver: {ex.Message}");
                }
            }
        }
        
        /// <summary>
        /// Notifies the screen saver that data has been received from the timing system.
        /// </summary>
        public void OnDataReceived()
        {
            // Check if the screen saver should exit when data is received
            if (screenSaverActive && screenSaverForm != null && Properties.Settings.Default.ScreenSaverExitOnData)
            {
                screenSaverForm.OnDataReceived();
            }
        }

        /// <summary>
        /// Updates the scoreboard UI with the latest data from the timing system.
        /// This method is called by the timer to keep the OBS display in sync with the main display.
        /// </summary>
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateScoreboard();
        }

        /// <summary>
        /// Updates all the labels with the current data from the shared data handler.
        /// </summary>
        private void UpdateScoreboard()
        {
            // Update event and time labels
            labelTime.Text = scoreboardData.RunningTime;
            labelEvent.Text = scoreboardData.EventName;

            // Update swimmer data with proper lane mapping based on numbering setting
            for (int i = 0; i < nameLabels.Count; i++)
            {
                // Get the correct data index based on lane numbering setting
                int dataIndex = GetDataIndexForDisplayIndex(i);
                nameLabels[i].Text = scoreboardData.SwimmerNames[dataIndex];
                placeLabels[i].Text = scoreboardData.SwimmerPlaces[dataIndex];
                timeLabels[i].Text = scoreboardData.SwimmerTimes[dataIndex];
            }
        }

        /// <summary>
        /// Maps a display index (position in the UI) to the correct data index based on lane numbering setting.
        /// </summary>
        /// <param name="displayIndex">The index of the label in the UI (0-9)</param>
        /// <returns>The index to use for accessing data from the arrays (0-9)</returns>
        private int GetDataIndexForDisplayIndex(int displayIndex)
        {
            if (!useLaneNumberingZeroToNine)
            {
                // Standard 1-10 numbering: display index matches data index
                return displayIndex;
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

        /// <summary>
        /// Handles the form load event. Loads any saved color settings.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void OBSScoreboard_Load(object sender, EventArgs e)
        {
            // Load saved color settings
            LoadColorSettings();
            
            // Apply the pool configuration based on saved settings
            UpdatePoolLaneVisibility(Properties.Settings.Default.PoolLaneCount);
            
            // Load and apply lane numbering setting
            useLaneNumberingZeroToNine = Properties.Settings.Default.UseLaneNumberingZeroToNine;
            UpdateLaneNumbering(useLaneNumberingZeroToNine);
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
                else if (Properties.Settings.Default.TextColor != Color.Empty)
                {
                    // Fall back to the legacy text color setting if no individual colors are set
                    ApplyTextColor(Properties.Settings.Default.TextColor);
                }
            }
            catch (Exception ex)
            {
                // Just log the error and continue with default colors
                Console.WriteLine($"Error loading color settings: {ex.Message}");
            }
        }

        /// <summary>
        /// Applies the specified color to header labels (labelTime, labelEvent).
        /// </summary>
        /// <param name="color">The color to apply</param>
        private void ApplyHeaderLabelsColor(Color color)
        {
            labelTime.ForeColor = color;
            labelEvent.ForeColor = color;
        }
        
        /// <summary>
        /// Applies the specified color to column headers (label1, label2, label3, label4).
        /// </summary>
        /// <param name="color">The color to apply</param>
        private void ApplyColumnHeadersColor(Color color)
        {
            label1.ForeColor = color;
            label2.ForeColor = color;
            label3.ForeColor = color;
            label4.ForeColor = color;
        }
        
        /// <summary>
        /// Applies the specified color to name labels.
        /// </summary>
        /// <param name="color">The color to apply</param>
        private void ApplyNameLabelsColor(Color color)
        {
            foreach (Label label in nameLabels)
            {
                label.ForeColor = color;
            }
        }
        
        /// <summary>
        /// Applies the specified color to time labels.
        /// </summary>
        /// <param name="color">The color to apply</param>
        private void ApplyTimeLabelsColor(Color color)
        {
            foreach (Label label in timeLabels)
            {
                label.ForeColor = color;
            }
        }
        
        /// <summary>
        /// Applies the specified color to place labels.
        /// </summary>
        /// <param name="color">The color to apply</param>
        private void ApplyPlaceLabelsColor(Color color)
        {
            foreach (Label label in placeLabels)
            {
                label.ForeColor = color;
            }
        }
        
        /// <summary>
        /// Applies the specified color to lane number labels.
        /// </summary>
        /// <param name="color">The color to apply</param>
        private void ApplyLaneLabelsColor(Color color)
        {
            for (int i = 5; i <= 14; i++)
            {
                Control[] controls = this.tableLayoutPanel1.Controls.Find("label" + i, true);
                if (controls.Length > 0 && controls[0] is Label)
                {
                    ((Label)controls[0]).ForeColor = color;
                }
            }
        }
        
        /// <summary>
        /// Applies the specified text color to all data labels in the scoreboard.
        /// </summary>
        /// <param name="color">The color to apply</param>
        private void ApplyTextColor(Color color)
        {
            // Apply to header labels
            labelTime.ForeColor = color;
            labelEvent.ForeColor = color;
            
            // Apply to column headers
            label1.ForeColor = color;
            label2.ForeColor = color;
            label3.ForeColor = color;
            label4.ForeColor = color;
            
            // Apply to all data labels
            foreach (Label label in nameLabels)
            {
                label.ForeColor = color;
            }
            
            foreach (Label label in timeLabels)
            {
                label.ForeColor = color;
            }
            
            foreach (Label label in placeLabels)
            {
                label.ForeColor = color;
            }
            
            // Apply to lane number labels
            for (int i = 5; i <= 14; i++)
            {
                Control[] controls = this.tableLayoutPanel1.Controls.Find("label" + i, true);
                if (controls.Length > 0 && controls[0] is Label)
                {
                    ((Label)controls[0]).ForeColor = color;
                }
            }
        }
        
        /// <summary>
        /// Applies the specified background color to the scoreboard.
        /// </summary>
        /// <param name="color">The color to apply</param>
        public void ApplyBackgroundColor(Color color)
        {
            this.BackColor = color;
            tableLayoutPanel1.BackColor = color;
        }
        
        /// <summary>
        /// Applies all color settings to the scoreboard.
        /// </summary>
        /// <param name="backgroundColor">The background color</param>
        /// <param name="headerLabelsColor">The header labels color</param>
        /// <param name="columnHeadersColor">The column headers color</param>
        /// <param name="nameLabelsColor">The name labels color</param>
        /// <param name="timeLabelsColor">The time labels color</param>
        /// <param name="placeLabelsColor">The place labels color</param>
        /// <param name="laneLabelsColor">The lane labels color</param>
        public void ApplyColorSettings(Color backgroundColor, Color headerLabelsColor, Color columnHeadersColor, 
                                      Color nameLabelsColor, Color timeLabelsColor, Color placeLabelsColor, Color laneLabelsColor)
        {
            // Apply background color
            ApplyBackgroundColor(backgroundColor);
            
            // Apply individual color settings
            ApplyHeaderLabelsColor(headerLabelsColor);
            ApplyColumnHeadersColor(columnHeadersColor);
            ApplyNameLabelsColor(nameLabelsColor);
            ApplyTimeLabelsColor(timeLabelsColor);
            ApplyPlaceLabelsColor(placeLabelsColor);
            ApplyLaneLabelsColor(laneLabelsColor);
        }
        
        /// <summary>
        /// Updates the lane number labels based on the lane numbering setting.
        /// </summary>
        /// <param name="useZeroToNine">Whether to use lane numbering 0-9 instead of 1-10</param>
        public void UpdateLaneNumbering(bool useZeroToNine)
        {
            try
            {
                // Store the setting
                useLaneNumberingZeroToNine = useZeroToNine;
                
                // Update lane number labels based on the setting
                for (int i = 5; i <= 14; i++)
                {
                    Control[] controls = this.tableLayoutPanel1.Controls.Find("label" + i, true);
                    if (controls.Length > 0 && controls[0] is Label)
                    {
                        Label laneLabel = (Label)controls[0];
                        int laneNumber = i - 4; // Convert from label index to lane number
                        
                        if (useLaneNumberingZeroToNine)
                        {
                            // Use 0-9 numbering
                            laneLabel.Text = (laneNumber - 1).ToString();
                        }
                        else
                        {
                            // Use 1-10 numbering
                            laneLabel.Text = laneNumber.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error but continue
                Console.WriteLine($"Error updating lane numbering: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Updates the visibility of lanes based on the selected pool configuration.
        /// </summary>
        /// <param name="laneCount">The number of lanes to display (8 or 10)</param>
        public void UpdatePoolLaneVisibility(int laneCount)
        {
            // Ensure lane count is valid
            if (laneCount != 8 && laneCount != 10)
            {
                laneCount = 10; // Default to 10 lanes
            }
            
            // Update visibility of lanes 9 and 10
            bool showLanes9And10 = (laneCount == 10);
            
            // Lane 9 controls
            Control[] lane9Controls = new Control[] {
                nameLabels[8], timeLabels[8], placeLabels[8]
            };
            
            // Lane 10 controls
            Control[] lane10Controls = new Control[] {
                nameLabels[9], timeLabels[9], placeLabels[9]
            };
            
            // Lane number labels
            Control[] lane9LabelControls = this.tableLayoutPanel1.Controls.Find("label13", true);
            Control[] lane10LabelControls = this.tableLayoutPanel1.Controls.Find("label14", true);
            
            // Update visibility
            foreach (Control control in lane9Controls)
            {
                control.Visible = showLanes9And10;
            }
            
            foreach (Control control in lane10Controls)
            {
                control.Visible = showLanes9And10;
            }
            
            // Update lane number label visibility
            if (lane9LabelControls.Length > 0)
            {
                lane9LabelControls[0].Visible = showLanes9And10;
            }
            
            if (lane10LabelControls.Length > 0)
            {
                lane10LabelControls[0].Visible = showLanes9And10;
            }
        }
    }
}
