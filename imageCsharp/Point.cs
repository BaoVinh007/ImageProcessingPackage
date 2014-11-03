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
using System.Drawing;

namespace imageCsharp
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }
        public int clusterIndex { get; set; }

        public Point(int x, int y, double red, double green, double blue)
		{
            X = x;
            Y = y;
			R = red;
            G = green;
            B = blue;
            clusterIndex = -1;
		}

        public static bool operator ==(Point p1, Point p2)
        {
            return (Math.Round(p1.R, 2) == Math.Round(p2.R, 2) &&
                    Math.Round(p1.G, 2) == Math.Round(p2.G, 2) &&
                    Math.Round(p1.B, 2) == Math.Round(p2.B, 2));
        }               

        public static bool operator !=(Point p1, Point p2)
        {
            return !(Math.Round(p1.R, 2) == Math.Round(p2.R, 2) ||
                    Math.Round(p1.G, 2) == Math.Round(p2.G, 2) ||
                    Math.Round(p1.B, 2) == Math.Round(p2.B, 2));
        }

    }
}
