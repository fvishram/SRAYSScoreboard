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
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRAYSScoreboard
{
    /// <summary>
    /// Handles the processing of data received from the Omega ARES 21 timing system.
    /// This class parses the incoming data stream according to the Venus ERTD scoreboard protocol
    /// and extracts relevant information such as event names, running times, and swimmer results.
    /// </summary>
    public class AresDataHandler
    {
        // Control characters used in the Venus ERTD protocol
        /// <summary>Start of Header character (ASCII 0x01)</summary>
        private const char SOH = '\u0001';
        /// <summary>Start of Text character (ASCII 0x02)</summary>
        private const char STX = '\u0002';
        /// <summary>End of Transmission character (ASCII 0x04)</summary>
        private const char EOT = '\u0004';

        // Header codes that identify different types of data
        /// <summary>Header code for event information</summary>
        private const string EVENT_HEADER = "0040100069";
        /// <summary>Header code for running time</summary>
        private const string TIME_HEADER = "0040100000";

        // Header codes for swimmer names and results by lane
        /// <summary>Header code for Lane 1 swimmer name</summary>
        private const string LANE1_NAME_HEADER = "0040100200";
        /// <summary>Header code for Lane 1 result (place and time)</summary>
        private const string LANE1_RESULT_HEADER = "0040100220";
        /// <summary>Header code for Lane 2 swimmer name</summary>
        private const string LANE2_NAME_HEADER = "0040100236";
        /// <summary>Header code for Lane 2 result (place and time)</summary>
        private const string LANE2_RESULT_HEADER = "0040100256";
        /// <summary>Header code for Lane 3 swimmer name</summary>
        private const string LANE3_NAME_HEADER = "0040100272";
        /// <summary>Header code for Lane 3 result (place and time)</summary>
        private const string LANE3_RESULT_HEADER = "0040100292";
        /// <summary>Header code for Lane 4 swimmer name</summary>
        private const string LANE4_NAME_HEADER = "0040100308";
        /// <summary>Header code for Lane 4 result (place and time)</summary>
        private const string LANE4_RESULT_HEADER = "0040100328";
        /// <summary>Header code for Lane 5 swimmer name</summary>
        private const string LANE5_NAME_HEADER = "0040100344";
        /// <summary>Header code for Lane 5 result (place and time)</summary>
        private const string LANE5_RESULT_HEADER = "0040100364";
        /// <summary>Header code for Lane 6 swimmer name</summary>
        private const string LANE6_NAME_HEADER = "0040100380";
        /// <summary>Header code for Lane 6 result (place and time)</summary>
        private const string LANE6_RESULT_HEADER = "0040100400";
        /// <summary>Header code for Lane 7 swimmer name</summary>
        private const string LANE7_NAME_HEADER = "0040100416";
        /// <summary>Header code for Lane 7 result (place and time)</summary>
        private const string LANE7_RESULT_HEADER = "0040100436";
        /// <summary>Header code for Lane 8 swimmer name</summary>
        private const string LANE8_NAME_HEADER = "0040100452";
        /// <summary>Header code for Lane 8 result (place and time)</summary>
        private const string LANE8_RESULT_HEADER = "0040100472";
        /// <summary>Header code for Lane 9 swimmer name</summary>
        private const string LANE9_NAME_HEADER = "0040100488";
        /// <summary>Header code for Lane 9 result (place and time)</summary>
        private const string LANE9_RESULT_HEADER = "0040100508";
        /// <summary>Header code for Lane 10 swimmer name</summary>
        private const string LANE10_NAME_HEADER = "0040100524";
        /// <summary>Header code for Lane 10 result (place and time)</summary>
        private const string LANE10_RESULT_HEADER = "0040100544";

        // Variables for tracking the current state of data parsing
        /// <summary>Stores the current header data being received</summary>
        private string headerData = "";
        /// <summary>Stores the current transmission data being received</summary>
        private string transData = "";

        /// <summary>Flag indicating whether we're currently receiving header data</summary>
        private bool inHeader = false;
        /// <summary>Flag indicating whether we're currently receiving transmission data</summary>
        private bool inTrans = false;

        // Data storage for scoreboard information
        /// <summary>The current running time of the event</summary>
        private string runningTime = "";
        /// <summary>The name and number of the current event</summary>
        private string eventName = "";
        /// <summary>Array of swimmer names for each lane (0-9 corresponds to lanes 1-10)</summary>
        private string[] swimmerNames = new string[10];
        /// <summary>Array of finishing places for each lane (0-9 corresponds to lanes 1-10)</summary>
        private string[] swimmerPlaces = new string[10];
        /// <summary>Array of finish times for each lane (0-9 corresponds to lanes 1-10)</summary>
        private string[] swimmerTimes = new string[10];

        // Properties to access the scoreboard data
        /// <summary>Gets or sets the current running time of the event</summary>
        public string RunningTime { get => runningTime; set => runningTime = value; }
        /// <summary>Gets or sets the name and number of the current event</summary>
        public string EventName { get => eventName; set => eventName = value; }
        /// <summary>Gets or sets the array of swimmer names for each lane</summary>
        public string[] SwimmerNames { get => swimmerNames; set => swimmerNames = value; }
        /// <summary>Gets or sets the array of finishing places for each lane</summary>
        public string[] SwimmerPlaces { get => swimmerPlaces; set => swimmerPlaces = value; }
        /// <summary>Gets or sets the array of finish times for each lane</summary>
        public string[] SwimmerTimes { get => swimmerTimes; set => swimmerTimes = value; }

        /// <summary>
        /// Processes a single character of input from the timing system.
        /// This method implements a state machine that parses the Venus ERTD protocol.
        /// </summary>
        /// <param name="data">The character to process</param>
        public void processInput(char data)
        {
            switch (data)
            {
                case SOH:
                    inHeader = true;
                    inTrans = false;
                    headerData = "";
                    transData = "";
                    break;
                case STX:
                    inHeader = false;
                    inTrans = true;
                    transData = "";
                    break;
                case EOT:
                   inTrans = false;
                    switch(headerData)
                    {
                        case EVENT_HEADER:
                            eventName = transData;
                            break;
                        case TIME_HEADER:
                            runningTime = transData;
                            break;
                        case LANE1_NAME_HEADER:
                            processName(1, transData);
                            break;
                        case LANE1_RESULT_HEADER:
                            processResults(1, transData);
                            break;
                        case LANE2_NAME_HEADER:
                            processName(2, transData);
                            break;
                        case LANE2_RESULT_HEADER:
                            processResults(2, transData);
                            break;
                        case LANE3_NAME_HEADER:
                            processName(3, transData);
                            break;
                        case LANE3_RESULT_HEADER:
                            processResults(3, transData);
                            break;
                        case LANE4_NAME_HEADER:
                            processName(4, transData);
                            break;
                        case LANE4_RESULT_HEADER:
                            processResults(4, transData);
                            break;
                        case LANE5_NAME_HEADER:
                            processName(5, transData);
                            break;
                        case LANE5_RESULT_HEADER:
                            processResults(5, transData);
                            break;
                        case LANE6_NAME_HEADER:
                            processName(6, transData);
                            break;
                        case LANE6_RESULT_HEADER:
                            processResults(6, transData);
                            break;
                        case LANE7_NAME_HEADER:
                            processName(7, transData);
                            break;
                        case LANE7_RESULT_HEADER:
                            processResults(7, transData);
                            break;
                        case LANE8_NAME_HEADER:
                            processName(8, transData);
                            break;
                        case LANE8_RESULT_HEADER:
                            processResults(8, transData);                                
                            break;
                        case LANE9_NAME_HEADER:
                            processName(9, transData);
                            break;
                        case LANE9_RESULT_HEADER:
                            processResults(9, transData);
                            break;
                        case LANE10_NAME_HEADER:
                            processName(10, transData);
                            break;
                        case LANE10_RESULT_HEADER:
                            processResults(10, transData);
                            break;
                        default:
                        break;
                    }
                   break;
                default: 
                    if(inHeader)
                    {
                        headerData += data;
                    }
                    else if(inTrans)
                    {
                        transData += data;
                    }
                break;
            }


        }

        /// <summary>
        /// Processes a swimmer name for a specific lane.
        /// </summary>
        /// <param name="lane">The lane number (1-10)</param>
        /// <param name="data">The swimmer name data</param>
        private void processName(int lane, string data)
        {
            swimmerNames[lane-1] = data.Trim();
        }

        /// <summary>
        /// Processes result data (place and time) for a specific lane.
        /// This method parses the result string which can come in different formats
        /// depending on the state of the race and the timing system.
        /// </summary>
        /// <param name="lane">The lane number (1-10)</param>
        /// <param name="data">The result data containing place and time information</param>
        private void processResults(int lane, string data)
        {
            string[] values = data.Trim().Split(' ');
            if (values.Length > 2)
            {
                string l = string.Empty;
                string place = string.Empty;
                string time = string.Empty;
                for(int i = 0; i < values.Length; i ++)
                {
                    if (values[i].Trim().Length > 0 )
                    {
                        if(l == string.Empty && place == string.Empty && time == string.Empty)
                            l = values[i].Trim();
                        else if(place == string.Empty && time == string.Empty)
                            if (values[i].Trim().Length > 8)
                            {
                                time = values[i].Substring(values[i].Trim().Length - 8, 8);
                                place = values[i].Trim().Replace(time, "");
                            }
                            else
                            {
                                place = values[i].Trim();
                            }
                            
                        else if (time == string.Empty)
                            time = values[i].Trim();
                    }
                }
                swimmerPlaces[lane-1] = place;
                swimmerTimes[lane-1] = time;
            }
            else if(values.Length == 2)
            {
                //9  910:20.00
                string time = values[1].Substring(values[1].Length - 8, 8);
                string place = values[1].Replace(time, "");

                swimmerPlaces[lane - 1] = place;
                swimmerTimes[lane - 1] = time;
            }   
            else
            {
                swimmerPlaces[lane - 1] = "";
                swimmerTimes[lane - 1] = "";
            }
        }

        /// <summary>
        /// Processes an array of characters from the timing system.
        /// This method iterates through each character and processes it individually.
        /// </summary>
        /// <param name="data">Array of characters to process</param>
        public void processInput(char[] data) 
        {
            foreach (char c in data)
            {
                processInput(c);
            }
        }
    }
}
