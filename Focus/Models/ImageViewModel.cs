using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Focus.Models
{
    public class ImageViewModel
    {
        public int ImageID { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string ImageText { get; set; }

        public HttpPostedFileWrapper ImageFile { get; set; }
    }
}