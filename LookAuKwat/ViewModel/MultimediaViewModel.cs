using LookAuKwat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class MultimediaViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Le titre de l'annonce ne doit pas être vide")]

        [DisplayName("Titre de l'annonce*")]
        public string TitleMultimedia { get; set; }
        [Required(ErrorMessage = "La description ne doit pas être vide")]
        public string DescriptionMultimedia { get; set; }
        [DisplayName("Ville")]
        public string TownMultimedia { get; set; }
        [Required(ErrorMessage = "L'adresse ne doit pas être vide")]
        [DisplayName("Adresse*")]
        public string StreetMultimedia { get; set; }

        [DisplayName("Salaire (FCFA)")]
        public int PriceMultimedia { get; set; }
        public DateTime DateAdd { get; set; }
        [DisplayName("J'offre/Je recherche")]
        public string SearchOrAskJobMultimedia { get; set; }
        [DisplayName("Rubrique")]
        public string TypeMultimedia { get; set; }
        [DisplayName("Marque")]
        public string BrandConsoleGame { get; set; }
        [DisplayName("Marque")]
        public string BrandInformatiquePhotocopi { get; set; }

        [DisplayName("Marque")]
        public string BrandPhoneAccesories { get; set; }
        [DisplayName("Marque")]
        public string BrandTv { get; set; }
        [DisplayName("Marque")]
        public string BrandSon { get; set; }
        [DisplayName("Marque")]
        public string BrandOtherMultimedia { get; set; }
        [DisplayName("Modèle")]
        public string ModelInformatiquePhotocopy { get; set; }
        [DisplayName("Modèle")]
        public string ModelConsoleGame { get; set; }
        [DisplayName("Modèle")]
        public string ModelApplePhoneAccesorie { get; set; }
        [DisplayName("Modèle")]
        public string ModelHuaweiPhoneAccesorie { get; set; }
        [DisplayName("Modèle")]
        public string ModelSamsungPhoneAccesorie { get; set; }
        [DisplayName("Modèle")]
        public string ModelSonyPhoneAccesorie { get; set; }
        [DisplayName("Modèle")]
        public string ModelAlcatelPhoneAccesorie { get; set; }
        [DisplayName("Modèle")]
        public string ModelAzusPhoneAccesorie { get; set; }
        [DisplayName("Modèle")]
        public string ModelHonorPhoneAccesorie { get; set; }
        [DisplayName("Modèle")]
        public string ModelHTCPhoneAccesorie { get; set; }
        [DisplayName("Modèle")]
        public string ModelLenovoPhoneAccesorie { get; set; }
        [DisplayName("Modèle")]
        public string ModelMicrosoftPhoneAccesorie { get; set; }
        [DisplayName("Modèle")]
        public string ModelLGPhoneAccesorie { get; set; }
        [DisplayName("Modèle")]
        public string ModelMotorolaPhoneAccesorie { get; set; }
        [DisplayName("Modèle")]
        public string ModelOnePlusPhoneAccesorie { get; set; }
        [DisplayName("Modèle")]
        public string ModelWikoPhoneAccesorie { get; set; }
        [DisplayName("Modèle")]
        public string ModelXaomiPhoneAccesorie { get; set; }
        [DisplayName("Modèle")]
        public string ModelZTEPhoneAccesorie { get; set; }
        [DisplayName("Modèle")]
        public string ModelOtherMultimedia { get; set; }
        [DisplayName("Modèle")]
        public string ModelTV { get; set; }
        [DisplayName("Modèle")]
        public string ModelSon { get; set; }
        [DisplayName("Capacité de stockage")]
        public string Capacity { get; set; }
        public string Category { get; set; }
        public ImageModelView Imageproduct { get; set; }
        public List<ImageProcductModel> listeImage { get; set; }
    }
}