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
    public partial class Scoreboard : Form
    {
        private AresDataHandler scoreboardData = new AresDataHandler();
        private List<Label> timeLabels = new List<Label>();
        private List<Label> nameLabels = new List<Label>();
        private List<Label> placeLabels = new List<Label>();
        public Scoreboard()
        {
            InitializeComponent();

            timeLabels.AddRange(new List<Label>() {labelTime1, labelTime2, labelTime3, labelTime4, labelTime5, labelTime6, labelTime7, labelTime8, labelTime9, labelTime10});
            nameLabels.AddRange(new List<Label>() { labelName1, labelName2, labelName3, labelName4, labelName5, labelName6, labelName7, labelName8, labelName9, labelName10 });
            placeLabels.AddRange(new List<Label>() { labelPlace1, labelPlace2, labelPlace3, labelPlace4, labelPlace5, labelPlace6, labelPlace7, labelPlace8, labelPlace9, labelPlace10 });
        }

        private void Scoreboard_Load(object sender, EventArgs e)
        {
            serialPort.Open();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            char[] readData = sp.ReadExisting().ToCharArray();
            scoreboardData.processInput(readData);
            SafeUpdateScoreboard();
        }

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

            //if (labelName1.InvokeRequired)
            //{
            //    labelName1.Invoke(new Action(() => { SafeUpdateScoreboard(); }));
            //}
            //else
            //    labelName1.Text = scoreboardData.SwimmerNames[0];

            //if (labelPlace1.InvokeRequired)
            //{
            //    labelPlace1.Invoke(new Action(() => { SafeUpdateScoreboard(); }));
            //}
            //else
            //    labelPlace1.Text = scoreboardData.SwimmerPlaces[0];

            //if (labelTime1.InvokeRequired)
            //{
            //    labelTime1.Invoke(new Action(() => { SafeUpdateScoreboard(); }));
            //}
            //else
            //    labelTime1.Text = scoreboardData.SwimmerTimes[0];

        }

        private void Scoreboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort.Close();
        }

        private void toolStripMenuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
