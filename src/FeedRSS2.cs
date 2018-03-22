using System.ServiceModel.Syndication;
using System.Xml;
using System.Collections.Generic;

namespace feeds
{
    public class FeedRSS2 : Feed
    {
        public FeedRSS2(string url) : base(url) { }

        public override Information[] ParseFeed()
        {
            SyndicationFeed feed = SyndicationFeed.Load(XmlReader.Create(URL));

            List<Information> listInf = new List<Information>();
            
            foreach (var i in feed.Items)
            {
                var information = new Information();
                information.Title = i.Title.Text;
                //information.PublicationDate = i.PublishDate.DateTime;
                //information.Description = i.Summary.Text;
                listInf.Add(information);
            }

            return listInf.ToArray();
        }
    }
}