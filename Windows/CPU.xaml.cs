using ScoobyDoo.Windows;
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
using System.Windows.Shapes;

namespace ScoobyDoo
{
    /// <summary>
    /// Interaction logic for CPU.xaml
    /// </summary>
    public partial class CPU : Window
    {
        public CPU()
        {
            InitializeComponent();
        }

        private void _CpuInfo_Click(object sender, RoutedEventArgs e)
        {
            WindowDialogue.CreateNewInstance(new ComponentInformation("CPU Information",ComponentInformation.Component.CPU));
        }

        private void DiscreteSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void _StartBenchmark_Click(object sender, RoutedEventArgs e)
        {
            WindowDialogue.Exception("This is my first Scooby Exception!");
        }
    }
}
