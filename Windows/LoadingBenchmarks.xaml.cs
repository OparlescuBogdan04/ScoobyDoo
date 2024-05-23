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
using Component = ScoobyDoo.Windows.ComponentInformation.Component;

namespace ScoobyDoo.Windows
{
    /// <summary>
    /// Interaction logic for LoadingBenchmarks.xaml
    /// </summary>
    public partial class LoadingBenchmarks : Window
    {
        int score = 0;
        Component tested_component=Component.NULL;
        public LoadingBenchmarks(string window_name, string benchmark_test)
        {
            InitializeComponent();
            this.Title=window_name;
            _BenchmarkName.Text = benchmark_test;
            UpdateElapsedTime(0);
        }

        void UpdateElapsedTime(int value)
        {
            _TimeElapsed.Text = $"Elapsed Time: {value}";
        }

        public void TestCPU(int array_length,int no_threads)
        {
            //testing
            tested_component = Component.CPU;
            _Done.Visibility = Visibility.Visible;
        }

        void TestGPU()
        {
            //testing
            tested_component = Component.GPU;
            _Done.Visibility = Visibility.Visible;
        }

        private void _Done_Click(object sender, RoutedEventArgs e)
        {
            this.SwitchTo(new Results(score,tested_component));
        }
    }
}
