using System;
using Newtonsoft.Json;

namespace PrismTwitterReader.Common
{
    public class TweetModel
    {
        public TweetModel()
        {            
        }

        public long TweetId { get; set; }
        public string TweetUrl { get; set; }
        public string TweetFullText { get; set; }
        public string TweetEmbedUrl { get; set; }
        public string TweetImageUrl { get; set; }
        [JsonIgnore]
        public bool TweetImageUrlNotEmpty => !string.IsNullOrWhiteSpace(TweetImageUrl);
        [JsonIgnore]
        public string TweetDateTime { get; set; }
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime TweetCreatedAt { get; set; }
        [JsonIgnore]
        public bool WasTweetSaved { get; set; }
        [JsonIgnore]
        public string SaveTweetToolTip => WasTweetSaved ? "The tweet was saved" : "Save this tweet in JSON file";        
    }
}
