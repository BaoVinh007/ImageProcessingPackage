// Course: CS6563
// Student name: Vinh Nguyen
// Student ID: 000200899
// Assignment #: #2
// Due Date: 10/22/2013
// Signature: _Vinh_____________
// (The signature means that the program is your own work)
// Score: ______________
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imageCsharp
{
    class PointCMean
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }
        public double clusterIndex { get; set; }

        public PointCMean(double x, double y, double red, double green, double blue)
		{
            X = x;
            Y = y;
			R = red;
            G = green;
            B = blue;
            clusterIndex = -1;
		}

        public static bool operator ==(PointCMean p1, PointCMean p2)
        {
            return (Math.Round(p1.R, 2) == Math.Round(p2.R, 2) &&
                    Math.Round(p1.G, 2) == Math.Round(p2.G, 2) &&
                    Math.Round(p1.B, 2) == Math.Round(p2.B, 2));
        }

        public static bool operator !=(PointCMean p1, PointCMean p2)
        {
            return !(Math.Round(p1.R, 2) == Math.Round(p2.R, 2) ||
                    Math.Round(p1.G, 2) == Math.Round(p2.G, 2) ||
                    Math.Round(p1.B, 2) == Math.Round(p2.B, 2));
        }

    }
}
