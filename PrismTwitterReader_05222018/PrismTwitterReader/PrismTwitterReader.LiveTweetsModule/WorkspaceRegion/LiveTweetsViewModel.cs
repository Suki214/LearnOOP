using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Commands;
using PrismTwitterReader.Common;

namespace PrismTwitterReader.LiveTweetsModule
{
    public class LiveTweetsViewModel : TweetsBaseViewModel
    {
        ITweetDataService _dataService;
        bool _saveTweetExecuted;

        public LiveTweetsViewModel(IEventAggregator eventAggregator, ITweetDataService dataService)
        {
            _dataService = dataService;
            eventAggregator.GetEvent<SelectLiveUserEvent>().Subscribe(LiveUserSelectedEventReceived);
            SaveUserTweetCommand = new DelegateCommand<TweetModel>(ExecuteSaveUserTweetCommand);
        }

        public DelegateCommand<TweetModel> SaveUserTweetCommand { get; }

        private async void LiveUserSelectedEventReceived(UserModel userModel)
        {
            try
            {
                _dataService.SetBusyState(true, $"Loading tweets for @{userModel.ScreenName}");

                IEnumerable<TweetEntity> tweetList =
                                            await Task.Run(() => _dataService.GetUserTweets(userModel.UserId));
                TweetModelList = tweetList.Select(GenerateTweetModelFrom).ToList();
                SelectedUserModel = userModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(LiveUserSelectedEventReceived)} => {ex.Message}");
            }
            finally
            {
                string message = $"Loaded tweets for @{userModel.ScreenName}";        
                if (!_saveTweetExecuted)
                {
                    message += " -> you can click an image button next to a tweet to save it in JSON file.";
                }
                _dataService.SetBusyState(false, message);
            }
        }

        private TweetModel GenerateTweetModelFrom(TweetEntity tweet)
        {
            // Split text and embed url
            string fullText, embedUrl;
            int index = tweet.FullText.IndexOf("http");
            if (index == 0)
            {
                fullText = string.Empty;
                embedUrl = tweet.FullText.Split(' ', '\n')?[0];
            }
            else if (index > 0)
            {
                fullText = tweet.FullText.Substring(0, index);
                embedUrl = tweet.FullText.Substring(index).Split(' ', ',', '，', '\n')?[0];
            }
            else
            {
                fullText = tweet.FullText;
                embedUrl = string.Empty;
            }

            // Determine tweet date / time
            string tweetDateTime;
            TimeSpan span = DateTime.Now.Subtract(tweet.CreatedAt);
            if ((int)span.TotalHours == 0)
            {
                tweetDateTime = ((int)span.TotalMinutes > 0) ?
                                     $"{(int)span.TotalMinutes}m" : $"{(int)span.TotalSeconds}s";
            }
            else if (span.TotalHours < 24)
            {
                int hours = (int)(span.TotalMinutes > 0 ? span.TotalHours + 1 : span.TotalHours);
                tweetDateTime = $"{hours}h";
            }
            else
            {
                tweetDateTime = string.Format("{0:t}   ", tweet.CreatedAt) +
                                        string.Format("{0:MMM d}", tweet.CreatedAt);
            }

            return new TweetModel
            {
                TweetId = tweet.Id,
                TweetUrl = $"https://twitter.com/{tweet.CreatedBy.ScreenName}/status/{tweet.Id}",
                TweetFullText = fullText,
                TweetEmbedUrl = embedUrl,
                TweetImageUrl = tweet.Entities?.MediaList?[0].MediaUrl,
                TweetDateTime = tweetDateTime,
                TweetCreatedAt = tweet.CreatedAt
            };
        }

        private void ExecuteSaveUserTweetCommand(TweetModel tweetModel)
        {            
            _saveTweetExecuted = true;
            if (!tweetModel.WasTweetSaved)
            {
                _dataService.SaveUserTweetToRepo(SelectedUserModel, tweetModel);

                // This is not pretty, but gets the job done for changing tooltip
                var newList = TweetModelList.ToList();
                newList.First(x => x.TweetId == tweetModel.TweetId).WasTweetSaved = true;
                TweetModelList = newList;
            }
        }
    }
}
