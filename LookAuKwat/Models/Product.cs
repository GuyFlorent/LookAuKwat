using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookAuKwat.Models
{
    public class Product
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAdd { get; set; }
        public string SearchOrAskJob { get; set; }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ProductCoordinate Coordinate { get; set; }
        public virtual List<ImageProcduct>  Images { get; set; }
    }
}