using LookAuKwat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LookAuKwat.ViewModel
{
    public class JobViewModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAdd { get; set; }
        public string SearchOrAskJob { get; set; }
        public string TypeContract { get; set; }
        public string ActivitySector { get; set; }
        public string Category { get; set; }

    }
}