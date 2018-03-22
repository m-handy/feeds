using System;
using System.Xml.Serialization;
using System.IO;

namespace feeds
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Parsing JSON...");
            var JSON_Format = "https://api-stage.getprice.com.au/v1/products?category=95&country=1&r=10&o=j";
            var json = GetFeed(Feed.Type.JSON, JSON_Format);
            SaveFeed(json, Feed.Type.JSON.ToString());

            Console.WriteLine("Parsing XML...");
            var XML_Format = "https://api-stage.getprice.com.au/v1/products?category=95&country=1&r=10&o=x";
            var xml = GetFeed(Feed.Type.XML, XML_Format);
            SaveFeed(xml, Feed.Type.XML.ToString());

            Console.WriteLine("Done.");
        }

        static Information[] GetFeed(Feed.Type type, string URL)
        {
            Feed feed;
            switch (type)
            {
                case Feed.Type.JSON:
                    feed = new FeedJson(URL);
                    break;
                case Feed.Type.NewsML:
                    feed = new FeedNewsML(URL);
                    break;
                case Feed.Type.RSS2:
                    feed = new FeedRSS2(URL);
                    break;
                case Feed.Type.XML:
                    feed = new FeedXML(URL);
                    break;
                default: throw new Exception("Unsupported type!");
            }
            return feed.ParseFeed();
        }

        static void SaveFeed(Information[] information, string filename)
        {
            var outputDir = "output";
            Directory.CreateDirectory(outputDir);
            var outputFileStream = new StreamWriter(outputDir + Path.DirectorySeparatorChar + filename + ".xml");

            var xmlSerializer = new XmlSerializer(typeof(Information[]));
            xmlSerializer.Serialize(outputFileStream, information);

            outputFileStream.Close();
        }

    }
}
