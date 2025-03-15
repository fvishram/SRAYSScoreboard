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
    /// A screen saver form that displays animated content when the scoreboard is inactive.
    /// </summary>
    public partial class ScreenSaver : Form
    {
        /// <summary>Timer for animation updates</summary>
        private Timer animationTimer;
        
        /// <summary>Random number generator for animation effects</summary>
        private Random random = new Random();
        
        /// <summary>Collection of swimming-related images for the screen saver</summary>
        private List<Image> images = new List<Image>();
        
        /// <summary>Current image index</summary>
        private int currentImageIndex = 0;
        
        /// <summary>Current position of the image</summary>
        private Point imagePosition;
        
        /// <summary>Direction of image movement</summary>
        private Point imageDirection;
        
        /// <summary>Flag indicating whether to exit the screen saver when data is received</summary>
        private bool exitOnDataReceived = true;
        
        /// <summary>Flag indicating whether to exit the screen saver when a key is pressed</summary>
        private bool exitOnKeyPress = true;
        
        /// <summary>
        /// Initializes a new instance of the ScreenSaver form.
        /// </summary>
        public ScreenSaver()
        {
            InitializeComponent();
            
            // Set up the form properties
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.BackColor = Color.Black;
            
            // Set up the animation timer
            animationTimer = new Timer();
            animationTimer.Interval = 50; // 20 FPS
            animationTimer.Tick += AnimationTimer_Tick;
            
            // Set up keyboard and mouse handling to exit the screen saver
            this.KeyDown += ScreenSaver_KeyDown;
            this.MouseMove += ScreenSaver_MouseMove;
            this.MouseClick += ScreenSaver_MouseClick;
            
            // Initialize the image position and direction
            imagePosition = new Point(random.Next(0, this.Width - 200), random.Next(0, this.Height - 200));
            imageDirection = new Point(random.Next(1, 5), random.Next(1, 5));
            
            // Load placeholder images (in a real implementation, these would be actual images)
            // For now, we'll just create some colored rectangles
            CreatePlaceholderImages();
        }
        
        /// <summary>
        /// Creates placeholder images for the screen saver.
        /// In a real implementation, these would be loaded from resources.
        /// </summary>
        private void CreatePlaceholderImages()
        {
            // Create some colored rectangles as placeholder images
            Color[] colors = new Color[] { Color.Blue, Color.Cyan, Color.Teal, Color.Navy };
            
            foreach (Color color in colors)
            {
                Bitmap bitmap = new Bitmap(200, 100);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(color);
                    
                    // Choose text color based on background brightness
                    Brush textBrush = GetContrastingBrushForColor(color);
                    g.DrawString("SRAYS", new Font("Arial", 24, FontStyle.Bold), textBrush, new Point(50, 30));
                }
                images.Add(bitmap);
            }
        }
        
        /// <summary>
        /// Gets a brush with a color that contrasts with the specified color.
        /// </summary>
        private Brush GetContrastingBrushForColor(Color color)
        {
            // Calculate the brightness of the color
            // Formula: (0.299*R + 0.587*G + 0.114*B) / 255
            double brightness = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;
            
            // Use white text for dark backgrounds and black text for light backgrounds
            if (brightness < 0.5)
            {
                return Brushes.White;
            }
            else
            {
                return Brushes.Black;
            }
        }
        
        /// <summary>
        /// Handles the form load event.
        /// </summary>
        private void ScreenSaver_Load(object sender, EventArgs e)
        {
            // Start the animation timer
            animationTimer.Start();
        }
        
        /// <summary>
        /// Handles the animation timer tick event.
        /// </summary>
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Update the image position
            imagePosition.X += imageDirection.X;
            imagePosition.Y += imageDirection.Y;
            
            // Check for collisions with the screen edges
            if (imagePosition.X < 0 || imagePosition.X > this.Width - 200)
            {
                imageDirection.X = -imageDirection.X;
                
                // Change the image when it hits the edge
                currentImageIndex = (currentImageIndex + 1) % images.Count;
            }
            
            if (imagePosition.Y < 0 || imagePosition.Y > this.Height - 100)
            {
                imageDirection.Y = -imageDirection.Y;
                
                // Change the image when it hits the edge
                currentImageIndex = (currentImageIndex + 1) % images.Count;
            }
            
            // Redraw the form
            this.Invalidate();
        }
        
        /// <summary>
        /// Handles the form paint event.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            // Draw the current image
            if (images.Count > 0 && currentImageIndex < images.Count)
            {
                e.Graphics.DrawImage(images[currentImageIndex], imagePosition);
            }
            
            // Draw the current time with a text color that contrasts with the background
            string timeString = DateTime.Now.ToString("HH:mm:ss");
            Brush textBrush = GetContrastingTextBrush();
            e.Graphics.DrawString(timeString, new Font("Arial", 48, FontStyle.Bold), textBrush, new Point(this.Width / 2 - 150, this.Height / 2 - 30));
        }
        
        /// <summary>
        /// Gets a brush with a color that contrasts with the background color.
        /// </summary>
        private Brush GetContrastingTextBrush()
        {
            // Calculate the brightness of the background color
            // Formula: (0.299*R + 0.587*G + 0.114*B) / 255
            double brightness = (0.299 * BackColor.R + 0.587 * BackColor.G + 0.114 * BackColor.B) / 255;
            
            // Use white text for dark backgrounds and black text for light backgrounds
            if (brightness < 0.5)
            {
                return Brushes.White;
            }
            else
            {
                return Brushes.Black;
            }
        }
        
        /// <summary>
        /// Handles the key down event to exit the screen saver.
        /// </summary>
        private void ScreenSaver_KeyDown(object sender, KeyEventArgs e)
        {
            // Exit the screen saver on any key press if configured to do so
            if (exitOnKeyPress)
            {
                this.Close();
            }
        }
        
        /// <summary>
        /// Handles the mouse move event to exit the screen saver.
        /// </summary>
        private void ScreenSaver_MouseMove(object sender, MouseEventArgs e)
        {
            // Exit the screen saver on mouse movement if configured to do so
            if (exitOnKeyPress)
            {
                this.Close();
            }
        }
        
        /// <summary>
        /// Handles the mouse click event to exit the screen saver.
        /// </summary>
        private void ScreenSaver_MouseClick(object sender, MouseEventArgs e)
        {
            // Exit the screen saver on mouse click if configured to do so
            if (exitOnKeyPress)
            {
                this.Close();
            }
        }
        
        /// <summary>
        /// Loads the screen saver settings from the application settings.
        /// </summary>
        public void LoadSettings()
        {
            // Load the exit on data received setting
            exitOnDataReceived = Properties.Settings.Default.ScreenSaverExitOnData;
            
            // Load the exit on key press setting
            exitOnKeyPress = Properties.Settings.Default.ScreenSaverExitOnKeyPress;
            
            // Load the background color setting
            if (Properties.Settings.Default.ScreenSaverBackgroundColor != Color.Empty)
            {
                this.BackColor = Properties.Settings.Default.ScreenSaverBackgroundColor;
            }
        }
        
        /// <summary>
        /// Notifies the screen saver that data has been received from the timing system.
        /// </summary>
        public void OnDataReceived()
        {
            // Exit the screen saver if configured to do so
            if (exitOnDataReceived)
            {
                this.Close();
            }
        }
        
        /// <summary>
        /// Handles the form closed event.
        /// </summary>
        private void ScreenSaver_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Stop the animation timer
            animationTimer.Stop();
            
            // Dispose of the images
            foreach (Image image in images)
            {
                image.Dispose();
            }
            images.Clear();
        }
        
        /// <summary>
        /// Initializes the form components.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ScreenSaver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenSaver";
            this.Text = "Screen Saver";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ScreenSaver_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ScreenSaver_FormClosed);
            this.ResumeLayout(false);
        }
    }
}
