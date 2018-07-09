using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrismDemo
{
    public class Bootstrapper: UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.TryResolve<PrismAppShell>();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            App.Current.MainWindow = (PrismAppShell)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            this.ModuleCatalog.AddModule(null);
        }
    }
}
