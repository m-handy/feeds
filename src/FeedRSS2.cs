using System.ServiceModel.Syndication;
using System.Xml;

namespace feeds
{
    public class FeedRSS2 : Feed
    {
        public FeedRSS2(string url) : base(url) { }

        public override Information ParseFeed()
        {
            //DownloadData();
            SyndicationFeed feed = SyndicationFeed.Load(XmlReader.Create(URL));

            var information = new Information();
            foreach (var i in feed.Items)
            {
                information.Title = i.Title.Text;
                information.PublicationDate = i.PublishDate.DateTime;
                information.Description = i.Summary.Text;
            }

            return information;
        }
    }
}