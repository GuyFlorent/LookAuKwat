using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class VehiculeViewModel
    {

        public int id { get; set; }
        [Required(ErrorMessage = "Le titre de l'annonce ne doit pas être vide")]

        [DisplayName("Titre de l'annonce*")]
        public string TitleVehicule { get; set; }
        [Required(ErrorMessage = "La description ne doit pas être vide")]
        [DisplayName("Description")]
        public string DescriptionVehicule { get; set; }
        [DisplayName("Ville")]
        public string TownVehicule { get; set; }
        [Required(ErrorMessage = "L'adresse ne doit pas être vide")]
        [DisplayName("Quartier*")]
        public string StreetVehicule { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "seule les valeurs positives sont acceptées")]
        [DisplayName("Prix (FCFA)")]
        public int PriceVehicule { get; set; }
        public DateTime DateAdd { get; set; }
        [DisplayName("Je vends/Je recherche")]
        public string SearchOrAskJobVehicule { get; set; }
        [DisplayName("Rubrique")]
        public string RubriqueVehicule { get; set; }
        [DisplayName("Marque")]
        public string BrandVehiculeAuto { get; set; }
        [DisplayName("Marque")]
        public string BrandVehiculeBike { get; set; }
        [DisplayName("Equipement auto")]
        public string BrandAccessoryAutoVehicule { get; set; }
        [DisplayName("Equipement moto")]
        public string BrandAccessoryBikeVehicule { get; set; }
        [DisplayName("Modèle")]
        public string ModelVehiculeToyota { get; set; }
        [DisplayName("Modèle")]
        public string ModelVehiculeMercedes { get; set; }
        [DisplayName("Modèle")]
        public string ModelVehiculeHuyndrai { get; set; }
        [DisplayName("Modèle")]
        public string ModelVehiculeMazda { get; set; }
        [DisplayName("Modèle")]
        public string ModelVehiculeKia { get; set; }
        [DisplayName("Modèle")]
        public string ModelVehiculeBike { get; set; }
        [DisplayName("Modèle")]
        public string ModelVehiculeAutoEquipment { get; set; }
        [DisplayName("Modèle")]
        public string ModelVehiculeBikeEquipment { get; set; }
        [DisplayName("Type")]
        public string TypeVehicule { get; set; }
        [DisplayName("Carburant")]
        public string PetrolVehicule { get; set; }
        [DisplayName("Mise en circulation")]
        public string FirstYearVehicule { get; set; }
        [DisplayName("Année")]
        public string YearVehicule { get; set; }
        [DisplayName("Kilométrage")]
        public string MileageVehicule { get; set; }
        [DisplayName("Nombre de portes")]
        public string NumberOfDoorVehicule { get; set; }
        [DisplayName("Couleur")]
        public string ColorVehicule { get; set; }
        [DisplayName("Transmission")]
        public string GearBoxVehicule { get; set; }
       
        [DisplayName("Etat")]
        public string StateVehicule { get; set; }
        public ImageModelView Imageproduct { get; set; }
    }
}