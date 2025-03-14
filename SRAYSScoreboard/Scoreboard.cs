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
        }

        /// <summary>
        /// Handles the form load event. Opens the serial port connection to the timing system.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void Scoreboard_Load(object sender, EventArgs e)
        {
            serialPort.Open();
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
        /// Handles the form closed event. Closes the serial port connection to the timing system.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event data</param>
        private void Scoreboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort.Close();
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
            serialPort.Close();
            serialPort.PortName = formSettings.COMPort;
            serialPort.Open();
        }
    }
}
