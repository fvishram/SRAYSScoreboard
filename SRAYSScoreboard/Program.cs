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
            
            // Show the OBS scoreboard window
            obsScoreboard.Show();
            
            // Run the main scoreboard form (this will block until the main form is closed)
            Application.Run(mainScoreboard);
            
            // When the main form is closed, close the OBS form as well
            obsScoreboard.Close();
        }
    }
}
