using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloWorldByPrism.Views
{
    /// <summary>
    /// Interaction logic for HelloWorldViewAgain.xaml
    /// </summary>
    public partial class HelloWorldViewAgain : UserControl
    {
        private readonly IRegionManager regionManager;
        public HelloWorldViewAgain()
        {
            InitializeComponent();
        }

        public void DisplayHelloWorldView()
        {
            var view = this.regionManager.Regions["MainRegion"].GetView("HelloWorldViewAgain") as DependencyObject;
            IRegion region = RegionManager.GetRegionManager(view).Regions["HelloWorldViewAgain"];
            region.Add(new HelloWorldView(), "Hello");
        }


    }
}
