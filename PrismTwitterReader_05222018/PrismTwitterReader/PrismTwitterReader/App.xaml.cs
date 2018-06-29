using System;
using System.Threading;
using System.Windows;

namespace PrismTwitterReader
{    
    public partial class App : Application
    {
        private static Mutex _InstanceMutex;

        /// <summary>
        /// App.xaml Build Action is Page,
        /// not ApplicationDefinition
        /// </summary>
        [STAThread]
        public static void Main()
        {
            _InstanceMutex = new Mutex(false, "PrismTwitterReader");
            bool owned = _InstanceMutex.WaitOne(TimeSpan.Zero, false);
            if (!owned)
            {
                MessageBox.Show("PrismTwitterReader is already running.  This instance will exit.",
                                "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var application = new App();
            application.Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                var bootstrapper = new Bootstrapper();                
                bootstrapper.Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                Shutdown();
            }
        }
    }
}
