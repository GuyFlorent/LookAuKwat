using LookAuKwat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class JobEditViewModel
    {
        public int JobEditid { get; set; }
        public string TitleJob { get; set; }
        public string DescriptionJob { get; set; }
        public string TownJob { get; set; }
        public string StreetJob { get; set; }
        public int PriceJob { get; set; }
        public string DateAddJob { get; set; }
        public string SearchOrAskJobJob { get; set; }
        public string TypeContractJob { get; set; }
        public string ActivitySectorJob { get; set; }
        public string CategoryJob { get; set; }
        public ImageModelView ImageproductJob { get; set; }
        public List<ImageProcductModel> listeImageJob { get; set; }
    }
}