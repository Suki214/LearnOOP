using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Infor.QAA.Enterprise.Migration.ViewModel;

namespace Infor.QAA.Enterprise.Migration
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var dialog = new MainWindow();
            var vm = new MigrationWizardViewModel();
            dialog.DataContext = vm;
            dialog.ShowDialog();
        }
    }
}
