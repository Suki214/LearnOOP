﻿using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using System.Windows;

namespace GetStartedPrismWPF
{
    class PrismGetStartedBootstrapper:UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.TryResolve<Shell>();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            Application.Current .MainWindow=(Window)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(MainModule.GetStartedPrismWPFMainModule));
        }
    }
}
