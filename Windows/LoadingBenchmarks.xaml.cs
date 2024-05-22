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
    /// Interaction logic for LoadingBenchmarks.xaml
    /// </summary>
    public partial class LoadingBenchmarks : Window
    {
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
    }
}
