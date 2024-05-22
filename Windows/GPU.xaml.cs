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
    /// Interaction logic for GPU.xaml
    /// </summary>
    public partial class GPU : Window
    {
        public GPU()
        {
            InitializeComponent();
        }

        private void _GpuInfo_Click(object sender, RoutedEventArgs e)
        {
            WindowDialogue.CreateNewInstance(new GpuInformation());
        }
    }
}
