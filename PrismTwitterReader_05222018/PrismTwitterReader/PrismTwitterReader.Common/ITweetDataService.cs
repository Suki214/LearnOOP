using System.Collections.Generic;

namespace PrismTwitterReader.Common
{
    public interface ITweetDataService
    {
        IEnumerable<UserEntity> GetLoginUsers();
        IEnumerable<TweetEntity> GetUserTweets(long userId);        
        IEnumerable<UserModel> GetUsersFromRepo();        
        IEnumerable<TweetModel> GetUserTweetsFromRepo(long userId);
        void SaveUserTweetToRepo(UserModel userModel, TweetModel tweetModel);
        void DeleteUserTweetFromRepo(UserModel userModel, long tweetId);
        void SetBusyState(bool isBusy, string message);
    }
}
