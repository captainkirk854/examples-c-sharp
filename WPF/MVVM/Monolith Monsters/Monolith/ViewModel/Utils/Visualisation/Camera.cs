namespace WpfSimpleGraphics.ViewModel.Utils.Visualisation
{
    using System.Windows.Controls;
    using System.Windows.Media.Media3D;

    public static class Camera
    {
        /// <summary>
        /// Camera perspective ..
        /// </summary>
        public static void ApplyPerspective(Viewport3D vpt)
        {
            PerspectiveCamera pCam = new PerspectiveCamera();
            pCam.FarPlaneDistance = 40;
            pCam.Position = new Point3D(20, 15, 15);
            pCam.LookDirection = new Vector3D(-20, -10, -10);
            pCam.UpDirection = new Vector3D(0, 0, 1);

            vpt.Camera = pCam;
        }
    }
}