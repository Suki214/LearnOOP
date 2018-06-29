﻿using Newtonsoft.Json;

namespace PrismTwitterReader.Common
{
    public class UserEntity
    {
        [JsonProperty("id")]
        public long Id { get; set; }
      
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
           
        [JsonProperty("profile_image_url")]
        public string ProfileImageUrl { get; set; }
               
        public override string ToString()
        {
            return $"{Name} | {ScreenName} | {Id}";
        }
    }
}
