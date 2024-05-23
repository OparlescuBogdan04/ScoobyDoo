using System;
using System.Collections.Generic;
using System.IO;
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
        public Results results = null;
        public SaveScore(Results results)
        {
            InitializeComponent();
            this.results = results;
        }

        private void _Save_Click(object sender, RoutedEventArgs e)
        {
            AppendScore();
        }


        string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/scores.txt";

        void AppendScore()
        {
            StreamWriter writer = File.AppendText(path);
            string line = $"Testing: {results.getComponent().name()}    Score: {results.getScore()}    Username: {_Username.Text}";
            writer.WriteLine(line);
            writer.Close();
            MessageBox.Show(line);
        }
    }
}
