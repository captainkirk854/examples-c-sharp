namespace WpfSimpleGraphics.Model
{
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Windows.Media.Media3D;

    public class MapData : IEnumerable
    {
        ObservableCollection<Point3D> gridPoints = new ObservableCollection<Point3D>();
        ObservableCollection<Point3D[,]> gridPointsArray = new ObservableCollection<Point3D[,]>();

        /// <summary>
        /// Add discrete points to Collection ...
        /// </summary>
        public MapData()
        {
            gridPoints.Add(new Point3D { X = 0, Y = 0, Z = 0 });
            gridPoints.Add(new Point3D { X = 0, Y = 1, Z = 1 });
            gridPoints.Add(new Point3D { X = 0, Y = 2, Z = 2 });
            gridPoints.Add(new Point3D { X = 0, Y = 3, Z = 3 });
            gridPoints.Add(new Point3D { X = 0, Y = 4, Z = 4 });
            gridPoints.Add(new Point3D { X = 0, Y = 5, Z = 5 });
            gridPoints.Add(new Point3D { X = 0, Y = 6, Z = 6 });
            gridPoints.Add(new Point3D { X = 0, Y = 7, Z = 7 });
            gridPoints.Add(new Point3D { X = 0, Y = 8, Z = 8 });
            gridPoints.Add(new Point3D { X = 0, Y = 9, Z = 9 });
            gridPoints.Add(new Point3D { X = 0, Y = 10, Z = 10 });
            gridPoints.Add(new Point3D { X = 11, Y = 11, Z = 11 });
        }

        /// <summary>
        /// Add generated points to Collection ... doesn't work :(
        /// </summary>
        /// <param name="xLength"></param>
        /// <param name="yLength"></param>
        /// <param name="zLength"></param>
        public MapData(int xLength, int yLength, int zLength)
        {
            Point3D[,] gridPoints = new Point3D[xLength, yLength];

            double z = 0.0;
            Random r = new Random();

            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    z = (Convert.ToDouble(r.Next(zLength)));
                    gridPoints[x, y] = new Point3D(Convert.ToDouble(x), Convert.ToDouble(y), z);
                }
            }

            gridPointsArray.Add(gridPoints);
        }

        public IEnumerator GetEnumerator()
        {
            return this.gridPoints.GetEnumerator();
        }

        public int Count()
        {
            return gridPoints.Count;
        }
    }
}
