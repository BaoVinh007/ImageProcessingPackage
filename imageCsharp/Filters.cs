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
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections;

namespace imageCsharp 
{
    #region various filters
    class Filters : ArrayImageConverter
    {
        // getMeanSmallestVariance = get mean with smallest variance
        public static int getMeanSmallestVariance(ArrayList a)
        {
            double variance_smallest = 0;
            int mean = 0;

            // Assign variance and mean of first element in arraylist to 2 variables: variance_smallest and mean, then break the loop

            foreach (double[] mean_var in a)
            {
                variance_smallest = mean_var[1];
                mean = (int)mean_var[0];
                break;
            }
            // Find smallest variance and get corresponding mean 
            foreach (double[] mean_var in a)
            {                
                if (mean_var[1] < variance_smallest)
                {
                    variance_smallest = mean_var[1];
                    mean = (int)mean_var[0];
                }
            }            
            return mean;
        }

        // getMeanVariance(...) return an array that contains mean and variance               

        //#1 Tomita Filter

        public static Image TomitaFilter(Image image)
        {
            Size size = image.Size;

            int[, ,] sourceArgb = ImageToArgbArray(image);
            int[, ,] targetArgb = GetNewArgbArray(size);
            Array.Copy(sourceArgb, targetArgb, sourceArgb.Length);
            ArrayList mean_variance = new ArrayList();
            
            // Set up size window
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter your window size (3,5,7...)", "Mask", "Type here...", 250, 250);
            int SizeWindow = int.Parse(input);                      

            // default window size = 3, if user enter  wrong input 
            if (SizeWindow == 1 || SizeWindow % 2 == 0)
                SizeWindow = 5;
            MessageBox.Show("Window size is set to " + "(" + SizeWindow + "x" + SizeWindow + ")" + "\nPress OK to continue");
                        
            // A size variable to modify correctly correspond with window size
            int temp = SizeWindow / 2;                       
            
            for (int colorComponent = 1; colorComponent < 4; colorComponent++)
                for (int x = temp; x < size.Width - temp; x++)
                    for (int y = temp; y < size.Height - temp; y++)
                    {
                        //Mask #1 center center mask 

                        int _sum = 0;
                        int _count = 0;
                        int temp1 = temp / 2;
                        for (int i = -temp1; i <= temp1; i++)
                            for (int j = -temp1; j <= temp1; j++)
                            {
                                _sum += sourceArgb[colorComponent, x - i, y - j];
                                _count++;
                            }
                        int mean = _sum / _count;
                        
                        double _variance = 0;
                                                
                        for (int i = -temp1; i <= temp1; i++)
                            for (int j = -temp1; j <= temp1; j++)
                            {
                                _variance += Math.Pow((sourceArgb[colorComponent, x - i, y - j] - mean), 2);
                            }

                        _variance = _variance / _count;
                        double[] mean_var1 = new double[2];
                        mean_var1[0] = mean;
                        mean_var1[1] = _variance;

                        // std means standard deviation
                        mean_variance.Add(mean_var1);
             
                        //Mask #2 top left mask

                        _sum = 0;
                        _count = 0;
                        
                        for (int i = 0; i <= temp; i++)
                            for (int j = 0; j <= temp; j++)
                            {
                                _sum += sourceArgb[colorComponent, x - i, y - j];
                                _count++;
                            }
                        mean = _sum / _count;

                        _variance = 0;

                        for (int i = 0; i <= temp; i++)
                            for (int j = 0; j <= temp; j++)
                            {
                                _variance += Math.Pow((sourceArgb[colorComponent, x - i, y - j] - mean), 2);
                            }

                        _variance = _variance / _count;

                        double[] mean_var2 = new double[2];
                        mean_var2[0] = mean;
                        mean_var2[1] = _variance;

                        // std means standard deviation
                        mean_variance.Add(mean_var2);
                                                             
                        //Mask #3 top right mask

                        _sum = 0;
                        _count = 0;

                        for (int i = 0; i <= temp; i++)
                            for (int j = -temp; j <= 0; j++)
                            {
                                _sum += sourceArgb[colorComponent, x - i, y - j];
                                _count++;
                            }
                        mean = _sum / _count;
                        
                        _variance = 0;

                        for (int i = 0; i <= temp; i++)
                            for (int j = -temp; j <= 0; j++)
                            {
                                _variance += Math.Pow((sourceArgb[colorComponent, x - i, y - j] - mean), 2);
                            }

                        _variance = _variance / _count;
                        double[] mean_var3 = new double[2];
                        mean_var3[0] = mean;
                        mean_var3[1] = _variance;

                        // std means standard deviation
                        mean_variance.Add(mean_var3);
             
                        //Mask #4 bottom right mask

                        _sum = 0;
                        _count = 0;

                        for (int i = -temp; i <= 0; i++)
                            for (int j = -temp; j <= 0; j++)
                            {
                                _sum += sourceArgb[colorComponent, x - i, y - j];
                                _count++;
                            }
                        mean = _sum / _count;

                        _variance = 0;

                        for (int i = -temp; i <= 0; i++)
                            for (int j = -temp; j <= 0; j++)
                            {
                                _variance += Math.Pow((sourceArgb[colorComponent, x - i, y - j] - mean), 2);
                            }

                        _variance = _variance / _count;
                        double[] mean_var4 = new double[2];
                        mean_var4[0] = mean;
                        mean_var4[1] = _variance;

                        // std means standard deviation
                        mean_variance.Add(mean_var4);
             
                        //Mask #5 bottom left mask

                        _sum = 0;
                        _count = 0;

                        for (int i = -temp; i <= 0; i++)
                            for (int j = 0; j <= temp; j++)
                            {
                                _sum += sourceArgb[colorComponent, x - i, y - j];
                                _count++;
                            }
                        mean = _sum / _count;

                        _variance = 0;

                        for (int i = -temp; i <= 0; i++)
                            for (int j = 0; j <= temp; j++)
                            {
                                _variance += Math.Pow((sourceArgb[colorComponent, x - i, y - j] - mean), 2);
                            }

                        _variance = _variance / _count;
                        double[] mean_var5 = new double[2];
                        mean_var5[0] = mean;
                        mean_var5[1] = _variance;

                        // std means standard deviation
                        mean_variance.Add(mean_var5);
                                                             
                        // Get Mean with Smallest Variance
                        targetArgb[colorComponent, x, y] = getMeanSmallestVariance(mean_variance);

                        // Reset ArrayList mean_variance by remove all existing element
                        mean_variance.Clear();
                    }

            return ArgbArrayToImage(targetArgb);
        }

        //#2 Nagao Filter

        public static Image NagaoFilter(Image image)
        {
            Size size = image.Size;

            int[, ,] sourceArgb = ImageToArgbArray(image);
            int[, ,] targetArgb = GetNewArgbArray(size);
            Array.Copy(sourceArgb, targetArgb, sourceArgb.Length);

            ArrayList mean_variance = new ArrayList();

            // Set up size window
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter your window size (3,5,7...)", "Mask", "Type here...", 250, 250);
            int SizeWindow = int.Parse(input);

            // default window size = 3, if user enter  wrong input 
            if (SizeWindow == 1 || SizeWindow % 2 == 0)
                SizeWindow = 5;
            MessageBox.Show("Window size is set to " + "(" + SizeWindow + "x" + SizeWindow + ")" + "\nPress OK to continue");

            // A size variable to modify correctly correspond with window size
            int temp = SizeWindow / 2;

            for (int colorComponent = 1; colorComponent < 4; colorComponent++)
                for (int x = temp; x < size.Width - temp; x++)
                    for (int y = temp; y < size.Height - temp; y++)
                    {                        
                        //Mask #1 center center

                        int _sum = 0;
                        int _count = 0;
                        int temp1 = temp / 2;
                        for (int i = -temp1; i <= temp1; i++)
                            for (int j = -temp1; j <= temp1; j++)
                            {
                                _sum += sourceArgb[colorComponent, x - i, y - j];
                                _count++;
                            }
                        int mean = _sum / _count;

                        double _variance = 0;

                        for (int i = -temp1; i <= temp1; i++)
                            for (int j = -temp1; j <= temp1; j++)
                            {
                                _variance += Math.Pow((sourceArgb[colorComponent, x - i, y - j] - mean), 2);
                            }

                        _variance = _variance / _count;
                        double[] mean_var1 = new double[2];
                        mean_var1[0] = mean;
                        mean_var1[1] = _variance;

                        // std means standard deviation
                        mean_variance.Add(mean_var1);
                                                
                        //Mask #2 top center 

                        _sum = 0;
                        _count = 0;
                        
                        for (int i = 0; i <= temp; i++)
                            for (int j = -1; j <= 1; j++)
                            {
                                if (i == 0 && (j == 1 || j == -1))
                                {}                                                           
                                else 
                                {
                                    _sum += sourceArgb[colorComponent, x - i, y - j];
                                    _count++;
                                }
                            }
                        mean = _sum / _count;

                        _variance = 0;

                        for (int i = 0; i <= temp; i++)
                            for (int j = -1; j <= 1; j++)
                            {
                                if (i == 0 && (j == 1 || j == -1))
                                {}
                                else
                                    _variance += Math.Pow((sourceArgb[colorComponent, x - i, y - j] - mean), 2);                                
                            }

                        _variance = _variance / _count;

                        double[] mean_var2 = new double[2];
                        mean_var2[0] = mean;
                        mean_var2[1] = _variance;

                        // std means standard deviation
                        mean_variance.Add(mean_var2);                                              

                        //Mask #3 right center 
                        
                        _sum = 0;
                        _count = 0;

                        for (int i = -1; i <= 1; i++)
                            for (int j = -temp; j <= 0; j++)
                            {
                                if (j == 0 && (i == 1 || i == -1))
                                { }
                                else
                                {
                                    _sum += sourceArgb[colorComponent, x - i, y - j];
                                    _count++;
                                }
                            }
                        mean = _sum / _count;

                        _variance = 0;

                        for (int i = -1; i <= 1; i++)
                            for (int j = -temp; j <= 0; j++)
                            {
                                if (j == 0 && (i == 1 || i == -1))
                                { }
                                else
                                    _variance += Math.Pow((sourceArgb[colorComponent, x - i, y - j] - mean), 2);
                            }

                        _variance = _variance / _count;

                        double[] mean_var3 = new double[2];
                        mean_var3[0] = mean;
                        mean_var3[1] = _variance;

                        // std means standard deviation
                        mean_variance.Add(mean_var3);                                              

                        //Mask #4 bottom center 
                        
                        _sum = 0;
                        _count = 0;

                        for (int i = -temp; i <= 0; i++)
                            for (int j = -1; j <= 1; j++)
                            {
                                if (i == 0 && (j == 1 || j == -1))
                                { }
                                else
                                {
                                    _sum += sourceArgb[colorComponent, x - i, y - j];
                                    _count++;
                                }
                            }
                        mean = _sum / _count;

                        _variance = 0;

                        for (int i = -temp; i <= 0; i++)
                            for (int j = -1; j <= 1; j++)
                            {
                                if (i == 0 && (j == 1 || j == -1))
                                { }
                                else
                                    _variance += Math.Pow((sourceArgb[colorComponent, x - i, y - j] - mean), 2);
                            }

                        _variance = _variance / _count;

                        double[] mean_var4 = new double[2];
                        mean_var4[0] = mean;
                        mean_var4[1] = _variance;

                        // std means standard deviation
                        mean_variance.Add(mean_var4);                                              

                        //Mask #5 left center 
                       
                        _sum = 0;
                        _count = 0;

                        for (int i = -1; i <= 1; i++)
                            for (int j = 0; j <= temp; j++)
                            {
                                if (j == 0 && (i == 1 || i == -1))
                                { }
                                else
                                {
                                    _sum += sourceArgb[colorComponent, x - i, y - j];
                                    _count++;
                                }
                            }
                        mean = _sum / _count;

                        _variance = 0;

                        for (int i = -1; i <= 1; i++)
                            for (int j = 0; j <= temp; j++)
                            {
                                if (j == 0 && (i == 1 || i == -1))
                                { }
                                else
                                    _variance += Math.Pow((sourceArgb[colorComponent, x - i, y - j] - mean), 2);
                            }

                        _variance = _variance / _count;

                        double[] mean_var5 = new double[2];
                        mean_var5[0] = mean;
                        mean_var5[1] = _variance;

                        // std means standard deviation
                        mean_variance.Add(mean_var5);                                              

                        //Mask #6 left top conrner 
                        
                        _sum = 0;
                        _count = 0;

                        for (int i = 0; i <= temp; i++)
                            for (int j = 0; j <= temp; j++)
                            {
                                if ((i == 0 && j == temp) || (i == temp && j == 0))
                                { }
                                else
                                {
                                    _sum += sourceArgb[colorComponent, x - i, y - j];
                                    _count++;
                                }
                            }
                        mean = _sum / _count;

                        _variance = 0;

                        for (int i = 0; i <= temp; i++)
                            for (int j = 0; j <= temp; j++)
                            {
                                if ((i == 0 && j == temp) || (i == temp && j == 0))
                                { }
                                else                                
                                    _variance += Math.Pow((sourceArgb[colorComponent, x - i, y - j] - mean), 2);                                
                            }

                        _variance = _variance / _count;

                        double[] mean_var6 = new double[2];
                        mean_var6[0] = mean;
                        mean_var6[1] = _variance;

                        // std means standard deviation
                        mean_variance.Add(mean_var6);

                        //Mask #7 right top conrner 
                        
                        _sum = 0;
                        _count = 0;

                        for (int i = 0; i <= temp; i++)
                            for (int j = -temp; j <= 0; j++)
                            {
                                if ((i == 0 && j == -temp) || (i == temp && j == 0))
                                { }
                                else
                                {
                                    _sum += sourceArgb[colorComponent, x - i, y - j];
                                    _count++;
                                }
                            }
                        mean = _sum / _count;

                        _variance = 0;

                        for (int i = 0; i <= temp; i++)
                            for (int j = -temp; j <= 0; j++)
                            {
                                if ((i == 0 && j == -temp) || (i == temp && j == 0))
                                { }
                                else
                                    _variance += Math.Pow((sourceArgb[colorComponent, x - i, y - j] - mean), 2);
                            }

                        _variance = _variance / _count;
                        double[] mean_var7 = new double[2];
                        mean_var7[0] = mean;
                        mean_var7[1] = _variance;

                        // std means standard deviation
                        mean_variance.Add(mean_var7);

                        //Mask #8 right bottom conner
                        
                        _sum = 0;
                        _count = 0;

                        for (int i = -temp; i <= 0; i++)
                            for (int j = -temp; j <= 0; j++)
                            {
                                if ((i == 0 && j == -temp) || (i == -temp && j == 0))
                                { }
                                else
                                {
                                    _sum += sourceArgb[colorComponent, x - i, y - j];
                                    _count++;
                                }
                            }
                        mean = _sum / _count;

                        _variance = 0;

                        for (int i = -temp; i <= 0; i++)
                            for (int j = -temp; j <= 0; j++)
                            {
                                if ((i == 0 && j == -temp) || (i == -temp && j == 0))
                                { }
                                else
                                    _variance += Math.Pow((sourceArgb[colorComponent, x - i, y - j] - mean), 2);
                            }

                        _variance = _variance / _count;
                        double[] mean_var8 = new double[2];
                        mean_var8[0] = mean;
                        mean_var8[1] = _variance;

                        // std means standard deviation
                        mean_variance.Add(mean_var8);

                        //9 left bottom mask

                        _sum = 0;
                        _count = 0;

                        for (int i = -temp; i <= 0; i++)
                            for (int j = 0; j <= temp; j++)
                            {
                                if ((i == 0 && j == temp) || (i == -temp && j == 0))
                                { }
                                else
                                {
                                    _sum += sourceArgb[colorComponent, x - i, y - j];
                                    _count++;
                                }
                            }
                        mean = _sum / _count;

                        _variance = 0;

                        for (int i = -temp; i <= 0; i++)
                            for (int j = 0; j <= temp; j++)
                            {
                                if ((i == 0 && j == temp) || (i == -temp && j == 0))
                                { }
                                else
                                    _variance += Math.Pow((sourceArgb[colorComponent, x - i, y - j] - mean), 2);
                            }

                        _variance = _variance / _count;
                        double[] mean_var9 = new double[2];
                        mean_var9[0] = mean;
                        mean_var9[1] = _variance;

                        // std means standard deviation
                        mean_variance.Add(mean_var9);

                        // Get Mean with Smallest Variance
                        targetArgb[colorComponent, x, y] = getMeanSmallestVariance(mean_variance);

                        // Reset ArrayList mean_variance by remove all existing element
                        mean_variance.Clear();
                    }

            return ArgbArrayToImage(targetArgb);
        }

        // #3 Sigma Filter
        public static Image SigmaFilter(Image image)
        {               
            Size size = image.Size;
            
            int[, ,] sourceArgb = ImageToArgbArray(image);
            int[, ,] targetArgb = GetNewArgbArray(size);
            Array.Copy(sourceArgb, targetArgb, sourceArgb.Length);

            // Set up size window
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter your window size (3,5,7...)", "Mask", "Type here...", 250, 250);
            int SizeWindow = int.Parse(input);
            
            // default window size = 3, if user enter  wrong input 
            if (SizeWindow == 1 || SizeWindow % 2 == 0)
                SizeWindow = 3;
            MessageBox.Show("Window size is set to " + "(" + SizeWindow + "x" + SizeWindow + ")" + "\nPress OK to continue");
            int k = SizeWindow/2;
            if (SizeWindow <= 5)
                k = 2;
            double std = 0;
            
            // A size variable to run correctly correspond with window size
            int temp = SizeWindow / 2;
            //MessageBox.Show(" temp = " + temp);

            for (int colorComponent = 1; colorComponent < 4; colorComponent++)
            {
                for (int x = temp; x < size.Width - temp; x++)
                    for (int y = temp; y < size.Height - temp; y++)
                    {                      
                        int _sum = 0;
                        int _count = 0;
                        for (int i = -temp; i <= temp; i++)
                            for (int j = -temp; j <= temp; j++)
                            {
                                _sum += sourceArgb[colorComponent, x - i, y - j];
                                _count++;
                            }
                        int mean = _sum / _count;
                        double _variance = 0;
                        for (int i = -temp; i <= temp; i++)
                            for (int j = -temp; j <= temp; j++)
                            {                                
                                _variance += Math.Pow((sourceArgb[colorComponent, x - i, y - j] - mean), 2);                                
                            }
                        _variance = _variance / _count;
                        // std means standard deviation
                        std = Math.Sqrt(_variance);                                               
                                                
                        // set up intensity range 
                        
                        double maxIntensity = sourceArgb[colorComponent, x, y] + 2 * std;
                        double minIntensity = sourceArgb[colorComponent, x, y] - 2 * std;

                        // get sum pixels lies within the intensity range
                        double total = 0;
                        int count = 0;
                        for (int i = -temp; i <= temp; i++)
                            for (int j = -temp; j <= temp; j++)
                            {
                                if ((sourceArgb[colorComponent, x - i, y - j] >= minIntensity) && (sourceArgb[colorComponent, x - i, y - j] <= maxIntensity))
                                {
                                    total += sourceArgb[colorComponent, x - i, y - j];
                                    count++;
                                }
                            }
                        
                        // get average by dividing the sum by the number of pixels in the sum

                        if (count > k)
                            targetArgb[colorComponent, x, y] = (int)(total / count);
                        else                            
                            targetArgb[colorComponent, x, y] = (int)mean;                        
                    }
            }
            // Calculate gradient after processing image
            int countAfterProcess = 0;
            double totalPixelAfterProcess = 0;
            for (int colorComponent = 1; colorComponent < 4; colorComponent++)
                for (int x = 0; x < size.Width; x++)
                    for (int y = 0; y < size.Height; y++)
                    {
                        totalPixelAfterProcess += sourceArgb[colorComponent, x, y];
                        countAfterProcess++;                        
                    }
            double meanAfterProcess = totalPixelAfterProcess / countAfterProcess;
            //MessageBox.Show("Count = " + countAfterProcess);
            MessageBox.Show("Mean After Processing = "+meanAfterProcess);

            double varianceAfterProcess = 0;
            for (int colorComponent = 1; colorComponent < 4; colorComponent++)
                for (int x = 0; x < size.Width; x++)
                    for (int y = 0; y < size.Height; y++)
                    {
                        varianceAfterProcess += Math.Pow((sourceArgb[colorComponent, x, y] - meanAfterProcess), 2);                                
                    }
            
            varianceAfterProcess = varianceAfterProcess / countAfterProcess;

            double stdAfterProcess = Math.Sqrt(varianceAfterProcess);
            //MessageBox.Show("Std After Processing = " + stdAfterProcess);

            return ArgbArrayToImage(targetArgb);
        }
    }
    #endregion
}
