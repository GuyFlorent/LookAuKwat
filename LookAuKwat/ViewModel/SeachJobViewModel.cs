using LookAuKwat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class SeachJobViewModel
    {
        public string TitleJobSearch { get; set; }
        public string TownJobSearch { get; set; }
        public string StreetJobSearch { get; set; }
        public string PriceJobMinSearch { get; set; }
        public string PriceJobMaxSearch { get; set; }
        public string SearchOrAskJobJob { get; set; }
        public string TypeContractJob { get; set; }
        public string ActivitySectorJob { get; set; }
        public List<ProductModel> ListePro { get; set; }
    }
}