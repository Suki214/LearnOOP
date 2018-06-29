using System;
using System.Collections.Generic;
using System.Diagnostics;
using Prism.Mvvm;
using Prism.Commands;

namespace PrismTwitterReader.Common
{
    public class TweetsBaseViewModel : BindableBase
    {
        List<TweetModel> _tweetModelList;
        UserModel _selectedUserModel;

        public TweetsBaseViewModel()
        {
            OpenUrlCommand = new DelegateCommand<string>(ExecuteOpenUrlCommand);
        }

        public UserModel SelectedUserModel
        {
            get { return _selectedUserModel; }
            set { SetProperty(ref _selectedUserModel, value); }
        }

        public List<TweetModel> TweetModelList
        {
            get { return _tweetModelList; }
            set { SetProperty(ref _tweetModelList, value); }
        }

        public DelegateCommand<string> OpenUrlCommand { get; }

        private void ExecuteOpenUrlCommand(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(ExecuteOpenUrlCommand)} => {ex.Message}");
            }
        }
    }
}
