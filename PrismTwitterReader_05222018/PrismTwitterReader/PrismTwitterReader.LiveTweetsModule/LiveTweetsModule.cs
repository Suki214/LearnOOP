using System;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace PrismTwitterReader.LiveTweetsModule
{
    public class LiveTweetsModule : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public LiveTweetsModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            // Register available controls with the Prism Region Manager, and on-demand controls
            // will be loaded when invoking IRegionManager.RequestNavigate() 

            // Register task button region                     
            _regionManager.RegisterViewWithRegion("TaskButtonRegion", typeof(ShowLiveTweetsButton));

            // Register view objects with DI Container (Unity)                       
            _container.RegisterType<object, LiveUsers>("LiveUsers");
            _container.RegisterType<object, LiveTweets>("LiveTweets");
        }
    }
}
