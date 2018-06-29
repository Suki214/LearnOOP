using System;
using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using PrismTwitterReader.Common;

namespace PrismTwitterReader
{
    public class Bootstrapper : UnityBootstrapper
    {
        ShellWindowViewModel _shellWindowViewModel;

        public Bootstrapper()
        {
        }

        protected override void ConfigureModuleCatalog()
        {
            Type liveTweetsModuleType = typeof(PrismTwitterReader.LiveTweetsModule.LiveTweetsModule);
            ModuleCatalog.AddModule(new ModuleInfo(liveTweetsModuleType.Name,
                                            liveTweetsModuleType.AssemblyQualifiedName));
            Type savedTweetsModuleType = typeof(PrismTwitterReader.SavedTweetsModule.SavedTweetsModule);
            ModuleCatalog.AddModule(new ModuleInfo(savedTweetsModuleType.Name,
                                            savedTweetsModuleType.AssemblyQualifiedName));
        }
        //// One alternative is to use the Module Discovery method of populating 
        //// the Module Catalog (sub-folder .\Modules).  It requires a post-build event 
        //// in each module to place the module assembly in the module catalog directory.        
        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    var moduleCatalog = new DirectoryModuleCatalog();
        //    moduleCatalog.ModulePath = @".\Modules";
        //    return moduleCatalog;
        //}

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            _shellWindowViewModel = Container.Resolve<ShellWindowViewModel>();
            Container.RegisterInstance<ITweetDataService>(_shellWindowViewModel);
        }

        protected override DependencyObject CreateShell()
        {
            //  This method sets the UnityBootstrapper.Shell property to the ShellWindow.
            //  UnityBootstrapper base  class will attach an instance of the RegionManager 
            //  to the new Shell window.

            return new ShellWindow(_shellWindowViewModel);
        }
        
        protected override void InitializeShell()
        {
            base.InitializeShell();

            if (!_shellWindowViewModel.LoadTwitterCredentialsAndLogin())
            {
                throw new Exception("Cannot find Twitter credentials json file or login failed.");
            }

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }
    }
}
