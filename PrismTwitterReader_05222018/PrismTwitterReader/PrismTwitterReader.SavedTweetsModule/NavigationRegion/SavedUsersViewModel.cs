using System.Linq;
using Prism.Events;
using PrismTwitterReader.Common;

namespace PrismTwitterReader.SavedTweetsModule
{
    public class SavedUsersViewModel : UsersBaseViewModel
    {
        IEventAggregator _eventAggregator;
        ITweetDataService _dataService;
        UserModel _currentLiveSelectedUserModel;

        public SavedUsersViewModel(IEventAggregator eventAggregator, ITweetDataService dataService)
        {
            _eventAggregator = eventAggregator;
            _dataService = dataService;
            _eventAggregator.GetEvent<SelectLiveUserEvent>().Subscribe(LiveUserSelectedEventReceived);
        }

        protected override void OnExecuteSelectUserCommand(UserModel userModel)
        {
            if (userModel != null)
            {
                _eventAggregator.GetEvent<SelectSavedUserEvent>().Publish(userModel);
            }
        }

        protected override void OnActiveChanged(bool isActive)
        {
            if (isActive)
            {
                UserModelList = _dataService.GetUsersFromRepo()
                                .OrderBy(x => x.ScreenName)
                                .ToList();

                if (_currentLiveSelectedUserModel != null)
                {
                    // Sync user with LiveTweetsModule
                    SelectedUserModelItem = _currentLiveSelectedUserModel;
                    OnExecuteSelectUserCommand(_currentLiveSelectedUserModel);
                }
            }
        }

        private void LiveUserSelectedEventReceived(UserModel userModel)
        {
            // Track live user selection in LiveTweetsModule
            _currentLiveSelectedUserModel = UserModelList?.FirstOrDefault(x => x.UserId == userModel.UserId);
        }
    }
}
