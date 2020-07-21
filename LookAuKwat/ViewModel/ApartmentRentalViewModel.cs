using LookAuKwat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class ApartmentRentalViewModel
    {
        public int Id { get; set; }
        [DisplayName("Titre de l'annonce")]
        public string TitleAppart { get; set; }
        [DisplayName("Description")]
        public string DescriptionAppart { get; set; }
        [DisplayName("Ville")]
        public string TownAppart { get; set; }
        [DisplayName("Adresse")]
        public string StreetAppart { get; set; }
        [DisplayName("Prix")]
        public int PriceAppart { get; set; }
        public string DateAddAppart { get; set; }
        [DisplayName("J'offre/Je demande")]
        public string SearchOrAskJobAppart { get; set; }
        public string Type { get; set; }
        [DisplayName("Superficie")]
        public int ApartSurface { get; set; }
        [DisplayName("Nombre de pièces")]
        public int RoomNumber { get; set; }
        [DisplayName("Meublé ou non meublé")]
        public string FurnitureOrNot { get; set; }
        public string Category { get; set; }
        public ImageModelView Imageproduct { get; set; }
        public List<ImageProcductModel> listeImageappart { get; set; }
    }
}