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

namespace ScoobyDoo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void _CPU_Testing_Click(object sender, RoutedEventArgs e)
        {
            //CPU Testing window
            this.SwitchTo(new CPU());
        }

        private void _GPU_Testing_Click(object sender, RoutedEventArgs e)
        {
            //GPU Testing window
            this.SwitchTo(new GPU());
        }
    }
}
