using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPrismDemoModule
{
    public class WpfPrismDemoModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        public WpfPrismDemoModule(IRegionViewRegistry registry)
        {
            regionViewRegistry = registry;
        }
        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("MainRegion", typeof(Views.WpfPrismDemoView));
        }
    }
}
