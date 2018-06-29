using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using Prism.Events;
using PrismTwitterReader.Common;

namespace PrismTwitterReader.SavedTweetsModule
{
    public class SavedTweetsViewModel : TweetsBaseViewModel
    {
        ITweetDataService _dataService;
        bool _deleteTweetExecuted;

        public SavedTweetsViewModel(IEventAggregator eventAggregator, ITweetDataService dataService)
        {
            _dataService = dataService;
            eventAggregator.GetEvent<SelectSavedUserEvent>().Subscribe(SavedUserSelectedEventReceived);
            DeleteUserSavedTweetCommand = new DelegateCommand<TweetModel>(ExecuteDeleteUserSavedTweetCommand);
        }

        public DelegateCommand<TweetModel> DeleteUserSavedTweetCommand { get; }

        private void SavedUserSelectedEventReceived(UserModel userModel)
        {
            try
            {
                _dataService.SetBusyState(true, $"Loading user (@{userModel.ScreenName}) tweets from JSON file");

                RebindSavedUserTweets(userModel.UserId, userModel.ScreenName);
                SelectedUserModel = userModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(SavedUserSelectedEventReceived)} => {ex.Message}");
            }
            finally
            {                
                string message = $"Loaded user (@{ userModel.ScreenName}) tweets from JSON file";
                if (!_deleteTweetExecuted)
                {
                    message += " -> you can click an image button next to a tweet delete it from JSON file.";
                }
                _dataService.SetBusyState(false, message);
            }
        }

        private void RebindSavedUserTweets(long userId, string screenName)
        {
            IEnumerable<TweetModel> tweetList = _dataService.GetUserTweetsFromRepo(userId);
            TweetModelList =
                tweetList.Select(x =>
                                    new TweetModel
                                    {
                                        TweetId = x.TweetId,
                                        TweetUrl = $"https://twitter.com/{screenName}/status/{x.TweetId}",
                                        TweetFullText = x.TweetFullText,
                                        TweetEmbedUrl = x.TweetEmbedUrl,
                                        TweetImageUrl = x.TweetImageUrl,
                                        TweetDateTime = x.TweetCreatedAt.ToString(),
                                        TweetCreatedAt = x.TweetCreatedAt
                                    })
                         .ToList();
        }

        private void ExecuteDeleteUserSavedTweetCommand(TweetModel tweetModel)
        {            
            _deleteTweetExecuted = true;
            _dataService.DeleteUserTweetFromRepo(SelectedUserModel, tweetModel.TweetId);
            RebindSavedUserTweets(SelectedUserModel.UserId, SelectedUserModel.ScreenName);
        }
    }
}
