using System;
using System.Windows;
using System.Windows.Threading;
using Component = ScoobyDoo.Windows.ComponentInformation.Component;

namespace ScoobyDoo.Windows
{
    public partial class LoadingBenchmarks : Window
    {
        public struct CPU_package
        {
            public int aray_length;
            public int no_threads;

            public CPU_package(int aray_length, int no_threads)
            {
                this.aray_length = aray_length;
                this.no_threads = no_threads;
            }
        }

        int score = 0;
        Component tested_component = Component.NULL;

        public LoadingBenchmarks(string window_name, string benchmark_test)
        {
            InitializeComponent();
            this.Title = window_name;
            _BenchmarkName.Text = benchmark_test;
            UpdateElapsedTime(0);
        }

        public LoadingBenchmarks(string window_name, string benchmark_test,CPU_package package):this(window_name, benchmark_test) 
        {
            TestCPU(package.aray_length, package.no_threads);
        }

        void UpdateElapsedTime(int value)
        {
            _TimeElapsed.Text = $"Elapsed Time:\n{value} milliseconds";
        }

        public void TestCPU(int array_length, int no_threads)
        {
            tested_component = Component.CPU;
            Clock clock = new Clock();
            //AICI !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            _Done.Visibility = Visibility.Visible;
            int time = clock.GetLapTime();

            if (time != 0)
                score = array_length / time; //thi is our score formula
            else
                score = 0;
        }

        public void TestGPU()
        {
            tested_component = Component.GPU;
            // GPU testing
            _Done.Visibility = Visibility.Visible;
        }

        private void _Done_Click(object sender, RoutedEventArgs e)
        {
            this.SwitchTo(new Results(score, tested_component));
        }
    }
}
