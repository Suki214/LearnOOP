using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThreadPoolDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int money = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.SetMaxThreads(5, 5);
            for (int i = 0; i < 60; i++)
            {
                ThreadPool.QueueUserWorkItem(Run, 5000);
            }
            Thread.Sleep(1000);
            Task.
            MessageBox.Show(money.ToString());
        }

        public void Run(object mny)
        {
            money += int.Parse(mny.ToString());
        }
    }
}
