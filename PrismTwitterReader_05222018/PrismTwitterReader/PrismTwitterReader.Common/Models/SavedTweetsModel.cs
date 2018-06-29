using System.Collections.Generic;

namespace PrismTwitterReader.Common.Models
{
    public class SavedTweetsModel
    {
        public SavedTweetsModel()
        {
            UserModelList = new List<UserModel>();
        }

        public List<UserModel> UserModelList { get; set; }
    }
}
