namespace WpfSimpleGraphics.ViewModel.Utils.Visualisation
{
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Media3D;

    public static class Environment
    {
        /// <summary>
        /// Lighting ...
        /// </summary>
        public static void DrawLight(Viewport3D vpt)
        {
            ModelVisual3D light = new ModelVisual3D();
            light.Content = new DirectionalLight(Colors.White, new Vector3D(-1, -1, -1));
            vpt.Children.Add(light);
        }
    }
}