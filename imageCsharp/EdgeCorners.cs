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

    class EdgeCorners : ArrayImageConverter
    {
        // #1 simple edge detection (by using simple mask)
        public static Image simpleEdgeDetect(Image image)
        {
            Size size = image.Size;

            int[, ,] sourceArgb = ImageToArgbArray(image);
            int[, ,] targetArgb = GetNewArgbArray(size);
            Array.Copy(sourceArgb, targetArgb, sourceArgb.Length);

            for (int colorComponent = 1; colorComponent < 4; colorComponent++)
                for (int x = 0; x < size.Height; x++)
                    for (int y = 0; y < size.Width; y++)
                    {
                        int fx = 0;
                        int fy = 0;
                        if ((x - 1 > 0) && (x + 1 < size.Height))
                            fx = sourceArgb[colorComponent, y, x - 1] - sourceArgb[colorComponent, y, x + 1];
                        if ((y - 1 > 0) && (y + 1 < size.Width))
                            fy = sourceArgb[colorComponent, y - 1, x] - sourceArgb[colorComponent, y + 1, x];
                        targetArgb[colorComponent, y, x] = (int)Math.Sqrt(Math.Pow((fy), 2) + Math.Pow((fx), 2));
                    }

            return ArgbArrayToImage(targetArgb);
        }


    }
}
