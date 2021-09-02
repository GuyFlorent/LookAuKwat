using LookAuKwat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class HouseViewModel
    {

        [Required(ErrorMessage = "Le titre de l'annonce ne doit pas être vide")]

        [DisplayName("Titre de l'annonce*")]
        [StringLength(50)]
        public string Title { get; set; }
        [Required(ErrorMessage = "La Description de l'annonce ne doit pas être vide")]

        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Ville")]
        public string Town { get; set; }
        [Required(ErrorMessage = "Le Quartier de l'annonce ne doit pas être vide")]
        [DisplayName("Quartier")]
        public string Street { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "seule les valeurs positives sont acceptées")]
        [DisplayName("Prix (FCFA)")]
        public int Price { get; set; }
        [DisplayName("Rubrique")]
        public string RubriqueHouse { get; set; }
        [DisplayName("Type")]
        public string TypeHouse { get; set; }
        [DisplayName("Matière")]
        public string FabricMaterialeHouse { get; set; }
        [DisplayName("Couleur")]
        public string ColorHouse { get; set; }
        [DisplayName("état")]
        public string StateHouse { get; set; }
        [DisplayName("J'offre/Je recherche")]
        public string SearchOrAskJob { get; set; }
        //new
        [DisplayName("Pays")]
        public string ProductCountry { get; set; }
        [DisplayName("Quantité")]
        public int Stock { get; set; }
        public int Stock_Initial { get; set; }
       
        [DisplayName("Y'a t'il un fournisseur ?")]
        public string Provider_Id { get; set; }
        public ImageModelView Imageproduct { get; set; }
        public List<ImageProcductModel> listeImage { get; set; }
    }
}