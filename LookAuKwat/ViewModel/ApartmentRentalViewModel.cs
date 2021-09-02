using LookAuKwat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class ApartmentRentalViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le titre de l'annonce ne doit pas être vide")]
        [DisplayName("Titre de l'annonce*")]
        [StringLength(50)]
        public string TitleAppart { get; set; }
        [Required(ErrorMessage = "La description de l'annonce ne doit pas être vide")]
        [DisplayName("Description*")]
        public string DescriptionAppart { get; set; }
        
        [DisplayName("Ville")]
        public string TownAppart { get; set; }
        [Required(ErrorMessage = "L'adresse ne doit pas être vide")]
        [DisplayName("Quartier*")]
        public string StreetAppart { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "seule les valeurs positives sont acceptées")]
        [DisplayName("Prix(FCFA)")]
        public int PriceAppart { get; set; }
        public DateTime DateAddAppart { get; set; }
        [DisplayName("J'offre/Je recherche")]
        public string SearchOrAskJobAppart { get; set; }
        [DisplayName("Type de bien")]
        public string Type { get; set; }
        [DisplayName("Superficie(m2)")]
        public int ApartSurface { get; set; }
        [DisplayName("Nombre de pièces")]
        public int RoomNumber { get; set; } 
        [DisplayName("Meublé ou non meublé")]
        public string FurnitureOrNot { get; set; }
        //new
        [DisplayName("Pays")]
        public string ProductCountry { get; set; }
        [DisplayName("Nombre")]
        public int Stock { get; set; }
        public int Stock_Initial { get; set; }
        [DisplayName("Y'a t'il un lien vidéo ?")]
        public string VideoUrl { get; set; }
        [DisplayName("Y'a t'il un fournisseur ?")]
        public string Provider_Id { get; set; }
        public string Category { get; set; }
        public ImageModelView Imageproduct { get; set; }
        public List<ImageProcductModel> listeImageappart { get; set; }
    }
}