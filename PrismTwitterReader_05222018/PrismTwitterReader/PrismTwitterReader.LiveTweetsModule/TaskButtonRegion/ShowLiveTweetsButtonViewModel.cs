using System;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using PrismTwitterReader.Common;

namespace PrismTwitterReader.LiveTweetsModule
{
    public class ShowLiveTweetsButtonViewModel : BindableBase
    {
        IRegionManager _regionManager;
        IEventAggregator _eventAggregator;
        string _buttonTextFontWeight;

        public ShowLiveTweetsButtonViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            ShowTweetListCommand = new DelegateCommand(ExecuteShowTweetListCommand);
            _eventAggregator.GetEvent<ModuleNavigationEvent>().Subscribe(OnModuleNavigation, ThreadOption.UIThread);
            _buttonTextFontWeight = "SemiBold";
        }

        public DelegateCommand ShowTweetListCommand { get; }

        public string ButtonTextFontWeight
        {
            get { return _buttonTextFontWeight; }
            set { SetProperty(ref _buttonTextFontWeight, value); }
        }

        private void ExecuteShowTweetListCommand()
        {
            // Show Navigator
            var usersNavigator = new Uri("LiveUsers", UriKind.Relative);
            _regionManager.RequestNavigate("NavigatorRegion", usersNavigator, ShowLiveTweetsUserListNavigationCompleted);

            // Show Workspace
            var tweetsNavigator = new Uri("LiveTweets", UriKind.Relative);
            _regionManager.RequestNavigate("WorkspaceRegion", tweetsNavigator);
        }

        private void ShowLiveTweetsUserListNavigationCompleted(NavigationResult result)
        {
            if (result.Result == true)
            {
                _eventAggregator.GetEvent<ModuleNavigationEvent>().Publish(DestinationModuleType.LiveTweets);
            }
        }

        private void OnModuleNavigation(DestinationModuleType destinationModuleType)
        {
            ButtonTextFontWeight = (destinationModuleType == DestinationModuleType.LiveTweets) ?
                                        "Bold" : "SemiBold";
        }
    }
}
