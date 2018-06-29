using System;
using Prism.Regions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using PrismTwitterReader.Common;

namespace PrismTwitterReader.SavedTweetsModule
{
    public class ShowSavedTweetsButtonViewModel : BindableBase
    {
        IRegionManager _regionManager;
        IEventAggregator _eventAggregator;
        string _buttonTextFontWeight;

        public ShowSavedTweetsButtonViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            ShowSavedTweetListCommand = new DelegateCommand(ExecuteShowSavedTweetListCommand);
            _eventAggregator.GetEvent<ModuleNavigationEvent>().Subscribe(OnModuleNavigation, ThreadOption.UIThread);
            _buttonTextFontWeight = "SemiBold";
        }

        public DelegateCommand ShowSavedTweetListCommand { get; }

        public string ButtonTextFontWeight
        {
            get { return _buttonTextFontWeight; }
            set { SetProperty(ref _buttonTextFontWeight, value); }
        }

        private void ExecuteShowSavedTweetListCommand()
        {         
            // Show Navigator
            var userListNavigator = new Uri("SavedUsers", UriKind.Relative);
            _regionManager.RequestNavigate("NavigatorRegion", userListNavigator, ShowSavedTweetsUserListNavigationCompleted);         

            // Show Workspace
            var tweetList = new Uri("SavedTweets", UriKind.Relative);
            _regionManager.RequestNavigate("WorkspaceRegion", tweetList);
        }

        private void ShowSavedTweetsUserListNavigationCompleted(NavigationResult result)
        {
            if (result.Result == true)
            {
                _eventAggregator.GetEvent<ModuleNavigationEvent>().Publish(DestinationModuleType.SavedTweets);
            }
        }

        private void OnModuleNavigation(DestinationModuleType destinationModuleType)
        {
            ButtonTextFontWeight = (destinationModuleType == DestinationModuleType.SavedTweets) ?
                                        "Bold" : "SemiBold";
        }
    }
}
