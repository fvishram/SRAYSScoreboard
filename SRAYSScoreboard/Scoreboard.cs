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
        
        /// <summary>
        /// Gets the data handler used by this scoreboard.
        /// This allows other forms to access the same data.
        /// </summary>
        /// <returns>The AresDataHandler instance</returns>
        public AresDataHandler GetDataHandler()
        {
            return scoreboardData;
        }
        
        /// <summary>Collection of labels for displaying swimmer times</summary>
        private List<Label> timeLabels = new List<Label>();
        
        /// <summary>Collection of labels for displaying swimmer names</summary>
        private List<Label> nameLabels = new List<Label>();
        
        /// <summary>Collection of labels for displaying swimmer places</summary>
        private List<Label> placeLabels = new List<Label>();
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
            
            // Initialize the COM port submenu
            InitializeComPortMenu();
        }
        
        /// <summary>
        /// Initializes the COM port submenu in the context menu.
        /// </summary>
        private void InitializeComPortMenu()
        {
            // Create a submenu for COM ports
            ToolStripMenuItem comPortMenu = new ToolStripMenuItem("COM Port");
            
            // Get available COM ports
            string[] availablePorts = SerialPort.GetPortNames();
            
            // Add each available port to the submenu
            foreach (string port in availablePorts)
            {
                ToolStripMenuItem portItem = new ToolStripMenuItem(port);
                portItem.Click += ComPortMenuItem_Click;
                
                // Check the current port
                if (port == serialPort.PortName)
                {
                    portItem.Checked = true;
                }
                
                comPortMenu.DropDownItems.Add(portItem);
            }
            
            // Add a refresh option to update the list of available ports
            comPortMenu.DropDownItems.Add(new ToolStripSeparator());
            ToolStripMenuItem refreshItem = new ToolStripMenuItem("Refresh List");
            refreshItem.Click += RefreshComPorts_Click;
            comPortMenu.DropDownItems.Add(refreshItem);
            
            // Insert the COM port menu between Settings and Exit
            contextMenuSettings.Items.Insert(1, comPortMenu);
        }
        
        /// <summary>
        /// Initializes the Colors submenu in the context menu.
        /// </summary>
        private void InitializeColorsMenu()
        {
            // Create a submenu for Colors
            ToolStripMenuItem colorsMenu = new ToolStripMenuItem("Colors");
            
            // Add background color option
            ToolStripMenuItem backgroundColorItem = new ToolStripMenuItem("Background Color");
            backgroundColorItem.Click += BackgroundColorMenuItem_Click;
            colorsMenu.DropDownItems.Add(backgroundColorItem);
            
            // Add text color option (kept for backward compatibility)
            ToolStripMenuItem textColorItem = new ToolStripMenuItem("Text Color (All)");
            textColorItem.Click += TextColorMenuItem_Click;
            colorsMenu.DropDownItems.Add(textColorItem);
            
            // Add separator
            colorsMenu.DropDownItems.Add(new ToolStripSeparator());
            
            // Add individual color options for each label group
            ToolStripMenuItem headerLabelsColorItem = new ToolStripMenuItem("Header Labels Color");
            headerLabelsColorItem.Click += HeaderLabelsColorMenuItem_Click;
            colorsMenu.DropDownItems.Add(headerLabelsColorItem);
            
            ToolStripMenuItem columnHeadersColorItem = new ToolStripMenuItem("Column Headers Color");
            columnHeadersColorItem.Click += ColumnHeadersColorMenuItem_Click;
            colorsMenu.DropDownItems.Add(columnHeadersColorItem);
            
            ToolStripMenuItem nameLabelsColorItem = new ToolStripMenuItem("Name Labels Color");
            nameLabelsColorItem.Click += NameLabelsColorMenuItem_Click;
            colorsMenu.DropDownItems.Add(nameLabelsColorItem);
            
            ToolStripMenuItem timeLabelsColorItem = new ToolStripMenuItem("Time Labels Color");
            timeLabelsColorItem.Click += TimeLabelsColorMenuItem_Click;
            colorsMenu.DropDownItems.Add(timeLabelsColorItem);
            
            ToolStripMenuItem placeLabelsColorItem = new ToolStripMenuItem("Place Labels Color");
            placeLabelsColorItem.Click += PlaceLabelsColorMenuItem_Click;
            colorsMenu.DropDownItems.Add(placeLabelsColorItem);
            
            ToolStripMenuItem laneLabelsColorItem = new ToolStripMenuItem("Lane Labels Color");
            laneLabelsColorItem.Click += LaneLabelsColorMenuItem_Click;
            colorsMenu.DropDownItems.Add(laneLabelsColorItem);
            
            // Add reset colors option
            colorsMenu.DropDownItems.Add(new ToolStripSeparator());
            ToolStripMenuItem resetItem = new ToolStripMenuItem("Reset to Default Colors");
            resetItem.Click += ResetColorsMenuItem_Click;
            colorsMenu.DropDownItems.Add(resetItem);
            
            // Insert the Colors menu between COM Port and Exit
            contextMenuSettings.Items.Insert(2, colorsMenu);
        }
        
        /// <summary>
        /// Handles the Header Labels Color menu item click event.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void HeaderLabelsColorMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Use the current color as the initial color
                colorDialog.Color = labelTime.ForeColor;
                colorDialog.FullOpen = true;
                
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Apply the selected color to header labels
                    ApplyHeaderLabelsColor(colorDialog.Color);
                    
                    // Save the color setting
                    Properties.Settings.Default.HeaderLabelsColor = colorDialog.Color;
                    Properties.Settings.Default.Save();
                }
            }
        }
        
        /// <summary>
        /// Handles the Column Headers Color menu item click event.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void ColumnHeadersColorMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Use the current color as the initial color
                colorDialog.Color = label1.ForeColor;
                colorDialog.FullOpen = true;
                
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Apply the selected color to column headers
                    ApplyColumnHeadersColor(colorDialog.Color);
                    
                    // Save the color setting
                    Properties.Settings.Default.ColumnHeadersColor = colorDialog.Color;
                    Properties.Settings.Default.Save();
                }
            }
        }
        
        /// <summary>
        /// Handles the Name Labels Color menu item click event.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void NameLabelsColorMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Use the current color as the initial color
                colorDialog.Color = nameLabels[0].ForeColor;
                colorDialog.FullOpen = true;
                
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Apply the selected color to name labels
                    ApplyNameLabelsColor(colorDialog.Color);
                    
                    // Save the color setting
                    Properties.Settings.Default.NameLabelsColor = colorDialog.Color;
                    Properties.Settings.Default.Save();
                }
            }
        }
        
        /// <summary>
        /// Handles the Time Labels Color menu item click event.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void TimeLabelsColorMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Use the current color as the initial color
                colorDialog.Color = timeLabels[0].ForeColor;
                colorDialog.FullOpen = true;
                
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Apply the selected color to time labels
                    ApplyTimeLabelsColor(colorDialog.Color);
                    
                    // Save the color setting
                    Properties.Settings.Default.TimeLabelsColor = colorDialog.Color;
                    Properties.Settings.Default.Save();
                }
            }
        }
        
        /// <summary>
        /// Handles the Place Labels Color menu item click event.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void PlaceLabelsColorMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Use the current color as the initial color
                colorDialog.Color = placeLabels[0].ForeColor;
                colorDialog.FullOpen = true;
                
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Apply the selected color to place labels
                    ApplyPlaceLabelsColor(colorDialog.Color);
                    
                    // Save the color setting
                    Properties.Settings.Default.PlaceLabelsColor = colorDialog.Color;
                    Properties.Settings.Default.Save();
                }
            }
        }
        
        /// <summary>
        /// Handles the Lane Labels Color menu item click event.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void LaneLabelsColorMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Use the current color as the initial color
                Control[] controls = this.tableLayoutPanel1.Controls.Find("label5", true);
                if (controls.Length > 0 && controls[0] is Label)
                {
                    colorDialog.Color = ((Label)controls[0]).ForeColor;
                }
                else
                {
                    colorDialog.Color = Color.LightSteelBlue;
                }
                
                colorDialog.FullOpen = true;
                
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Apply the selected color to lane labels
                    ApplyLaneLabelsColor(colorDialog.Color);
                    
                    // Save the color setting
                    Properties.Settings.Default.LaneLabelsColor = colorDialog.Color;
                    Properties.Settings.Default.Save();
                }
            }
        }
        
        /// <summary>
        /// Handles the COM port menu item click event.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void ComPortMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            string selectedPort = clickedItem.Text;
            
            try
            {
                // Close the port if it's open
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                
                // Update the port name
                serialPort.PortName = selectedPort;
                
                // Try to open the new port
                if (Array.Exists(SerialPort.GetPortNames(), port => port == serialPort.PortName))
                {
                    serialPort.Open();
                    
                    // Update the checked state of all port menu items
                    foreach (ToolStripMenuItem item in ((ToolStripMenuItem)contextMenuSettings.Items[1]).DropDownItems)
                    {
                        if (item.Text == selectedPort)
                        {
                            item.Checked = true;
                        }
                        else if (item.Text != "Refresh List")
                        {
                            item.Checked = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"COM port {serialPort.PortName} not found. Please check your connection.", 
                        "Port Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error configuring serial port: {ex.Message}", 
                    "Serial Port Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Refreshes the list of available COM ports.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void RefreshComPorts_Click(object sender, EventArgs e)
        {
            // Get the existing COM port menu
            ToolStripMenuItem comPortMenu = (ToolStripMenuItem)contextMenuSettings.Items[1];
            
            // Clear existing port items, but keep the separator and refresh option
            while (comPortMenu.DropDownItems.Count > 2)
            {
                comPortMenu.DropDownItems.RemoveAt(0);
            }
            
            // Get available COM ports
            string[] availablePorts = SerialPort.GetPortNames();
            
            // Add each available port to the submenu
            foreach (string port in availablePorts)
            {
                ToolStripMenuItem portItem = new ToolStripMenuItem(port);
                portItem.Click += ComPortMenuItem_Click;
                
                // Check the current port
                if (port == serialPort.PortName)
                {
                    portItem.Checked = true;
                }
                
                // Insert at the beginning, before the separator
                comPortMenu.DropDownItems.Insert(0, portItem);
            }
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
                // Check if the port exists before trying to open it
                if (Array.Exists(System.IO.Ports.SerialPort.GetPortNames(), port => port == serialPort.PortName))
                {
                    serialPort.Open();
                }
                else
                {
                    // Port doesn't exist, but we'll continue without it
                    Console.WriteLine($"Warning: COM port {serialPort.PortName} not found. Continuing without timing system connection.");
                }
            }
            catch (Exception ex)
            {
                // Log the error but continue without the timing system
                Console.WriteLine($"Error opening serial port: {ex.Message}");
            }
            
            // Initialize the Colors menu
            InitializeColorsMenu();
            
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
        /// Placeholder for menu item click event.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Unused event handler
        }

        /// <summary>
        /// Handles data received from the serial port. This event is triggered when
        /// the timing system sends data to the application.
        /// </summary>
        /// <param name="sender">The source of the event (SerialPort)</param>
        /// <param name="e">Event data</param>
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            char[] readData = sp.ReadExisting().ToCharArray();
            scoreboardData.processInput(readData);
            SafeUpdateScoreboard();
        }

        /// <summary>
        /// Updates the scoreboard UI with the latest data from the timing system.
        /// This method ensures that UI updates are performed on the UI thread using Invoke when necessary.
        /// </summary>
        private void SafeUpdateScoreboard()
        {
            if (labelTime.InvokeRequired)
            {
                labelTime.Invoke(new Action(() => { SafeUpdateScoreboard(); }));
            }
            else
                labelTime.Text = scoreboardData.RunningTime;

            if(labelEvent.InvokeRequired)
            {
                labelEvent.Invoke(new Action(() => { SafeUpdateScoreboard();}));        
            }
            else
                labelEvent.Text = scoreboardData.EventName;

            for(int i = 0; i < nameLabels.Count; i++) 
            {
                if (nameLabels[i].InvokeRequired)
                {
                    nameLabels[i].Invoke(new Action(() => { SafeUpdateScoreboard(); }));
                }
                else
                    nameLabels[i].Text = scoreboardData.SwimmerNames[i];
            }

            for (int i = 0; i < placeLabels.Count; i++)
            {
                if (placeLabels[i].InvokeRequired)
                {
                    placeLabels[i].Invoke(new Action(() => { SafeUpdateScoreboard(); }));
                }
                else
                    placeLabels[i].Text = scoreboardData.SwimmerPlaces[i];
            }

            for (int i = 0; i < timeLabels.Count; i++)
            {
                if (timeLabels[i].InvokeRequired)
                {
                    timeLabels[i].Invoke(new Action(() => { SafeUpdateScoreboard(); }));
                }
                else
                    timeLabels[i].Text = scoreboardData.SwimmerTimes[i];
            }

        }

        /// <summary>
        /// Handles the form closed event. Safely closes the serial port connection to the timing system.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void Scoreboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Only close the port if it's open
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
            }
            catch (Exception ex)
            {
                // Just log the error since we're closing anyway
                Console.WriteLine($"Error closing serial port: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the Exit menu item click event. Closes the application.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void toolStripMenuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Settings menu item click event. Opens the settings dialog
        /// and applies the COM port setting to the serial port.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void toolStripMenuSettings_Click(object sender, EventArgs e)
        {
            Settings formSettings = new Settings();
            formSettings.ShowDialog();
            
            // Only proceed if the user entered a COM port
            if (!string.IsNullOrEmpty(formSettings.COMPort))
            {
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show($"Error configuring serial port: {ex.Message}", 
                        "Serial Port Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        /// <summary>
        /// Handles the Background Color menu item click event. Opens a color dialog
        /// to allow the user to select a new background color for the scoreboard.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void BackgroundColorMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = this.BackColor;
                colorDialog.FullOpen = true;
                
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Apply the selected color to the form and table layout panel
                    this.BackColor = colorDialog.Color;
                    tableLayoutPanel1.BackColor = colorDialog.Color;
                    
                    // Save the color setting
                    Properties.Settings.Default.BackgroundColor = colorDialog.Color;
                    Properties.Settings.Default.Save();
                }
            }
        }
        
        /// <summary>
        /// Handles the Text Color menu item click event. Opens a color dialog
        /// to allow the user to select a new text color for the scoreboard.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void TextColorMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Use the current text color of the first label as the initial color
                colorDialog.Color = labelTime.ForeColor;
                colorDialog.FullOpen = true;
                
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Apply the selected color to all data labels
                    ApplyTextColor(colorDialog.Color);
                    
                    // Save the color setting
                    Properties.Settings.Default.TextColor = colorDialog.Color;
                    Properties.Settings.Default.Save();
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
        /// Handles the Reset Colors menu item click event. Resets the background and text colors
        /// to their default values.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void ResetColorsMenuItem_Click(object sender, EventArgs e)
        {
            // Reset to default colors
            this.BackColor = Color.Black;
            tableLayoutPanel1.BackColor = Color.Black;
            
            // Define default colors
            Color headerColor = SystemColors.HotTrack;
            Color dataColor = Color.LightSteelBlue;
            
            // Reset header labels
            ApplyHeaderLabelsColor(headerColor);
            
            // Reset column headers
            ApplyColumnHeadersColor(headerColor);
            
            // Reset data labels
            ApplyNameLabelsColor(dataColor);
            ApplyTimeLabelsColor(dataColor);
            ApplyPlaceLabelsColor(dataColor);
            ApplyLaneLabelsColor(dataColor);
            
            // Reset the saved settings
            Properties.Settings.Default.BackgroundColor = Color.Black;
            Properties.Settings.Default.TextColor = headerColor;
            Properties.Settings.Default.HeaderLabelsColor = headerColor;
            Properties.Settings.Default.ColumnHeadersColor = headerColor;
            Properties.Settings.Default.NameLabelsColor = dataColor;
            Properties.Settings.Default.TimeLabelsColor = dataColor;
            Properties.Settings.Default.PlaceLabelsColor = dataColor;
            Properties.Settings.Default.LaneLabelsColor = dataColor;
            Properties.Settings.Default.Save();
        }
    }
}
