using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThreadDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private AccountBalance ab = new AccountBalance(100);

        Context context = new Context(new DebugLog());
        Context context1 = new Context(new SimpleFileLog());

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            Task.Run(()=> 
            {
                while (ab.Withdraw(1))
                {
                    context.LogWrite(string.Format("task 1 balance {0}", ab.myBalance));
                }
                
            });

            Task.Run(() =>
            {
                while (ab.Withdraw(1))
                {
                    context.LogWrite(string.Format("task 2 balance {0}", ab.myBalance));
                }

            });
        }
    }
}
