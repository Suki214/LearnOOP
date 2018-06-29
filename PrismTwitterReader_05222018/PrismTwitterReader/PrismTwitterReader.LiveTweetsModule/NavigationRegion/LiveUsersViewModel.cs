using System.Collections.Generic;
using System.Linq;
using Prism.Events;
using PrismTwitterReader.Common;

namespace PrismTwitterReader.LiveTweetsModule
{
    public class LiveUsersViewModel : UsersBaseViewModel
    {
        IEventAggregator _eventAggregator;
        UserModel _selectedSavedUserModel;

        public LiveUsersViewModel(IEventAggregator eventAggregator, ITweetDataService dataService)
        {
            _eventAggregator = eventAggregator;
            UserModelList = dataService.GetLoginUsers()?
                                .Select(x => new UserModel(x))
                                .OrderBy(x => x.ScreenName)
                                .ToList() ?? new List<UserModel>();
            eventAggregator.GetEvent<SelectSavedUserEvent>().Subscribe(SavedUserSelectedEventReceived);
        }

        protected override void OnExecuteSelectUserCommand(UserModel userModel)
        {
            if (userModel != null)
            {
                _eventAggregator.GetEvent<SelectLiveUserEvent>().Publish(userModel);
            }
        }

        protected override void OnActiveChanged(bool isActive)
        {
            if (isActive && _selectedSavedUserModel != null)
            {
                // Sync user with SavedTweetsModule
                SelectedUserModelItem = _selectedSavedUserModel;
                OnExecuteSelectUserCommand(_selectedSavedUserModel);
            }
        }

        private void SavedUserSelectedEventReceived(UserModel userModel)
        {
            // Track saved user selection in the SavedTweetsModule
            _selectedSavedUserModel = UserModelList?.FirstOrDefault(x => x.UserId == userModel.UserId);
        }
    }
}
