
namespace InstagramTokenExample
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class InstagramMediaContent
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("media_type")]
        public string Media_Type { get; set; }

        [JsonProperty("media_url")]
        public string Media_Url { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("timestamp")]
        public DateTime TimeStamp { get; set; }
    }

    public class InstagramMediaContentResult
    {
        [JsonProperty("data")]
        public IEnumerable<InstagramMediaContent> Data { get; set; }
    }


    public class InstagramLongLiveAccessToken
    {
        [JsonProperty("expires_in")]
        public int Expires_In { get; set; }
    }
}
