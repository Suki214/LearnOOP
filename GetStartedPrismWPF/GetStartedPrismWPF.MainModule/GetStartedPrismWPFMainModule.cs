using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetStartedPrismWPF.MainModule
{
    public class GetStartedPrismWPFMainModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        public GetStartedPrismWPFMainModule(IRegionViewRegistry registry)
        {
            regionViewRegistry = registry;
        }
        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("MainRegion", typeof(View.GetStartedPrismView));
        }
    }
}
