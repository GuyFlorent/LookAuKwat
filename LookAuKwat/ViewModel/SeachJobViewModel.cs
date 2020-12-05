using LookAuKwat.Migrations;
using LookAuKwat.Models;
using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ModeModel = LookAuKwat.Models.ModeModel;

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
        [Range(0, int.MaxValue, ErrorMessage = "seule les valeurs positives sont acceptées")]
        [DisplayName("Prix min")]
        public int PriceMinSearch { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "seule les valeurs positives sont acceptées")]
        [DisplayName("Prix max")]
        public int PriceMaxSearch { get; set; }
        
        public List<ProductModel> ListePro { get; set; }
        public List<JobModel> ListeProJob { get; set; }
        public List<ApartmentRentalModel> ListeProAppart { get; set; }
        public List<MultimediaModel> ListeProMulti { get; set; }
        public List<ModeModel> ListeProMode { get; set; }
        public List<VehiculeModel> ListeProVehicule { get; set; }
        public List<Models.HouseModel> ListeProHouse { get; set; }
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
        [Range(0, int.MaxValue, ErrorMessage = "seule les valeurs positives sont acceptées")]
        [DisplayName("Surface min(m2)")]
        public int MinApartSurface { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "seule les valeurs positives sont acceptées")]
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

        [Range(0, int.MaxValue, ErrorMessage = "seule les valeurs positives sont acceptées")]
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
        [Range(0, int.MaxValue, ErrorMessage = "seule les valeurs positives sont acceptées")]
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
        [DisplayName("Sexe")]
        public string UniversMode { get; set; }
        [DisplayName("Taille")]
        public string SizeModeClothes { get; set; }
        [DisplayName("Taille")]
        public string SizeModeShoes { get; set; }

        [DisplayName("Couleur")]
        public string ColorMode { get; set; }
        [DisplayName("Etat")]
        public string StateMode { get; set; }


        //for all product
        [DisplayName("Ville")]
        public string TownAllProduct { get; set; }
        [DisplayName("Recherche")]
        public string SearchTermAllProduct { get; set; }

        //for House model
        [DisplayName("Ville")]
        public string TownHouse { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "seule les valeurs positives sont acceptées")]
        [DisplayName("Prix max")]
        public int PriceHouse { get; set; }
        [DisplayName("Rubrique")]
        public string RubriqueHouse { get; set; }
        [DisplayName("type")]
        public string TypeHouseAmmeublement { get; set; }
        [DisplayName("type")]
        public string TypeHouseDecoration { get; set; }
        [DisplayName("type")]
        public string TypeHouseLinge { get; set; }
        [DisplayName("Produit")]
        public string TypeHouseCuisine { get; set; }
        [DisplayName("Matière")]
        public string FabricMaterialeHouseAmmeublementDeco { get; set; }
        [DisplayName("Matière")]
        public string FabricMaterialeHouseLinge { get; set; }
        [DisplayName("Matière")]
        public string FabricMaterialeHouseCuisine { get; set; }
        [DisplayName("Couleur")]
        public string ColorHouse { get; set; }
        [DisplayName("état")]
        public string StateHouse { get; set; }

    }
}