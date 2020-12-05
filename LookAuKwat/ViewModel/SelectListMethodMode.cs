using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LookAuKwat.ViewModel
{
    public class SelectListMethodMode
    {
        public static IEnumerable<SelectListItem> RubriqueModeList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Vêtements", Value = "Vêtements" },
                new SelectListItem() { Text = "Chaussures", Value = "Chaussures" },
                new SelectListItem() { Text = "Accesoires & Bagagerie", Value = "Accesoires & Bagagerie" },
                new SelectListItem() { Text = "Montres & Bijoux", Value = "Montres & Bijoux" },
                new SelectListItem() { Text = "Equipement bébé", Value = "Equipement bébé" },
                new SelectListItem() { Text = "Vêtements bébé", Value = "Vêtements bébé" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> TypeClothesList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Robes/Jupes", Value = "Robes/Jupes" },
                new SelectListItem() { Text = "Manteaux & Vestes", Value = "Manteaux & Vestes" },
                new SelectListItem() { Text = "Hauts/T-Shirts/Polos", Value = "Hauts/T-Shirts/Polos" },
                new SelectListItem() { Text = "Pantalons", Value = "Pantalons" },
                new SelectListItem() { Text = "Pulls/Gilets/Mailles", Value = "Pulls/Gilets/Mailles" },
                new SelectListItem() { Text = "Jeans", Value = "Jeans" },
                 new SelectListItem() { Text = "Chemises/Chemisiers", Value = "Chemises/Chemisiers" },
                  new SelectListItem() { Text = "Costumes/Tailleurs", Value = "Costumes/Tailleurs" },
                   new SelectListItem() { Text = "Shorts/Pantacourts/Bermudas", Value = "Shorts/Pantacourts/Bermudas" },
                    new SelectListItem() { Text = "Sport/Danse", Value = "Sport/Danse" },
                     new SelectListItem() { Text = "Maillots de bain/ve^tements de plage", Value = "Maillots de bain/ve^tements de plage" },
                      new SelectListItem() { Text = "Lingerie", Value = "Lingerie" },
                       new SelectListItem() { Text = "Sous-vêtements & vêtements de nuit", Value = "Sous-vêtements & vêtements de nuit" },
                       new SelectListItem() { Text = "Déguisements", Value = "Déguisements" },
                       new SelectListItem() { Text = "Mariage", Value = "Mariage" }
                      
            };
            return list;
        }

        public static IEnumerable<SelectListItem> BrandClothesList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Adidas", Value = "Adidas" },
                new SelectListItem() { Text = "Armani", Value = "Armani" },
                new SelectListItem() { Text = "Balenciaga", Value = "Balenciaga" },
                new SelectListItem() { Text = "BCBG Max Azria", Value = "BCBG Max Azria" },
                new SelectListItem() { Text = "Bershka", Value = "Bershka" },
                new SelectListItem() { Text = "Burberry", Value = "Burberry" },
                new SelectListItem() { Text = "C&A", Value = "C&A" },
                new SelectListItem() { Text = "Calvin Klein", Value = "Calvin Klein" },
                new SelectListItem() { Text = "Camaieu", Value = "Camaieu" },
                new SelectListItem() { Text = "Canada Goose", Value = "Canada Goose" },
                new SelectListItem() { Text = "Celio", Value = "Celio" },
                new SelectListItem() { Text = "Chanel", Value = "Chanel" },
                new SelectListItem() { Text = "Desigual", Value = "Desigual" },
                new SelectListItem() { Text = "Diesel", Value = "Diesel" },
                new SelectListItem() { Text = "Dior", Value = "Dior" },
                new SelectListItem() { Text = "Dolce & Gabbana", Value = "Dolce & Gabbana" },
                new SelectListItem() { Text = "Esprit", Value = "Esprit" },
                new SelectListItem() { Text = "Etam", Value = "Etam" },
                new SelectListItem() { Text = "Givenchy", Value = "Givenchy" },
                new SelectListItem() { Text = "G-Star", Value = "G-Star" },
                new SelectListItem() { Text = "Gucci", Value = "Gucci" },
                new SelectListItem() { Text = "Guess", Value = "Guess" },
                new SelectListItem() { Text = "H&M", Value = "H&M" },
                new SelectListItem() { Text = "Hugo Boss", Value = "Hugo Boss" },
                new SelectListItem() { Text = "Jack & Jones", Value = "Jack & Jones" },
                new SelectListItem() { Text = "ean Paul Gaultie", Value = "ean Paul Gaultie" },
                new SelectListItem() { Text = "Kaporal", Value = "Kaporal" },
                new SelectListItem() { Text = "Kappa", Value = "Kappa" },
                new SelectListItem() { Text = "Kenzo", Value = "Kenzo" },
                new SelectListItem() { Text = "Lacoste", Value = "Lacoste" },
                new SelectListItem() { Text = "Levi's", Value = "Levi's" },
                new SelectListItem() { Text = "Louis Vuitton", Value = "Louis Vuitton" },
                new SelectListItem() { Text = "Mango", Value = "Mango" },
                new SelectListItem() { Text = "Nike", Value = "Nike" },
                new SelectListItem() { Text = "Zara", Value = "Zara" },
                new SelectListItem() { Text = "Autre", Value = "Autre" },

            };
            return list;
        }

        public static IEnumerable<SelectListItem> TypeShoesList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Baskets/Sneakers", Value = "Baskets/Sneakers" },
                new SelectListItem() { Text = "Chaussures à lacets", Value = "Chaussures à lacets" },
                new SelectListItem() { Text = "Chaussures à scratch", Value = "Chaussures à scratch" },
                new SelectListItem() { Text = "Mocassins", Value = "Mocassins" },
                new SelectListItem() { Text = "Bottines & lowboots", Value = "Bottines & lowboots" },
                new SelectListItem() { Text = "Bottes", Value = "Bottes" },
                 new SelectListItem() { Text = "Escarpins", Value = "Escarpins" },
                  new SelectListItem() { Text = "Sandales & Nu-pieds", Value = "Sandales & Nu-pieds" },
                   new SelectListItem() { Text = "Chaussons & Pantoufles", Value = "Chaussons & Pantoufles" },
                    new SelectListItem() { Text = "Ballerines", Value = "Ballerines" },
                       new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> BrandShoesList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Adidas", Value = "Adidas" },
                new SelectListItem() { Text = "Asics", Value = "Asics" },
                new SelectListItem() { Text = "Azzaro", Value = "Azzaro" },
                new SelectListItem() { Text = "Balenciaga", Value = "Balenciaga" },
                new SelectListItem() { Text = "Bensimon", Value = "Bensimon" },
                new SelectListItem() { Text = "Bexley", Value = "Bexley" },
                 new SelectListItem() { Text = "Calvin Klein", Value = "Calvin Klein" },
                  new SelectListItem() { Text = "Celio", Value = "Celio" },
                   new SelectListItem() { Text = "Chanel", Value = "Chanel" },
                    new SelectListItem() { Text = "Christian Louboutin", Value = "Christian Louboutin" },
                       new SelectListItem() { Text = "Clarks", Value = "Clarks" },
                       new SelectListItem() { Text = "Converse", Value = "Converse" },
                       new SelectListItem() { Text = "Coq Sportif", Value = "Coq Sportif" },
                       new SelectListItem() { Text = "Dc Shoes", Value = "Dc Shoes" },
                       new SelectListItem() { Text = "Desigual", Value = "Desigual" },
                       new SelectListItem() { Text = "Dior", Value = "Dior" },
                       new SelectListItem() { Text = "Ellesse", Value = "Ellesse" },
                       new SelectListItem() { Text = "Geox", Value = "Geox" },
                       new SelectListItem() { Text = "Giuseppe Zanotti", Value = "Giuseppe Zanotti" },
                       new SelectListItem() { Text = "Gucci", Value = "Gucci" },
                       new SelectListItem() { Text = "Guess", Value = "Guess" },
                       new SelectListItem() { Text = "H&M", Value = "H&M" },
                       new SelectListItem() { Text = "Hugo Boss", Value = "Hugo Boss" },
                       new SelectListItem() { Text = "Jm Weston", Value = "Jm Weston" },
                       new SelectListItem() { Text = "Kappa", Value = "Kappa" },
                       new SelectListItem() { Text = "Lacoste", Value = "Lacoste" },
                       new SelectListItem() { Text = "Levis", Value = "Levis" },
                       new SelectListItem() { Text = "Louis Vuitton", Value = "Louis Vuitton" },
                       new SelectListItem() { Text = "New Balance", Value = "New Balance" },
                       new SelectListItem() { Text = "Nike", Value = "Nike" },
                       new SelectListItem() { Text = "Palladium", Value = "Palladium" },
                       new SelectListItem() { Text = "Paul Smith", Value = "Paul Smith" },
                       new SelectListItem() { Text = "Prada", Value = "Prada" },
                       new SelectListItem() { Text = "Puma", Value = "Puma" },
                       new SelectListItem() { Text = "Ralph Lauren", Value = "Ralph Lauren" },
                       new SelectListItem() { Text = "Reebok", Value = "Reebok" },
                       new SelectListItem() { Text = "Timberland", Value = "Timberland" },
                       new SelectListItem() { Text = "Vans", Value = "Vans" },
                       new SelectListItem() { Text = "Weston", Value = "Weston" },
                       new SelectListItem() { Text = "Zara", Value = "Zara" },
                       new SelectListItem() { Text = "Autre", Value = "Autre" },

            };
            return list;
        }

        public static IEnumerable<SelectListItem> SizeShoesList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "16", Value = "16" },
                new SelectListItem() { Text = "18", Value = "18" },
                new SelectListItem() { Text = "19", Value = "19" },
                new SelectListItem() { Text = "20", Value = "20" },
                new SelectListItem() { Text = "21", Value = "21" },
                new SelectListItem() { Text = "22", Value = "22" },
                 new SelectListItem() { Text = "23", Value = "23" },
                  new SelectListItem() { Text = "24", Value = "24" },
                   new SelectListItem() { Text = "25", Value = "25" },
                    new SelectListItem() { Text = "26", Value = "26" },
                       new SelectListItem() { Text = "27", Value = "27" },
                       new SelectListItem() { Text = "28", Value = "28" },
                       new SelectListItem() { Text = "29", Value = "29" },
                       new SelectListItem() { Text = "30", Value = "30" },
                       new SelectListItem() { Text = "31", Value = "31" },
                       new SelectListItem() { Text = "32", Value = "32" },
                       new SelectListItem() { Text = "33", Value = "33" },
                       new SelectListItem() { Text = "34", Value = "34" },
                       new SelectListItem() { Text = "35", Value = "35" },
                       new SelectListItem() { Text = "36", Value = "36" },
                       new SelectListItem() { Text = "37", Value = "37" },
                       new SelectListItem() { Text = "38", Value = "38" },
                       new SelectListItem() { Text = "39", Value = "39" },
                       new SelectListItem() { Text = "40", Value = "40" },
                       new SelectListItem() { Text = "41", Value = "41" },
                       new SelectListItem() { Text = "42", Value = "42" },
                       new SelectListItem() { Text = "43", Value = "43" },
                       new SelectListItem() { Text = "44", Value = "44" },
                       new SelectListItem() { Text = "45", Value = "45" },
                       new SelectListItem() { Text = "46", Value = "46" },
                       new SelectListItem() { Text = "47", Value = "47" },
                       new SelectListItem() { Text = "48", Value = "48" },
                       new SelectListItem() { Text = "49", Value = "49" },
                       new SelectListItem() { Text = "50+", Value = "50+" }                      

            };
            return list;
        }

        public static IEnumerable<SelectListItem> TypeAccesorieLugagesList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Accessoire pour cheveux", Value = "Accessoire pour cheveux" },
                new SelectListItem() { Text = "Bonnet, bob, béret", Value = "Bonnet, bob, béret" },
                new SelectListItem() { Text = "Bretelles", Value = "Bretellesh" },
                new SelectListItem() { Text = "Cartable", Value = "Cartable" },
                new SelectListItem() { Text = "Casquette", Value = "Casquette" },
                new SelectListItem() { Text = "Ceinture", Value = "Ceinture" },
                 new SelectListItem() { Text = "Châle et étole", Value = "Châle et étole" },
                  new SelectListItem() { Text = "Chapeau", Value = "Chapeau" },
                   new SelectListItem() { Text = "Cravate et noeud papillon", Value = "Cravate et noeud papillon" },
                    new SelectListItem() { Text = "Echarpe et foulard", Value = "Echarpe et foulard" },
                       new SelectListItem() { Text = "Etui téléphone", Value = "Etui téléphone" },
                        new SelectListItem() { Text = "Gants, mitaines et moufles", Value = "Gants, mitaines et moufles" },
                         new SelectListItem() { Text = "Housse de tablette et ordinateur", Value = "Housse de tablette et ordinateur" },
                          new SelectListItem() { Text = "Lunettes", Value = "Lunettes" },
                          new SelectListItem() { Text = "Mallette", Value = "Mallette" },
                          new SelectListItem() { Text = "Parapluie", Value = "Parapluie" },
                          new SelectListItem() { Text = "Perruque", Value = "Perruque" },
                          new SelectListItem() { Text = "Pochette", Value = "Pochette" },
                          new SelectListItem() { Text = "Porte-cartes", Value = "Porte-cartes" },
                          new SelectListItem() { Text = "Porte-chéquier", Value = "Porte-chéquier" },
                          new SelectListItem() { Text = "Porte-clés", Value = "Porte-clés" },
                          new SelectListItem() { Text = "Porte-habits", Value = "Porte-habits" },
                          new SelectListItem() { Text = "Porte-monnaie et portefeuille", Value = "Porte-monnaie et portefeuille" },
                          new SelectListItem() { Text = "Sac à dos", Value = "Sac à dos" },
                          new SelectListItem() { Text = "Sac à main", Value = "Sac à main" },
                          new SelectListItem() { Text = "Sac de voyage", Value = "Sac de voyage" },
                          new SelectListItem() { Text = "Sac en bandoulière", Value = "Sac en bandoulière" },
                          new SelectListItem() { Text = "Sacoche", Value = "Sacoche" },
                          new SelectListItem() { Text = "Trousse", Value = "Trousse" },
                          new SelectListItem() { Text = "Valise cabine", Value = "Valise cabine" },
                          new SelectListItem() { Text = "Valise moyenne et grande taille", Value = "Valise moyenne et grande taille" },
                          new SelectListItem() { Text = "Autre", Value = "Autre" },


            };
            return list;
        }

        public static IEnumerable<SelectListItem> TypeWatchJewelryList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Bague", Value = "Bague" },
                new SelectListItem() { Text = "Bijou de téléphone", Value = "Bijou de téléphone" },
                new SelectListItem() { Text = "Bijou de tête", Value = "Bijou de tête" },
                new SelectListItem() { Text = "Boucles d'oreilles", Value = "Boucles d'oreilles" },
                new SelectListItem() { Text = "Boutons de manchette", Value = "Boutons de manchette" },
                new SelectListItem() { Text = "Bracelet", Value = "Bracelet" },
                 new SelectListItem() { Text = "Broche", Value = "Broche" },
                  new SelectListItem() { Text = "Chaîne", Value = "Chaîne" },
                   new SelectListItem() { Text = "Charm", Value = "Charm" },
                    new SelectListItem() { Text = "Chevalière", Value = "Chevalière" },
                       new SelectListItem() { Text = "Collier, pendentif", Value = "Collier, pendentif" },
                       new SelectListItem() { Text = "Gourmette", Value = "Gourmette" },
                       new SelectListItem() { Text = "Montre à gousset", Value = "Montre à gousset" },
                       new SelectListItem() { Text = "Montre automatique", Value = "Montre automatique" },
                       new SelectListItem() { Text = "Montre connectée", Value = "Montre connectée" },
                       new SelectListItem() { Text = "Montre de sport", Value = "Montre de sport" },
                       new SelectListItem() { Text = "Montre mécanique", Value = "Montre mécanique" },
                       new SelectListItem() { Text = "Montre quartz", Value = "Montre quartz" },
                       new SelectListItem() { Text = "Montre-bague", Value = "Montre-bague" },
                       new SelectListItem() { Text = "Montre-pendentif", Value = "Montre-pendentif" },
                       new SelectListItem() { Text = "Parure", Value = "Parure" },
                       new SelectListItem() { Text = "Piercing", Value = "Piercing" },
                       new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }


        public static IEnumerable<SelectListItem> TypeBabyEquipmentList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Babyphone", Value = "Babyphone" },
                new SelectListItem() { Text = "Baignoire", Value = "Baignoire" },
                new SelectListItem() { Text = "Barrière de sécurité", Value = "Barrière de sécurité" },
                new SelectListItem() { Text = "Bavoir", Value = "Bavoir" },
                new SelectListItem() { Text = "Berceau", Value = "Berceau" },
                new SelectListItem() { Text = "Biberon", Value = "Biberon" },
                 new SelectListItem() { Text = "Chaise haute", Value = "Chaise haute" },
                  new SelectListItem() { Text = "Chancelière", Value = "Chancelière" },
                   new SelectListItem() { Text = "Chauffe-biberon", Value = "Chauffe-biberon" },
                    new SelectListItem() { Text = "Couffin", Value = "Couffin" },
                       new SelectListItem() { Text = "Coussin d'allaitement", Value = "Coussin d'allaitement" },
                       new SelectListItem() { Text = "Gigoteuse", Value = "Gigoteuse" },
                       new SelectListItem() { Text = "Humidificateur", Value = "Humidificateur" },
                       new SelectListItem() { Text = "Lit bébé", Value = "Lit bébé" },
                       new SelectListItem() { Text = "Lit parapluie", Value = "Lit parapluie" },
                       new SelectListItem() { Text = "Matelas et matelas à langer", Value = "Matelas et matelas à langer" },
                       new SelectListItem() { Text = "Nacelle", Value = "Nacelle" },
                       new SelectListItem() { Text = "Nid d'ange", Value = "Nid d'ange" },
                       new SelectListItem() { Text = "Parc", Value = "Parc" },
                       new SelectListItem() { Text = "Porte-bébé et écharpe de portage", Value = "Porte-bébé et écharpe de portage" },
                       new SelectListItem() { Text = "Poubelle à couches", Value = "Poubelle à couches" },
                       new SelectListItem() { Text = "Poussette", Value = "Poussette" },
                       new SelectListItem() { Text = "Pot et siège réducteur", Value = "Pot et siège réducteur" },
                       new SelectListItem() { Text = "Rehausseur", Value = "Rehausseur" },
                       new SelectListItem() { Text = "Robot de cuisine bébé", Value = "Robot de cuisine bébé" },
                       new SelectListItem() { Text = "Sac à langer", Value = "Sac à langer" },
                       new SelectListItem() { Text = "Sécurité domestique", Value = "Sécurité domestique" },
                       new SelectListItem() { Text = "Sécurité extérieur", Value = "Sécurité extérieur" },
                       new SelectListItem() { Text = "Siège auto", Value = "Siège auto" },
                       new SelectListItem() { Text = "Stérilisateur", Value = "Stérilisateur" },
                       new SelectListItem() { Text = "Sucette", Value = "Sucette" },
                       new SelectListItem() { Text = "Table à langer", Value = "Table à langer" },
                       new SelectListItem() { Text = "Tapis d'éveil", Value = "Tapis d'éveil" },
                       new SelectListItem() { Text = "Tétine", Value = "Tétine" },
                       new SelectListItem() { Text = "Thermomètre", Value = "Thermomètre" },
                       new SelectListItem() { Text = "Tire-lait", Value = "Tire-lait" },
                       new SelectListItem() { Text = "Transat et balancelle", Value = "Transat et balancelle" },
                       new SelectListItem() { Text = "Trotteur", Value = "Trotteur" },
                       new SelectListItem() { Text = "Vaisselle", Value = "Vaisselle" },
                       new SelectListItem() { Text = "Veilleuse", Value = "Veilleuse" },
                       new SelectListItem() { Text = "Autre", Value = "Autre" }
                     

            };
            return list;
        }

        public static IEnumerable<SelectListItem> TypeBabyClothesList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Bodies", Value = "Bodies" },
                new SelectListItem() { Text = "T-shirt & brassières", Value = "T-shirt & brassières" },
                new SelectListItem() { Text = "Bermudas & Shorts", Value = "Bermudas & Shorts" },
                new SelectListItem() { Text = "Pantalons", Value = "Pantalons" },
                new SelectListItem() { Text = "Jeans", Value = "Jeans" },
                new SelectListItem() { Text = "Dors-bien & Pyjamas", Value = "Dors-bien & Pyjamas" },
                 new SelectListItem() { Text = "Pull & Gilets", Value = "Pull & Gilets" },
                  new SelectListItem() { Text = "Robes & Jupes", Value = "Robes & Jupes" },
                   new SelectListItem() { Text = "Manteaux & Vestes", Value = "Manteaux & Vestes" },
                    new SelectListItem() { Text = "Legging & collants", Value = "Legging & collants" },
                       new SelectListItem() { Text = "Déguisements", Value = "Déguisements" },
                       new SelectListItem() { Text = "Ensembles & Combinaisons", Value = "Ensembles & Combinaisons" },
                       new SelectListItem() { Text = "Bonnets & Chapeaux", Value = "Bonnets & Chapeaux" },
                       new SelectListItem() { Text = "Maillots de bain", Value = "Maillots de bain" },
                       new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }



        public static IEnumerable<SelectListItem> UniversList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Femme", Value = "Femme" },
                new SelectListItem() { Text = "Maternité", Value = "Maternité" },
                new SelectListItem() { Text = "Mixte", Value = "Mixte" },
                new SelectListItem() { Text = "Homme", Value = "Homme" },
                new SelectListItem() { Text = "Enfant", Value = "Enfant" },
                 
            };
            return list;
        }

        public static IEnumerable<SelectListItem> SeizeClothesList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                 new SelectListItem() { Text = "Prématuré", Value = "Prématuré" },
                 new SelectListItem() { Text = "0 mois", Value = "0 mois" },
                 new SelectListItem() { Text = "1 mois", Value = "1 mois" },
                 new SelectListItem() { Text = "5 mois", Value = "5 mois" },
                 new SelectListItem() { Text = "10 mois", Value = "10 mois" },
                 new SelectListItem() { Text = "15 mois", Value = "15 mois" },
                 new SelectListItem() { Text = "25 mois", Value = "25 mois" },
                 new SelectListItem() { Text = "3 ans", Value = "3 ans" },
                 new SelectListItem() { Text = "4 ans", Value = "4 ans" },
                 new SelectListItem() { Text = "5 ans", Value = "5 ans" },
                 new SelectListItem() { Text = "6 ans", Value = "6 ans" },
                 new SelectListItem() { Text = "7 ans", Value = "7 ans" },
                 new SelectListItem() { Text = "8 ans", Value = "8 ans" },
                 new SelectListItem() { Text = "9 ans", Value = "9 ans" },
                 new SelectListItem() { Text = "10 ans", Value = "10 ans" },
                 new SelectListItem() { Text = "12 ans", Value = "12 ans" },
                 new SelectListItem() { Text = "14 ans", Value = "14 ans" },
                new SelectListItem() { Text = "32 - XXS", Value = "32 - XXS" },
                new SelectListItem() { Text = "34 - XS", Value = "34 - XS" },
                new SelectListItem() { Text = "36 - S", Value = "36 - S" },
                new SelectListItem() { Text = "38 - M", Value = "38 - M" },
                new SelectListItem() { Text = "40 - L", Value = "40 - L" },
                new SelectListItem() { Text = "42 - XL", Value = "42 - XL" },
                new SelectListItem() { Text = "44 - XXL", Value = "44 - XXL" },
                new SelectListItem() { Text = "46 - XXXL", Value = "46 - XXXL" },
                new SelectListItem() { Text = "48 - 4XL", Value = "48 - 4XL" },
                new SelectListItem() { Text = "50 et plus - 5XL", Value = "50 et plus - 5XL" },

            };
            return list;
        }

        public static IEnumerable<SelectListItem> StateModeList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Neuf avec étiquette", Value = "Neuf avec étiquette" },
                new SelectListItem() { Text = "Neuf sans étiquette", Value = "Neuf sans étiquette" },
                new SelectListItem() { Text = "Très bon état", Value = "Très bon état" },
                new SelectListItem() { Text = "Bon état", Value = "Bon état" },
                new SelectListItem() { Text = "État satisfaisant", Value = "État satisfaisant" },

            };
            return list;
        }

        public static IEnumerable<SelectListItem> ColorModeList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Argenté / Acier", Value = "Argenté / Acier" },
                new SelectListItem() { Text = "Beige / Camel", Value = "Beige / Camel" },
                new SelectListItem() { Text = "Blanc", Value = "Blanc" },
                new SelectListItem() { Text = "Bleu / Ciel", Value = "Bleu / Ciel" },
                new SelectListItem() { Text = "Crème / Blanc cassé / Écru", Value = "Crème / Blanc cassé / Écru" },
                new SelectListItem() { Text = "Doré / Bronze / Cuivre", Value = "Doré / Bronze / Cuivre" },
                new SelectListItem() { Text = "Gris / Anthracite", Value = "Gris / Anthracite" },
                new SelectListItem() { Text = "Imprimés multicolore", Value = "Imprimés multicolore" },
                new SelectListItem() { Text = "Jaune / Moutarde", Value = "Jaune / Moutarde" },
                new SelectListItem() { Text = "Kaki", Value = "Kaki" },
                new SelectListItem() { Text = "Lavande / Lilas", Value = "Lavande / Lilas" },
                new SelectListItem() { Text = "Marine / Turquoise", Value = "Marine / Turquoise" },
                new SelectListItem() { Text = "Multicolore", Value = "Multicolore" },
                new SelectListItem() { Text = "Noir", Value = "Noir" },
                new SelectListItem() { Text = "Orange / Corail", Value = "Orange / Corail" },
                new SelectListItem() { Text = "Rose / Fushia", Value = "Rose / Fushia" },
                new SelectListItem() { Text = "Rouge / Bordeaux", Value = "Rouge / Bordeaux" },
                new SelectListItem() { Text = "Vert", Value = "Vert" },
                new SelectListItem() { Text = "Violet / Mauve", Value = "Violet / Mauve" },
                new SelectListItem() { Text = "Autre", Value = "Autre" },

            };
            return list;
        }
    }
}