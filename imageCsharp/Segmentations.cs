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
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections;

namespace imageCsharp
{
    class Segmentations : ArrayImageConverter
    {

        public static Image K_Means(Image image)
        {
            // Original image
            Bitmap orignialImage = (Bitmap)image;

            // a copy image to be processed
            Bitmap sourceImage = (Bitmap)image.Clone();
                        
            // Set up k clusters
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter the number of clusters ", "K Value", "Type here...", 250, 250);
            int numClusters = int.Parse(input);

            MessageBox.Show("The number of clusters is set to " + numClusters + "\nPress OK to continue");

            //Process to convert image to a list of points  
            List<Point> points = new List<Point>();

            for (int row = 0; row < sourceImage.Width; row++)
            {
                for (int column = 0; column < sourceImage.Height; column++)
                {
                    // get color at position (x, y)
                    Color c = sourceImage.GetPixel(row, column);
                
                    // Add a point into a list which is used to store points
                    points.Add(new Point(row, column, c.R, c.G, c.B));
                }
            }

            //Process to create a list of random cluster centroids
            //Check initial centroid by sometimes error divide by 0
            List<Point> centroids = new List<Point>();                        
            
            Random random = new Random();
            for (int i = 0; i < numClusters; i++)
            {   
                // generate random x-coordinate
                int randomX = random.Next(sourceImage.Width);
                
                // generate random x-coordinate
                int randomY = random.Next(sourceImage.Height);
                
                // get pixel at position(x,y)
                Color c = sourceImage.GetPixel(randomX, randomY);
                
                //Create a centroid                
                Point tempPoint = new Point(randomX, randomY, c.R, c.G, c.B);
                
                // Assign cluster index to centroids
                tempPoint.clusterIndex = i;
                
                //assign index for centoids in points, to avoid divide by 0
                //MessageBox.Show("cluster" + i + " has r = " + c.R + " g = " + c.G + " b = " + c.B);
                //Add new centroid into a list
                centroids.Add(tempPoint);
            }

            // Run K-Means Algorithm
            
            // Set up max iteration
            int maxIteration = numClusters * 20;
            
            int it = 0;
            while (it < maxIteration)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    // Process to find min distance

                    Point p = points[i];

                    // A variable is used to find min distance
                    double distance = Math.Pow(10, 5);

                    // A variable is used to store position of point has min distance
                    int position = -1;                                     
                    
                    for (int j = 0; j < numClusters; j++)
                    {
                        Point c = centroids[j];
                        if (distance > CalculateEuclideanDistance(p, c) && (c.X != p.X || c.Y != p.Y) )
                        {
                            distance = CalculateEuclideanDistance(p, c);
                            position = j;                            
                        }
                        if (c.X == p.X && c.Y == p.Y && p == c)
                        {
                            position = c.clusterIndex;
                        }
                    }                    
                    // Change cluster index 
                    p.clusterIndex = position;
                }

                // Calculate new cluster centroids
                List<Point> newCentroids = CalculateNewClusterCentroids(points, centroids);
                
                // Process to check convergence
                int countCentroids = 0;

                // Count the number of same centroids of old cluster centroids and new cluster centroids
                for (int i = 0; i < newCentroids.Count; i++)
                    for (int j = 0; j < centroids.Count; j++)
                    {                
                        if (newCentroids[i] == centroids[j])
                            countCentroids++;                        
                    }
                // If they are the same, stop 
                if (countCentroids == centroids.Count)
                {
                    MessageBox.Show("Stop at iteration " + it+ ". DONE!!!");
                    it = maxIteration;                    
                }
                else
                {
                    // reset cluster index of all points
                    for (int j = 0; j < points.Count; j++)
                    {
                        points[j].clusterIndex = -1;
                    }

                    // process to update new cluster centroids
                    centroids.Clear();

                    // update new cluster centroids
                    for (int i = 0; i < newCentroids.Count; i++)
                    {
                        centroids.Add(newCentroids[i]);
                    }
                    newCentroids.Clear();
                }                
                it++;
            }

            // Process to convert points back to image
            for (int index = 0; index < points.Count; index++)
            {
                for (int i = 0; i < centroids.Count; i++)
                {
                    if (points[index].clusterIndex == centroids[i].clusterIndex)
                    {
                        Color colour = Color.FromArgb((int)centroids[i].R, (int)centroids[i].G, (int)centroids[i].B);                 
                        sourceImage.SetPixel(points[index].X, points[index].Y, colour);
                    }
                }
            }            
            return sourceImage;
        }        

        public static double CalculateEuclideanDistance(Point p, Point c)
        {
            return Math.Sqrt(Math.Pow(p.R - c.R, 2.0) + Math.Pow(p.G - c.G, 2.0) + Math.Pow(p.B - c.B, 2.0));
        }

        public static double CalculateEuclideanDistance(PointCMean p, PointCMean c)
        {
            return Math.Sqrt(Math.Pow(p.R - c.R, 2.0) + Math.Pow(p.G - c.G, 2.0) + Math.Pow(p.B - c.B, 2.0));
        }

        public static List<Point> CalculateNewClusterCentroids(List<Point> points, List<Point> centroids)
        {
            List<Point> newCenter = new List<Point>();
            int x = 0;
            int y = 0;
            double r = 0;
            double g = 0;
            double b = 0;
            
            for (int i = 0; i < centroids.Count; i++)
            {
                int count = 0; 
                for (int j = 0; j < points.Count; j++)
                {
                    if (points[j].clusterIndex == centroids[i].clusterIndex)
                    {
                        x += points[j].X;
                        y += points[j].Y;
                        r += points[j].R;
                        g += points[j].G;
                        b += points[j].B;
                        count++;
                    }
                }
                Point temp = new Point(x / count, y / count, Math.Round(r / count, 2), Math.Round(g / count, 2), Math.Round(b / count, 2));
                temp.clusterIndex = centroids[i].clusterIndex;            
                newCenter.Add(temp);
                x = 0;
                y = 0;
                r = 0;
                g = 0;
                b = 0;
            }            
            return newCenter;            
        }

        public static List<PointCMean> CalculateNewClusterCentroids(List<PointCMean> points, List<PointCMean> centroids, double[,] U)
        {
            List<PointCMean> newCenter = new List<PointCMean>();
            double x = 0;
            double y = 0;
            double r = 0;
            double g = 0;
            double b = 0;

            for (int i = 0; i < centroids.Count; i++)
            {                
                double denominator = 0;
                for (int j = 0; j < points.Count; j++)
                {                    
                    double t = Math.Pow(U[j, i], 2);
                    denominator += t;
                    x += t * points[j].X;
                    y += t * points[j].Y;
                    r += t * points[j].R;
                    g += t * points[j].G;
                    b += t * points[j].B;                                            
                }
                PointCMean temp = new PointCMean(x / denominator, y / denominator, Math.Round(r / denominator, 2), Math.Round(g / denominator, 2), Math.Round(b / denominator, 2));                
                newCenter.Add(temp);
                x = 0;
                y = 0;
                r = 0;
                g = 0;
                b = 0;
            }
            return newCenter;
        }

        public static List<PointCMean> CalculateFinalClusterCentroids(List<PointCMean> points, List<PointCMean> centroids)
        {
            List<PointCMean> newCenter = new List<PointCMean>();
            double x = 0;
            double y = 0;
            double r = 0;
            double g = 0;
            double b = 0;

            for (int i = 0; i < centroids.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < points.Count; j++)
                {
                    if (points[j].clusterIndex == centroids[i].clusterIndex)
                    {
                        x += points[j].X;
                        y += points[j].Y;
                        r += points[j].R;
                        g += points[j].G;
                        b += points[j].B;
                        count++;
                    }
                }
                PointCMean temp = new PointCMean( Math.Round( x / count , 2), Math.Round( y / count, 2), Math.Round(r / count, 2), Math.Round(g / count, 2), Math.Round(b / count, 2));
                temp.clusterIndex = centroids[i].clusterIndex;
                newCenter.Add(temp);
                x = 0;
                y = 0;
                r = 0;
                g = 0;
                b = 0;
            }
            return newCenter;
        }

        public static Image FuzzyC_Means(Image image)
        {
            // Original image
            Bitmap orignialImage = (Bitmap)image;

            // a copy image to be processed
            Bitmap sourceImage = (Bitmap)image.Clone();

            // Set up k clusters
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter the number of clusters ", "K Value", "Type here...", 250, 250);
            int numClusters = int.Parse(input);

            MessageBox.Show("The number of clusters is set to " + numClusters + "\nPress OK to continue");

            //Process to convert image to a list of points  
            List<PointCMean> points = new List<PointCMean>();

            for (int row = 0; row < sourceImage.Width; row++)
            {
                for (int column = 0; column < sourceImage.Height; column++)
                {
                    // get color at position (x, y)
                    Color c = sourceImage.GetPixel(row, column);

                    // Add a point into a list which is used to store points
                    points.Add(new PointCMean(row, column, c.R, c.G, c.B));
                }
            }

            //Step 1 : Process to create a list of random cluster centroids
            List<PointCMean> centroids = new List<PointCMean>();

            Random random = new Random();
            for (int i = 0; i < numClusters; i++)
            {                
                // generate random x-coordinate
                int randomX = random.Next(sourceImage.Width);

                // generate random x-coordinate
                int randomY = random.Next(sourceImage.Height);

                // get pixel at position(x,y)
                Color c = sourceImage.GetPixel(randomX, randomY);
                
                //Create a centroid                
                PointCMean tempPoint = new PointCMean(randomX, randomY, c.R, c.G, c.B);
                tempPoint.clusterIndex = i;
                //Add new centroid into a list
                centroids.Add(tempPoint);                
            }
            
            // Run Fuzzy C-Means Algorithm

            // A membership matrix 
            double[,] U = new double[points.Count, numClusters];

            // A matrix to be used to store distance
            double[,] distanceM = new double[points.Count, numClusters];

            // fuzzier rate
            double m = 2;

            // Accurate rate
            double epsilon = 0.01;
            
            // Set up max iteration
            int maxIteration = numClusters * 20;
            
            int it = 0;
            while (it < maxIteration)
            {

                // Step 2 : create distance matrix from a point Xi to cluster center
                for (int i = 0; i < points.Count; i++)
                {
                    PointCMean p = points[i];
                    for (int j = 0; j < centroids.Count; j++)
                    {
                        PointCMean c = centroids[j];

                        if (CalculateEuclideanDistance(p, c) != 0)
                            distanceM[i, j] = CalculateEuclideanDistance(p, c);
                        else
                            distanceM[i, j] = epsilon;
                    }
                }

                // Step 3: create membership matrix
                for (int i = 0; i < points.Count; i++)
                {
                    PointCMean p = points[i];
                    for (int j = 0; j < centroids.Count; j++)
                    {
                        double numerator = Math.Pow(1 / distanceM[i, j], (1 / (m - 1)));
                        double sumTem = 0;

                        for (int k = 0; k < distanceM.GetLength(1); k++)
                        {
                            sumTem += Math.Pow(1 / distanceM[i, k], (1 / (m - 1)));
                        }

                        U[i, j] = Math.Round(numerator / sumTem, 3);
                    }
                }
                                
                // Step 4: create new centroid
                
                List<PointCMean> newCentroids = CalculateNewClusterCentroids(points, centroids, U);
                
                // Process to check convergence
                int countCentroids = 0;

                // Count the number of same centroids of old cluster centroids and new cluster centroids
                for (int i = 0; i < newCentroids.Count; i++)
                {
                    for (int j = 0; j < centroids.Count; j++)
                    {                                                                     
                        if (Math.Round(Math.Abs(newCentroids[i].R - centroids[j].R), 2) <= epsilon &&
                            Math.Round(Math.Abs(newCentroids[i].G - centroids[j].G), 2) <= epsilon &&
                            Math.Round(Math.Abs(newCentroids[i].B - centroids[j].B), 2) <= epsilon
                            )
                        {
                            countCentroids++;
                        }                        
                    }
                }
                // If they are the same, stop 
                if (countCentroids == centroids.Count)
                {
                    MessageBox.Show("Stop at iteration " + it + ". DONE!!!");
                    it = maxIteration;
                }
                else
                {
                    // reset cluster index of all points
                    for (int j = 0; j < points.Count; j++)
                    {
                        points[j].clusterIndex = -1;
                    }

                    // process to update new cluster centroids
                    centroids.Clear();

                    // update new cluster centroids
                    for (int i = 0; i < newCentroids.Count; i++)
                    {
                        centroids.Add(newCentroids[i]);
                    }
                    newCentroids.Clear();
                }            
                it++;
            }

            // Defuzzy process
                        
            for (int j = 0; j < numClusters; j++)
            {
                centroids[j].clusterIndex = j;                
            }            

            // Assign index cluster for points

            for (int i = 0; i < points.Count; i++)
            {
                // Process to find min distance

                PointCMean p = points[i];

                // A variable is used to find min distance
                double distance = Math.Pow(10, 5);

                // A variable is used to store position of point has min distance
                int position = -1;
                                
                for (int j = 0; j < numClusters; j++)
                {
                    PointCMean c = centroids[j];
                    if (distance > CalculateEuclideanDistance(p, c) && (c.X != p.X || c.Y != p.Y))
                    {
                        distance = CalculateEuclideanDistance(p, c);
                        position = j;
                    }
                    if (c.X == p.X && c.Y == p.Y && p == c)
                    {
                        position = (int)c.clusterIndex;
                    }
                }
                // Change cluster index 
                p.clusterIndex = position;
            }                       

            // Process calculate final centroid for each cluster
            List<PointCMean> finalCentroids = CalculateFinalClusterCentroids(points, centroids);
                        
            // Process to convert points back to image

            for (int index = 0; index < points.Count; index++)
            {
                for (int i = 0; i < finalCentroids.Count; i++)
                {
        
                    if (points[index].clusterIndex == centroids[i].clusterIndex)
                    {             
                        Color colour = Color.FromArgb((int)finalCentroids[i].R, (int)finalCentroids[i].G, (int)finalCentroids[i].B);
                        sourceImage.SetPixel((int)points[index].X, (int)points[index].Y, colour);
                    }
                }
            }
            return sourceImage;
        }
        
    }
}
