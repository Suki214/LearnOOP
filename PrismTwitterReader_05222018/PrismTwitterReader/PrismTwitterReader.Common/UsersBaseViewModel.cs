using System;
using System.Collections.Generic;
using System.Linq;
using Prism;
using Prism.Mvvm;
using Prism.Commands;

namespace PrismTwitterReader.Common
{
    public class UsersBaseViewModel : BindableBase, IActiveAware
    {
        List<UserModel> _userModelList;
        UserModel _selectedUserModelItem;

        public UsersBaseViewModel()
        {
            SelectUserCommand = new DelegateCommand<object[]>(ExecuteSelectUserCommand);

            IsActiveChanged += (s, e) =>
            {
                OnActiveChanged(IsActive);
            };
        }

        public UserModel SelectedUserModelItem
        {
            get { return _selectedUserModelItem; }
            set { SetProperty(ref _selectedUserModelItem, value); }
        }

        public List<UserModel> UserModelList
        {
            get { return _userModelList; }
            set { SetProperty(ref _userModelList, value); }
        }

        public DelegateCommand<object[]> SelectUserCommand { get; }

        protected void ExecuteSelectUserCommand(object[] selectedUser)
        {
            UserModel userModel = selectedUser?.FirstOrDefault() as UserModel;
            OnExecuteSelectUserCommand(userModel);
        }

        protected virtual void OnExecuteSelectUserCommand(UserModel userModel)
        {
        }

        protected virtual void OnActiveChanged(bool isActive)
        {
        }

        #region IActiveAware 
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (SetProperty(ref _isActive, value))
                {
                    IsActiveChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        public event EventHandler IsActiveChanged;
        #endregion
    }
}
