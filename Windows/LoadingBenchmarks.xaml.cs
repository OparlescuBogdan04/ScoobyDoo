using System;
using System.Threading.Tasks;
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
            Title = window_name;
            _BenchmarkName.Text = benchmark_test;
            UpdateElapsedTime(0);
        }

        #region coroutine
        DateTime start_time;
        bool is_running = false;
        void InitializeCoroutine()
        {
            is_running = true;
            start_time = DateTime.Now;
            StartCoroutine();
        }

        void StartCoroutine()
        {
            begin:
            UpdateElapsedTime();

            Task.Delay(100).Wait();
            if (is_running)
                goto begin;
        }

        void StopCoroutine()
        {
            is_running= false;
        }
        #endregion

        public LoadingBenchmarks(string window_name, string benchmark_test,CPU_package package):this(window_name, benchmark_test) 
        {
            TestCPU(package.aray_length, package.no_threads);
        }

        void UpdateElapsedTime(int value)
        {
            _TimeElapsed.Text = $"Elapsed Time:\n{value} milliseconds";
        }

        void UpdateElapsedTime()
        {
            int ms = (int)(DateTime.Now - start_time).TotalMilliseconds;
            UpdateElapsedTime(ms);
        }

        public void TestCPU(int array_length, int no_threads)
        {
            tested_component = Component.CPU;
            Clock clock = new Clock();
            //InitializeCoroutine();
            new TestingThreading().____ThreadsTesting(array_length, no_threads);
            //StopCoroutine();
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
