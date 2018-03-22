using System;
using Newtonsoft.Json;

namespace feeds
{
    public class FeedJson : Feed
    {
        public FeedJson(string url) : base(url) { }

        public override Information[] ParseFeed()
        {
            return JsonConvert.DeserializeObject<Information[]>(Client.DownloadString(URL));
        }

    }
}