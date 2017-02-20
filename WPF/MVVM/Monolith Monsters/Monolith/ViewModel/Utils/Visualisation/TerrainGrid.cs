namespace WpfSimpleGraphics.ViewModel.Utils.Visualisation
{
    using System;
    using System.Windows.Media.Media3D;
    using WpfSimpleGraphics.Model;

    public static class TerrainGrid
    {
        /// <summary>
        /// Define a grid of points to represent a surface ..
        /// </summary>
        /// <param name="xLength"></param>
        /// <param name="yLength"></param>
        /// <param name="zLength"></param>
        /// <returns></returns>
        public static Point3D[,] Generate(int xLength, int yLength, int zLength)
        {
            Point3D[,] gridPoints = new Point3D[xLength, yLength];

            double z = 0.0;
            Random r = new Random();

            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    z = (Convert.ToDouble(r.Next(zLength)));
                    gridPoints[x, y] = new Point3D(Convert.ToDouble(x), Convert.ToDouble(y), z); // Note: Inclusion of Z here
                }
            }

            return gridPoints;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapData"></param>
        /// <returns></returns>
        public static MapData Generate(MapData mapData)
        {
            return mapData;
        }
    }
}