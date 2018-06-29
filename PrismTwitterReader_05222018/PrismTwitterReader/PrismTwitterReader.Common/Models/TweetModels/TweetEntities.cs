using System.Collections.Generic;
using Newtonsoft.Json;

namespace PrismTwitterReader.Common
{
    public class TweetEntities
    {
        [JsonProperty("urls")]
        public List<UrlEntity> UrlList { get; set; }

        [JsonProperty("media")]
        public List<MediaEntity> MediaList { get; set; }
    }
}
