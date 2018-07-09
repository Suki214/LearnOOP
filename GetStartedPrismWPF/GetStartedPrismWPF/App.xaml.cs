using System.Windows;

namespace GetStartedPrismWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            PrismGetStartedBootstrapper bootstrapper = new PrismGetStartedBootstrapper();
            bootstrapper.Run();
        }
    }
}
