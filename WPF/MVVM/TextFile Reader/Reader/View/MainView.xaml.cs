namespace WpfApplication1.View
{

    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms; // if a WPF project, dll reference also has to be manually added


    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : System.Windows.Controls.UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The btn file open_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnFileOpen_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog { Multiselect = false, Filter = "A Text File (*.txt)|*.txt" };
            var result = fileDialog.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    TxtBoxSelectedFile.Text = fileDialog.FileName;
                    break;
                case DialogResult.Cancel:
                default:
                    break;
            }
        }
    }
}
