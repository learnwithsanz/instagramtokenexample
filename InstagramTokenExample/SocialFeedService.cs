namespace InstagramTokenExample
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class SocialFeedService
    {
        private readonly string instagramBaseAPIUrl = "https://graph.instagram.com/";

        public IEnumerable<InstagramMediaContent> GetInstagramContents(string userToken)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string queryUrl = $"me/media?fields=id,username,timestamp,caption,media_url,media_type,permalink&access_token={userToken}";
                    string fullUrl = $"{this.instagramBaseAPIUrl}{queryUrl}";

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.GetStringAsync(new Uri(fullUrl)).Result;

                    if (!string.IsNullOrEmpty(response))
                    {
                        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                        var result = serializer.Deserialize<InstagramMediaContentResult>(response);
                        return result.Data;
                    }

                    return new List<InstagramMediaContent>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public string RefreshToken(string userToken)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string queryUrl = $"refresh_access_token?grant_type=ig_refresh_token&access_token={userToken}";
                    string fullUrl = $"{this.instagramBaseAPIUrl}{queryUrl}";

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.GetStringAsync(new Uri(fullUrl)).Result;

                    var data = (JObject)JsonConvert.DeserializeObject(response);
                    string expires = data["expires_in"].Value<string>();
                    return expires;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}
