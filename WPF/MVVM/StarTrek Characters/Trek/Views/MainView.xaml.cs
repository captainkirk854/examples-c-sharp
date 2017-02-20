using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleMVVM.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        // Custom Button Events related to Mouse ...
        private void myOKButton_Click(object sender, RoutedEventArgs e)
        {
            myOKButton.Content = "Whoops!";
        }
        private void myOKButton_MouseEnter(object sender, MouseEventArgs e)
        {
            myOKButton.Content = "Why Hello Mouse ....";
        }

        private void myOKButton_MouseLeave(object sender, MouseEventArgs e)
        {
            myOKButton.Content = "Goodbye little mousey :(";
        }
    }
}
