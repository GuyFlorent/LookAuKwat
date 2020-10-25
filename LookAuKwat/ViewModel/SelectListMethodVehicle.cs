using LookAuKwat.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LookAuKwat.ViewModel
{
    public class SelectListMethodVehicle
    {
        public static IEnumerable<SelectListItem> RubriqueVehiculeList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Voitures", Value = "Voitures" },
                new SelectListItem() { Text = "Location voitures", Value = "Location voitures" },
                new SelectListItem() { Text = "Motos", Value = "Motos" },
                new SelectListItem() { Text = "Equipement Auto", Value = "Equipement Auto" },
                new SelectListItem() { Text = "Equipement Moto", Value = "Equipement Moto" }

            };
            return list;
        }
        public static IEnumerable<SelectListItem> BrandVehiculeAutoList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Toyota", Value = "Toyota" },
                new SelectListItem() { Text = "Mercedes", Value = "Mercedes" },
                new SelectListItem() { Text = "Hyundrai", Value = "Hyundrai" },
                 new SelectListItem() { Text = "Mazda", Value = "Mazda" },
                  new SelectListItem() { Text = "Kia", Value = "Kia" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }
        public static IEnumerable<SelectListItem> ModelVehiculeAutoToyotaList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "4-runner", Value = "Toyota" },
                new SelectListItem() { Text = "Avensis", Value = "Avensis" },
                new SelectListItem() { Text = "Aygo", Value = "Aygo" },
                new SelectListItem() { Text = "C-hr", Value = "C-hr" },
                new SelectListItem() { Text = "Camry", Value = "Camry" },
                new SelectListItem() { Text = "Carina", Value = "Carina" },
                new SelectListItem() { Text = "Celica", Value = "Celica" },
                new SelectListItem() { Text = "Corolla", Value = "Corolla" },
                new SelectListItem() { Text = "Cressida", Value = "Cressida" },
                new SelectListItem() { Text = "Escape", Value = "Escape" },
                new SelectListItem() { Text = "GRSupra", Value = "GRSupra" },
                new SelectListItem() { Text = "Gt86", Value = "Gt86" },
                new SelectListItem() { Text = "Hi Ace", Value = "Hi Ace" },
                new SelectListItem() { Text = "iq", Value = "iq" },
                new SelectListItem() { Text = "Land Cruiser", Value = "Land Cruiser" },
                new SelectListItem() { Text = "Lc.Td", Value = "Lc.Td" },
                new SelectListItem() { Text = "Lexus", Value = "Lexus" },
                new SelectListItem() { Text = "GRSupra", Value = "GRSupra" },
                new SelectListItem() { Text = "Lite-ace", Value = "Lite-ace" },
                new SelectListItem() { Text = "Mirai", Value = "Mirai" },
                new SelectListItem() { Text = "Model", Value = "Modet" },
                new SelectListItem() { Text = "Modet F", Value = "Modet F" },
                new SelectListItem() { Text = "Mr", Value = "Mr" },
                new SelectListItem() { Text = "Mr2", Value = "Mr2" },
                new SelectListItem() { Text = "Paseo", Value = "Paseo" },
                new SelectListItem() { Text = "Picnic", Value = "Picnic" },
                new SelectListItem() { Text = "Proace Combi", Value = "Proace Combi" },
                new SelectListItem() { Text = "Proace verso", Value = "Proace verso" },
                new SelectListItem() { Text = "Rav 4", Value = "Rav 4" },
                new SelectListItem() { Text = "Runner", Value = "Runner" },
                new SelectListItem() { Text = "Starlet", Value = "Starlet" },
                new SelectListItem() { Text = "Supra", Value = "Supra" },
                new SelectListItem() { Text = "Tercel", Value = "Tercel" },
                new SelectListItem() { Text = "Urban Cruiser", Value = "Urban Cruiser" },
                new SelectListItem() { Text = "Verso", Value = "Verso" },
                new SelectListItem() { Text = "Yaris", Value = "Yaris" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> ModelVehiculeAutoHyundaiList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Accent", Value = "Accent" },
                new SelectListItem() { Text = "Atos", Value = "Atos" },
                new SelectListItem() { Text = "Azera", Value = "Azera" },
                new SelectListItem() { Text = "Coupe", Value = "Coupe" },
                new SelectListItem() { Text = "Elantra", Value = "Elantra" },
                new SelectListItem() { Text = "Golloper", Value = "Golloper" },
                new SelectListItem() { Text = "Genesis", Value = "Genesis" },
                new SelectListItem() { Text = "Getz", Value = "Getz" },
                new SelectListItem() { Text = "Grandeur", Value = "Grandeur" },
                new SelectListItem() { Text = "I10", Value = "I10" },
                new SelectListItem() { Text = "I20", Value = "I20" },
                new SelectListItem() { Text = "I30", Value = "I30" },
                new SelectListItem() { Text = "I40", Value = "I40" },
                new SelectListItem() { Text = "Iq", Value = "Iq" },
                new SelectListItem() { Text = "Ioniq", Value = "Ioniq" },
                new SelectListItem() { Text = "I×35", Value = "I×35" },
                new SelectListItem() { Text = "I×55", Value = "I×55" },
                new SelectListItem() { Text = "Kona", Value = "Kona" },
                new SelectListItem() { Text = "Lantra", Value = "Lantra" },
                new SelectListItem() { Text = "Matrix", Value = "Matrix" },
                new SelectListItem() { Text = "Nexo", Value = "Nexo" },
                new SelectListItem() { Text = "Tucson", Value = "Tucson" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> ModelVehiculeAutoMercedesList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "190-series", Value = "190-series" },
                new SelectListItem() { Text = "200", Value = "200" },
                new SelectListItem() { Text = "220", Value = "220" },
                new SelectListItem() { Text = "230", Value = "230" },
                new SelectListItem() { Text = "240", Value = "240" },
                new SelectListItem() { Text = "250", Value = "250" },
                new SelectListItem() { Text = "260", Value = "260" },
                new SelectListItem() { Text = "280", Value = "280" },
                new SelectListItem() { Text = "300", Value = "300" },
                new SelectListItem() { Text = "350", Value = "350" },
                new SelectListItem() { Text = "400", Value = "400" },
                new SelectListItem() { Text = "500", Value = "500" },
                new SelectListItem() { Text = "560", Value = "560" },
                new SelectListItem() { Text = "AMG", Value = "AMG" },
                new SelectListItem() { Text = "AMG GT", Value = "AMG GT" },
                new SelectListItem() { Text = "Citan Combi", Value = "Citan Combi" },
                new SelectListItem() { Text = "I×55", Value = "I×55" },
                new SelectListItem() { Text = "Classe A", Value = "Classe A" },
                new SelectListItem() { Text = "Classe B", Value = "Classe B" },
                new SelectListItem() { Text = "Classe C", Value = "Classe C" },
                 new SelectListItem() { Text = "Classe Cl", Value = "Classe Cl" },
                  new SelectListItem() { Text = "Classe Cla", Value = "Classe Cla" },
                   new SelectListItem() { Text = "Classe Clk", Value = "Classe Clk" },
                    new SelectListItem() { Text = "Classe Cls", Value = "Classe Cls" },
                     new SelectListItem() { Text = "Classe E", Value = "Classe E" },
                      new SelectListItem() { Text = "Classe G", Value = "Classe G" },
                       new SelectListItem() { Text = "Classe GLE", Value = "Classe GLE" },
                        new SelectListItem() { Text = "Classe Gl", Value = "Classe Gl" },
                         new SelectListItem() { Text = "Classe Gla", Value = "Classe Gla" },
                          new SelectListItem() { Text = "Classe Glk", Value = "Classe Glk" },
                           new SelectListItem() { Text = "Classe M", Value = "Classe M" },
                            new SelectListItem() { Text = "Classe R", Value = "Classe R" },
                             new SelectListItem() { Text = "Classe S", Value = "Classe S" },
                              new SelectListItem() { Text = "Classe SI Roadster", Value = "Classe SI Roadste" },
                               new SelectListItem() { Text = "Classe V", Value = "Classe V" },
                                new SelectListItem() { Text = "EQC", Value = "EQC" },
                new SelectListItem() { Text = "GLB", Value = "GLB" },
                new SelectListItem() { Text = "GLC", Value = "GLC" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }


        public static IEnumerable<SelectListItem> ModelVehiculeAutoMazdaList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "121", Value = "121" },
                new SelectListItem() { Text = "2", Value = "2" },
                new SelectListItem() { Text = "3", Value = "3" },
                new SelectListItem() { Text = "323", Value = "323" },
                new SelectListItem() { Text = "5", Value = "5" },
                new SelectListItem() { Text = "6", Value = "6" },
                new SelectListItem() { Text = "626", Value = "626" },
                new SelectListItem() { Text = "929", Value = "929" },
                new SelectListItem() { Text = "Cx-3", Value = "Cx-3" },
                new SelectListItem() { Text = "Cx-30", Value = "Cx-30" },
                new SelectListItem() { Text = "Cx-5", Value = "Cx-5" },
                new SelectListItem() { Text = "Cx-7", Value = "Cx-7" },
                new SelectListItem() { Text = "Demio", Value = "Demio" },
                new SelectListItem() { Text = "Mpv", Value = "Mpv" },
                new SelectListItem() { Text = " Mx-3", Value = "Mx-3" },
                new SelectListItem() { Text = "Mx-5", Value = "Mx-5" },
                new SelectListItem() { Text = "Mx-6", Value = "Mx-6" },
                new SelectListItem() { Text = "Premacy", Value = "Premacy" },
                new SelectListItem() { Text = "5", Value = "5" },
                new SelectListItem() { Text = "Rx-7", Value = "Rx-7" },
                new SelectListItem() { Text = "Rx-8", Value = "Rx-8" },
                new SelectListItem() { Text = "Tribute", Value = "Tribute" },
                new SelectListItem() { Text = "Xedos", Value = "Xedos" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }
        public static IEnumerable<SelectListItem> ModelVehiculeAutoKiaList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Carnival", Value = "Carnival" },
                new SelectListItem() { Text = "Cee D", Value = "Cee D" },
                new SelectListItem() { Text = "Cerato", Value = "Cerato" },
                new SelectListItem() { Text = "Clarus", Value = "Clarus" },
                new SelectListItem() { Text = "Leo", Value = "Leo" },
                new SelectListItem() { Text = "Magentis", Value = "Magentis" },
                new SelectListItem() { Text = "Niro", Value = "Niro" },
                new SelectListItem() { Text = "Opirus", Value = "Opirus" },
                new SelectListItem() { Text = "Optima", Value = "Optima" },
                new SelectListItem() { Text = "Picanto", Value = "Picanto" },
                new SelectListItem() { Text = "Pride", Value = "Pride" },
                new SelectListItem() { Text = "Pride Break", Value = "Pride Break" },
                new SelectListItem() { Text = "Pro Cee D", Value = "Pro Cee D" },
                new SelectListItem() { Text = "Rio", Value = "Rio" },
                new SelectListItem() { Text = "Sephia", Value = "Sephia" },
                new SelectListItem() { Text = "Shuma", Value = "Shuma" },
                new SelectListItem() { Text = "Sorento", Value = "Sorento" },
                new SelectListItem() { Text = "Soul", Value = "Soul" },
                new SelectListItem() { Text = "Sportage", Value = "Sportage" },
                new SelectListItem() { Text = "Stinger", Value = "Stinger" },
                new SelectListItem() { Text = "Stonic", Value = "Stonic" },
                new SelectListItem() { Text = "Venga", Value = "Venga" },
                new SelectListItem() { Text = "XCeed", Value = "XCeed" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> BrandVehiculeMotoList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Barjac", Value = "Barjac" },
                new SelectListItem() { Text = "Bli", Value = "Bli" },
                new SelectListItem() { Text = "Kawasaki", Value = "Kawasaki" },
                new SelectListItem() { Text = "Harley davidson", Value = "Harley davidson" },
                new SelectListItem() { Text = "Suziki", Value = "Suziki" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> TypeVehiculeAutoList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "4×4,Suv", Value = "4×4,Suv" },
                new SelectListItem() { Text = "Berline", Value = "Berline" },
                new SelectListItem() { Text = "Break", Value = "Break" },
                new SelectListItem() { Text = "Cabriolet", Value = "Cabriolet" },
                new SelectListItem() { Text = "Camion", Value = "Camion" },
                new SelectListItem() { Text = "Citadine", Value = "Citadine" },
                new SelectListItem() { Text = "Coupé", Value = "Coupé" },
                new SelectListItem() { Text = "Minibus", Value = "Minibus" },
                 new SelectListItem() { Text = "Monospaces", Value = "Monospaces" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }
        public static IEnumerable<SelectListItem> PetrolVehiculeList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Essence", Value = "Essence" },
                new SelectListItem() { Text = "Diesel", Value = "Diesel" },
                new SelectListItem() { Text = "Hybride", Value = "Hybride" },
                new SelectListItem() { Text = "Electrique", Value = "Electrique" },
                new SelectListItem() { Text = "GPL", Value = "GPL" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> NumberOfDoorVehiculeList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "2", Value = "2" },
                new SelectListItem() { Text = "3", Value = "3" },
                new SelectListItem() { Text = "4", Value = "4" },
                new SelectListItem() { Text = "5", Value = "5" },
                new SelectListItem() { Text = "6", Value = "6" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }
        public static IEnumerable<SelectListItem> ColorVehiculeList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Argent", Value = "Argent" },
                new SelectListItem() { Text = "Beige", Value = "Beige" },
                new SelectListItem() { Text = "Blanc", Value = "Bleu" },
                new SelectListItem() { Text = "Bleu", Value = "Bleu" },
                new SelectListItem() { Text = "Bordeaux", Value = "Bordeaux" },
                new SelectListItem() { Text = "Gris", Value = "Gris" },
                new SelectListItem() { Text = "Ivoire", Value = "Ivoire" },
                new SelectListItem() { Text = "Jaune", Value = "Jaune" },
                new SelectListItem() { Text = "Marron", Value = "Marron" },
                new SelectListItem() { Text = "Noir", Value = "Noir" },
                new SelectListItem() { Text = "Orange", Value = "Orange" },
                new SelectListItem() { Text = "Rose", Value = "Rose" },
                new SelectListItem() { Text = "Rouge", Value = "Rouge" },
                new SelectListItem() { Text = "Vert", Value = "Vert" },
                new SelectListItem() { Text = "Violet", Value = "Violet" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> GearBoxVehiculeList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Manuelle", Value = "Manuelle" },
                new SelectListItem() { Text = "Automatique", Value = "Automatique" },

            };
            return list;
        }

        public static IEnumerable<SelectListItem> StateVehiculeList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Neuf", Value = "Neuf" },
                new SelectListItem() { Text = "Occasion", Value = "Occasion" },

            };
            return list;
        }

        public static IEnumerable<SelectListItem> SearchOrAskVehiculeList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Je vends", Value = "Je vends" },
                new SelectListItem() { Text = "Je recherche", Value = "Je recherche" },

            };
            return list;
        }
        
        public static IEnumerable<SelectListItem> ModelVehiculeTotalList()
        {
            IList<SelectListItem> list = new List<SelectListItem>();

            foreach (var liste in ModelVehiculeAutoHyundaiList())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelVehiculeAutoKiaList())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelVehiculeAutoMazdaList())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelVehiculeAutoMercedesList())
            {
                list.Add(liste);
            }
            foreach (var liste in ModelVehiculeAutoToyotaList())
            {
                list.Add(liste);
            }
           
            return list.DistinctBy(x => x.Text);
        }


        public static IEnumerable<SelectListItem> BrandVehiculeTotalList()
        {
            IList<SelectListItem> list = new List<SelectListItem>();

            foreach (var liste in BrandVehiculeAutoList())
            {
                list.Add(liste);
            }
            foreach (var liste in BrandVehiculeMotoList())
            {
                list.Add(liste);
            }
           
            return list.DistinctBy(x => x.Text);
        }

    }
}