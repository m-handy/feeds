using System;
using System.Xml.Serialization;

namespace feeds
{
    public class Information
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("price")]
        public string Price { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("image_path")]
        public string Image_Path { get; set; }


        public override string ToString()
        {
            return "Information: " + "[" +
            "Title: " + Title + ", " +
            "Price: " + Price + ", " +
            "Link: " + Link + ", " +
            "ImagePath: " + Image_Path + "]";
        }
    }

    [XmlRoot("ArrayOfProductOffer")]
    public class InformationArray
    {
        [XmlElement("ProductOffer")]
        public Information[] Information { get; set; }
    }
}