using System;

namespace feeds
{
    public class Information
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ImagePath { get; set; }


        public override string ToString()
        {
            return "Information: " + "[" + 
            "Title: " + Title + ", " + 
            "Description: " + Description + ", " + 
            "PublicationDate: " + PublicationDate + ", " + 
            "ImagePath: " + ImagePath + "]";
        }
    }
}