using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LookAuKwat.Controllers
{
    public class HouseOfferSearchController : Controller
    {
        private IDal dal;
        public HouseOfferSearchController() : this(new Dal())
        {

        }

        public HouseOfferSearchController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: HouseOfferSearch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FilterSearchHouse(SeachJobViewModel model)
        {

            return View(model);
        }

        public ActionResult SearchOfferHouse_PartialView(SeachJobViewModel model)
        {
            model.PriceHouse = 1000000000;
            return PartialView(model);
        }

       // [OutputCache(Duration = 300, VaryByParam = "TownHouse;ColorHouse;StateHouse;PriceHouse;RubriqueHouse;pageNumber;sortBy")]
        public ActionResult searchOfferHouse(SeachJobViewModel model, int? pageNumber, string sortBy)
        {
            ViewBag.PriceAscSort = String.IsNullOrEmpty(sortBy) ? "Price desc" : "";
            ViewBag.PriceDescSort = sortBy == "Prix croissant" ? "Price asc" : "";
            ViewBag.DateAscSort = sortBy == "Plus anciennes" ? "date asc" : "";
            ViewBag.DateDescSort = sortBy == "Plus recentes" ? "date desc" : "";

            model.CagtegorieSearch = "Maison";
            model.SearchOrAskJobJob = "J'offre";
            model.sortBy = sortBy;
            model.PageNumber = pageNumber;

            List<HouseModel> liste = dal.GetListHouseWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch &&
            m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();

            if (!string.IsNullOrWhiteSpace(model.TownHouse))
            {
                liste = liste.Where(m => m.Town == model.TownHouse).ToList();
            }
            if (!string.IsNullOrWhiteSpace(model.ColorHouse))
            {
                liste = liste.Where(m => m.ColorHouse == model.ColorHouse).ToList();
            }
            if (!string.IsNullOrWhiteSpace(model.StateHouse))
            {
                liste = liste.Where(m => m.StateHouse == model.StateHouse).ToList();
            }
            if (model.PriceHouse > 0)
            {
                liste = liste.Where(m => m.Price < model.PriceHouse).ToList();
            }
            switch (model.RubriqueHouse)
            {
                case "Ameublement":
                    liste = liste.Where(m => m.RubriqueHouse == model.RubriqueHouse).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeHouseAmmeublement))
                    {
                        liste = liste.Where(m => m.TypeHouse == model.TypeHouseAmmeublement).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.FabricMaterialeHouseAmmeublementDeco))
                    {
                        liste = liste.Where(m => m.FabricMaterialeHouse == model.FabricMaterialeHouseAmmeublementDeco).ToList();
                    }
                   
                    break;
                case "Cuisine":
                    liste = liste.Where(m => m.RubriqueHouse == model.RubriqueHouse).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeHouseCuisine))
                    {
                        liste = liste.Where(m => m.TypeHouse == model.TypeHouseCuisine).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.FabricMaterialeHouseCuisine))
                    {
                        liste = liste.Where(m => m.FabricMaterialeHouse == model.FabricMaterialeHouseCuisine).ToList();
                    }
                    break;
                case "Décoration":
                    liste = liste.Where(m => m.RubriqueHouse == model.RubriqueHouse).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeHouseDecoration))
                    {
                        liste = liste.Where(m => m.TypeHouse == model.TypeHouseDecoration).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.FabricMaterialeHouseAmmeublementDeco))
                    {
                        liste = liste.Where(m => m.FabricMaterialeHouse == model.FabricMaterialeHouseAmmeublementDeco).ToList();
                    }

                    break;
                case "Linge de maison":

                    liste = liste.Where(m => m.RubriqueHouse == model.RubriqueHouse).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeHouseLinge))
                    {
                        liste = liste.Where(m => m.TypeHouse == model.TypeHouseLinge).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.FabricMaterialeHouseLinge))
                    {
                        liste = liste.Where(m => m.FabricMaterialeHouse == model.FabricMaterialeHouseLinge).ToList();
                    }
                    break;

            }
             

            model.ListePro = new List<ProductModel>();

            model.ListeProHouse = liste ;

            switch (model.sortBy)
            {
                case "Price desc":
                    model.ListeProHouse = model.ListeProHouse.OrderByDescending(m => m.Price).ToList();
                    model.ListeProPagedList = model.ListeProHouse.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "Price asc":
                    model.ListeProHouse = model.ListeProHouse.OrderBy(m => m.Price).ToList();
                    model.ListeProPagedList = model.ListeProHouse.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "date desc":
                    model.ListeProHouse = model.ListeProHouse.OrderByDescending(m => m.DateAdd).ToList();
                    model.ListeProPagedList = model.ListeProHouse.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "date asc":
                    model.ListeProHouse = model.ListeProHouse.OrderBy(m => m.DateAdd).ToList();
                    model.ListeProPagedList = model.ListeProHouse.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                default:
                    model.ListeProHouse = model.ListeProHouse.OrderByDescending(x => x.DateAdd).ToList();
                    model.ListeProPagedList = model.ListeProHouse.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
            }


            return View("FilterSearchHouse", model);
            // return RedirectToAction("ResultSearch_PartialView", "Product", model);

        }
  
         public async Task<JsonResult> searchOfferHouse_Json(string rubrique, string town, int maxPrice, string typeHouseAmmeublement, string typeHouseCuisine,
            string typeHouseDecoration, string typeHouseLinge, string fabricMaterialeHouseAmmeublementDeco, string fabricMaterialeHouseCuisine, 
            string fabricMaterialeHouseLinge, string colorHouse, string stateHouse)
        {
            SeachJobViewModel model = new SeachJobViewModel();
            model.TownHouse = town;
            model.RubriqueHouse = rubrique;
            model.PriceHouse = maxPrice;
            model.TypeHouseAmmeublement = typeHouseAmmeublement;
            model.TypeHouseCuisine = typeHouseCuisine;
            model.TypeHouseDecoration = typeHouseDecoration;
            model.TypeHouseLinge = typeHouseLinge;
            model.FabricMaterialeHouseAmmeublementDeco = fabricMaterialeHouseAmmeublementDeco;
            model.FabricMaterialeHouseCuisine = fabricMaterialeHouseCuisine;
            model.FabricMaterialeHouseLinge = fabricMaterialeHouseLinge;
            model.ColorHouse = colorHouse;
            model.StateHouse = stateHouse;
            model.ColorMode = colorHouse;
           
            model.CagtegorieSearch = "Maison";
            model.SearchOrAskJobJob = "J'offre";




            List<HouseModel> liste = await dal.GetListHouseWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch &&
            m.SearchOrAskJob == model.SearchOrAskJobJob).ToListAsync();

            if (!string.IsNullOrWhiteSpace(model.TownHouse))
            {
                liste = liste.Where(m => m.Town == model.TownHouse).ToList();
            }
            if (!string.IsNullOrWhiteSpace(model.ColorHouse))
            {
                liste = liste.Where(m => m.ColorHouse == model.ColorHouse).ToList();
            }
            if (!string.IsNullOrWhiteSpace(model.StateHouse))
            {
                liste = liste.Where(m => m.StateHouse == model.StateHouse).ToList();
            }
            if (model.PriceHouse > 0)
            {
                liste = liste.Where(m => m.Price < model.PriceHouse).ToList();
            }
            switch (model.RubriqueHouse)
            {
                case "Ameublement":
                    liste = liste.Where(m => m.RubriqueHouse == model.RubriqueHouse).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeHouseAmmeublement))
                    {
                        liste = liste.Where(m => m.TypeHouse == model.TypeHouseAmmeublement).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.FabricMaterialeHouseAmmeublementDeco))
                    {
                        liste = liste.Where(m => m.FabricMaterialeHouse == model.FabricMaterialeHouseAmmeublementDeco).ToList();
                    }

                    break;
                case "Cuisine":
                    liste = liste.Where(m => m.RubriqueHouse == model.RubriqueHouse).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeHouseCuisine))
                    {
                        liste = liste.Where(m => m.TypeHouse == model.TypeHouseCuisine).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.FabricMaterialeHouseCuisine))
                    {
                        liste = liste.Where(m => m.FabricMaterialeHouse == model.FabricMaterialeHouseCuisine).ToList();
                    }
                    break;
                case "Décoration":
                    liste = liste.Where(m => m.RubriqueHouse == model.RubriqueHouse).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeHouseDecoration))
                    {
                        liste = liste.Where(m => m.TypeHouse == model.TypeHouseDecoration).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.FabricMaterialeHouseAmmeublementDeco))
                    {
                        liste = liste.Where(m => m.FabricMaterialeHouse == model.FabricMaterialeHouseAmmeublementDeco).ToList();
                    }

                    break;
                case "Linge de maison":

                    liste = liste.Where(m => m.RubriqueHouse == model.RubriqueHouse).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeHouseLinge))
                    {
                        liste = liste.Where(m => m.TypeHouse == model.TypeHouseLinge).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.FabricMaterialeHouseLinge))
                    {
                        liste = liste.Where(m => m.FabricMaterialeHouse == model.FabricMaterialeHouseLinge).ToList();
                    }
                    break;

            }
            // TempData["listeHouse_json"] = liste;

            var data = liste.Select(s => new DataJsonProductViewModel
            {
                Title = s.Title,
                Lat = s.Coordinate.Lat,
                Lon = s.Coordinate.Lon,
                id = s.id,
                Images = s.Images.Select(m => m.Image).FirstOrDefault(),
                Town = s.Town,
                Category = s.Category.CategoryName
            }).ToList();
            //model.ListePro = new List<ProductModel>();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> searchOfferHouseSpan_Json(string rubrique, string town, int maxPrice, string typeHouseAmmeublement, string typeHouseCuisine,
           string typeHouseDecoration, string typeHouseLinge, string fabricMaterialeHouseAmmeublementDeco, string fabricMaterialeHouseCuisine,
           string fabricMaterialeHouseLinge, string colorHouse, string stateHouse)
        {
            SeachJobViewModel model = new SeachJobViewModel();
            model.TownHouse = town;
            model.RubriqueHouse = rubrique;
            model.PriceHouse = maxPrice;
            model.TypeHouseAmmeublement = typeHouseAmmeublement;
            model.TypeHouseCuisine = typeHouseCuisine;
            model.TypeHouseDecoration = typeHouseDecoration;
            model.TypeHouseLinge = typeHouseLinge;
            model.FabricMaterialeHouseAmmeublementDeco = fabricMaterialeHouseAmmeublementDeco;
            model.FabricMaterialeHouseCuisine = fabricMaterialeHouseCuisine;
            model.FabricMaterialeHouseLinge = fabricMaterialeHouseLinge;
            model.ColorHouse = colorHouse;
            model.StateHouse = stateHouse;
            model.ColorMode = colorHouse;

            model.CagtegorieSearch = "Maison";
            model.SearchOrAskJobJob = "J'offre";




            List<HouseModel> liste = await dal.GetListHouseWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch &&
            m.SearchOrAskJob == model.SearchOrAskJobJob).ToListAsync();

            if (!string.IsNullOrWhiteSpace(model.TownHouse))
            {
                liste = liste.Where(m => m.Town == model.TownHouse).ToList();
            }
            if (!string.IsNullOrWhiteSpace(model.ColorHouse))
            {
                liste = liste.Where(m => m.ColorHouse == model.ColorHouse).ToList();
            }
            if (!string.IsNullOrWhiteSpace(model.StateHouse))
            {
                liste = liste.Where(m => m.StateHouse == model.StateHouse).ToList();
            }
            if (model.PriceHouse > 0)
            {
                liste = liste.Where(m => m.Price < model.PriceHouse).ToList();
            }
            switch (model.RubriqueHouse)
            {
                case "Ameublement":
                    liste = liste.Where(m => m.RubriqueHouse == model.RubriqueHouse).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeHouseAmmeublement))
                    {
                        liste = liste.Where(m => m.TypeHouse == model.TypeHouseAmmeublement).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.FabricMaterialeHouseAmmeublementDeco))
                    {
                        liste = liste.Where(m => m.FabricMaterialeHouse == model.FabricMaterialeHouseAmmeublementDeco).ToList();
                    }

                    break;
                case "Cuisine":
                    liste = liste.Where(m => m.RubriqueHouse == model.RubriqueHouse).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeHouseCuisine))
                    {
                        liste = liste.Where(m => m.TypeHouse == model.TypeHouseCuisine).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.FabricMaterialeHouseCuisine))
                    {
                        liste = liste.Where(m => m.FabricMaterialeHouse == model.FabricMaterialeHouseCuisine).ToList();
                    }
                    break;
                case "Décoration":
                    liste = liste.Where(m => m.RubriqueHouse == model.RubriqueHouse).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeHouseDecoration))
                    {
                        liste = liste.Where(m => m.TypeHouse == model.TypeHouseDecoration).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.FabricMaterialeHouseAmmeublementDeco))
                    {
                        liste = liste.Where(m => m.FabricMaterialeHouse == model.FabricMaterialeHouseAmmeublementDeco).ToList();
                    }

                    break;
                case "Linge de maison":

                    liste = liste.Where(m => m.RubriqueHouse == model.RubriqueHouse).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeHouseLinge))
                    {
                        liste = liste.Where(m => m.TypeHouse == model.TypeHouseLinge).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.FabricMaterialeHouseLinge))
                    {
                        liste = liste.Where(m => m.FabricMaterialeHouse == model.FabricMaterialeHouseLinge).ToList();
                    }
                    break;

            }
            var data = liste.Count();

            return Json(data, JsonRequestBehavior.AllowGet);

        }

    }
}