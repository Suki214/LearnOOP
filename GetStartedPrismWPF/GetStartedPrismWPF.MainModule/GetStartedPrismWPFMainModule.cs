using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

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
