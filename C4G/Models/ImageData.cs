using System;

namespace C4G.Models
{
    public class ImageData
    {
        public Uri ImagePath { get; set; }
        public String ImageName { get; set; }

        public ImageData(Uri uri, String imgName)
        {
            this.ImagePath = uri;
            this.ImageName = imgName;
        }
    }
}
