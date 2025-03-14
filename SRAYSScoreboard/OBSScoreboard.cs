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

            // Update swimmer data
            for (int i = 0; i < nameLabels.Count; i++)
            {
                nameLabels[i].Text = scoreboardData.SwimmerNames[i];
                placeLabels[i].Text = scoreboardData.SwimmerPlaces[i];
                timeLabels[i].Text = scoreboardData.SwimmerTimes[i];
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
    }
}
