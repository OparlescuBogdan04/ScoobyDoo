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

namespace ScoobyDoo.Windows
{
    /// <summary>
    /// Interaction logic for SaveScore.xaml
    /// </summary>
    public partial class SaveScore : Window
    {
        public SaveScore()
        {
            InitializeComponent();
        }

        private void _Save_Click(object sender, RoutedEventArgs e)
        {
            //save data to user db
        }
    }
}
