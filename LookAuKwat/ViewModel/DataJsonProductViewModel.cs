using LookAuKwat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class DataJsonProductViewModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public int Price { get; set; }
        public string DateAdd { get; set; }
        public string SearchOrAskJob { get; set; }
        public virtual CategoryModel Category { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ProductCoordinateModel Coordinate { get; set; }
        public virtual List<string> Images { get; set; }
    }
}