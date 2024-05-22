using ScoobyDoo.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScoobyDoo
{
    public static class WindowDialogue
    {
        public static void CreateNewInstance(Window window)
        {
            window.Show();
        }

        public static void SwitchTo(this Window current, Window new_window)
        {
            double left = current.Left;
            double top = current.Top;
            new_window.Show();
            current.Hide();
            new_window.Left = left;
            new_window.Top = top;
        }

        public static void Exception(string message)
        {
            CreateNewInstance(new ExceptionWindow(message));
        }
    }
}
