﻿using LookAuKwat.Models;
using Microsoft.Ajax.Utilities;
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
        [DisplayName("Prix minimale")]
        public int PriceMinSearch { get; set; }
        [DisplayName("Prix maximale")]
        public int PriceMaxSearch { get; set; }

        public List<ProductModel> ListePro { get; set; }

        //For jobs
        [DisplayName("J'offre/Je demande")]
        public string SearchOrAskJobJob { get; set; }
        [DisplayName("Type de contrat")]
        public string TypeContractJob { get; set; }
        [DisplayName("Secteur d'activité")]
        public string ActivitySectorJob { get; set; }

        //for Appartment Rental
        [DisplayName("Surface minimale")]
        public int MinApartSurface { get; set; }
        [DisplayName("Surface maximale")]
        public int MaxApartSurface { get; set; }
        [DisplayName("Nombre de pièces minimale")]
        public int RoomNumber { get; set; }
        [DisplayName("Meublé ou non meublé")]
        public string FurnitureOrNot { get; set; }
        public string Type { get; set; }

    }
}