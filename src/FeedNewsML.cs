using System.Xml.Linq;
using System.Linq;
using System;
using System.Collections.Generic;

namespace feeds
{
    public class FeedNewsML : Feed
    {
        public FeedNewsML(string url) : base(url) { }

        public override Information[] ParseFeed()
        {
            IEnumerable<XElement> childList;
            List<Information> listInf = new List<Information>();
            using (var reader = Client.OpenRead(URL))
            {
                var x = XElement.Load(reader);
                childList =
                    from el in x.Descendants("ProductOffer")
                        //where (string)el.Attribute("uri") == "Yes"
                    select el;
            }

            foreach (XElement e in childList)
            {
                Console.WriteLine(e);
            }

            
            return listInf.ToArray();
        }
    }
}