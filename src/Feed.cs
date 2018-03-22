using System;
using System.Net;


namespace feeds
{
    public abstract class Feed
    {
        private static WebClient _client = null;
        protected string URL { get; }
        protected WebClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new WebClient();
                    _client.Credentials = new NetworkCredential("viglink", "viglink123");
                }
                return _client;
            }
        }
        public enum Type { RSS2, NewsML, JSON, XML };

        public Feed(string url)
        {
            this.URL = url;
        }

        public abstract Information[] ParseFeed();

    }
}