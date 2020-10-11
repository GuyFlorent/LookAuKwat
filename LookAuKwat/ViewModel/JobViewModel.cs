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
        [Required]
        [DisplayName("Titre de l'annonce*")]
        public string Title { get; set; }

        public string Description { get; set; }
        [DisplayName("Ville")]
        public string Town { get; set; }
        [Required]
        [DisplayName("Adresse*")]
        public string Street { get; set; }
        
        [DisplayName("Salaire")]
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