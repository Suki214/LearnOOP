using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // 建立ViewModel和使用ViewModel作为DataContext
            MainWindow view = new MainWindow();
            var vm = new ViewModel.CalculatorViewModel();
            
            view.DataContext = vm;
            view.Show();
        }

    }
}
