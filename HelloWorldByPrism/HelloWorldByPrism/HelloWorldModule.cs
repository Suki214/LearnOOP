using HelloWorldByPrism.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace HelloWorldByPrism
{
    public class HelloWorldModule : IModule
    {
        
        private readonly IRegionManager regionManager;
        public IUnityContainer container { get; set; }
        public HelloWorldModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }
        public void Initialize()
        {
            RenderHelloWorldView();
        }
        private void RenderHelloWorldView()
        {
            IRegion mainRegion = this.regionManager.Regions["MainRegion"];
            mainRegion.Add(new HelloWorldView());
        }

        private void RenderHelloWorldViewAgain()
        {
            IRegion mainRegion = regionManager.Regions["MainRegion"];
            HelloWorldViewAgain viewAgain = container.Resolve<HelloWorldViewAgain>();
            mainRegion.Add(viewAgain, "MainRegion");
            viewAgain.DisplayHelloWorldView();
        }

        protected virtual RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings regionAdapterMappings = container.Resolve<RegionAdapterMappings>();
            if (regionAdapterMappings != null)
            {
                regionAdapterMappings.RegisterMapping(typeof(Selector), this.container.Resolve<SelectorRegionAdapter>());
                regionAdapterMappings.RegisterMapping(typeof(ItemsControl), this.container.Resolve<ItemsControlRegionAdapter>());
                regionAdapterMappings.RegisterMapping(typeof(ContentControl), container.Resolve<ContentControlRegionAdapter>());
            }
            return regionAdapterMappings;
        }    
    }

    public class StakPanelRegionAdapter : IRegionAdapter
    {
        public IRegion Initialize(object regionTarget, string regionName)
        {
            //StackPanel stackPanel = regionTarget as StackPanel;
            //AllActiveRegion region = new AllActiveRegion();
            //region.Name = regionName;
            //region.ActiveViews.CollectionChanged += delegate
            //{
            //    stackPanel.Children.Clear();
            //    foreach (var item in region.ActiveViews)
            //    {
            //        stackPanel.Children.Add(item as UIElement);
            //    }
            //};
            if (regionName == null)
                throw new ArgumentNullException("regionName");
            IRegion region = CreateRegion();
            region.Name = regionName;

            SetObservableRegionOnHostingControl(region, regionTarget);
            //Adapt(region, regionTarget);
            return region;
        }

        private void SetObservableRegionOnHostingControl(IRegion region, object regionTarget)
        {
            throw new NotImplementedException();
        }

    }

    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(IRegionBehaviorFactory defauleBehaviors) : base(defauleBehaviors) { }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.ActiveViews.CollectionChanged += delegate
            {
                regionTarget.Children.Clear();
                foreach (var item in region.ActiveViews)
                {
                    regionTarget.Children.Add(item as UIElement);
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
