using LookAuKwat.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class SeachJobViewModel
    {
        public string CagtegorieSearch { get; set; }
        public string TitleSearch { get; set; }
        public string TownSearch { get; set; }
        public string StreetSearch { get; set; }
        public int PriceMinSearch { get; set; }
        public int PriceMaxSearch { get; set; }

        public List<ProductModel> ListePro { get; set; }

        //For jobs
        public string SearchOrAskJobJob { get; set; }
        public string TypeContractJob { get; set; }
        public string ActivitySectorJob { get; set; }
        
       
    }
}