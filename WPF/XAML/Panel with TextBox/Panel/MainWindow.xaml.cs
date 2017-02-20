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


namespace WpfApplicationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StackPanel plop = new StackPanel();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "Hello WPF!";
        }

        private void textBox1_MouseEnter(object sender, MouseEventArgs e)
        {
            textBox1.Text = "Why Hello Mouse ....";
        }

        private void textBox1_MouseLeave(object sender, MouseEventArgs e)
        {
            textBox1.Text = "Goodbye little mousey :(";
        }
    }
}