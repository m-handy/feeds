using System;
using System.Xml.Serialization;
using System.IO;

namespace feeds
{
    class Program
    {
        static void Main(string[] args)
        {
            var newsML = "http://fse.futurelicensing.com/feed/fetch/token/7cd98ffad2be20944ce8f13c1533697d";
            var RSS2_Format = "http://fse.futurelicensing.com/feed/fetch/token/40526a492f631f0306bd5bbdff042cb2/";
            var JSON_Format = "http://fse.futurelicensing.com/feed/fetch/token/cc4920d3fd32c3000501d66afdd9c2eb/";

            //GetFeed(Feed.Type.JSON, JSON_Format);
            //GetFeed(Feed.Type.RSS2, RSS2_Format);
            //GetFeed(Feed.Type.NewsML, newsML);
            //GetFeed(Feed.Type.NewsML, "https://www.iptc.org/std/NewsML-G2/2.15/examples/LISTING%202%20NewsML-G2%20Text%20Document.xml");
            var rss = GetFeed(Feed.Type.RSS2, "https://gist.githubusercontent.com/ToddG/1974651/raw/f7978c779bcb00aaa5a6551936e2387590cb303f/sample-rss-2.0-feed.xml");
            SaveFeed(rss, "rss");
        }

        static Information GetFeed(Feed.Type type, string URL)
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
                default: throw new Exception("Unsupported type!");
            }
            return feed.ParseFeed();
        }

        static void SaveFeed(Information information, string filename)
        {
            var outputDir = "output";
            var xmlSerializer = new XmlSerializer(typeof(Information));
            Directory.CreateDirectory(outputDir);
            var outputFileStream = new StreamWriter(outputDir + Path.DirectorySeparatorChar + filename + ".xml");

            xmlSerializer.Serialize(outputFileStream, information);

            outputFileStream.Close();
        }

    }
}
