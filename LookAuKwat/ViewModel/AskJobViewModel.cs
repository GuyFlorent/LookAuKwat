﻿using LookAuKwat.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class AskJobViewModel
    {
        [DisplayName("Catégorie")]
        public string CagtegorieSearchAsk { get; set; }
        [DisplayName("Recherche")]
        public string TitleSearchAsk { get; set; }
        [DisplayName("Ville")]
        public string TownSearchAsk { get; set; }
        public string sortBy { get; set; }
        public List<ProductModel> ListePro { get; set; }
        public IPagedList<ProductModel> ListeProPagedList { get; set; }
        // for pagedList

        public int? PageNumber { get; set; }
       
    }
}