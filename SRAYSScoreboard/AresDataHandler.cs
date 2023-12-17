// Copyright (c) 2023 Faisal Vishram, Silver Rays Swim Club

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
      

    internal class AresDataHandler
    {
        private const char SOH = '\u0001';
        private const char STX = '\u0002';
        private const char EOT = '\u0004';

        private const string EVENT_HEADER = "0040100069";
        private const string TIME_HEADER = "0040100000";

        private const string LANE1_NAME_HEADER = "0040100200";
        private const string LANE1_RESULT_HEADER = "0040100220";
        private const string LANE2_NAME_HEADER = "0040100236";
        private const string LANE2_RESULT_HEADER = "0040100256";
        private const string LANE3_NAME_HEADER = "0040100272";
        private const string LANE3_RESULT_HEADER = "0040100292";
        private const string LANE4_NAME_HEADER = "0040100308";
        private const string LANE4_RESULT_HEADER = "0040100328";
        private const string LANE5_NAME_HEADER = "0040100344";
        private const string LANE5_RESULT_HEADER = "0040100364";
        private const string LANE6_NAME_HEADER = "0040100380";
        private const string LANE6_RESULT_HEADER = "0040100400";
        private const string LANE7_NAME_HEADER = "0040100416";
        private const string LANE7_RESULT_HEADER = "0040100436";
        private const string LANE8_NAME_HEADER = "0040100452";
        private const string LANE8_RESULT_HEADER = "0040100472";
        private const string LANE9_NAME_HEADER = "0040100488";
        private const string LANE9_RESULT_HEADER = "0040100508";
        private const string LANE10_NAME_HEADER = "0040100524";
        private const string LANE10_RESULT_HEADER = "0040100544";

        private string headerData = "";
        private string transData = "";

        private bool inHeader = false;
        private bool inTrans = false;

        private string runningTime = "";
        private string eventName = "";
        private string[] swimmerNames = new string[10];
        private string[] swimmerPlaces = new string[10];
        private string[] swimmerTimes = new string[10];

        public string RunningTime { get => runningTime; set => runningTime = value; }
        public string EventName { get => eventName; set => eventName = value; }
        public string[] SwimmerNames { get => swimmerNames; set => swimmerNames = value; }
        public string[] SwimmerPlaces { get => swimmerPlaces; set => swimmerPlaces = value; }
        public string[] SwimmerTimes { get => swimmerTimes; set => swimmerTimes = value; }

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

        private void processName(int lane, string data)
        {
            swimmerNames[lane-1] = data.Trim();
        }

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

        public void processInput(char[] data) 
        {
            foreach (char c in data)
            {
                processInput(c);
            }
        }
    }
}
