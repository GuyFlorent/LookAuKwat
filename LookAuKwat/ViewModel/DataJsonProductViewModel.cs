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
        public int? Price { get; set; }
        public string DateAdd { get; set; }
        public string SearchOrAskJob { get; set; }
        public string  Category { get; set; }
       
        public string Lat { get; set; }
        public string Lon { get; set; }
        public  string Images { get; set; }
    }
}