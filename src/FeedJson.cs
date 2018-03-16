using Newtonsoft.Json;
using System;

namespace feeds
{
    public class FeedJson : Feed
    {
        string json = @"{
                    'Title': 'šáščášýěáíýšěáí',
                    'Description': 'lorem ipsum',
                    'PublicationDate': '2013-01-20T00:00:00Z',
                    'ImagePath': 'url://url.url',
                    'Navic': 'neco navic',
                    'zase': 2
                    }";

        public FeedJson(string url) : base(url) { }

        public override Information ParseFeed()
        {
            //DownloadData();
            Information information = JsonConvert.DeserializeObject<Information>(json);
            return information;
        }

    }
}