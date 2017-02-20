namespace WpfSimpleGraphics.ViewModel.Utils.Visualisation
{
    using System.Windows.Media.Media3D;

    public static class Helper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xyzPoints"></param>
        /// <returns></returns>
        public static Point3D FindMaxValues(Point3D[,] xyzPoints)
        {
            int numberElementsX = xyzPoints.GetUpperBound(0);
            int numberElementsY = xyzPoints.GetUpperBound(1);

            double maxX = float.MinValue;
            double maxY = float.MinValue;
            double maxZ = float.MinValue;

            for (int x = 0; x <= numberElementsX; x++)
            {
                for (int y = 0; y <= numberElementsY; y++)
                {
                    Point3D p3D = xyzPoints[x, y];
                    if (p3D.X > maxX) maxX = p3D.X;
                    if (p3D.Y > maxY) maxY = p3D.Y;
                    if (p3D.Z > maxZ) maxZ = p3D.Z;
                }
            }

            return new Point3D(maxX, maxY, maxZ);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xyzPoints"></param>
        /// <returns></returns>
        public static Point3D FindMinValues(Point3D[,] xyzPoints)
        {
            int numberElementsX = xyzPoints.GetUpperBound(0);
            int numberElementsY = xyzPoints.GetUpperBound(1);

            double minX = float.MaxValue;
            double minY = float.MaxValue;
            double minZ = float.MaxValue;

            for (int x = 0; x <= numberElementsX; x++)
            {
                for (int y = 0; y <= numberElementsY; y++)
                {
                    Point3D p3D = xyzPoints[x, y];
                    if (p3D.X < minX) minX = p3D.X;
                    if (p3D.Y < minY) minY = p3D.Y;
                    if (p3D.Z < minZ) minZ = p3D.Z;
                }
            }

            return new Point3D(minX, minY, minZ);
        }

        /// <summary>
        /// Calculate normal vector of point in 3D space ..
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        public static Vector3D CalculateNormal(Point3D p1, Point3D p2, Point3D p3)
        {
            Vector3D v0 = new Vector3D(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z);
            Vector3D v1 = new Vector3D(p3.X - p2.X, p3.Y - p2.Y, p3.Z - p2.Z);

            return Vector3D.CrossProduct(v0, v1);
        }
    }
}