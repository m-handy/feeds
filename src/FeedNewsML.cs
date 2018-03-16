using System.Xml.Linq;
using System.Linq;
using System;
using System.Collections.Generic;

namespace feeds
{
    public class FeedNewsML : Feed
    {
        public FeedNewsML(string url) : base(url) { }

        public override Information ParseFeed()
        {
            DownloadData();
            var x = XElement.Parse(URLdata);
            IEnumerable<XElement> childList =
                from el in x.Descendants("name")
                //where (string)el.Attribute("uri") == "Yes"
                select el ;
            foreach (XElement e in childList)
                Console.WriteLine(e);
            return new Information();
        }
    }
}