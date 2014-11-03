// Course: CS6563
// Student name: Vinh Nguyen
// Student ID: 000200899
// Assignment #: #1
// Due Date: 10/08/2013
// Signature: _Vinh_____________
// (The signature means that the program is your own work)
// Score: ______________

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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            // initializing file menu: does not allow save
            this.saveToolStripMenuItem.Enabled = false; 
        }
           
        // File menu 
        // 1. Open
        // 2. Save
        // 3. Exit
        #region File Menu methods
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog(this) != System.Windows.Forms.DialogResult.Cancel)
            {
                try
                {
                    var myImageWindow = new ImageWindow(openFileDialog1.FileName);
                    this.IsMdiContainer = true;
                    myImageWindow.MdiParent = this;
                    myImageWindow.Show();
                    this.ActivateMdiChild(myImageWindow);
                    this.saveToolStripMenuItem.Enabled = true;
    
                }
                catch
                {
                    MessageBox.Show("Unable to insert image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.ShowDialog();

            if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                var imageWin = (ImageWindow)this.ActiveMdiChild;
                var image = imageWin.pictureBox1.Image;

                try
                {
                    image.Save(saveFileDialog1.FileName);
                    imageWin.Text = saveFileDialog1.FileName;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    MessageBox.Show(exception.StackTrace);
                }
            }

   
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        // Transformations menu
        // 1. Mirror
        // 2. GrayScale
        // 6. Copy image
        #region Transformations menu list
        
        // #1 mirror transformation
        private void mirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cursor Class 
            // to display a wait cursor over the application while the file loads
            // or saves to prevent any mouse events from being processed. 
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var source = (ImageWindow)this.ActiveMdiChild;
                if (source != null)
                {
                    var newImage = new ImageWindow(Transformations.Mirror(source.pictureBox1.Image));

                    newImage.Text = "Mirror Conversion";
                    newImage.MdiParent = this;
                    newImage.Show();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.StackTrace);
            }

            finally
            {
                // When the process is complete, set the Current property to Cursors.Default 
                // for the application to display the appropriate cursor over each control type.
                Cursor.Current = Cursors.Default;
            }
        }

        // #2 gray color transformation
        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var source = (ImageWindow)this.ActiveMdiChild;
                if (source != null)
                {
                    var newImage = new ImageWindow(Transformations.ColorToGrayscale(source.pictureBox1.Image));

                    newImage.Text = "Grayscale Conversion";
                    newImage.MdiParent = this;
                    newImage.Show();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.StackTrace);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        
        // #6 copy image
        private void copyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var source = (ImageWindow)this.ActiveMdiChild;
                if (source != null)
                {
                    var imageWin = new ImageWindow(Transformations.CopyImage(source.pictureBox1.Image));

                    imageWin.Text = "Duplicate image";
                    imageWin.MdiParent = this;
                    imageWin.Show();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.StackTrace);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion 

        // Segmentations menu 
        #region Segmentations method list

        


        #endregion 

        // Filter menu 
        #region Filter method list

       
        #endregion 

        // Edge and Corner Detection menu
        // 1. Simple edge detection
        #region EdgeCorner method list
        
        // #1 simple edge detection
        private void simpleEdgeDetectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var source = (ImageWindow)this.ActiveMdiChild;
                if (source != null)
                {
                    var imageWin = new ImageWindow(EdgeCorners.simpleEdgeDetect(source.pictureBox1.Image));

                    imageWin.Text = "Simple Edge Detection";
                    imageWin.MdiParent = this;
                    imageWin.Show();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.StackTrace);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        
        #endregion 

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Contact Vinh Nguyen : vnguyen7@spsu.edu\nCreated By Vinh Nguyen\nCS Department, SPSU");
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void negateImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var source = (ImageWindow)this.ActiveMdiChild;
                if (source != null)
                {
                    var newImage = new ImageWindow(Transformations.NegateImage(source.pictureBox1.Image));

                    newImage.Text = "Negate Conversion";
                    newImage.MdiParent = this;
                    newImage.Show();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.StackTrace);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void tomitaFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var source = (ImageWindow)this.ActiveMdiChild;
                if (source != null)
                {
                    var newImage = new ImageWindow(Filters.TomitaFilter(source.pictureBox1.Image));

                    newImage.Text = "Tomita Filter";
                    newImage.MdiParent = this;
                    newImage.Show();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.StackTrace);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void nagaoFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var source = (ImageWindow)this.ActiveMdiChild;
                if (source != null)
                {
                    var newImage = new ImageWindow(Filters.NagaoFilter(source.pictureBox1.Image));

                    newImage.Text = "Nagao Filter";
                    newImage.MdiParent = this;
                    newImage.Show();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.StackTrace);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void sigmaFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var source = (ImageWindow)this.ActiveMdiChild;
                if (source != null)
                {
                    var newImage = new ImageWindow(Filters.SigmaFilter(source.pictureBox1.Image));

                    newImage.Text = "Sigma Filter";
                    newImage.MdiParent = this;
                    newImage.Show();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.StackTrace);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void fuzzyCMeanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var source = (ImageWindow)this.ActiveMdiChild;
                if (source != null)
                {
                    var newImage = new ImageWindow(Segmentations.FuzzyC_Means(source.pictureBox1.Image));

                    newImage.Text = "Fuzzy C-Means";
                    newImage.MdiParent = this;
                    newImage.Show();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.StackTrace);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void kMeanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var source = (ImageWindow)this.ActiveMdiChild;
                if (source != null)
                {
                    var newImage = new ImageWindow(Segmentations.K_Means(source.pictureBox1.Image));

                    newImage.Text = "K-Means";
                    newImage.MdiParent = this;
                    newImage.Show();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.StackTrace);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void fourierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var source = (ImageWindow)this.ActiveMdiChild;
                if (source != null)
                {
                    var newImage = new ImageWindow(Transformations.DFT(source.pictureBox1.Image, 0));

                    newImage.Text = "DFT-Magnitude";
                    newImage.MdiParent = this;
                    newImage.Show();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.StackTrace);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void dFTInverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var source = (ImageWindow)this.ActiveMdiChild;
                if (source != null)
                {
                    var newImage = new ImageWindow(Transformations.DFT(source.pictureBox1.Image, 1));

                    newImage.Text = "DFT-Phase";
                    newImage.MdiParent = this;
                    newImage.Show();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.StackTrace);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void dFTInverseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var source = (ImageWindow)this.ActiveMdiChild;
                if (source != null)
                {
                    var newImage = new ImageWindow(Transformations.DFT(source.pictureBox1.Image, -1));

                    newImage.Text = "DFT-Inverse";
                    newImage.MdiParent = this;
                    newImage.Show();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.StackTrace);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void dFTRealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var source = (ImageWindow)this.ActiveMdiChild;
                if (source != null)
                {
                    var newImage = new ImageWindow(Transformations.DFT(source.pictureBox1.Image, 2));

                    newImage.Text = "DFT-Real";
                    newImage.MdiParent = this;
                    newImage.Show();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.StackTrace);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void dFTImaginaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var source = (ImageWindow)this.ActiveMdiChild;
                if (source != null)
                {
                    var newImage = new ImageWindow(Transformations.DFT(source.pictureBox1.Image, 3));

                    newImage.Text = "DFT-Imaginary";
                    newImage.MdiParent = this;
                    newImage.Show();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.StackTrace);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void fFTRealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var source = (ImageWindow)this.ActiveMdiChild;
                if (source != null)
                {
                    var newImage = new ImageWindow(Transformations.FFT(source.pictureBox1.Image, 3));

                    newImage.Text = "FFT-Real";
                    newImage.MdiParent = this;
                    newImage.Show();
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.StackTrace);
            }

            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void superResolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var SRForm = new Super_Resolution_WF();
            SRForm.Show();
        }

    }
}
