using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace imageCsharp
{
    class ClusterPoint
    {
        /// Gets or sets X-coord of the point
        public double X { get; set; }
        /// Gets or sets Y-coord of the point
        public double Y { get; set; }
        /// Gets or sets the RGB color of the point
        public Color PixelColor { get; set; }
        /// Gets or sets the original RGB color of the point
        public Color OriginalPixelColor { get; set; }
        /// Gets or sets cluster index, the strongest membership value to a cluster
        /// , used for defuzzification
        public double ClusterIndex { get; set; }
        //Construction
        public ClusterPoint(double x, double y, Color col)
        {
            this.X = x;
            this.Y = y;
            this.PixelColor = col;
            this.OriginalPixelColor = col;
            this.ClusterIndex = -1;
        }

        public ClusterPoint(double x, double y, Color z, object tag)
        {
            this.X = x;
            this.Y = y;
            this.PixelColor = z;
            this.ClusterIndex = -1;
        }
    }
}
