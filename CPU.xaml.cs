﻿using ScoobyDoo.Windows;
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

        #region Binding Slider with textbox
        private void ThreadsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ThreadsTextBox != null)
            {
                ThreadsTextBox.Text = ThreadsSlider.Value.ToString();
            }
        }

        private void ThreadsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(ThreadsTextBox.Text, out int value))
            {
                ThreadsSlider.Value = value;
            }
        }

        private void ArrayLengthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ArrayLengthTextBox != null)
            {
                ArrayLengthTextBox.Text = ArrayLengthSlider.Value.ToString();
            }
        }

        private void ArrayLengthTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(ArrayLengthTextBox.Text, out int value))
            {
                ArrayLengthSlider.Value = value;
            }
        }
        #endregion

        private void _CpuInfo_Click(object sender, RoutedEventArgs e)
        {
            WindowDialogue.CreateNewInstance(new ComponentInformation("CPU Information", ComponentInformation.Component.CPU));
        }

        private void _StartBenchmark_Click(object sender, RoutedEventArgs e)
        {
            WindowDialogue.Exception("This is my first Scooby Exception!");
        }
    }
}