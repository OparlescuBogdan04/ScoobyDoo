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
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : Window
    {
        int score = 0;
        Component Component = Component.NULL;
        public Results(int score,Component component)
        {
            InitializeComponent();
            this.score = score;
            this.Component=component;
            DisplayScoobyScore(score,component);
        }

        public int getScore()
        {
            return score;
        }
        public Component getComponent()
        {
            return Component;
        }

        private void _Save_Click(object sender, RoutedEventArgs e)
        {
            WindowDialogue.CreateNewInstance(new SaveScore(this));
        }

        void DisplayScoobyScore(int value,Component component)
        {
            string component_name=component.name();
            _ScoobyScore.Text = $"Your Scooby Score is: {value}\nTested {component_name}";
        }
    }
}
