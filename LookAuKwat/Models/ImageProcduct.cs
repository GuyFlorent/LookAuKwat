using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookAuKwat.Models
{
    public class ImageProcduct
    { 
        public int id { get; set; }
        public string Image { get; set; }
        public List <HttpPostedFileBase> ImageFile { get; set; }
        public Product Product { get; set; }
    }
}