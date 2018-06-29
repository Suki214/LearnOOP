using System.Collections.Generic;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace PrismTwitterReader.Common
{
    /// <summary>
    /// Json serializable
    /// </summary>
    public class UserModel : BindableBase
    {
        bool _isSelected;

        public UserModel()
        {
        }

        public UserModel(UserEntity user)
        {
            UserId = user.Id;
            UserName = user.Name;
            ScreenName = user.ScreenName;
            ProfileImageUrl = user.ProfileImageUrl;
            TweetModelList = new List<TweetModel>();
        }

        public UserModel(UserModel userModel)
        {
            UserId = userModel.UserId;
            UserName = userModel.UserName;
            ScreenName = userModel.ScreenName;
            ProfileImageUrl = userModel.ProfileImageUrl;
            TweetModelList = new List<TweetModel>();
        }

        public long UserId { get; set; }
        public string UserName { get; set; }
        public string ScreenName { get; set; }        
        public string ProfileImageUrl { get; set; }
        public List<TweetModel> TweetModelList { get; set; }
        [JsonIgnore]
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }
    }
}