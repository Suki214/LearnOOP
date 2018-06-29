using Newtonsoft.Json;

namespace PrismTwitterReader.Common
{
    public class MediaEntity
    {
        [JsonProperty("media_url")]
        public string MediaUrl { get; set; }       

        [JsonProperty("type")]
        public string MediaType { get; set; }
    }
}
