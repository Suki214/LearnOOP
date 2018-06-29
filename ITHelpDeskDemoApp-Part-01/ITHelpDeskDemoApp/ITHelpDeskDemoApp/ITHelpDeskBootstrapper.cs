using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using System.Windows;

namespace ITHelpDeskDemoApp
{
    class ITHelpDeskBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            
           // return Container.Resolve<Shell>();
             return new Shell();

        }
        protected override void InitializeShell()
        {
           // base.InitializeShell();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }
    }
}