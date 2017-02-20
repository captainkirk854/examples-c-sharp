namespace WpfSimpleGraphics
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Media3D;
    using WpfSimpleGraphics.Model;
    using WpfSimpleGraphics.ViewModel.Utils.Visualisation;
    using WpfSimpleGraphics.ViewModel.Helpers;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Viewport3D staticXamlVpt3D = new Viewport3D();
               
        public MainWindow()
        {
            InitializeComponent();

            // Assign address of Window's Viewport for use in GetTerrainPoints
            staticXamlVpt3D = this.xamlVpt3D;          
        }

        public static void GetandShowTerrainPoints()
        {
            //Clear the viewport ..
            staticXamlVpt3D.Children.Clear();

            // Draw something new in the viewport ..
            Random rnd = new Random();
            int x = rnd.Next(5, 15);
            int y = rnd.Next(5, 20);
            int z = rnd.Next(5, 25);

            if (x > 10)
            {
                // Draw Terrain based on the random x,y,z seeds ...
                var myTerrain = new TerrainFill(TerrainGrid.Generate(x, y, z), staticXamlVpt3D);
            }
            else
            {
                // Draw Terrain based on fixed map data ...
                var myTerrain = new TerrainFill(TerrainGrid.Generate(new MapData()), staticXamlVpt3D);
            }
        }
    }
}
