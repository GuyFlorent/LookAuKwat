using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LookAuKwat.ViewModel
{
    public class SelectListMethodHouse
    {
        public static IEnumerable<SelectListItem> RubriqueHouseList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Ameublement", Value = "Ameublement" },
                new SelectListItem() { Text = "Electroménager", Value = "Electroménager" },
                new SelectListItem() { Text = "Cuisine", Value = "Cuisine" },
                new SelectListItem() { Text = "Décoration", Value = "Décoration" },
                new SelectListItem() { Text = "Linge de maison", Value = "Linge de maison" },
                new SelectListItem() { Text = "Bricolage", Value = "Bricolage" },
                new SelectListItem() { Text = "Jardinage", Value = "Jardinage" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> TypeAmebleumentHouseList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Accessoire", Value = "Accessoire" },
                new SelectListItem() { Text = "Armoire", Value = "Armoire" },
                new SelectListItem() { Text = "Bar", Value = "Bar" },
                new SelectListItem() { Text = "Bain & baignoire", Value = "Bain & baignoire" },
                new SelectListItem() { Text = "Bibliothèque et étagère", Value = "Bibliothèque et étagère" },
                new SelectListItem() { Text = "Buffet", Value = "Buffet" },
                new SelectListItem() { Text = "Bureau", Value = "Bureau" },
                new SelectListItem() { Text = "Canapé", Value = "Canapé" },
                new SelectListItem() { Text = "Canapé convertible et clic clac", Value = "Canapé convertible et clic clac" },
                new SelectListItem() { Text = "Chaise, tabouret et banc", Value = "Chaise, tabouret et banc" },
                new SelectListItem() { Text = "Coffre et malle", Value = "Coffre et malle" },
                new SelectListItem() { Text = "Coiffeuse", Value = "Coiffeuse" },
                new SelectListItem() { Text = "Commode", Value = "Commode" },
                new SelectListItem() { Text = "Console", Value = "Console" },
                new SelectListItem() { Text = "Dressing et penderie", Value = "Dressing et penderie" },
                new SelectListItem() { Text = "Fauteuil", Value = "Fauteuil" },
                new SelectListItem() { Text = "Lit", Value = "Lit" },
                new SelectListItem() { Text = "Lit pour enfant", Value = "Lit pour enfant" },
                new SelectListItem() { Text = "Luminaire", Value = "Luminaire" },
                new SelectListItem() { Text = "Matelas", Value = "Matelas" },
                new SelectListItem() { Text = "Meuble de cuisine", Value = "Meuble de cuisine" },
                new SelectListItem() { Text = "Meuble de jardin", Value = "Meuble de jardin" },
                new SelectListItem() { Text = "Meuble de rangement", Value = "Meuble de rangement" },
                new SelectListItem() { Text = "Meuble de salle de bain", Value = "Meuble de salle de bain" },
                new SelectListItem() { Text = "Meuble TV", Value = "Meuble TV" },
                new SelectListItem() { Text = "Porte", Value = "Porte" },
                new SelectListItem() { Text = "Porte-manteau", Value = "Porte-manteau" },
                new SelectListItem() { Text = "Sommier", Value = "Sommier" },
                new SelectListItem() { Text = "Table d'appoint", Value = "Table d'appoint" },
                new SelectListItem() { Text = "Table de salle à manger", Value = "Table de salle à manger" },
                new SelectListItem() { Text = "Table basse", Value = "Table basse" },
                new SelectListItem() { Text = "Table de chevet", Value = "Table de chevet" },
                new SelectListItem() { Text = "Tapis", Value = "Tapis" },
                new SelectListItem() { Text = "Vaisselier", Value = "Vaisselier" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }
               
            };
            return list;
        }

        public static IEnumerable<SelectListItem> FabricMaterialAmmeblementDecorationList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Acier", Value = "Acier" },
                new SelectListItem() { Text = "Bois", Value = "Bois" },
                new SelectListItem() { Text = "Bois massif", Value = "Bois massif" },
                new SelectListItem() { Text = "Bronze", Value = "Bronze" },
                new SelectListItem() { Text = "Céramique", Value = "Céramique" },
                new SelectListItem() { Text = "Chêne", Value = "Chêne" },
                new SelectListItem() { Text = "Cuir", Value = "Cuir" },
                new SelectListItem() { Text = "Fer", Value = "Fer" },
                new SelectListItem() { Text = "Formica", Value = "Formica" },
                new SelectListItem() { Text = "Laqué", Value = "Laqué" },
                new SelectListItem() { Text = "Marbre", Value = "Marbre" },
                new SelectListItem() { Text = "Métal", Value = "Métal" },
                new SelectListItem() { Text = "Pierre", Value = "Pierre" },
                new SelectListItem() { Text = "Pin", Value = "Pin" },
                new SelectListItem() { Text = "Plastique", Value = "Plastique" },
                new SelectListItem() { Text = "Rotin et osier", Value = "Rotin et osier" },
                new SelectListItem() { Text = "Tissu", Value = "Tissu" },
                new SelectListItem() { Text = "Velours", Value = "Velours" },
                new SelectListItem() { Text = "Verre", Value = "Verre" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> TypeOutilTableHouseList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Assiette", Value = "Assiette" },
                new SelectListItem() { Text = "Beurrier", Value = "Beurrier" },
                new SelectListItem() { Text = "Bocaux et pots", Value = "Bocaux et pots" },
                new SelectListItem() { Text = "Boite de conservation et boite en métal", Value = "Boite de conservation et boite en métal" },
                new SelectListItem() { Text = "Bol", Value = "Bol" },
                new SelectListItem() { Text = "Bonbonnière", Value = "Bonbonnière" },
                new SelectListItem() { Text = "Carafe et pichet", Value = "Carafe et pichet" },
                new SelectListItem() { Text = "Casserole", Value = "Casserole" },
                new SelectListItem() { Text = "Cocotte", Value = "Cocotte" },
                new SelectListItem() { Text = "Coffret", Value = "Coffret" },
                new SelectListItem() { Text = "Coquetier", Value = "Coquetier" },
                new SelectListItem() { Text = "Corbeille", Value = "Corbeille" },
                new SelectListItem() { Text = "Coupe et coupelle", Value = "Coupe et coupelle" },
                new SelectListItem() { Text = "Couteaux", Value = "Couteaux" },
                new SelectListItem() { Text = "Couvercle", Value = "Couvercle" },
                new SelectListItem() { Text = "Couvert", Value = "Couvert" },
                new SelectListItem() { Text = "Dessous de plat", Value = "Dessous de plat" },
                new SelectListItem() { Text = "Flûte", Value = "Flûte" },
                new SelectListItem() { Text = "Gourde", Value = "Gourde" },
                new SelectListItem() { Text = "Huilier et vinaigrier", Value = "Huilier et vinaigrier" },
                new SelectListItem() { Text = "Mazagran", Value = "Mazagran" },
                new SelectListItem() { Text = "Moule", Value = "Moule" },
                new SelectListItem() { Text = "Planche à découper", Value = "Planche à découper" },
                new SelectListItem() { Text = "Plat à four et à tarte", Value = "Plat à four et à tarte" },
                new SelectListItem() { Text = "Plat apéritif", Value = "Plat apéritif" },
                new SelectListItem() { Text = "Plat de service", Value = "Plat de service" },
                new SelectListItem() { Text = "Plateau", Value = "Plateau" },
                new SelectListItem() { Text = "Poële", Value = "Poële" },
                new SelectListItem() { Text = "Ramequin", Value = "Ramequin" },
                new SelectListItem() { Text = "Rond de serviette", Value = "Rond de serviette" },
                new SelectListItem() { Text = "Saladier", Value = "Saladier" },
                new SelectListItem() { Text = "Salière, poivrière et sucrier", Value = "Salière, poivrière et sucrier" },
                new SelectListItem() { Text = "Saucière", Value = "Saucière" },
                new SelectListItem() { Text = "Seau à glaçons", Value = "Seau à glaçons" },
                new SelectListItem() { Text = "Service à café ou à thé", Value = "Service à café ou à thé" },
                new SelectListItem() { Text = "Service de vaisselle", Value = "Service de vaisselle" },
                new SelectListItem() { Text = "Set de table", Value = "Set de table" },
                new SelectListItem() { Text = "Shaker", Value = "Shaker" },
                new SelectListItem() { Text = "Soucoupe", Value = "Soucoupe" },
                new SelectListItem() { Text = "Soupière", Value = "Soupière" },
                new SelectListItem() { Text = "Sous verre", Value = "Sous verre" },
                new SelectListItem() { Text = "Tasse et mug", Value = "Tasse et mug" },
                new SelectListItem() { Text = "Terrine", Value = "Terrine" },
                new SelectListItem() { Text = "Théière, tisanière", Value = "Théière, tisanière" },
                new SelectListItem() { Text = "Tire-bouchon", Value = "Tire-bouchon" },
                new SelectListItem() { Text = "Ustensile de cuisine", Value = "Ustensile de cuisine" },
                new SelectListItem() { Text = "Verre", Value = "Verre" },
                new SelectListItem() { Text = "Verrine", Value = "Verrine" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }
               

            };
            return list;
        }

        public static IEnumerable<SelectListItem> TypeDecorationHouseList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Abat-jour", Value = "Abat-jour" },
                new SelectListItem() { Text = "Accessoire de rangement", Value = "Accessoire de rangement" },
                new SelectListItem() { Text = "Accessoire de salle de bain", Value = "Accessoire de salle de bain" },
                new SelectListItem() { Text = "Applique", Value = "Applique" },
                new SelectListItem() { Text = "Bibelot", Value = "Bibelot" },
                new SelectListItem() { Text = "Bougeoir et photophore", Value = "Bougeoir et photophore" },
                new SelectListItem() { Text = "Bouquet et plante artificielle", Value = "Bouquet et plante artificielle" },
                new SelectListItem() { Text = "Cadre photo", Value = "Cadre photo" },
                new SelectListItem() { Text = "Cendrier et vide-poche", Value = "Cendrier et vide-poche" },
                new SelectListItem() { Text = "Coussin", Value = "Coussin" },
                new SelectListItem() { Text = "Dame-jeanne et bonbonne", Value = "Dame-jeanne et bonbonne" },
                new SelectListItem() { Text = "Guirlande", Value = "Guirlande" },
                new SelectListItem() { Text = "Horloge, pendule et réveil", Value = "Horloge, pendule et réveil" },
                new SelectListItem() { Text = "Lampadaire", Value = "Lampadaire" },
                new SelectListItem() { Text = "Lampe à poser", Value = "Lampe à poser" },
                new SelectListItem() { Text = "Lampe sur pied", Value = "Lampe sur pied" },
                new SelectListItem() { Text = "Lustre", Value = "Lustre" },
                new SelectListItem() { Text = "Miroir", Value = "Miroir" },
                new SelectListItem() { Text = "Panier, boite", Value = "Panier, boite" },
                new SelectListItem() { Text = "Paravent", Value = "Paravent" },
                new SelectListItem() { Text = "Pêle-mêle photo", Value = "Pêle-mêle photo" },
                new SelectListItem() { Text = "Rideaux, voilage et store", Value = "Rideaux, voilage et store" },
                new SelectListItem() { Text = "Sculpture et statue", Value = "Sculpture et statue" },
                new SelectListItem() { Text = "Suspension", Value = "Suspension" },
                new SelectListItem() { Text = "Tableau et toile", Value = "Tableau et toile" },
                new SelectListItem() { Text = "Tapis", Value = "Tapis" },
                new SelectListItem() { Text = "Vase, cache pot et céramique", Value = "Vase, cache pot et céramique" },
                
                new SelectListItem() { Text = "Autre", Value = "Autre" }


            };
            return list;
        }
        public static IEnumerable<SelectListItem> FabricMaterialOutilTableList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Acrylique", Value = "Acrylique" },
                new SelectListItem() { Text = "Alu", Value = "Alu" },
                new SelectListItem() { Text = "Argenterie", Value = "Argenterie" },
                new SelectListItem() { Text = "Bambou", Value = "Bambou" },
                new SelectListItem() { Text = "Bois", Value = "Bois" },
                new SelectListItem() { Text = "Caoutchouc", Value = "Caoutchouc" },
                new SelectListItem() { Text = "Carton", Value = "Carton" },
                new SelectListItem() { Text = "Céramique", Value = "Céramique" },
                new SelectListItem() { Text = "Coton", Value = "Coton" },
                new SelectListItem() { Text = "Cristal", Value = "Cristal" },
                new SelectListItem() { Text = "Cuivre", Value = "Cuivre" },
                new SelectListItem() { Text = "Faïence", Value = "Faïence" },
                new SelectListItem() { Text = "Fer forgé", Value = "Fer forgé" },
                new SelectListItem() { Text = "Grès", Value = "Grès" },
                new SelectListItem() { Text = "Inox", Value = "Inox" },
                new SelectListItem() { Text = "Métal", Value = "Métal" },
                new SelectListItem() { Text = "Papier", Value = "Papier" },
                new SelectListItem() { Text = "Pierre", Value = "Pierre" },
                new SelectListItem() { Text = "Plastique", Value = "Plastique" },
                new SelectListItem() { Text = "Polyester", Value = "Polyester" },
                new SelectListItem() { Text = "Porcelaine", Value = "Porcelaine" },
                new SelectListItem() { Text = "PVC", Value = "PVC" },
                new SelectListItem() { Text = "Résine", Value = "Résine" },
                new SelectListItem() { Text = "Terre cuite", Value = "Terre cuite" },
                new SelectListItem() { Text = "Verre", Value = "Verre" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> TypeLingeHouseList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Linge de lit", Value = "Linge de lit" },
                new SelectListItem() { Text = "Linge de bain", Value = "Linge de bain" },
                new SelectListItem() { Text = "Déco textile", Value = "Déco textile" },
                new SelectListItem() { Text = "Linge de table", Value = "Linge de table" },
                new SelectListItem() { Text = "Équipement du lit", Value = "Équipement du lit" },
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }

        public static IEnumerable<SelectListItem> FabricMaterialLingeList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Coton", Value = "Coton" },
                new SelectListItem() { Text = "Coton biologique", Value = "Coton biologique" },
                new SelectListItem() { Text = "Lin", Value = "Lin" },
                new SelectListItem() { Text = "PVC et synthétique", Value = "PVC et synthétique" },
                new SelectListItem() { Text = "Velours", Value = "Velours" },
                new SelectListItem() { Text = "Laine", Value = "Laine" },
                new SelectListItem() { Text = "Fausse fourrure", Value = "Fausse fourrure" },
                new SelectListItem() { Text = "Fibres Naturelles", Value = "Fibres Naturelles" },
                new SelectListItem() { Text = "Papier", Value = "Papier" },
                new SelectListItem() { Text = "Viscose", Value = "Viscose" },
                new SelectListItem() { Text = "Satin de coton", Value = "Satin de coton" },
                new SelectListItem() { Text = "Percale de coton", Value = "Percale de coton" },
                new SelectListItem() { Text = "Toile ciré", Value = "Toile ciré" },
                new SelectListItem() { Text = "Polyester, Polyester/Coton", Value = "Polyester, Polyester/Coton" },
                new SelectListItem() { Text = "Flanelle", Value = "Flanelle" },
                new SelectListItem() { Text = "Métis", Value = "Métis" },
                
                new SelectListItem() { Text = "Autre", Value = "Autre" }

            };
            return list;
        }
        public static IEnumerable<SelectListItem> StateHouseList()
        {
            IList<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "État neuf", Value = "État neuf" },
                new SelectListItem() { Text = "Très bon étatussures", Value = "Très bon état" },
                new SelectListItem() { Text = "Bon état", Value = "Bon état" },
                new SelectListItem() { Text = "État satisfaisant", Value = "État satisfaisant" },
                new SelectListItem() { Text = "Pour pièces", Value = "Pour pièces" }

            };
            return list;
        }
    }
}