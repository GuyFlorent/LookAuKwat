using LookAuKwat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class ModeViewModel
    {
        public int id { get; set; }
        [DisplayName("Je vends/Je recherche")]
        public string SearchOrAskMode { get; set; }
        [DisplayName("Ville")]
        public string TownMode { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "seule les valeurs positives sont acceptées")]
        [DisplayName("Prix(CFA)")]
        public int PriceMode { get; set; }
        [DisplayName("Titre de l'annoce")]
        public string TitleMode { get; set; }
        [DisplayName("Description")]
        public string DescriptionMode { get; set; }
        [DisplayName("Quartier")]
        public string StreetMode { get; set; }
        [DisplayName("Rubrique")]
        public string RubriqueMode { get; set; }
        [DisplayName("Type")]
        public string TypeModeClothes { get; set; }
        [DisplayName("Type")]
        public string TypeModeShoes { get; set; }
        [DisplayName("Type")]
        public string TypeModeAccesorieLugages { get; set; }
        [DisplayName("Type")]
        public string TypeModeWatchJewelry { get; set; }
        [DisplayName("Type")]
        public string TypeModeBabyEquipment { get; set; }
        [DisplayName("Type")]
        public string TypeModeBabyClothes { get; set; }
        [DisplayName("Marque")]
        public string BrandModeClothes { get; set; }
        [DisplayName("Marque")]
        public string BrandModeShoes { get; set; }
        [DisplayName("Univers")]
        public string UniversMode { get; set; }
        [DisplayName("Taille")]
        public string SizeModeClothes { get; set; }
        [DisplayName("Taille")]
        public string SizeModeShoes { get; set; }
        
        [DisplayName("Couleur")]
        public string ColorMode { get; set; }
        [DisplayName("Etat")]
        public string StateMode { get; set; }
        public ImageModelView Imageproduct { get; set; }
        public List<ImageProcductModel> listeImage { get; set; }
    }
}