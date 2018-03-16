using System;
using System.Net;

namespace feeds
{
    public abstract class Feed
    {
        public string URLdata { get; private set; }
        protected string URL { get; }
        public enum Type { RSS2, NewsML, JSON };

        public Feed(string url)
        {
            this.URL = url;
        }

        protected void DownloadData()
        {
            Console.WriteLine("Downloading " + this.ToString());
            URLdata = new WebClient().DownloadString(URL);
        }

        public abstract Information ParseFeed();


    }
}