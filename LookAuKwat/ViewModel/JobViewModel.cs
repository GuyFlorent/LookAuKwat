using LookAuKwat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace LookAuKwat.ViewModel
{
    public class JobViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Le titre de l'annonce ne doit pas être vide")]
       
        [DisplayName("Titre de l'annonce*")]
        [StringLength(50)]
        public string Title { get; set; }
        [Required(ErrorMessage = "La description ne doit pas être vide")]
        public string Description { get; set; }
        [DisplayName("Ville")]
        public string Town { get; set; }
        [Required(ErrorMessage = "L'adresse ne doit pas être vide")]
        [DisplayName("Quartier*")]
        public string Street { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "seule les valeurs positives sont acceptées")]
        [DisplayName("Salaire (FCFA)")]
        public int Price { get; set; }
        public string DateAdd { get; set; }
        [DisplayName("J'offre/Je recherche")]
        public string SearchOrAskJob { get; set; }
        [DisplayName("Type de contrat")]
        public string TypeContract { get; set; }
        [DisplayName("Secteur d'activté")]
        public string ActivitySector { get; set; }
        public string Category { get; set; }
        public ImageModelView Imageproduct { get; set; }
    }
}