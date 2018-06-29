using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Prism.Mvvm;
using Prism.Events;
using PrismTwitterReader.TwitterAccesss;
using PrismTwitterReader.Common;
using PrismTwitterReader.Common.Models;

namespace PrismTwitterReader
{
    public class ShellWindowViewModel : BindableBase, ITweetDataService
    {
        UserEntity _loginUser;
        TwitterHttpClient _twitterHttpClient;
        string _currentStatusMessage;
        string _loadedModuleImageName = "App.ico";
        string _loadedModuleTitle = "No Module Loaded";
        string _savedTweetsFilePath;
        SavedTweetsModel _savedTweetsModel;

        public ShellWindowViewModel(IEventAggregator eventAggregator)
        {
            _savedTweetsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SavedTweets.json");
            _savedTweetsModel = ReloadSavedTweetsModelFromRepo();
            eventAggregator.GetEvent<ModuleNavigationEvent>().Subscribe(OnModuleNavigation, ThreadOption.UIThread);
        }

        public string WindowTitle { get; set; }

        public string CurrentStatusMessage
        {
            get { return _currentStatusMessage; }
            set { SetProperty(ref _currentStatusMessage, value); }
        }

        public string LoadedModuleImageName
        {
            get { return _loadedModuleImageName; }
            set { SetProperty(ref _loadedModuleImageName, value); }
        }

        public string LoadedModuleTitle
        {
            get { return _loadedModuleTitle; }
            set { SetProperty(ref _loadedModuleTitle, value); }
        }

        #region ITweetDataService implementation               
        public IEnumerable<UserEntity> GetLoginUsers()
        {
            return _twitterHttpClient.GetFriends(_loginUser.Id);
        }

        public IEnumerable<TweetEntity> GetUserTweets(long userId)
        {
            return _twitterHttpClient.GetUserTweetList(userId);
        }

        public void SetBusyState(bool isBusy, string message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (isBusy)
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                }
                else
                {
                    // If I restore mouse cursor here, it might be too early since TweetList may be still updating,
                    // so I start a timer with ApplicationIdle and restore mouse cursor there on the first tick.
                    // Mouse.OverrideCursor = null;
                    new DispatcherTimer(TimeSpan.FromSeconds(0),
                            DispatcherPriority.ApplicationIdle,
                                (s, e) =>
                                {
                                    ((DispatcherTimer)s).Stop();
                                    Mouse.OverrideCursor = null;
                                },
                                Application.Current.Dispatcher);
                }

                CurrentStatusMessage = message;
            });
        }

        public IEnumerable<UserModel> GetUsersFromRepo()
        {
            _savedTweetsModel = ReloadSavedTweetsModelFromRepo();
            return _savedTweetsModel.UserModelList;
        }

        public void SaveUserTweetToRepo(UserModel userModel, TweetModel tweetModel)
        {
            try
            {
                var user = _savedTweetsModel.UserModelList.FirstOrDefault(x => x.UserId == userModel.UserId);
                if (user == null)
                {
                    user = new UserModel(userModel);
                    _savedTweetsModel.UserModelList.Add(user);
                }
                if (!user.TweetModelList.Any(x => x.TweetId == tweetModel.TweetId))
                {
                    user.TweetModelList.Add(tweetModel);
                    JsonHelper.SaveAsJsonToFile(_savedTweetsModel, _savedTweetsFilePath);
                    CurrentStatusMessage = $"The tweet (Id: {tweetModel.TweetId}) saved in {Path.GetFileName(_savedTweetsFilePath)}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(SaveUserTweetToRepo)} => {ex.Message}");
            }
        }

        public IEnumerable<TweetModel> GetUserTweetsFromRepo(long userId)
        {
            _savedTweetsModel = ReloadSavedTweetsModelFromRepo();
            return _savedTweetsModel.UserModelList.Where(x => x.UserId == userId).SelectMany(x => x.TweetModelList);
        }

        public void DeleteUserTweetFromRepo(UserModel userModel, long tweetId)
        {
            var user = _savedTweetsModel.UserModelList.FirstOrDefault(x => x.UserId == userModel.UserId);
            if (user != null)
            {
                var tweet = user.TweetModelList.FirstOrDefault(x => x.TweetId == tweetId);
                if (tweet != null)
                {
                    user.TweetModelList.Remove(tweet);
                    if (user.TweetModelList.Count == 0)
                    {
                        _savedTweetsModel.UserModelList.Remove(user);
                    }
                    JsonHelper.SaveAsJsonToFile(_savedTweetsModel, _savedTweetsFilePath);
                    CurrentStatusMessage = $"{userModel.UserName}'s tweet (Id: {tweetId}) deleted from {Path.GetFileName(_savedTweetsFilePath)}";
                }
            }
        }
        #endregion

        public bool LoadTwitterCredentialsAndLogin()
        {
            // Look for first credentials file *_Creds.json and try login
            FileInfo fileInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory)
                                                   .GetFiles("*_Creds.json")
                                                   .FirstOrDefault();
            if (File.Exists(fileInfo?.FullName))
            {
                var twitterCreds = JsonHelper.DeserializeFromFile<TwitterCredentials>(fileInfo.FullName);
                if (twitterCreds != null)
                {
                    return TwitterLogin(twitterCreds);
                }
            }
            return false;
        }

        private bool TwitterLogin(TwitterCredentials twitterCreds)
        {
            _twitterHttpClient = new TwitterHttpClient(twitterCreds);
            _loginUser = _twitterHttpClient.GetAuthenticatedUser();
            if (_loginUser == null)
            {
                return false;
            }

            WindowTitle = $"Prism Twitter Reader Login: {_loginUser.Name} (@{_loginUser.ScreenName})";
            CurrentStatusMessage = "Click a 'Show' button to load the corresponding module";
            return true;
        }

        private SavedTweetsModel ReloadSavedTweetsModelFromRepo()
        {
            SavedTweetsModel savedTweetsModel = null;
            if (File.Exists(_savedTweetsFilePath))
            {
                try
                {
                    savedTweetsModel = JsonHelper.DeserializeFromFile<SavedTweetsModel>(_savedTweetsFilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{nameof(ReloadSavedTweetsModelFromRepo)} {_savedTweetsFilePath} => {ex.Message}");
                }
            }
            return savedTweetsModel ?? new SavedTweetsModel();
        }

        private void OnModuleNavigation(DestinationModuleType destinationModuleType)
        {
            if (destinationModuleType == DestinationModuleType.LiveTweets)
            {
                LoadedModuleImageName = @"Resources\Tweet.png";
                LoadedModuleTitle = "Live Tweets Module";
            }
            else if (destinationModuleType == DestinationModuleType.SavedTweets)
            {
                LoadedModuleImageName = @"Resources\TweetSave.png";
                LoadedModuleTitle = "Saved Tweets Module";
            }
            else
            {
                LoadedModuleImageName = @"Resources\App.ico";
                LoadedModuleTitle = "Unknown Module";
            }
        }
    }
}
