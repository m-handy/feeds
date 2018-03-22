using System;
using System.Xml.Serialization;

namespace feeds
{
    public class FeedXML : Feed
    {
        public FeedXML(string url) : base(url) { }

        public override Information[] ParseFeed()
        {
            var informationArray = new InformationArray();
            using (var reader = Client.OpenRead(URL))
            {
                var serializer = new XmlSerializer(typeof(InformationArray));
                informationArray = (InformationArray)serializer.Deserialize(reader);
            }
            return informationArray.Information;
        }
    }
}