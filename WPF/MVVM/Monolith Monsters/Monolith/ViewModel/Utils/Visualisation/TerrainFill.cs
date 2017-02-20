namespace WpfSimpleGraphics.ViewModel.Utils.Visualisation
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Media3D;
    using WpfSimpleGraphics.Model;

    class TerrainFill
    {
        private Point3D[,] terrainGridPoints;
        private Viewport3D vpt3D = new Viewport3D();

        /// <summary>
        /// Terrain Constructor
        /// </summary>
        /// <param name="gridPoints"></param>
        /// <param name="vpt"></param>
        public TerrainFill(Point3D[,] gridPoints, Viewport3D vpt)
        {
            this.terrainGridPoints = gridPoints;
            this.vpt3D = vpt;

            this.ApplyTrianglesToGridPoints(this.terrainGridPoints);
            Environment.DrawLight(vpt);
            Camera.ApplyPerspective(vpt);
        }


        public TerrainFill(MapData gridPoints, Viewport3D vpt)
        {
            this.vpt3D = vpt;

            this.ApplyTrianglesToGridPoints(gridPoints);
            Environment.DrawLight(vpt);
            Camera.ApplyPerspective(vpt);
        }
        
        /// <summary>
        /// Iterate through the grid points using them as triangle vertices to draw triangles .. ...
        /// </summary>
        /// <param name="gridPoints"></param>
        private void ApplyTrianglesToGridPoints(Point3D[,] gridPoints)
        {
            var pointWithMax = Helper.FindMaxValues(gridPoints);
            int xTerrainLength = Convert.ToInt32(pointWithMax.X);
            int yTerrainLength = Convert.ToInt32(pointWithMax.Y);

            // For speed in any subsequent processing (transform, rotate, translate), group generated triangles as a single Model3DGroup entity ...
            Model3DGroup triangleGroup = new Model3DGroup();

            // Generate triangles and add to triangle group ..
            for (int x = 0; x <= (xTerrainLength - 2); x++)
            {
                Point3D pt1 ;
                Point3D pt2 ;
                Point3D pt3 ;

                // Draw triangle (right and above)..
                for (int y = 0; y <= (yTerrainLength - 2); y++)
                {
                    pt1 = gridPoints[x, y];
                    pt2 = gridPoints[x + 1, y];
                    pt3 = gridPoints[x, y + 1];
                    triangleGroup.Children.Add(this.DrawSingleTriangle(pt1, pt2, pt3));
                }

                // Draw its mirror image (right and below) ..
                for (int y = 1; y <= (yTerrainLength - 1); y++)
                {
                    pt1 = gridPoints[x, y];
                    pt2 = gridPoints[x + 1, y - 1];
                    pt3 = gridPoints[x + 1, y];
                    triangleGroup.Children.Add(this.DrawSingleTriangle(pt1, pt2, pt3));
                }
            }

            // Add generated terrain model to scene to be rendered ..
            ModelVisual3D terrainModel = new ModelVisual3D();
            terrainModel.Content = triangleGroup;
            this.vpt3D.Children.Add(terrainModel);
        }

        ///// <summary>
        ///// Iterate through the grid points using them as triangle vertices to draw triangles .. ...
        ///// </summary>
        ///// <param name="gridPoints"></param>
        private void ApplyTrianglesToGridPoints(MapData gridPoints)
        {
            // For speed in any subsequent processing (transform, rotate, translate), group generated triangles as a single Model3DGroup entity ...
            Model3DGroup triangleGroup = new Model3DGroup();

            float offset = 1.0F;

            foreach (Point3D gridPoint in gridPoints)
            {
                // Draw triangle ..
                triangleGroup.Children.Add(this.Triangle(gridPoint, offset));

                // Draw its mirror image ..
                triangleGroup.Children.Add(this.TriangleMirror(gridPoint, offset));
            }

            // Add generated terrain model to scene to be rendered ..
            ModelVisual3D terrainModel = new ModelVisual3D();
            terrainModel.Content = triangleGroup;
            this.vpt3D.Children.Add(terrainModel);
        }

        /// <summary>
        /// Draw Triangle from single point - extend +'ve x and +'ve y
        /// </summary>
        /// <param name="vertex"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        private GeometryModel3D Triangle(Point3D vertex, float offset)
        {
            var pt1 = vertex;
            var pt2 = new Point3D { X = pt1.X + offset, Y = pt1.Y,          Z = pt1.Z };
            var pt3 = new Point3D { X = pt1.X,          Y = pt1.Y + offset, Z = pt1.Z };
            return this.DrawSingleTriangle(pt1, pt2, pt3);
        }

        /// <summary>
        /// Draw mirror image triangle - extend +'ve x and -ve y
        /// </summary>
        /// <param name="vertex"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        private GeometryModel3D TriangleMirror(Point3D vertex, float offset)
        {
            var pt1 = vertex;
            var pt2 = new Point3D { X = pt1.X + offset, Y = pt1.Y - offset, Z = pt1.Z };
            var pt3 = new Point3D { X = pt1.X + offset, Y = pt1.Y,          Z = pt1.Z };
            return this.DrawSingleTriangle(pt1, pt2, pt3);
        }

        /// <summary>
        /// Draw a single triangle from a set of 3 points ..
        /// </summary>
        /// <param name="pt1"></param>
        /// <param name="pt2"></param>
        /// <param name="pt3"></param>
        private GeometryModel3D DrawSingleTriangle(Point3D pt1, Point3D pt2, Point3D pt3)
        {
            MeshGeometry3D triangleMesh = new MeshGeometry3D();
            triangleMesh.Positions.Add(pt1);
            triangleMesh.Positions.Add(pt2);
            triangleMesh.Positions.Add(pt3);

            triangleMesh.TriangleIndices.Add(0);
            triangleMesh.TriangleIndices.Add(1);
            triangleMesh.TriangleIndices.Add(2);

            Vector3D normalVectorToTrianglePlane = Helper.CalculateNormal(pt1, pt2, pt3);
            triangleMesh.Normals.Add(normalVectorToTrianglePlane);

            Material materialDiffuse = new DiffuseMaterial(new SolidColorBrush(Colors.Green));
            Material materialSpecular = new SpecularMaterial(new SolidColorBrush(Colors.White), 30);
            MaterialGroup materialGroup = new MaterialGroup();
            materialGroup.Children.Add(materialDiffuse);
            materialGroup.Children.Add(materialSpecular);

            return new GeometryModel3D(triangleMesh, materialGroup);
        }
    }
}