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

namespace imageCsharp
{
    class ArrayImageConverter
    {
        #region conversion method ARGB array <-> Image
        public static int[, ,] ImageToArgbArray(Image image)
        {
            // Create a new bitmap.
            Bitmap bmp = (Bitmap)image;

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                    bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
                    PixelFormat.Format32bppArgb);//bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] bgra = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, bgra, 0, bytes);
            var argb = GetNewArgbArray(bmp.Size);

            int byteIdx = 0;

            // Process the channel array in reverse. Even though the pixel format says
            // argb GDI+ returns it as bgra.
            for (int row = 0; row < bmp.Height; row++)
                for (int column = 0; column < bmp.Width; column++)
                    for (int channel = 3; channel > -1; channel--)
                    {
                        argb[channel, column, row] = bgra[byteIdx];
                        byteIdx++;
                    }

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            return argb;
        }

        public static Image ArgbArrayToImage(int[, ,] argb)
        {
            Size size = new Size(argb.GetLength(1), argb.GetLength(2));
            // Create a new bitmap.
            Bitmap bmp = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                    bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.WriteOnly,
                    PixelFormat.Format32bppArgb);//format);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] bgra = new byte[bytes];

            int byteIdx = 0;

            // Process the argb array in reverse to convert it to a single dimension
            // BGRA array. 
            for (int row = 0; row < bmp.Height; row++)
                for (int column = 0; column < bmp.Width; column++)
                    for (int channel = 3; channel > -1; channel--)
                    {
                        // enforce range boundary
                        if (argb[channel, column, row] > 255) argb[channel, column, row] = 255;
                        if (argb[channel, column, row] < 0) argb[channel, column, row] = 0;

                        bgra[byteIdx] = (byte)(argb[channel, column, row]);
                        byteIdx++;
                    }

            //Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(bgra, 0, ptr, bytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            return bmp;
        }

        /// <summary>
        /// Returns an empty ARGB aray.
        /// 
        /// The first index is the color channel. 
        ///		0 = Alpha
        ///		1 = Red
        ///		2 = Green
        ///		3 = Blue
        ///		
        /// The second index is for the column position within a bitmap.
        /// The third index is for the row position within a bitmap.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static int[, ,] GetNewArgbArray(Size size)
        {
            return new int[4, size.Width, size.Height];
        }
        #endregion
    }
}
