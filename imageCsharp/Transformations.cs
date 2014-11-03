// Course: CS6563
// Student name: Vinh Nguyen
// Student ID: 000200899
// Assignment #: #4
// Due Date: 11/19/2013
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


namespace imageCsharp
{
    class Transformations : ArrayImageConverter
    {
        #region transformation methods 

        // #1 Mirror method
        public static Image Mirror(Image image)
        {
            Size size = image.Size;// Height and Width property will be implemented for looping
            int[, ,] sourceArgb = ImageToArgbArray(image);
            int[, ,] targetArgb = GetNewArgbArray(size);
            Array.Copy(sourceArgb, targetArgb, sourceArgb.Length);// utilize System.Array class
            
            // copy image array also can be coded as follows;
            // int[, ,] sourceArgb = ImageToArgbArray(image);
            // var targetArgb = GetNewArgbArray(size); // create targetArgb with the same size of sourceArgb

            for (int colorComponent = 0; colorComponent < 4; colorComponent++) // color components (A=0 R=1 G=2 B=3)
                for (int column = 0; column < size.Width; column++)
                    for (int row = 0; row < size.Height; row++)
                    {
                        targetArgb[colorComponent, column, row] = sourceArgb[colorComponent, size.Width - column-1, row];
                        // can be rewritten as follows;
                        // int newColumn = (size.Width - 1) - column;
                        // targetArgb[channel, newColumn, row] = sourceArgb[channel, column, row];
                    }

            return ArgbArrayToImage(targetArgb);
        }
        
        // #2 Grayscale method
        public static Image ColorToGrayscale(Image image)
        {
            Size size = image.Size; 

            int[, ,] argb = ImageToArgbArray(image);

            for (int row = 0; row < size.Height; row++)
                for (int column = 0; column < size.Width; column++)
                {
                    int average = (argb[1, column, row] + argb[2, column, row] + argb[3, column, row]) / 3;

                    argb[1, column, row] = average;
                    argb[2, column, row] = average;
                    argb[3, column, row] = average;
                }

            return ArgbArrayToImage(argb);
        }

        // #3 Negate method
        public static Image NegateImage(Image image)
        {
            Size size = image.Size;

            int[, ,] argb = ImageToArgbArray(image);

            for (int row = 0; row < size.Height; row++)
                for (int column = 0; column < size.Width; column++)
                {
                    argb[1, column, row] = 255 - argb[1, column, row];
                    argb[2, column, row] = 255 - argb[2, column, row];
                    argb[3, column, row] = 255 - argb[3, column, row];
                }

            return ArgbArrayToImage(argb);
        }

       
        //#6 Copy image
        public static Image CopyImage(Image image)
        {
            Size size = image.Size;
            int[, ,] sourceArgb = ImageToArgbArray(image);
            int[, ,] targetArgb = GetNewArgbArray(size);
            Array.Copy(sourceArgb, targetArgb, sourceArgb.Length);

            for (int colorComponent = 0; colorComponent < 4; colorComponent++)
                for (int column = 0; column < size.Width; column++)
                    for (int row = 0; row < size.Height; row++)
                    {
                        targetArgb[colorComponent, column, row] = sourceArgb[colorComponent, column, row];
                    }

            return ArgbArrayToImage(targetArgb);
        }

        //#7 DFT = Discrete Fourier Transforms                
                
        public static double calculateUReal(int x, int u, int N)
        {            
            double cosArg = Math.Round( Math.Cos((2 * Math.PI * x * u) / N), 3);         
            return cosArg;
        }
        
        // int type, if type = -1, it means inverse, otherwise it is forward

        public static Complex calculateUImaginary(int x, int u, int N, int type)
        {            
            Complex j = new Complex();            
            double sinArg;
            if (type == -1)
            {
                // inverse 
                sinArg = Math.Round(Math.Sin((2 * Math.PI * x * u) / N), 1);
            }
            else
            {
                //forward
                sinArg = Math.Round(Math.Sin((2 * Math.PI * x * u) / N), 1) * (-1);
            }

            return sinArg * j;
        }
            
        public static int[, ,] applyTransform(int[, ,] UGU, int N)
        {
            int[, ,] UgUTemp = new int[4, N, N];
            for (int colorComponent = 0; colorComponent < 4; colorComponent++)
            {
                for (int column = 0; column < N; column++)
                {
                    for (int row = 0; row < N; row++)
                    {
                        int newX = row - N / 2;
                        int newY = column - N / 2;

                        if (newY < 0)
                            newY = column + N / 2;

                        if (newX < 0)
                            newX = row + N / 2;
         
                        UgUTemp[colorComponent, newY, newX] = UGU[colorComponent, column, row];
                    }
                }
            }
            return UgUTemp;
        }

        // int type  : choose type to show. EX: magnitude - use type = 0; phase - use type = 1

        public static Image DFT(Image image, int type)
        {
            Size size = image.Size;
            int[, ,] sourceArgb = ImageToArgbArray(image);
            int[, ,] targetArgb = GetNewArgbArray(size);
            Array.Copy(sourceArgb, targetArgb, sourceArgb.Length);

            // calculate U[,] matrix
            Complex[,] U = new Complex[size.Width, size.Height];                        

            for (int column = 0; column < size.Width; column++)
            {
                for (int row = 0; row < size.Height; row++)
                {
                    int N = size.Width;                    
                    U[column, row] = calculateUReal(column, row, N) + calculateUImaginary(column, row, N, type);                    
                }
            }

            // calculate gU 
            
            Complex[, ,] gU = new Complex[4, size.Width, size.Height];
            for (int colorComponent = 1; colorComponent < 4; colorComponent++)
            {
                for (int row = 0; row < size.Height; row++)
                {
                    for (int column = 0; column < size.Width; column++)
                    {            
                        Complex sumU = new Complex();
                        sumU.imaginary = 0;                     
                        for (int column1 = 0; column1 < size.Width; column1++)
                        {
                            sumU = sumU + sourceArgb[colorComponent, column1, row] * U[column, column1];                            
                        }
                        gU[colorComponent, column, row] = sumU;                        
                    }                   
                }
            } 

            // calculate A = UgU             

            Complex[, ,] UgU = new Complex[4, size.Width, size.Height];
            
            for (int colorComponent = 1; colorComponent < 4; colorComponent++)
            {
                for (int row = 0; row < size.Height; row++)
                {
                    for (int column = 0; column < size.Width; column++)
                    {            
                        Complex sumUGU = new Complex();
                        sumUGU.imaginary = 0;

                        for (int column1 = 0; column1 < size.Width; column1++)
                        {                     
                            sumUGU = sumUGU + U[column1, row] * gU[colorComponent, column, column1];                         
                        }
                        
                        UgU[colorComponent, column, row] = sumUGU / size.Width;
                        
                        UgU[colorComponent, column, row].real = Math.Round(UgU[colorComponent, column, row].real,2);
                        UgU[colorComponent, column, row].imaginary = Math.Round(UgU[colorComponent, column, row].imaginary, 2);

                        if (type == 0)
                        {
                            //MessageBox.Show("Magnitude");
                            targetArgb[colorComponent, column, row] = (int)UgU[colorComponent, column, row].magnitude();                            
                        }
                        else if (type == 1)
                        {
                            //MessageBox.Show("Phase");
                            targetArgb[colorComponent, column, row] = (int)(UgU[colorComponent, column, row].phase()*50);
                        }
                        else if (type == 2)
                        {
                            //MessageBox.Show("Real");
                            targetArgb[colorComponent, column, row] = (int)(UgU[colorComponent, column, row].real);
                        }
                        else if (type == 3)
                        {
                            //MessageBox.Show("Imaginary");
                            targetArgb[colorComponent, column, row] = (int)UgU[colorComponent, column, row].imaginary;
                        }
                        else {
                            // for inverse real
                            //MessageBox.Show("inverse");
                            //targetArgb[colorComponent, column, row] = (int)(UgU[colorComponent, column, row].real);
                            
                            // for inverse imaginary
                            //targetArgb[colorComponent, column, row] = (int)(UgU[colorComponent, column, row].imaginary);

                            // for inverse magnitude
                            targetArgb[colorComponent, column, row] = (int)(UgU[colorComponent, column, row].magnitude());

                            // for inverse phase
                            //targetArgb[colorComponent, column, row] = (int)(UgU[colorComponent, column, row].phase()*50);
                        }                        
                    }
                }
            }
            
            targetArgb = applyTransform(targetArgb, size.Width);
                        
            return ArgbArrayToImage(targetArgb);
        }

        public static Complex[] subFFT(Complex[] sourceArgb)
        {
            int N = sourceArgb.Length;
            if (N == 1)
            {
                return sourceArgb;
            }

            Complex[] d = new Complex[N / 2];
            Complex[] D;
            Complex[] e = new Complex[N / 2];
            Complex[] E;

            for (int i = 0; i < N / 2; i++)
            {
                e[i] = sourceArgb[i * 2];
                d[i] = sourceArgb[i * 2 + 1];
            }

            D = subFFT(d);
            E = subFFT(e);

            for (int i = 0; i < N / 2; i++)
            {
                Complex temp = new Complex();
                //temp = temp.from_polar(1, -2 * Math.PI * i / N);
                D[i] *= temp;
            }

            for (int i = 0; i < N / 2; i++)
            {                
                sourceArgb[i] = E[i] + D[i];
                sourceArgb[i + N/2] = E[i] - D[i];
            }

            return sourceArgb;
        }

        public static Image FFT(Image image, int type)
        {
            Size size = image.Size;
            int[, ,] sourceArgb = ImageToArgbArray(image);
            int[, ,] targetArgb = GetNewArgbArray(size);
            Array.Copy(sourceArgb, targetArgb, sourceArgb.Length);

            // calculate tempSource[,] matrix
            Complex[] tempSource = new Complex[3 * size.Width * size.Height];
            int index = 0;
            for (int colorComponent = 1; colorComponent < 4; colorComponent++)
            {
                for (int row = 0; row < size.Width; row++)
                {
                    for (int column = 0; column < size.Height; column++)
                    {                        
                        tempSource[index] = new Complex((double)sourceArgb[colorComponent, row, column], 0);
                        index++;
                    }
                }
            }

            tempSource = subFFT(tempSource);
            MessageBox.Show("length = " + tempSource.Length);
            // Process to convert one dimensional to three dimensional

            int new_colorComponent = 1;
            int new_row = 0;
            int new_col = 0;
            int new_count = 0;
            int new_count_color = 0;
            
            for (int i = 0; i < tempSource.Length; i++)
            {
                if (new_count_color < size.Width * size.Height)
                {
                    if (new_count < size.Width)
                    {
                        targetArgb[new_colorComponent, new_row, new_col] = (int)tempSource[i].real;
                        //MessageBox.Show("img [" + new_colorComponent + ", " + new_row + ", " + new_col + "] = " + targetArgb[new_colorComponent, new_row, new_col]);
                        new_col++;
                    }
                    if (new_count == size.Width)
                    {
                        new_row++;
                        new_col = 0;
                        new_count = 0;
                        targetArgb[new_colorComponent, new_row, new_col] = (int)tempSource[i].real;
                        //MessageBox.Show("img [" + new_colorComponent + ", " + new_row + ", " + new_col + "] = " + targetArgb[new_colorComponent, new_row, new_col]);
                        new_col++;
                    }
                    new_count++;                    
                }
                
                if (new_count_color == size.Width * size.Height)
                {
                    new_colorComponent++;
                    new_row = 0;
                    new_col = 0;
                    new_count = 0;
                    new_count_color = 0;
                    targetArgb[new_colorComponent, new_row, new_col] = (int)tempSource[i].real;
                    //MessageBox.Show("img [" + new_colorComponent + ", " + new_row + ", " + new_col + "] = " + targetArgb[new_colorComponent, new_row, new_col]);
                    new_col++;
                    new_count++;  
                }
                new_count_color++;
                //Console.WriteLine("img [" + new_colorComponent +", " + new_row + ", " + new_col+"] = " + targetArgb[new_colorComponent, new_row, new_col]);
                
            }
            targetArgb = applyTransform(targetArgb, size.Width);
                // transfer one dimension to 2-3 dimension
            return ArgbArrayToImage(targetArgb);
        }


        #endregion
    }
}
