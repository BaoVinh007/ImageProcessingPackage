using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace imageCsharp
{
    public partial class ImageWindow : Form
    {
        #region ImageWindow overload
        public ImageWindow()
        {
            InitializeComponent();
        }

        public ImageWindow(string path)
        {
            InitializeComponent();

            pictureBox1.ImageLocation = path;
        }

        public ImageWindow(Image image)
        {
            InitializeComponent();

            pictureBox1.Image = image;
            ImageFitToWindow();
        }
        #endregion ImageWindow overload end

        // method to adjust a window so that input image can be fitted into 
        public void ImageFitToWindow()
        {
            this.Height = this.pictureBox1.Image.Height;
            this.Width = this.pictureBox1.Image.Width;
        }
        
        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ImageFitToWindow();

            if (!string.IsNullOrWhiteSpace(this.pictureBox1.ImageLocation))
            {
                this.Text = "Original Image Path Info: " + this.pictureBox1.ImageLocation;
            }
        }
 
        
        #region pixel information methods

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            int x, y;
            x = e.X;
            y = e.Y;
            string xCoord = x.ToString();
            string yCoord = y.ToString();

            if (pictureBox1.Image != null)
            {
                Bitmap b = (Bitmap)pictureBox1.Image;
                try
                {
                    if (x <= this.pictureBox1.Image.Width && y <= this.pictureBox1.Image.Height)
                    {
                        Color c = b.GetPixel(x, y);
                        label1.Text = string.Format("[X Coordinate: " + xCoord + "  " + "Y Coordinate: " + yCoord + "]       " +
                        "[Red: " + c.R.ToString() + " Green: " + c.G.ToString() + " Blue: " + c.B.ToString() + "]");
                    }
                }
                catch
                {
                  //  MessageBox.Show("Mouse pointer out of boundary");
                }

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
            int[] intensityR = new int[256];

            if (chart1.Visible == false)
            {
                chart1.Visible = true;
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                Bitmap b = (Bitmap)pictureBox1.Image;
                
                for (int i = 0; i < this.pictureBox1.Image.Width; i++)
                    for (int j = 0; j < this.pictureBox1.Image.Height; j++)
                    {
                        Color c = b.GetPixel(i, j);
                        intensityR[c.R] += 1;
                    }

                for (int k = 0; k < 256; k++)
                {
                    this.chart1.Series["Frequency"].Points.AddXY(" ", intensityR[k]);
                }
            }
            
               
            else
            {
                chart1.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            int[] intensityG = new int[256];

            if (chart2.Visible == false)
            {
                chart2.Visible = true;
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                Bitmap b = (Bitmap)pictureBox1.Image;

                for (int i = 0; i < this.pictureBox1.Image.Width; i++)
                    for (int j = 0; j < this.pictureBox1.Image.Height; j++)
                    {
                        Color c = b.GetPixel(i, j);
                        intensityG[c.G] += 1;
                    }

                for (int k = 0; k < 256; k++)
                {
                    this.chart2.Series["Frequency"].Points.AddXY(" ", intensityG[k]);
                }
            }


            else
            {
                chart2.Visible = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            int[] intensityB = new int[256];

            if (chart3.Visible == false)
            {
                chart3.Visible = true;
                foreach (var series in chart3.Series)
                {
                    series.Points.Clear();
                }
                Bitmap b = (Bitmap)pictureBox1.Image;

                for (int i = 0; i < this.pictureBox1.Image.Width; i++)
                    for (int j = 0; j < this.pictureBox1.Image.Height; j++)
                    {
                        Color c = b.GetPixel(i, j);
                        intensityB[c.B] += 1;
                    }

                for (int k = 0; k < 256; k++)
                {
                    this.chart3.Series["Frequency"].Points.AddXY(" ", intensityB[k]);
                }
            }


            else
            {
                chart3.Visible = false;
            }
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("clicked");

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x, y;
            x = e.X;
            y = e.Y;
            string xCoord = x.ToString();
            string yCoord = y.ToString();
            //MessageBox.Show("x = " + xCoord + " y = " + yCoord);
            System.Drawing.Pen myPen;
            myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            formGraphics.DrawLine(myPen, 0, 0, x, y);
            myPen.Dispose();

            formGraphics.Dispose();
            /*
            Pen blackPen = new Pen(Color.Black, 3);

            int x1 = 100;
            int y1 = 100;
            int x2 = 500;
            int y2 = 100;
            // Draw line to screen.
            using (var graphics = Graphics.FromImage(pictureBox1.Image))
            {
                graphics.DrawLine(blackPen, x1, y1, x, y);
            }
            */

        }
    }
}
