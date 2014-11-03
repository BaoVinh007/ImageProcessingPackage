using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace imageCsharp
{
    class K_Means
    {
        /// Array containing all points used by the algorithm
        private List<ClusterPoint> Points;
        /// Array containing all clusters handled by the algorithm
        private List<ClusterCentroid> Clusters;
        private bool isConverged = false;
        private Bitmap processedImage;

        public double[,] U;
        public Bitmap myImage;
        public Bitmap getProcessedImage { get { return processedImage; } }
        public bool Converged { get { return isConverged; } }
        public int myImageWidth;
        public int myImageHeight;

        public K_Means(List<ClusterPoint> points, List<ClusterCentroid> clusters, Bitmap myImage, int numCluster)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }

            if (clusters == null)
            {
                throw new ArgumentNullException("clusters");
            }
            
            processedImage = (Bitmap)myImage.Clone();
 
            this.Points = points;
            this.Clusters = clusters;
            this.myImageHeight = myImage.Height;
            this.myImageWidth = myImage.Width;
            this.myImage = new Bitmap(myImageWidth, myImageHeight, PixelFormat.Format32bppRgb);
            U = new double[this.Points.Count, this.Clusters.Count];
            
            double distance;

            // Iterate through all points to create initial U matrix
            
            // an arraylist contain each element is an array that have a point and cluster
            ArrayList arrPointCluster = new ArrayList();
            ArrayList arrPointCluster2 = new ArrayList();
            for (int i = 0; i < this.Points.Count; i++)
            {
                ClusterPoint p = this.Points[i];
                double sum = 0.0;
                double min = Math.Pow(10, 5);
                int pos = -1;
                for (int j = 0; j < this.Clusters.Count; j++)
                {
                    ClusterCentroid c = this.Clusters[j];
                    distance = Math.Sqrt(Math.Pow(CalculateEuclideanDistance1(p, c), 2.0));
                    if (distance < min)
                    {
                        min = distance;
                        pos = j;
                    }
                    //U[i, j] = distance;                    
                    //sum += U[i, j];
                }
                ArrayList temp = new ArrayList();
                if (pos == 1)
                {
                    temp.Add(this.Points[i]);
                    temp.Add(this.Clusters[pos]);
                    arrPointCluster.Add(temp);
                    //MessageBox.Show("Cluster 1 " + this.Points[i].PixelColor );
                }
                else {
                    temp.Add(this.Points[i]);
                    temp.Add(this.Clusters[pos]);
                    arrPointCluster2.Add(temp);
                    //MessageBox.Show("Cluster 0 " + this.Points[i].PixelColor);
                }


                //CalculateNewClusterCenter for arrPointCluster and arrPointCluster2

                temp.Clear();
            }
            MessageBox.Show("cluster 1 has " + arrPointCluster.Count);
            MessageBox.Show("cluster 2 has " + arrPointCluster2.Count);
            //this.RecalculateClusterMembershipValues();
        }

        private double CalculateEuclideanDistance1(ClusterPoint p, ClusterCentroid c)
        {
            return Math.Sqrt(Math.Pow(p.PixelColor.R - c.PixelColor.R, 2.0) + Math.Pow(p.PixelColor.G - c.PixelColor.G, 2.0) + Math.Pow(p.PixelColor.B - c.PixelColor.B, 2.0));
        }

    }
}
