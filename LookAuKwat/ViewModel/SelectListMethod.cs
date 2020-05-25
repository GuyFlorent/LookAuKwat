    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LookAuKwat.ViewModel
{
    public static class SelectListMethod
    {
        public static IEnumerable<SelectListItem> GetListTownCameroon()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Douala", Value = "Douala" },
                new SelectListItem() { Text = "Yaoundé", Value = "Yaoundé" },
                new SelectListItem() { Text = "Garoua", Value = "Garoua" },
                new SelectListItem() { Text = "Bamenda", Value = "Bamenda" },
                new SelectListItem() { Text = "	Maroua", Value = "Maroua" },
                new SelectListItem() { Text = "Nkongsamba", Value = "Nkongsamba" },
                new SelectListItem() { Text = "Bafoussam", Value = "Bafoussam" },
                new SelectListItem() { Text = "Ngaoundéré", Value = "Ngaoundéré" },
                new SelectListItem() { Text = "Bertoua", Value = "Bertoua" },
                new SelectListItem() { Text = "	Loum", Value = "Loum" },
                new SelectListItem() { Text = "Kumba", Value = "Kumba" },
                new SelectListItem() { Text = "	Kumbo", Value = "Kumbo" },
                new SelectListItem() { Text = "Foumban", Value = "Foumban" },
                new SelectListItem() { Text = "	Mbouda", Value = "Mbouda" },
                new SelectListItem() { Text = "Dschang", Value = "Dschang" },
                new SelectListItem() { Text = "Limbé", Value = "Limbé" },
                new SelectListItem() { Text = "Ebolowa", Value = "Ebolowa" },
                new SelectListItem() { Text = "Kousséri", Value = "Kousséri" },
                new SelectListItem() { Text = "Guider", Value = "Guider" },
                new SelectListItem() { Text = "Meiganga", Value = "Meiganga" },
                new SelectListItem() { Text = "Yagoua", Value = "Yagoua" },
                new SelectListItem() { Text = "Mbalmayo", Value = "Mbalmayo" },
                new SelectListItem() { Text = "Bafang", Value = "Bafang" },
                new SelectListItem() { Text = "Tiko", Value = "Tiko" },
                new SelectListItem() { Text = "	Bafia", Value = "Bafia" },
                new SelectListItem() { Text = "Wum", Value = "Wum" },
                new SelectListItem() { Text = "Kribi", Value = "Kribi" },
                new SelectListItem() { Text = "Buea", Value = "Buea" },
                new SelectListItem() { Text = "Sangmélima", Value = "Sangmélima" },
                new SelectListItem() { Text = "Foumbot", Value = "Foumbot" },
                new SelectListItem() { Text = "Bangangté", Value = "Bangangté" },
                new SelectListItem() { Text = "Batouri", Value = "Batouri" },
                new SelectListItem() { Text = "Banyo", Value = "Banyo" },
                new SelectListItem() { Text = "Nkambé", Value = "Nkambé" },
                new SelectListItem() { Text = "Bali", Value = "Bali" },
                new SelectListItem() { Text = "Mbanga", Value = "Mbanga" },
                new SelectListItem() { Text = "Mokolo", Value = "Mokolo" },
                new SelectListItem() { Text = "Melong", Value = "Melong" },
                new SelectListItem() { Text = "Manjo", Value = "Manjo" },
                new SelectListItem() { Text = "Garoua-Boulaï", Value = "Garoua-Boulaï" },
                new SelectListItem() { Text = "Mora", Value = "Mora" },
                new SelectListItem() { Text = "Kaélé", Value = "Kaélé" },
                new SelectListItem() { Text = "Tibati", Value = "Tibati" },
                new SelectListItem() { Text = "Ndop", Value = "Ndop" },
                new SelectListItem() { Text = "Akonolinga", Value = "Akonolinga" },
                new SelectListItem() { Text = "	Eséka", Value = "Eséka" },
                new SelectListItem() { Text = "Mamfé", Value = "Mamfé" },
                new SelectListItem() { Text = "Obala", Value = "Obala" },
                new SelectListItem() { Text = "Muyuka", Value = "Muyuka" },
                new SelectListItem() { Text = "Nanga-Eboko", Value = "Nanga-Eboko" },
                new SelectListItem() { Text = "Abong-Mbang", Value = "Abong-Mbang" },
                 new SelectListItem() { Text = "Fundong", Value = "Fundong" },
                new SelectListItem() { Text = "Nkoteng", Value = "Nkoteng" },
                new SelectListItem() { Text = "Fontem", Value = "Fontem" },
                 new SelectListItem() { Text = "Mbandjock", Value = "Mbandjock" },
                new SelectListItem() { Text = "Touboro", Value = "Touboro" },
                new SelectListItem() { Text = "Ngaoundal", Value = "Ngaoundal" },
                 new SelectListItem() { Text = "Yokadouma", Value = "Yokadouma" },
                new SelectListItem() { Text = "Pitoa", Value = "Pitoa" },
                new SelectListItem() { Text = "Tombel", Value = "Tombel" },
                 new SelectListItem() { Text = "Kékem", Value = "Kékem" },
                new SelectListItem() { Text = "	Magba", Value = "Magba" },
                new SelectListItem() { Text = "Bélabo", Value = "Bélabo" },
                 new SelectListItem() { Text = "Tonga", Value = "Tonga" },
                new SelectListItem() { Text = "Maga", Value = "Maga" },
                new SelectListItem() { Text = "Koutaba", Value = "Koutaba" },
                 new SelectListItem() { Text = "Blangoua", Value = "Blangoua" },
                new SelectListItem() { Text = "Guidiguis", Value = "Guidiguis" },
                new SelectListItem() { Text = "Bogo", Value = "Bogo" },
                 new SelectListItem() { Text = "Batibo", Value = "Batibo" },
                new SelectListItem() { Text = "Yabassi", Value = "Yabassi" },
                 new SelectListItem() { Text = "Figuil", Value = "Figuil" },
                new SelectListItem() { Text = "Makénéné", Value = "Makénéné" },
                 new SelectListItem() { Text = "Gazawa", Value = "Gazawa" },
                new SelectListItem() { Text = "Tcholliré", Value = "Tcholliré" }
            };
            return list;
        }

        public static IEnumerable<SelectListItem> ChooseSearchOrAsk()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Recherche", Value = "Recherche" },
                new SelectListItem() { Text = "J'offre", Value = "J'offre" }
            };
            return list;
            }
        public static IEnumerable<SelectListItem> GetListWorkContract()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "CDI", Value = "CDI" },
                new SelectListItem() { Text = "CDD", Value = "CDD" },
                new SelectListItem() { Text = "Stage/Alternance", Value = "Stage/Alternance" },
                new SelectListItem() { Text = "Sans contrat", Value = "Sans contrat" }
            };
            return list;
        }
        public static IEnumerable<SelectListItem> GetListActivitySector()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Agriculture", Value = "Agriculture" },
                new SelectListItem() { Text = "Immobilier", Value = "Immobilier" },
                new SelectListItem() { Text = "Hôtellerie/Restauration", Value = "Hôtellerie/Restauration" },
                new SelectListItem() { Text = "Sport", Value = "Sport" },
                 new SelectListItem() { Text = "Service à la personne", Value = "Service à la personne" }
            };
            return list;
        }

        //for apartment
        public static IEnumerable<SelectListItem> FurnitureOrNot()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Meublé", Value = "Meublé" },
                new SelectListItem() { Text = "Non meublé", Value = "Non meublé" }
               
            };
            return list;
        }
    }

}