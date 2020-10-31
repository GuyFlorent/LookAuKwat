using LookAuKwat.Models;
using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class SeachJobViewModel
    {
        public string CagtegorieSearch { get; set; }
        public string TitleSearch { get; set; }
        [DisplayName("Ville")]
        public string TownSearch { get; set; }
        [DisplayName("Lieu")]
        public string StreetSearch { get; set; }
        [DisplayName("Salaire min")]
        public int PriceMinSearch { get; set; }
        [DisplayName("Salaire max")]
        public int PriceMaxSearch { get; set; }
        
        public List<ProductModel> ListePro { get; set; }
        public IPagedList<ProductModel> ListeProPagedList { get; set; }
        // for pagedList

        public int? PageNumber { get; set; }
        public string sortBy { get; set; }
        //For jobs
        [DisplayName("J'offre/Je demande")]
        public string SearchOrAskJobJob { get; set; }
        [DisplayName("Type de contrat")]
        public string TypeContractJob { get; set; }
        [DisplayName("Secteur d'activité")]
        public string ActivitySectorJob { get; set; }

        //for Appartment Rental
        [DisplayName("Surface min(m2)")]
        public int MinApartSurface { get; set; }
        [DisplayName("Surface max(m2)")]
        public int MaxApartSurface { get; set; }
        [DisplayName("Nombre de pièces minimale")]
        public int RoomNumber { get; set; }
        [DisplayName("Meublé ou non meublé")]
        public string FurnitureOrNot { get; set; }
        public string Type { get; set; }

        //for multimedia
        [DisplayName("Ville*")]
        public string TownMultimedia { get; set; }
        

        [DisplayName("Prix maximal")]
        public int PriceMultimedia { get; set; }
        [DisplayName("Rubrique")]
        public string TypeMultimedia { get; set; }
        [DisplayName("Marque")]
        public string BrandMultimedia { get; set; }
        
        [DisplayName("Marque")]
        public string BrandOtherMultimedia { get; set; }
        [DisplayName("Modèle")]
        public string ModelMultimedia { get; set; }
       
        [DisplayName("Stockage")]
        public string Capacity { get; set; }

        //for vehicule
        [DisplayName("Ville")]
        public string TownVehicule { get; set; }
        [DisplayName("Rubrique")]
        public string RubriqueVehicule { get; set; }
        [DisplayName("Marque")]
        public string BrandVehicule { get; set; }
        [DisplayName("Modèle")]
        public string ModelVehicule { get; set; }
        [DisplayName("Recherche")]
        public string SearchTitleVehicule { get; set; }

        // for mode
        [DisplayName("Ville")]
        public string TownMode { get; set; }
        [DisplayName("Prix max")]
        public int PriceMode { get; set; }
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
    }
}