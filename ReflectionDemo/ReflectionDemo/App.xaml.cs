using ReflecteForUTDemo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ReflectionDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var solution = "UtProject";
            var assemblyList = new List<string>
            {
                @"C:\Users\sxu\source\repos\CalculatorDemo\CalculatorDemoTests\bin\Debug\CalculatorDemoTests.dll",
            };

            var treeRoot = AssemblyWalker.BuildTree(solution, assemblyList);
            var projects = new UtTreeViewModel(treeRoot);
            MainWindow window = new MainWindow();
            window.DataContext = projects;
            window.ShowDialog();
        }
    }
}
