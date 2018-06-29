using System;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace PrismTwitterReader.SavedTweetsModule
{
    public class SavedTweetsModule : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;        

        public SavedTweetsModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("TaskButtonRegion", typeof(ShowSavedTweetsButton));
            
            _container.RegisterType<object, SavedTweets>("SavedTweets");
            _container.RegisterType<object, SavedUsers>("SavedUsers");
        }
    }
}
