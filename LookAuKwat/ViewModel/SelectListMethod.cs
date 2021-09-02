using LookAuKwat.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LookAuKwat.ViewModel
{
    public static class SelectListMethod
    {
        public static IEnumerable<SelectListItem> GetParrainList()
        {
            IDal dal = new Dal();
            IList<SelectListItem> list = new List<SelectListItem>();
            var liste = dal.GetParrainList_WithRole().ToList();
            list = liste.Select(x => new SelectListItem() { Value = x.Email, Text = x.FirstName }).ToList();
            return list.OrderBy(m => m.Text);
        }

        public static IEnumerable<SelectListItem> GetProviders()
        {
            IDal dal = new Dal();
            return dal.GetProviderList();
        }

        public static IEnumerable<SelectListItem> GetCountryList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Cameroun", Value = "Cameroun" },
                 new SelectListItem() { Text = "Côte d'ivoire", Value = "Côte d'ivoire" },
                 new SelectListItem() { Text = "Gabon", Value = "Gabon" },
                 new SelectListItem() { Text = "Sénégal", Value = "Sénégal" },
            };

            return list.OrderBy(m => m.Value);
        }

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
                new SelectListItem() { Text = "Loum", Value = "Loum" },
                new SelectListItem() { Text = "Kumba", Value = "Kumba" },
                new SelectListItem() { Text = "Kumbo", Value = "Kumbo" },
                new SelectListItem() { Text = "Foumban", Value = "Foumban" },
                new SelectListItem() { Text = "Mbouda", Value = "Mbouda" },
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
                new SelectListItem() { Text = "Bafia", Value = "Bafia" },
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
                new SelectListItem() { Text = "Eséka", Value = "Eséka" },
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
                new SelectListItem() { Text = "Tcholliré", Value = "Tcholliré" },
                new SelectListItem() { Text = "Edéa", Value = "Edéa" }
            };
            return list.OrderBy(m =>m.Value);
        }

        public static IEnumerable<SelectListItem> GetListTownCoteIvoire()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Abidjan", Value = "Abidjan" },
                new SelectListItem() { Text = "Bouaké", Value = "Bouaké" },
                new SelectListItem() { Text = "Daloa", Value = "Daloa" },
                new SelectListItem() { Text = "Yamoussoukro", Value = "Yamoussoukro" },
                new SelectListItem() { Text = "San-Pédro", Value = "San-Pédro" },
                new SelectListItem() { Text = "Divo", Value = "Divo" },
                new SelectListItem() { Text = "Korhogo", Value = "Korhogo" },
                new SelectListItem() { Text = "Anyama", Value = "Anyama" },
                new SelectListItem() { Text = "Abengourou", Value = "Abengourou" },
                new SelectListItem() { Text = "Man", Value = "Man" },
                new SelectListItem() { Text = "Gagnoa", Value = "Gagnoa" },
                new SelectListItem() { Text = "Soubré", Value = "Soubré" },
                new SelectListItem() { Text = "Agboville", Value = "Agboville" },
                new SelectListItem() { Text = "	Dabou", Value = "Dabou" },
                new SelectListItem() { Text = "Grand-Bassam", Value = "Grand-Bassam" },
                new SelectListItem() { Text = "Bouaflé", Value = "Bouaflé" },
                new SelectListItem() { Text = "Issia", Value = "Issia" },
                new SelectListItem() { Text = "Sinfra", Value = "Sinfra" },
                new SelectListItem() { Text = "Katiola", Value = "Katiola" },
                new SelectListItem() { Text = "Bingerville", Value = "Bingerville" },
                new SelectListItem() { Text = "Adzopé", Value = "Adzopé" },
                new SelectListItem() { Text = "Séguéla", Value = "Séguéla" },
                new SelectListItem() { Text = "Bondoukou", Value = "Bondoukou" },
                new SelectListItem() { Text = "Oumé", Value = "Oumé" },
                new SelectListItem() { Text = "Ferkessedougou", Value = "Ferkessedougou" },
                new SelectListItem() { Text = "Dimbokro1", Value = "Dimbokro1" },
                new SelectListItem() { Text = "Odienné", Value = "Odienné" },
                new SelectListItem() { Text = "Duékoué", Value = "Duékoué" },
                new SelectListItem() { Text = "Danané", Value = "Danané" },
                new SelectListItem() { Text = "Tingréla", Value = "Tingréla" },
                new SelectListItem() { Text = "Guiglo", Value = "Guiglo" },
                new SelectListItem() { Text = "Boundiali", Value = "Boundiali" },
                new SelectListItem() { Text = "Agnibilékrou", Value = "Agnibilékrou" },
                new SelectListItem() { Text = "Daoukro", Value = "Daoukro" },
                new SelectListItem() { Text = "Vavoua", Value = "Vavoua" },
                new SelectListItem() { Text = "Zuénoula", Value = "Zuénoula" },
                new SelectListItem() { Text = "Tiassalé", Value = "Tiassalé" },
                new SelectListItem() { Text = "Toumodi", Value = "Toumodi" },
                new SelectListItem() { Text = "Akoupé", Value = "Akoupé" },
                new SelectListItem() { Text = "Lakota", Value = "Lakota" },
               
            };
            return list.OrderBy(m => m.Value);
        }

        public static IEnumerable<SelectListItem> GetListTownGabon()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Libreville", Value = "Libreville" },
                new SelectListItem() { Text = "Port-Gentil", Value = "Port-Gentil" },
                new SelectListItem() { Text = "Franceville", Value = "Franceville" },
                new SelectListItem() { Text = "Oyem", Value = "Oyem" },
                new SelectListItem() { Text = "Moanda", Value = "Moanda" },
                new SelectListItem() { Text = "Mouila", Value = "Mouila" },
                new SelectListItem() { Text = "Lambaréné", Value = "Lambaréné" },
                new SelectListItem() { Text = "Tchibanga", Value = "Tchibanga" },
                new SelectListItem() { Text = "Koulamoutou", Value = "Koulamoutou" },
                new SelectListItem() { Text = "Makokou", Value = "Makokou" },
                new SelectListItem() { Text = "Bitam", Value = "Bitam" },
                new SelectListItem() { Text = "Tsogni", Value = "Tsogni" },
                new SelectListItem() { Text = "Gamba", Value = "Gamba" },
                new SelectListItem() { Text = "Mounana", Value = "Mounana" },
                new SelectListItem() { Text = "Ntoum", Value = "Ntoum" },
                new SelectListItem() { Text = "Nkan", Value = "Nkan" },
                new SelectListItem() { Text = "Lastourville", Value = "Lastourville" },
                new SelectListItem() { Text = "Okondja", Value = "Okondja" },
                new SelectListItem() { Text = "Ndendé", Value = "Ndendé" },
                new SelectListItem() { Text = "Booué", Value = "Booué" },
                new SelectListItem() { Text = "Fougamou", Value = "Fougamou" },
                new SelectListItem() { Text = "Ndjolé", Value = "Ndjolé" },
                new SelectListItem() { Text = "Mayumba", Value = "Mayumba" },
                new SelectListItem() { Text = "Mitzic", Value = "Mitzic" },
                new SelectListItem() { Text = "Mékambo", Value = "Mékambo" },
                new SelectListItem() { Text = "Lékoni", Value = "Lékoni" },
                new SelectListItem() { Text = "Mimongo", Value = "Mimongo" },
                new SelectListItem() { Text = "Minvoul", Value = "Minvoul" },
                new SelectListItem() { Text = "Medouneu", Value = "Medouneu" },
                new SelectListItem() { Text = "Omboué", Value = "Omboué" },
                new SelectListItem() { Text = "Cocobeach", Value = "Cocobeach" },
                new SelectListItem() { Text = "Kango", Value = "Kango" },
               
            };
            return list.OrderBy(m => m.Value);
        }

        public static IEnumerable<SelectListItem> GetListTownSenegal()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Dakar", Value = "Dakar" },
                new SelectListItem() { Text = "Pikine", Value = "Pikinel" },
                new SelectListItem() { Text = "Touba", Value = "Touba" },
                new SelectListItem() { Text = "Guédiawaye", Value = "Guédiawaye" },
                new SelectListItem() { Text = "Thiès", Value = "Thiès" },
                new SelectListItem() { Text = "Kaolack", Value = "Kaolack" },
                new SelectListItem() { Text = "Mbour", Value = "Mbour" },
                new SelectListItem() { Text = "Saint-Louis", Value = "Saint-Louis" },
                new SelectListItem() { Text = "Rufisque", Value = "Rufisque" },
                new SelectListItem() { Text = "Ziguinchor", Value = "Ziguinchor" },
                new SelectListItem() { Text = "Diourbel", Value = "Diourbel" },
                new SelectListItem() { Text = "Louga", Value = "Louga" },
                new SelectListItem() { Text = "Tambacounda", Value = "Tambacounda" },
                new SelectListItem() { Text = "Mbacké", Value = "Mbacké" },
                new SelectListItem() { Text = "Kolda", Value = "Kolda" },
                new SelectListItem() { Text = "Richard-Toll", Value = "Richard-Toll" },
                new SelectListItem() { Text = "Bargny", Value = "Bargny" },
                new SelectListItem() { Text = "Tivaouane", Value = "Tivaouane" },
                new SelectListItem() { Text = "Joal-Fadiouth", Value = "Joal-Fadiouth" },
                new SelectListItem() { Text = "Dahra", Value = "Dahra" },
                new SelectListItem() { Text = "Kaffrine", Value = "Kaffrine" },
                new SelectListItem() { Text = "Bignona", Value = "Bignona" },
                new SelectListItem() { Text = "Fatick", Value = "Fatick" },
                new SelectListItem() { Text = "Vélingara", Value = "Vélingara" },
                new SelectListItem() { Text = "Bambey", Value = "Bambey" },
                new SelectListItem() { Text = "Sébikhotane", Value = "Sébikhotane" },
                new SelectListItem() { Text = "Dagana", Value = "Dagana" },
                new SelectListItem() { Text = "Sédhiou", Value = "Sédhiou" },
                new SelectListItem() { Text = "Nguékhokh", Value = "Nguékhokh" },
                new SelectListItem() { Text = "Diawara", Value = "Diawara" },
                new SelectListItem() { Text = "Kédougou", Value = "Kédougou" },
                new SelectListItem() { Text = "Pout", Value = "Pout" },
                new SelectListItem() { Text = "Kayar", Value = "Kayar" },
                new SelectListItem() { Text = "Matam", Value = "Matam" },
                new SelectListItem() { Text = "Meckhe", Value = "Meckhe" },
                new SelectListItem() { Text = "Nioro du Rip", Value = "Nioro du Rip" },
                new SelectListItem() { Text = "Ourossogui", Value = "Ourossogui" },
                new SelectListItem() { Text = "Kébémer", Value = "Kébémer" },
                new SelectListItem() { Text = "Ndioum", Value = "Ndioum" },
                new SelectListItem() { Text = "Koungheul", Value = "Koungheul" },
                new SelectListItem() { Text = "Guinguinéo", Value = "Guinguinéo" },
                new SelectListItem() { Text = "Linguère", Value = "Linguère" },
                new SelectListItem() { Text = "Khombole", Value = "Khombole" },
                new SelectListItem() { Text = "Bakel", Value = "Bakel" },
                new SelectListItem() { Text = "Sokone", Value = "Sokone" },
                new SelectListItem() { Text = "Diamniadio", Value = "Diamniadio" },
                new SelectListItem() { Text = "Mboro", Value = "Mboro" },
                new SelectListItem() { Text = "Thiadiaye", Value = "Thiadiaye" },
                new SelectListItem() { Text = "Goudomp", Value = "Goudomp" },
                new SelectListItem() { Text = "Gossas", Value = "Gossas" },
                new SelectListItem() { Text = "Kanel", Value = "Kanel" },
                new SelectListItem() { Text = "Rosso", Value = "Rosso" },
                new SelectListItem() { Text = "Ndoffane", Value = "Ndoffane" },
                new SelectListItem() { Text = "Gandiaye", Value = "Gandiaye" },

            };
            return list.OrderBy(m => m.Value);
        }
        public static IEnumerable<SelectListItem> ChooseSearchOrAsk()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "J'offre", Value = "J'offre" },
                 new SelectListItem() { Text = "Je recherche", Value = "Je recherche" }
               
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
                new SelectListItem() { Text = "Sans contrat", Value = "Sans contrat" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }
            };
            return list;
        }

        public static IEnumerable<SelectListItem> GetListCategory()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Emploi", Value = "Emploi" },
                new SelectListItem() { Text = "Immobilier", Value = "Immobilier" },
                new SelectListItem() { Text = "Multimedia", Value = "Multimedia" },
                new SelectListItem() { Text = "Vehicule", Value = "Vehicule" },
                new SelectListItem() { Text = "Mode", Value = "Mode" },
                new SelectListItem() { Text = "Maison", Value = "Maison" }
                
            };
            return list.OrderBy(m => m.Value); 
        }
        public static IEnumerable<SelectListItem> GetListActivitySector()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Ingénieur", Value = "Ingénieur" },
                 new SelectListItem() { Text = "Agriculture", Value = "Agriculture" },
                new SelectListItem() { Text = "Immobilier", Value = "Immobilier" },
                new SelectListItem() { Text = "Corp médicale", Value = "Corp médicale" },
                 new SelectListItem() { Text = "Enseignement", Value = "Enseignement" },
                new SelectListItem() { Text = "Hôtellerie/Restauration", Value = "Hôtellerie/Restauration" },
                new SelectListItem() { Text = "Sport", Value = "Sport" },
                 new SelectListItem() { Text = "Technique", Value = "Technique" },
                 new SelectListItem() { Text = "Maçonnerie", Value = "Maçonnerie" },
                 new SelectListItem() { Text = "Couture", Value = "Couture" },
                 new SelectListItem() { Text = "Sérigraphie", Value = "Sérigraphie" },
                 new SelectListItem() { Text = "Infographie", Value = "Infographie" },
                 new SelectListItem() { Text = "Electricien", Value = "Electricien" },
                 new SelectListItem() { Text = "Mécanicien", Value = "Mécanicien" },
                 new SelectListItem() { Text = "Taximan", Value = "Taximan" },
                 new SelectListItem() { Text = "Bensikineur", Value = "Bensikineur" },
                 new SelectListItem() { Text = "Comptable", Value = "Comptable" },
                 new SelectListItem() { Text = "Service à la personne", Value = "Service à la personne" },
                 new SelectListItem() { Text = "Prestation de service", Value = "Prestation de service" },
                 new SelectListItem() { Text = "Commnication", Value = "Commnication" },
                 new SelectListItem() { Text = "Commercial", Value = "Commercial" },
                 new SelectListItem() { Text = "Sécurité", Value = "Sécurité" },
                 new SelectListItem() { Text = "Administration", Value = "Administration" },
                 new SelectListItem() { Text = "Autre", Value = "Autre" }
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

        public static IEnumerable<SelectListItem> TypeImmobilier()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                
                new SelectListItem() { Text = "Appartement à louer", Value = "Appartement à louer" },
                new SelectListItem() { Text = "Entrepot à louer", Value = "Entrepot à louer" },
                new SelectListItem() { Text = "Boutique à louer", Value = "Boutique à louer" },
                new SelectListItem() { Text = "Chambre à louer", Value = "Chambre à louer" },
                 new SelectListItem() { Text = "studio à louer", Value = "studio à louer" },
                  new SelectListItem() { Text = "Maison à louer", Value = "Maison à louer" },
                   new SelectListItem() { Text = "Bureau à louer", Value = "Bureau à louer" },
                    new SelectListItem() { Text = "Maison à Vendre", Value ="Maison à Vendre" },
                     new SelectListItem() { Text = "Terrain à vendre", Value = "terrain à vendre" },
                     new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        //for multimedia
        public static IEnumerable<SelectListItem> TypeMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Informatique", Value = "Informatique" },
                new SelectListItem() { Text = "Consoles de jeux", Value = "Consoles de jeux" },
                new SelectListItem() { Text = "Jeux video", Value = "Jeux video" },
                new SelectListItem() { Text = "Téléphonie", Value = "Téléphonie" },
                new SelectListItem() { Text = "Accésoires téléphonie", Value = "Accésoires téléphonie" },
                new SelectListItem() { Text = "Téléviseur", Value = "Téléviseur" },
                new SelectListItem() { Text = "Son", Value = "Son" },
                new SelectListItem() { Text = "Image & Camera vidéo", Value = "Image & Camera vidéo" },
                new SelectListItem() { Text = "Photocopieuse", Value = "Photocopieuse" },
                
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }


        public static IEnumerable<SelectListItem> BrandInformatiquePhotocopyMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Hp", Value = "Hp" },
                new SelectListItem() { Text = "Dell", Value = "Dell" },
                new SelectListItem() { Text = "Samsung", Value = "Samsung" },
                new SelectListItem() { Text = "MSI", Value = "MSI" },
                new SelectListItem() { Text = "Apple", Value = "Apple" },
                new SelectListItem() { Text = "Acer", Value = "Acer" },
                new SelectListItem() { Text = "Lenovo", Value = "Lenovo" },
                new SelectListItem() { Text = "Microsoft", Value = "Microsoft" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }
        public static IEnumerable<SelectListItem> ModelInformatiquePhotocopyMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Laptop 14 pouces", Value = "Laptop 14 pouces" },
                 new SelectListItem() { Text = "Laptop 15 pouces", Value = "Laptop 15 pouces" },
                 new SelectListItem() { Text = "Laptop 16 pouces", Value = "Laptop 16 pouces" },
                new SelectListItem() { Text = "Desktop", Value = "Desktop" },
                new SelectListItem() { Text = "Souris", Value = "Souris" },
                new SelectListItem() { Text = "Imprimante", Value = "Imprimante" },
                new SelectListItem() { Text = "Photocopieuse", Value = "Photocopieuse" },
                new SelectListItem() { Text = "Disque dur externe", Value = "Disque dur externe" },
                new SelectListItem() { Text = "Logiciel", Value = "Logiciel" },
                new SelectListItem() { Text = "Encre", Value = "Encre" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }



        public static IEnumerable<SelectListItem> BrandConsoleGamequeMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Sony", Value = "Sony" },
                new SelectListItem() { Text = "Nitendo", Value = "Nitendo" },
                new SelectListItem() { Text = "Microsoft", Value = "Microsoft" },
                new SelectListItem() { Text = "Sega", Value = "Sega" },
                new SelectListItem() { Text = "Neo-Geo-AES", Value = "Neo-Geo-AES" },
                new SelectListItem() { Text = "Amiga", Value = "Amiga" },
                new SelectListItem() { Text = "Atari", Value = "Atari" },
                new SelectListItem() { Text = "Retrogaming", Value = "Retrogaming" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> ModelConsoleGameMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "PS5", Value = "PS5" },
                 new SelectListItem() { Text = "PS4 Pro", Value = "PS4 Pro" },
                new SelectListItem() { Text = "PS4", Value = "PS4" },
                new SelectListItem() { Text = "PS3", Value = "PS3" },
                new SelectListItem() { Text = "PS2", Value = "PS2" },
                new SelectListItem() { Text = "Wii", Value = "Wii" },
                new SelectListItem() { Text = "Switch", Value = "Switch" },
                new SelectListItem() { Text = "Game Boy Advance", Value = "Game Boy Advance" },
                new SelectListItem() { Text = "XBOX ONE", Value = "XBOX ONE" },
                new SelectListItem() { Text = "XBOX 360", Value = "XBOX 360" },
                new SelectListItem() { Text = "XBOX", Value = "XBOX" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> BrandPhoneAccesorieMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Apple", Value = "Apple" },
                new SelectListItem() { Text = "Huawei", Value = "Huawei" },
                new SelectListItem() { Text = "Samsung", Value = "Samsung" },
                new SelectListItem() { Text = "Sony", Value = "Sony" },
                new SelectListItem() { Text = "Alcatel", Value = "Alcatel" },
                new SelectListItem() { Text = "Asus", Value = "Asus" },
                new SelectListItem() { Text = "Honor", Value = "Honor" },
                new SelectListItem() { Text = "HTC", Value = "HTC" },
                new SelectListItem() { Text = "Lenovo", Value = "Lenovo" },
                new SelectListItem() { Text = "LG", Value = "LG" },
                new SelectListItem() { Text = "Microsoft", Value = "Microsoft" },
                
                new SelectListItem() { Text = "Motorola", Value = "Motorola" },
                new SelectListItem() { Text = "Nokia", Value = "Nokia" },
                new SelectListItem() { Text = "One plus", Value = "One plus" },
                new SelectListItem() { Text = "Wiko", Value = "Wiko" },
                 new SelectListItem() { Text = "Xaomi", Value = "Xaomi" },
                  new SelectListItem() { Text = "ZTE", Value = "ZTE" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> ModelApplePhoneAccesorieMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "IPhone 11 Pro Max", Value = "IPhone 11 Pro Max" },
                new SelectListItem() { Text = "IPhone 11 Pro", Value = "IPhone 11 Pro" },
                new SelectListItem() { Text = "IPhone 11", Value = "IPhone 11" },
                new SelectListItem() { Text = "IPhone XS Max", Value = "IPhone XS Max" },
                new SelectListItem() { Text = "IPhone XS", Value = "IPhone XS" },
                new SelectListItem() { Text = "IPhone XR", Value = "IPhone XR" },
                new SelectListItem() { Text = "IPhone X", Value = "IPhone X" },
                new SelectListItem() { Text = "IPhone 8Plus", Value = "IPhone 8Plus" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }
        public static IEnumerable<SelectListItem> ModelHuaweiPhoneAccesorieMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "P8 Lite", Value = "P8 Lite" },
                new SelectListItem() { Text = "P9", Value = "P9" },
                new SelectListItem() { Text = "P9 Lite", Value = "P9 Lite" },
                new SelectListItem() { Text = "P10", Value = "P10" },
                new SelectListItem() { Text = "P10 Lite", Value = "P10 Lite" },
                new SelectListItem() { Text = "Mate 10 Pro", Value = "Mate 10 Pro" },
                new SelectListItem() { Text = "P20", Value = "P20" },
                new SelectListItem() { Text = "P20 Pro", Value = "P20 Pro" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }
        public static IEnumerable<SelectListItem> ModelSamsungPhoneAccesorieMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Galaxy S20 Ultra", Value = "Galaxy S20 Ultra" },
                new SelectListItem() { Text = "Galaxy S20+", Value = "Galaxy S20+" },
                new SelectListItem() { Text = "Galaxy S20", Value = "Galaxy S20" },
                new SelectListItem() { Text = "Galaxy S10+", Value = "Galaxy S10+" },
                new SelectListItem() { Text = "Galaxy S10", Value = "Galaxy S10" },
                new SelectListItem() { Text = "Galaxy Note 4", Value = "Galaxy Note 4" },
                new SelectListItem() { Text = "Galaxy Note 3", Value = "Galaxy Note 3" },
                new SelectListItem() { Text = "Galaxy S7 Edge", Value = "Galaxy S7 Edge" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> ModelSonyPhoneAccesorieMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Xperia XZ2", Value = "Xperia XZ2" },
                new SelectListItem() { Text = "Xperia E3", Value = "Xperia E3" },
                new SelectListItem() { Text = "Xperia X", Value = "Xperia X" },
                new SelectListItem() { Text = "Xperia XA", Value = "Xperia XA" },
                new SelectListItem() { Text = "Xperia XA1", Value = "Xperia XA1" },
                new SelectListItem() { Text = "Xperia Z5", Value = "Xperia Z5" },
                new SelectListItem() { Text = "Xperia XZ", Value = "Xperia XZ" },
                new SelectListItem() { Text = "Xperia Z3", Value = "Xperia Z3" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> ModelAlcatelPhoneAccesorieMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "1", Value = "1" },
                new SelectListItem() { Text = "3L", Value = "6L" },
                new SelectListItem() { Text = "5", Value = "5" },
                new SelectListItem() { Text = "5V", Value = "5V" },
                new SelectListItem() { Text = "A5 LED", Value = "A5 LED" },
                new SelectListItem() { Text = "Idol 3", Value = "Idol 3" },
                new SelectListItem() { Text = "One Touch 995", Value = "One Touch 995" },
                new SelectListItem() { Text = "One Touch Idol Alpha", Value = "One Touch Idol Alpha" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> ModelAzusPhoneAccesorieMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "ZenFone 2", Value = "ZenFone 2" },
                new SelectListItem() { Text = "ZenFone 2 Laser", Value = "ZenFone 2 Laser" },
                new SelectListItem() { Text = "ZenFone 3 Laser", Value = "ZenFone 3 Laser" },
                new SelectListItem() { Text = "ZenFone 3 Max", Value = "ZenFone 3 Max" },
                new SelectListItem() { Text = "ZenFone 3 Max Plus", Value = "ZenFone 3 Max Plus" },
                new SelectListItem() { Text = "ZenFone 3 Deluxe", Value = "ZenFone 3 Deluxe" },
                new SelectListItem() { Text = "ZenFone Zoom", Value = "ZenFone Zoom" },
                new SelectListItem() { Text = "Zenfone Max Pro M1", Value = "Zenfone Max Pro M1" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;

        }
        public static IEnumerable<SelectListItem> ModelHonorPhoneAccesorieMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "5", Value = "5" },
                new SelectListItem() { Text = "5A", Value = "5A" },
                new SelectListItem() { Text = "5C", Value = "5C" },
                new SelectListItem() { Text = "6", Value = "6" },
                new SelectListItem() { Text = "6 Plus", Value = "6 Plus" },
                new SelectListItem() { Text = "9X Pro", Value = "9X Pro" },
                new SelectListItem() { Text = "9X", Value = "9X" },
                new SelectListItem() { Text = "20 Pro", Value = "20 Pro" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;

        }

        public static IEnumerable<SelectListItem> ModelHTCPhoneAccesorieMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "8X", Value = "8X" },
                new SelectListItem() { Text = "Desire 10 Lifestyle", Value = "Desire 10 Lifestyle" },
                new SelectListItem() { Text = "Desire 10 Pro", Value = "Desire 10 Pro" },
                new SelectListItem() { Text = "Desire 12", Value = "Desire 12" },
                new SelectListItem() { Text = "Desire 610", Value = "Desire 610" },
                new SelectListItem() { Text = "One M9 Plus", Value = "One M9 Plus" },
                new SelectListItem() { Text = "One X10", Value = "One X10" },
                new SelectListItem() { Text = "One Mini 2", Value = "One Mini 2" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;

        }

        public static IEnumerable<SelectListItem> ModelLenovoPhoneAccesorieMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "C2", Value = "8X" },
                new SelectListItem() { Text = "K5", Value = "Desire 10 Lifestyle" },
                new SelectListItem() { Text = "K5 Note", Value = "Desire 10 Pro" },
                new SelectListItem() { Text = "K6 Note", Value = "K6 Note" },
                new SelectListItem() { Text = "Moto C Plus", Value = "Moto C Plus" },
                new SelectListItem() { Text = "Moto G4 Plus", Value = "Moto G4 Plus" },
                new SelectListItem() { Text = "Moto G5 Plus", Value = "Moto G5 Plus" },
                new SelectListItem() { Text = "Z6 Pro", Value = "Z6 Pro" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;

        }

        public static IEnumerable<SelectListItem> ModelMicrosoftPhoneAccesorieMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Lumia 435", Value = "Lumia 435" },
                new SelectListItem() { Text = "Lumia 532", Value = "Lumia 532" },
                new SelectListItem() { Text = "Lumia 535", Value = "Lumia 535" },
                new SelectListItem() { Text = "Lumia 550", Value = "Lumia 550" },
                new SelectListItem() { Text = "Lumia 640", Value = "Lumia 640" },
                new SelectListItem() { Text = "Lumia 640 LTE", Value = "Lumia 640 LTE" },
                new SelectListItem() { Text = "Lumia 640 XL", Value = "Lumia 640 XL" },
                new SelectListItem() { Text = "Lumia 650 XL", Value = "Lumia 650 XL" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;

        }

        public static IEnumerable<SelectListItem> ModelLGPhoneAccesorieMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Optimus G", Value = "Optimus G" },
                new SelectListItem() { Text = "Optimus F6", Value = "Optimus F6" },
                new SelectListItem() { Text = "Optimus L7", Value = "Optimus L7" },
                new SelectListItem() { Text = "Optimus L9", Value = "Optimus L9" },
                new SelectListItem() { Text = "Nexus 5", Value = "Nexus 5" },
                new SelectListItem() { Text = "Nexus 5X", Value = "Nexus 5X" },
                new SelectListItem() { Text = "V30", Value = "V30" },
                new SelectListItem() { Text = "G6", Value = "G6" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;

        }
        public static IEnumerable<SelectListItem> ModelMotorolaPhoneAccesorieMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "One", Value = "One" },
                new SelectListItem() { Text = "One Vision", Value = "One Vision" },
                new SelectListItem() { Text = "Moto Defy", Value = "Moto Defy" },
                new SelectListItem() { Text = "Moto E4 Plus", Value = "Moto E4 Plus" },
                new SelectListItem() { Text = "Moto G5 Plus", Value = "Moto G5 Plus" },
                new SelectListItem() { Text = "Moto G5S Plus", Value = "Moto G5S Plus" },
                new SelectListItem() { Text = "Moto G7 Power", Value = "Moto G7 Power" },
                new SelectListItem() { Text = "Moto X Force", Value = "Moto X Force" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;

        }

        public static IEnumerable<SelectListItem> ModelOnePlusPhoneAccesorieMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "One", Value = "One" },
                new SelectListItem() { Text = "2", Value = "2" },
                new SelectListItem() { Text = "3", Value = "3" },
                new SelectListItem() { Text = "3T", Value = "3T" },
                new SelectListItem() { Text = "5", Value = "5" },
                new SelectListItem() { Text = "5T", Value = "5T" },
                new SelectListItem() { Text = "6", Value = "6" },
                new SelectListItem() { Text = "7 Pro", Value = "7 Pro" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;

        }
        public static IEnumerable<SelectListItem> ModelWikoPhoneAccesorieMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Cink", Value = "Cink" },
                new SelectListItem() { Text = "Cink Five", Value = "Cink Five" },
                new SelectListItem() { Text = "Cink King", Value = "Cink King" },
                new SelectListItem() { Text = "Cink Peax", Value = "Cink Peax" },
                new SelectListItem() { Text = "Getaway", Value = "Getaway" },
                new SelectListItem() { Text = "Jerry 3", Value = "Jerry 3" },
                new SelectListItem() { Text = "JimmyBirdy 4G", Value = "JimmyBirdy 4G" },
                new SelectListItem() { Text = "JimmyBirdy 4G", Value = "JimmyBirdy 4G" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;

        }
        public static IEnumerable<SelectListItem> ModelXaomiPhoneAccesorieMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Mi 4", Value = "Mi 4" },
                new SelectListItem() { Text = "Mi 5", Value = "Mi 5" },
                new SelectListItem() { Text = "Mi 5S", Value = "Mi 5S" },
                new SelectListItem() { Text = "Mi 8 Lite", Value = "Mi 8 Lite" },
                new SelectListItem() { Text = "Mi 8 Pro", Value = "Mi 8 Pro" },
                new SelectListItem() { Text = "Mi 9", Value = "Mi 9" },
                new SelectListItem() { Text = "Mi 9T", Value = "Mi 9T" },
                new SelectListItem() { Text = "Mi A1", Value = "Mi A1" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;

        }

        public static IEnumerable<SelectListItem> ModelZTEPhoneAccesorieMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Axon 7", Value = "Axon 7" },
                new SelectListItem() { Text = "Axon 7 Mini", Value = "Axon 7 Mini" },
                new SelectListItem() { Text = "Axon Lite", Value = "Axon Lite" },
                new SelectListItem() { Text = "Axon Mini", Value = "Axon Mini" },
                new SelectListItem() { Text = "Blade 3", Value = "Blade 3" },
                new SelectListItem() { Text = "Blade A310", Value = "Blade A310" },
                new SelectListItem() { Text = "Blade A452", Value = "Blade A452" },
                new SelectListItem() { Text = "Blade A506", Value = "Blade A506" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;

        }
        public static IEnumerable<SelectListItem> ModelOtherMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;

        }
        public static IEnumerable<SelectListItem> BrandTVGameMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Samsung", Value = "Samsung" },
                new SelectListItem() { Text = "Sony", Value = "Sony" },
                new SelectListItem() { Text = "Panasonic", Value = "Panasonic" },
                new SelectListItem() { Text = "LG", Value = "LG" },
                new SelectListItem() { Text = "Sharp", Value = "Sharp" },
                new SelectListItem() { Text = "TCL", Value = "TCL" },
                
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> ModelTVGameMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "TV Full HD 32 pouces", Value = "TV Full HD 32 pouces" },
                new SelectListItem() { Text = "TV Full HD 40 pouces", Value = "TV Full HD 40 pouces" },
                new SelectListItem() { Text = "TV Full HD 48 pouces", Value = "TV Full HD 48 pouces" },
                new SelectListItem() { Text = "TV 4K Ultra-HD 48 pouces", Value = "TV 4K Ultra-HD 48 pouces" },
                new SelectListItem() { Text = "TV 4K Ultra-HD 50 pouces", Value = "TV 4K Ultra-HD 50 pouces" },
                new SelectListItem() { Text = "TV 4K Ultra-HD 55pouces", Value = "TV 4K Ultra-HD 55pouces" },

                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> BrandSonMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Amazon", Value = "Amazon" },
                new SelectListItem() { Text = "Apple", Value = "Apple" },
                new SelectListItem() { Text = "Bose", Value = "Bose" },
                new SelectListItem() { Text = "LG", Value = "LG" },
                new SelectListItem() { Text = "Teufel", Value = "Teufel" },
                new SelectListItem() { Text = "Klipsch", Value = "Klipsch" },

                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> ModelSonGamequeMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Haut-parleur voiture", Value = "Haut-parleur voiture" },
                new SelectListItem() { Text = "Haut-parleur PC", Value = "Haut-parleur PC" },
                new SelectListItem() { Text = "Haut-parleur bluetooth", Value = "Haut-parleur bluetooth" },
                new SelectListItem() { Text = "Haut-parleur discothèque", Value = "Haut-parleur discothèque" },
                new SelectListItem() { Text = "Casque sans fil", Value = "Casque sans fil" },
                new SelectListItem() { Text = "écouteurs", Value = "écouteurs" },

                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> BrandOtherMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }
        public static IEnumerable<SelectListItem> CapacityMultimedia()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Aucune", Value = "Aucune" },
                new SelectListItem() { Text = "2 Go", Value = "2 Go" },
                new SelectListItem() { Text = "4 Go", Value = "4 Go" },
                new SelectListItem() { Text = "6 Go", Value = "6 Go" },
                new SelectListItem() { Text = "8 Go", Value = "8 Go" },
                new SelectListItem() { Text = "16 Go", Value = "16 Go" },
                new SelectListItem() { Text = "32 Go", Value = "32 Go" },
                new SelectListItem() { Text = "64 Go", Value = "64 Go" },
                new SelectListItem() { Text = "128 Go", Value = "128 Go" },
                new SelectListItem() { Text = "256 Go", Value = "256 Go" },
                new SelectListItem() { Text = "512 Go", Value = "512 Go" },
                new SelectListItem() { Text = "+ de 512 Go", Value = "+ de 512 Go" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> BrandTotalList()
        {
            IList<SelectListItem> list = new List<SelectListItem>();
           
            foreach(var liste in BrandSonMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in BrandPhoneAccesorieMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in BrandOtherMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in BrandInformatiquePhotocopyMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in BrandConsoleGamequeMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in BrandTVGameMultimedia())
            {
                list.Add(liste);
            }

            return list.DistinctBy(x => x.Text);
        }

        public static IEnumerable<SelectListItem> ModelTotalList()
        {
            IList<SelectListItem> list = new List<SelectListItem>();

            foreach (var liste in ModelSamsungPhoneAccesorieMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelMotorolaPhoneAccesorieMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelMicrosoftPhoneAccesorieMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelAlcatelPhoneAccesorieMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelApplePhoneAccesorieMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelHonorPhoneAccesorieMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelHTCPhoneAccesorieMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelHuaweiPhoneAccesorieMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelInformatiquePhotocopyMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelLenovoPhoneAccesorieMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelLGPhoneAccesorieMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelTVGameMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelSonyPhoneAccesorieMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelSonGamequeMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelWikoPhoneAccesorieMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelZTEPhoneAccesorieMultimedia())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelXaomiPhoneAccesorieMultimedia())
            {
                list.Add(liste);
            }
            
            foreach (var liste in ModelOtherMultimedia())
            {
                list.Add(liste);
            }

            return list.DistinctBy(x =>x.Text);
        }
    }

    public class SelectListItemComparer : IEqualityComparer<SelectListItem>
    {
        public bool Equals(SelectListItem x, SelectListItem y)
        {
            return x.Text == y.Text && x.Value == y.Value;
        }

        public int GetHashCode(SelectListItem item)
        {
            int hashText = item.Text == null ? 0 : item.Text.GetHashCode();
            int hashValue = item.Value == null ? 0 : item.Value.GetHashCode();
            return hashText ^ hashValue;
        }


    }

}