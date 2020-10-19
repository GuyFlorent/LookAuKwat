using LookAuKwat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class JobEditViewModel
    {
        public int JobEditid { get; set; }
        [Required(ErrorMessage = "Le titre de l'annonce ne doit pas être vide")]
        [DisplayName("Titre de l'annonce *")]
        public string TitleJob { get; set; }
        public ProductCoordinateModel Coordinate { get; set; }
        public string DescriptionJob { get; set; }
        [DisplayName("Ville *")]
        public string TownJob { get; set; }
        [Required(ErrorMessage = "L'adresse ne doit pas être vide")]
        [DisplayName("Quartier *")]
        public string StreetJob { get; set; }
        [Required(ErrorMessage = "Le salaire ne doit pas être vide")]
        [DisplayName("Salaire *")]
        public int PriceJob { get; set; }
        public DateTime DateAddJob { get; set; }
        public string SearchOrAskJobJob { get; set; }
        [DisplayName("Type de contrat")]
        public string TypeContractJob { get; set; }
        [DisplayName("Secteur d'activté")]
        public string ActivitySectorJob { get; set; }
        public string CategoryJob { get; set; }
        public ImageModelView ImageproductJob { get; set; }
        public List<ImageProcductModel> listeImageJob { get; set; }
    }
}