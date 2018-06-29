using Newtonsoft.Json;

namespace PrismTwitterReader.Common
{
    public class UrlEntity
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        public override string ToString()
        {
            return Url;
        }

    }
}
