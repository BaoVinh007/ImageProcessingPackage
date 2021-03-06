﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace imageCsharp
{
    class ClusterCentroid
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double RSum { get; set; }
        public double GSum { get; set; }
        public double BSum { get; set; }


        public ClusterCentroid(double x, double y, Color col)
        {
            this.X = x;
            this.Y = y;
            this.RSum = 0;
            this.GSum = 0;
            this.BSum = 0;
            this.PixelCount = 0;
            this.MembershipSum = 0;
            this.PixelColor = col;
            this.OriginalPixelColor = col;
        }
    }
}
