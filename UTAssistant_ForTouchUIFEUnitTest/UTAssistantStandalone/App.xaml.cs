using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Windows;

using UTAssistant.BE;
using UTAssistant.BE.ViewModel;

namespace UTAssistantStandalone
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [PermissionSet(SecurityAction.LinkDemand)]
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var solution = "TouchUI";
            var assemblyList = new List<string>
            {
                //@"D:\TFS\SSME.HMI\bin\Debug\CT.Exam.TouchUI.FE.Test.Unit.dll",
                @"C:\Users\sxu\source\repos\CalculatorDemo\CalculatorDemoTests\bin\Debug\CalculatorDemoTests.dll",                
            };
            var treeRoot = AssemblyWalker.BuildTree(solution, assemblyList);

            var projects = new UtTreeViewModel(treeRoot);

            UTAssistant.FE.MainWindow mainWindow = new UTAssistant.FE.MainWindow();
            mainWindow.DataContext = projects;

            mainWindow.ShowDialog();

        }
    }
}
