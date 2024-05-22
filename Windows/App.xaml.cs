using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ScoobyDoo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow((DependencyObject)sender);
            if (window != null)
                window.SwitchTo(new MainWindow());
        }
    }
}
