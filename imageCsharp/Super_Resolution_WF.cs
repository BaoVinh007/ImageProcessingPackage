using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Collections;

/*
 * Version 1.0
 * Choose only nearest patch
 * William T. Freeman, Thouis R. Jones, and Egon C. Pasztor,
 * “Example-Based Super-Resolution,” 2002
 * 
 * Version 1.1
 Hong Chang, Dit-Yan Yeung, and Yimin Xiong, 
 * “Super-Resolution Through Neighbor Embedding,” 2004
 * 
 **/

namespace imageCsharp
{
    public partial class Super_Resolution_WF : Form
    {
        // 2 places need to change folder path when use the program on other computer
        // one right here, and another is Combine function
        public string folderPath = @"C:\Users\VinhNguyen\Documents\GitHub\ImageProcessingPackage\";

        public Super_Resolution_WF()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Image File";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackgroundImage = new Bitmap(theDialog.FileName);
                pictureBox2.BackgroundImage = new Bitmap(theDialog.FileName);
                
                // Get only filename of an image without extension and store into label
                label3.Text = Path.GetFileNameWithoutExtension(theDialog.FileName.ToString());
                label5.Visible = true;
                //GetDirectoryName = get full path except filename
                //label3.Text = Path.GetDirectoryName(theDialog.FileName.ToString());                
            }
        }

        private void sortAscending(double[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i+1; j < a.Length; j++)
                {                    
                    if (a[i] >= a[j])
                    {
                        double temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }

        // Version 1.0 - Freeman Method
        //Choose only one closest patch

        private void button2_Click(object sender, EventArgs e)
        {            
            Bitmap bm = (Bitmap) pictureBox1.BackgroundImage;
            
            //label contain filename
            string piece_name = label3.Text;
            //MessageBox.Show("test" + piece_name);            

            //Split piece_name to get only subject name
            string[] arr_subject_name = piece_name.Split('.');
            string subject_name = arr_subject_name[0];
            //MessageBox.Show("test " + subject_name);   

            // Start splitting the Bitmap.
            int numberPatch = generateImagePach(bm, piece_name);
            
            // Find K nearest patches - K = 4,5 it doesn't matter
            int K_Nearest = 4;
            
            // process 64 patches
            //each test patche in 64 patches store K nearest training patches
            
            // ArrayList store 64 arrays which has 4 nearest

            ArrayList listTest_4TrainingPatch = new ArrayList();

            for (int i = 0; i < numberPatch; i++)
            {
                //MessageBox.Show("iteration = " + i);
                
                Bitmap testImagePatch = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TestingImagePatch\" + subject_name + @"\" + piece_name + "abc" + i +".bmp");
                //pictureBox3.BackgroundImage = testImagePatch;
                //MessageBox.Show(@"G:\SPSU\Spring 2014\Research Asisstant Project\SuperResolution\Program\imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + ".centerlight" + i + ".bmp");

                Bitmap trainingImagePatch0 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".1abc" + i + ".bmp");
                Bitmap trainingImagePatch1 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".2abc" + i + ".bmp");
                Bitmap trainingImagePatch2 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".3abc" + i + ".bmp");
                Bitmap trainingImagePatch3 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".4abc" + i + ".bmp");
                Bitmap trainingImagePatch4 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".5abc" + i + ".bmp");
                Bitmap trainingImagePatch5 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".6abc" + i + ".bmp");
                Bitmap trainingImagePatch6 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".7abc" + i + ".bmp");
                Bitmap trainingImagePatch7 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".8abc" + i + ".bmp");
                Bitmap trainingImagePatch8 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".9abc" + i + ".bmp");
                Bitmap trainingImagePatch9 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".10abc" + i + ".bmp");
                Bitmap trainingImagePatch10 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".11abc" + i + ".bmp");
                Bitmap trainingImagePatch11 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".12abc" + i + ".bmp");
                Bitmap trainingImagePatch12 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".13abc" + i + ".bmp");
                Bitmap trainingImagePatch13 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".14abc" + i + ".bmp");
                Bitmap trainingImagePatch14 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".15abc" + i + ".bmp");
                Bitmap trainingImagePatch15 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".16abc" + i + ".bmp");
                Bitmap trainingImagePatch16 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".17abc" + i + ".bmp");
                Bitmap trainingImagePatch17 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".18abc" + i + ".bmp");
                //MessageBox.Show("training = " + folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".1abc" + i + ".bmp");
                //MessageBox.Show("training = " + folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".2abc" + i + ".bmp");
                // calculate euclician distance betweens test patch and training patches
                double[] distance = new double[18];
                distance[0] = EucldianDistanceImages(testImagePatch, trainingImagePatch0);
                distance[1] = EucldianDistanceImages(testImagePatch, trainingImagePatch1);
                distance[2] = EucldianDistanceImages(testImagePatch, trainingImagePatch2);
                distance[3] = EucldianDistanceImages(testImagePatch, trainingImagePatch3);
                distance[4] = EucldianDistanceImages(testImagePatch, trainingImagePatch4);
                distance[5] = EucldianDistanceImages(testImagePatch, trainingImagePatch5);
                distance[6] = EucldianDistanceImages(testImagePatch, trainingImagePatch6);
                distance[7] = EucldianDistanceImages(testImagePatch, trainingImagePatch7);
                distance[8] = EucldianDistanceImages(testImagePatch, trainingImagePatch8);
                distance[9] = EucldianDistanceImages(testImagePatch, trainingImagePatch9);
                distance[10] = EucldianDistanceImages(testImagePatch, trainingImagePatch10);
                distance[11] = EucldianDistanceImages(testImagePatch, trainingImagePatch11);
                distance[12] = EucldianDistanceImages(testImagePatch, trainingImagePatch12);
                distance[13] = EucldianDistanceImages(testImagePatch, trainingImagePatch13);
                distance[14] = EucldianDistanceImages(testImagePatch, trainingImagePatch14);
                distance[15] = EucldianDistanceImages(testImagePatch, trainingImagePatch15);
                distance[16] = EucldianDistanceImages(testImagePatch, trainingImagePatch16);
                distance[17] = EucldianDistanceImages(testImagePatch, trainingImagePatch17);
                //sort array in ascending
                double[] temp_distance = new double[18];
                
                for (int u = 0; u < distance.Length; u++)
                {
                    temp_distance[u] = distance[u];
                }
                                                               
                sortAscending(temp_distance);
                             
                // get K nearest K=4 for each test patch
                                
                int[] nearestPatch = new int[K_Nearest];

                for (int k = 0; k < K_Nearest; k++)
                {
                    nearestPatch[k] = -1;
                }
                int countNearest = 0;

                for (int k = 0; k < K_Nearest; k++)
                {
                    for (int u = 0; u < distance.Length; u++)
                    {
                        if (temp_distance[k] == distance[u] )
                        {
                            int flag = 0;
                            for (int v = 0; v < K_Nearest; v++)
                            {
                                if (u == nearestPatch[v])
                                {
                                    flag = 1;
                                    //v = 4;
                                }
                            }// save position of u
                            if (flag == 0)
                            {
                                nearestPatch[countNearest] = u;
                                //MessageBox.Show("position = " + u);
                                countNearest++;
                                u = temp_distance.Length;
                            }                            
                        }                
                    }
                }
                //add an array which contains 4 nearest into arraylist
                //listTest_4TrainingPatch.Add(nearestPatch);                

                // Version 1.0 choose only one nearest patch
                listTest_4TrainingPatch.Add(nearestPatch[0]);
            }

            
            //Get HR image corresponding, LR
            Bitmap targetHRImagePatch;
            for (int i = 0; i < listTest_4TrainingPatch.Count; i++)
            {
                //MessageBox.Show("postion = " + (int)listTest_4TrainingPatch[i]);
                //i = subject01.centerlight0
                //TargetPatch = mean get centerlight, glasses, noglass...
                int targetPatch = (int)listTest_4TrainingPatch[i];
                string exten = "";
                if (targetPatch == 0)
                {
                    exten = ".1abc"+i;
                }else if (targetPatch == 1)
                {
                    exten = ".2abc" + i;
                }else if (targetPatch == 2)
                {
                    exten = ".3abc" + i;
                }else if (targetPatch == 3)
                {
                    exten = ".4abc" + i;
                }else if (targetPatch == 4)
                {
                    exten = ".5abc" + i;
                }else if (targetPatch == 5)
                {
                    exten = ".6abc" + i;
                }else if (targetPatch == 6)
                {
                    exten = ".7abc" + i;
                }else if (targetPatch == 7)
                {
                    exten = ".8abc" + i;
                }else if (targetPatch == 8)
                {
                    exten = ".9abc" + i;
                }else if (targetPatch == 9)
                {
                    exten = ".10abc" + i;
                } else if (targetPatch == 10)
                {
                    exten = ".11abc" + i;
                }
                else if (targetPatch == 11)
                {
                    exten = ".12abc" + i;
                }
                else if (targetPatch == 12)
                {
                    exten = ".13abc" + i;
                }
                else if (targetPatch == 13)
                {
                    exten = ".14abc" + i;
                }
                else if (targetPatch == 14)
                {
                    exten = ".15abc" + i;
                }
                else if (targetPatch == 15)
                {
                    exten = ".16abc" + i;
                }
                else if (targetPatch == 16)
                {
                    exten = ".17abc" + i;
                }
                else if (targetPatch == 17)
                {
                    exten = ".18abc" + i;
                }

                Bitmap trainingHRImagePatch = new Bitmap(folderPath + @"imageCsharp\bin\Debug\HR_TrainingImagePatch\" + subject_name + @"\" + subject_name + exten + ".bmp");
                targetHRImagePatch = new Bitmap(trainingHRImagePatch);
                targetHRImagePatch.Save(folderPath + @"imageCsharp\bin\Debug\HR_TargetImagePatch\" + subject_name + @"\" + piece_name + ".target" + i + ".bmp");
            }

            // Generate HR image

            //get all the files in a directory
            string[] files = Directory.GetFiles(folderPath + @"imageCsharp\bin\Debug\HR_TargetImagePatch");

            //combine them into one image
            Bitmap stitchedImage = CombinePacth(files, subject_name, piece_name);
            pictureBox3.BackgroundImage = stitchedImage;
            //save the new image
            stitchedImage.Save(folderPath + @"imageCsharp\bin\Debug\" + piece_name + "_HR.bmp", ImageFormat.Bmp);
            
        }

        public static Bitmap CombinePacth(string[] files, string subject_name, string piece_name)
        {
            //change folder Path when use it on others comuter
            string folderPath = @"C:\Users\VinhNguyen\Documents\GitHub\ImageProcessingPackage\";

            //read all images into memory
            List<Bitmap> images = new List<Bitmap>();
            Bitmap finalImage = null;
            //MessageBox.Show("so file = " + files.Length);                       

            //create a bitmap to hold the combined image
            finalImage = new Bitmap(256, 256);
            
            //get a graphics object from the image so we can draw on it
            using (Graphics g = Graphics.FromImage(finalImage))
            {
                //set background color
                g.Clear(Color.White);

                //go through each image and draw it on the final image
                int offsetW = 0;
                int offsetH = 0;
                int temp_count = 0;
                
                for (int i = 0; i < 64; i++)
                {
                    Bitmap image = new Bitmap( folderPath + @"imageCsharp\bin\Debug\HR_TargetImagePatch\" + subject_name + @"\" + piece_name + ".target" + i + ".bmp");

                    if (temp_count < 8)
                    {
                        if (i % 8 == 1 && i > 8)
                        {
                            offsetW += image.Width;
                        }
                        g.DrawImage(image, new Rectangle(offsetW, offsetH, image.Width, image.Height));
                        offsetW += image.Width;
                        temp_count++;
                    }
                    else if (temp_count == 8)
                    {
                        offsetW = 0;
                        offsetH += image.Height;
                        g.DrawImage(image, new Rectangle(offsetW, offsetH, image.Width, image.Height));
                        temp_count = 1;
                    }
                    //pictureBox3.BackgroundImage = finalImage;
                    //save the new image
                    finalImage.Save(folderPath + @"imageCsharp\bin\Debug\" + piece_name + "_HR.bmp", ImageFormat.Bmp);
                    //Console.WriteLine("i = " + i + " img = " + @"imageCsharp\bin\Debug\HR_TargetImagePatch\" + subject_name + @"\" + piece_name + ".target" + i + ".bmp");
                }
            }

            return finalImage;
            
            
        }

        private double CalEuclideanDistance(Color p, Color c)
        {
            return Math.Pow(p.R - c.R, 2.0) + Math.Pow(p.G - c.G, 2.0) + Math.Pow(p.B - c.B, 2.0);
        }

        private double EucldianDistanceImages(Bitmap bm1, Bitmap bm2)
        {
            //Point p = new Point();
            double distance = 0;
            for (int i = 0; i < bm1.Height; i++)
            {
                for (int j = 0; j < bm1.Width; j++)
                {
                    Color c1 = bm1.GetPixel(i, j);
                    Color c2 = bm2.GetPixel(i, j);
                    distance += CalEuclideanDistance(c1, c2);
                }
            }
            return Math.Sqrt(distance);
        }

        private int generateImagePach(Bitmap bm, string piece_name)
        {
            // Set width and height of an image patch
            int wid = 4;
            int hgt = 4;

            Bitmap piece = new Bitmap(wid, hgt);
            Rectangle dest_rect = new Rectangle(0, 0, wid, hgt);
            using (Graphics gr = Graphics.FromImage(piece))
            {
                //Split piece_name to get only subject name
                string[] arr_subject_name = piece_name.Split('.');
                string subject_name = arr_subject_name[0];
                //MessageBox.Show("test " + subject_name); 

                int num_rows = bm.Height / hgt;
                int num_cols = bm.Width / wid;
                Rectangle source_rect = new Rectangle(0, 0, wid, hgt);
                int count = 0;
                for (int row = 0; row < num_rows; row++)
                {
                    source_rect.X = 0;
                    for (int col = 0; col < num_cols; col++)
                    {
                        // Copy the piece of the image.
                        gr.DrawImage(bm, dest_rect, source_rect, GraphicsUnit.Pixel);

                        // Save the piece.
                        string filename = piece_name + "abc" + count + ".bmp";
                        //MessageBox.Show("Name = " + folderPath + @"imageCsharp\bin\Debug\LR_TestingImagePatch\" + subject_name + @"\" + filename);
                        //piece.Save(folderPath + @"imageCsharp\bin\Debug\HR_TrainingImagePatch\" + subject_name + @"\" + filename, ImageFormat.Bmp);
                        piece.Save(folderPath + @"imageCsharp\bin\Debug\LR_TestingImagePatch\" + subject_name + @"\" + filename, ImageFormat.Bmp);
                        //piece.Save(@"G:\SPSU\Spring 2014\Research Asisstant Project\SuperResolution\Program\imageCsharp\bin\Debug\LR_TestingImagePatch\subject01" + filename, ImageFormat.Bmp);
                        // Move to the next column.
                        source_rect.X += wid;
                        count++;
                    }
                    source_rect.Y += hgt;
                }
                MessageBox.Show("Created " + num_rows * num_cols + " files",
                    "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return num_rows * num_cols;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
            Bitmap bm = (Bitmap)pictureBox1.BackgroundImage;

            //label contain filename
            string piece_name = label3.Text;
            //MessageBox.Show("test" + piece_name);            

            //Split piece_name to get only subject name
            string[] arr_subject_name = piece_name.Split('.');
            string subject_name = arr_subject_name[0];
            //MessageBox.Show("test " + subject_name);   

            // Start splitting the Bitmap.
            int numberPatch = generateImagePach(bm, piece_name);
            /*
            // Find K nearest patches - K = 4,5 it doesn't matter
            int K_Nearest = 4;

            // process 64 patches
            //each test patche in 64 patches store K nearest training patches

            // ArrayList store 64 arrays which has 4 nearest

            ArrayList listTest_4TrainingPatch = new ArrayList();

            for (int i = 0; i < numberPatch; i++)
            {
                //MessageBox.Show("iteration = " + i);

                Bitmap testImagePatch = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TestingImagePatch\" + subject_name + @"\" + piece_name + i + ".bmp");
                //pictureBox3.BackgroundImage = testImagePatch;
                //MessageBox.Show(@"G:\SPSU\Spring 2014\Research Asisstant Project\SuperResolution\Program\imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + ".centerlight" + i + ".bmp");

                Bitmap trainingImagePatch0 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".centerlight" + i + ".bmp");
                Bitmap trainingImagePatch1 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".glasses" + i + ".bmp");
                Bitmap trainingImagePatch2 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".happy" + i + ".bmp");
                Bitmap trainingImagePatch3 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".leftlight" + i + ".bmp");
                Bitmap trainingImagePatch4 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".noglasses" + i + ".bmp");
                Bitmap trainingImagePatch5 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".rightlight" + i + ".bmp");
                Bitmap trainingImagePatch6 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".sad" + i + ".bmp");
                Bitmap trainingImagePatch7 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".sleepy" + i + ".bmp");
                Bitmap trainingImagePatch8 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".surprised" + i + ".bmp");
                Bitmap trainingImagePatch9 = new Bitmap(folderPath + @"imageCsharp\bin\Debug\LR_TrainingImagePatch\" + subject_name + @"\" + subject_name + ".wink" + i + ".bmp");

                // calculate euclician distance betweens test patch and training patches
                double[] distance = new double[10];
                distance[0] = EucldianDistanceImages(testImagePatch, trainingImagePatch0);
                distance[1] = EucldianDistanceImages(testImagePatch, trainingImagePatch1);
                distance[2] = EucldianDistanceImages(testImagePatch, trainingImagePatch2);
                distance[3] = EucldianDistanceImages(testImagePatch, trainingImagePatch3);
                distance[4] = EucldianDistanceImages(testImagePatch, trainingImagePatch4);
                distance[5] = EucldianDistanceImages(testImagePatch, trainingImagePatch5);
                distance[6] = EucldianDistanceImages(testImagePatch, trainingImagePatch6);
                distance[7] = EucldianDistanceImages(testImagePatch, trainingImagePatch7);
                distance[8] = EucldianDistanceImages(testImagePatch, trainingImagePatch8);
                distance[9] = EucldianDistanceImages(testImagePatch, trainingImagePatch9);

                //sort array in ascending
                double[] temp_distance = new double[10];

                for (int u = 0; u < distance.Length; u++)
                {
                    temp_distance[u] = distance[u];
                }

                sortAscending(temp_distance);

                // get K nearest K=4 for each test patch

                int[] nearestPatch = new int[K_Nearest];

                for (int k = 0; k < K_Nearest; k++)
                {
                    nearestPatch[k] = -1;
                }
                int countNearest = 0;

                for (int k = 0; k < K_Nearest; k++)
                {
                    for (int u = 0; u < distance.Length; u++)
                    {
                        if (temp_distance[k] == distance[u])
                        {
                            int flag = 0;
                            for (int v = 0; v < K_Nearest; v++)
                            {
                                if (u == nearestPatch[v])
                                {
                                    flag = 1;
                                    //v = 4;
                                }
                            }// save position of u
                            if (flag == 0)
                            {
                                nearestPatch[countNearest] = u;
                                //MessageBox.Show("position = " + u);
                                countNearest++;
                                u = temp_distance.Length;
                            }
                        }
                    }
                }
                //add an array which contains 4 nearest into arraylist
                //listTest_4TrainingPatch.Add(nearestPatch);                

                // Version 1.0 choose only one nearest patch
                listTest_4TrainingPatch.Add(nearestPatch[0]);
            }


            //Get HR image corresponding, LR
            Bitmap targetHRImagePatch;
            for (int i = 0; i < listTest_4TrainingPatch.Count; i++)
            {
                //MessageBox.Show("postion = " + (int)listTest_4TrainingPatch[i]);
                //i = subject01.centerlight0
                //TargetPatch = mean get centerlight, glasses, noglass...
                int targetPatch = (int)listTest_4TrainingPatch[i];
                string exten = "";
                if (targetPatch == 0)
                {
                    exten = ".centerlight" + i;
                }
                if (targetPatch == 1)
                {
                    exten = ".glasses" + i;
                }
                if (targetPatch == 2)
                {
                    exten = ".happy" + i;
                }
                if (targetPatch == 3)
                {
                    exten = ".leftlight" + i;
                }
                if (targetPatch == 4)
                {
                    exten = ".noglasses" + i;
                }
                if (targetPatch == 5)
                {
                    exten = ".rightlight" + i;
                }
                if (targetPatch == 6)
                {
                    exten = ".sad" + i;
                }
                if (targetPatch == 7)
                {
                    exten = ".sleepy" + i;
                }
                if (targetPatch == 8)
                {
                    exten = ".surprised" + i;
                }
                if (targetPatch == 9)
                {
                    exten = ".wink" + i;
                }

                Bitmap trainingHRImagePatch = new Bitmap(folderPath + @"imageCsharp\bin\Debug\HR_TrainingImagePatch\" + subject_name + @"\" + subject_name + exten + ".bmp");
                targetHRImagePatch = new Bitmap(trainingHRImagePatch);
                targetHRImagePatch.Save(folderPath + @"imageCsharp\bin\Debug\HR_TargetImagePatch\" + subject_name + @"\" + subject_name + ".target" + i + ".bmp");
            }

            // Generate HR image

            //get all the files in a directory
            string[] files = Directory.GetFiles(folderPath + @"imageCsharp\bin\Debug\HR_TargetImagePatch");

            //combine them into one image
            Bitmap stitchedImage = CombinePacth(files, subject_name, piece_name);
            pictureBox3.BackgroundImage = stitchedImage;
            //save the new image
            stitchedImage.Save(folderPath + @"imageCsharp\bin\Debug\" + subject_name + "_HR.bmp", ImageFormat.Bmp);
            */

        }

        // Load a Bitmap without locking its file.
        /*
        private Bitmap LoadUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                Bitmap copied_bm = new Bitmap(bm.Width, bm.Height);
                using (Graphics gr = Graphics.FromImage(copied_bm))
                {
                    gr.DrawImage(bm, 0, 0);
                }
                return copied_bm;
            }
        }
        */
    }
}
