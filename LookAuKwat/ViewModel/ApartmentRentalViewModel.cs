using LookAuKwat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class ApartmentRentalViewModel
    {
        public int Id { get; set; }
        public string TitleAppart { get; set; }
        public string DescriptionAppart { get; set; }
        public string TownAppart { get; set; }
        public string StreetAppart { get; set; }
        public int PriceAppart { get; set; }
        public string DateAddAppart { get; set; }
        public string SearchOrAskJobAppart { get; set; }
        public int ApartSurface { get; set; }
        public int RoomNumber { get; set; }
        public string FurnitureOrNot { get; set; }
        public string Category { get; set; }
        public ImageModelView Imageproduct { get; set; }
        public List<ImageProcductModel> listeImageappart { get; set; }
    }
}