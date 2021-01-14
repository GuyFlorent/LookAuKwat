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

namespace LookAuKwat.Controllers
{
    public class ModeOfferSearchController : Controller
    {
        private IDal dal;
        public ModeOfferSearchController() : this(new Dal())
        {

        }

        public ModeOfferSearchController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: MultimediaOfferSearch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FilterSearchMode(SeachJobViewModel model)
        {

            return View(model);
        }

        public ActionResult SearchOfferMode_PartialView(SeachJobViewModel model)
        {
            model.PriceMode = 1000000000;
            return PartialView(model);
        }

      //  [OutputCache(Duration = 300, VaryByParam = "TownMode;ColorMode;StateMode;PriceMode;RubriqueMode;pageNumber;sortBy")]
        public async Task< ActionResult> searchOfferMode(SeachJobViewModel model, int? pageNumber, string sortBy)
        {
            ViewBag.PriceAscSort = String.IsNullOrEmpty(sortBy) ? "Price desc" : "";
            ViewBag.PriceDescSort = sortBy == "Prix croissant" ? "Price asc" : "";
            ViewBag.DateAscSort = sortBy == "Plus anciennes" ? "date asc" : "";
            ViewBag.DateDescSort = sortBy == "Plus recentes" ? "date desc" : "";

            model.CagtegorieSearch = "Mode";
            model.SearchOrAskJobJob = "J'offre";
            model.sortBy = sortBy;
            model.PageNumber = pageNumber;
            
            List<ModeModel> liste = await dal.GetListModeWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch &&
            m.SearchOrAskJob == model.SearchOrAskJobJob).ToListAsync();
            if (!string.IsNullOrWhiteSpace(model.TownMode))
            {
                liste = liste.Where(m => m.Town == model.TownMode).ToList();
            }
            if (!string.IsNullOrWhiteSpace(model.ColorMode))
            {
                liste = liste.Where(m => m.ColorMode == model.ColorMode).ToList();
            }
            if (!string.IsNullOrWhiteSpace(model.StateMode))
            {
                liste = liste.Where(m => m.StateMode == model.StateMode).ToList();
            }
            if (model.PriceMode> 0)
            {
                liste = liste.Where(m => m.Price < model.PriceMode).ToList();
            }
            switch (model.RubriqueMode)
            {
                case "Vêtements":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeClothes))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeClothes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeClothes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeClothes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.SizeModeClothes))
                    {
                        liste = liste.Where(m => m.SizeMode == model.SizeModeClothes).ToList();
                    }
                    break;
                case "Chaussures":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeShoes))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeShoes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeShoes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeShoes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.SizeModeShoes))
                    {
                        liste = liste.Where(m => m.SizeMode == model.SizeModeShoes).ToList();
                    }
                    break;
                case "Accesoires & Bagagerie":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeAccesorieLugages))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeAccesorieLugages).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeClothes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeClothes).ToList();
                    }
                    
                    break;
                case "Montres & Bijoux":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeWatchJewelry))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeWatchJewelry).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeClothes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeClothes).ToList();
                    }

                    break;
                case "Equipement bébé":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeBabyEquipment))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeBabyEquipment).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeClothes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeClothes).ToList();
                    }

                    break;
                case "Vêtements bébé":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeBabyClothes))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeBabyClothes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeClothes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeClothes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.SizeModeClothes))
                    {
                        liste = liste.Where(m => m.SizeMode == model.SizeModeClothes).ToList();
                    }
                    break;
            }
           // TempData["listeMode"] = liste;

            model.ListePro = new List<ProductModel>();

            model.ListeProMode = liste;

            switch (model.sortBy)
            {
                case "Price desc":
                    model.ListeProMode = model.ListeProMode.OrderByDescending(m => m.Price).ToList();
                    model.ListeProPagedList = model.ListeProMode.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "Price asc":
                    model.ListeProMode = model.ListeProMode.OrderBy(m => m.Price).ToList();
                    model.ListeProPagedList = model.ListeProMode.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "date desc":
                    model.ListeProMode = model.ListeProMode.OrderByDescending(m => m.id).ToList();
                    model.ListeProPagedList = model.ListeProMode.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "date asc":
                    model.ListeProMode = model.ListeProMode.OrderBy(m => m.id).ToList();
                    model.ListeProPagedList = model.ListeProMode.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                default:
                    model.ListeProMode = model.ListeProMode.OrderByDescending(x => x.id).ToList();
                    model.ListeProPagedList = model.ListeProMode.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
            }


            return View("FilterSearchMode", model);
            // return RedirectToAction("ResultSearch_PartialView", "Product", model);

        }


        public async Task< JsonResult> searchOfferMode_Json(string rubrique, string town, string typeClothes, string typeShoes, string typeLuggages,
            string typeWatch, string typeBabyEquipment, string typeBabyClothes, string brandClothes, string brandShoes, int price,
            string state, string color, string univers, string sizeSchoes, string sizeClothes)
        {
            SeachJobViewModel model = new SeachJobViewModel();
            model.TownMode = town;
            model.RubriqueMode = rubrique;
            model.TypeModeClothes = typeClothes;
            model.TypeModeShoes = typeShoes;
            model.TypeModeAccesorieLugages = typeLuggages;
            model.TypeModeWatchJewelry = typeWatch;
            model.TypeModeBabyEquipment = typeBabyEquipment;
            model.TypeModeBabyClothes = typeBabyClothes;
            model.BrandModeClothes = brandClothes;
            model.BrandModeShoes = brandShoes;
            model.PriceMode = price;
            model.StateMode = state;
            model.ColorMode = color;
            model.UniversMode = univers;
            model.SizeModeClothes = sizeClothes;
            model.SizeModeShoes = sizeSchoes;

            model.CagtegorieSearch = "Mode";
            model.SearchOrAskJobJob = "J'offre";
           


            List<ModeModel> liste = await dal.GetListModeWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch &&
            m.SearchOrAskJob == model.SearchOrAskJobJob).ToListAsync();
            if (!string.IsNullOrWhiteSpace(model.TownMode))
            {
                liste = liste.Where(m => m.Town == model.TownMode).ToList();
            }
            if (!string.IsNullOrWhiteSpace(model.ColorMode))
            {
                liste = liste.Where(m => m.ColorMode == model.ColorMode).ToList();
            }
            if (!string.IsNullOrWhiteSpace(model.StateMode))
            {
                liste = liste.Where(m => m.StateMode == model.StateMode).ToList();
            }
            if (model.PriceMode > 0)
            {
                liste = liste.Where(m => m.Price < model.PriceMode).ToList();
            }
            switch (model.RubriqueMode)
            {
                case "Vêtements":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeClothes))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeClothes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeClothes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeClothes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.SizeModeClothes))
                    {
                        liste = liste.Where(m => m.SizeMode == model.SizeModeClothes).ToList();
                    }
                    break;
                case "Chaussures":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeShoes))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeShoes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeShoes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeShoes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.SizeModeShoes))
                    {
                        liste = liste.Where(m => m.SizeMode == model.SizeModeShoes).ToList();
                    }
                    break;
                case "Accesoires & Bagagerie":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeAccesorieLugages))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeAccesorieLugages).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeClothes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeClothes).ToList();
                    }

                    break;
                case "Montres & Bijoux":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeWatchJewelry))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeWatchJewelry).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeClothes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeClothes).ToList();
                    }

                    break;
                case "Equipement bébé":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeBabyEquipment))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeBabyEquipment).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeClothes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeClothes).ToList();
                    }

                    break;
                case "Vêtements bébé":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeBabyClothes))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeBabyClothes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeClothes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeClothes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.SizeModeClothes))
                    {
                        liste = liste.Where(m => m.SizeMode == model.SizeModeClothes).ToList();
                    }
                    break;
            }
            // TempData["listeMode_json"] = liste;


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

        public async Task< JsonResult> searchOfferModeSpan_Json(string rubrique, string town, string typeClothes, string typeShoes, string typeLuggages,
      string typeWatch, string typeBabyEquipment, string typeBabyClothes, string brandClothes, string brandShoes, int price,
      string state, string color, string univers, string sizeSchoes, string sizeClothes)
        {
            SeachJobViewModel model = new SeachJobViewModel();
            model.TownMode = town;
            model.RubriqueMode = rubrique;
            model.TypeModeClothes = typeClothes;
            model.TypeModeShoes = typeShoes;
            model.TypeModeAccesorieLugages = typeLuggages;
            model.TypeModeWatchJewelry = typeWatch;
            model.TypeModeBabyEquipment = typeBabyEquipment;
            model.TypeModeBabyClothes = typeBabyClothes;
            model.BrandModeClothes = brandClothes;
            model.BrandModeShoes = brandShoes;
            model.PriceMode = price;
            model.StateMode = state;
            model.ColorMode = color;
            model.UniversMode = univers;
            model.SizeModeClothes = sizeClothes;
            model.SizeModeShoes = sizeSchoes;

            model.CagtegorieSearch = "Mode";
            model.SearchOrAskJobJob = "J'offre";



            List<ModeModel> liste = await dal.GetListModeWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch &&
            m.SearchOrAskJob == model.SearchOrAskJobJob).ToListAsync();
            if (!string.IsNullOrWhiteSpace(model.TownMode))
            {
                liste = liste.Where(m => m.Town == model.TownMode).ToList();
            }
            if (!string.IsNullOrWhiteSpace(model.ColorMode))
            {
                liste = liste.Where(m => m.ColorMode == model.ColorMode).ToList();
            }
            if (!string.IsNullOrWhiteSpace(model.StateMode))
            {
                liste = liste.Where(m => m.StateMode == model.StateMode).ToList();
            }
            if (model.PriceMode > 0)
            {
                liste = liste.Where(m => m.Price < model.PriceMode).ToList();
            }
            switch (model.RubriqueMode)
            {
                case "Vêtements":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeClothes))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeClothes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeClothes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeClothes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.SizeModeClothes))
                    {
                        liste = liste.Where(m => m.SizeMode == model.SizeModeClothes).ToList();
                    }
                    break;
                case "Chaussures":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeShoes))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeShoes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeShoes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeShoes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.SizeModeShoes))
                    {
                        liste = liste.Where(m => m.SizeMode == model.SizeModeShoes).ToList();
                    }
                    break;
                case "Accesoires & Bagagerie":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeAccesorieLugages))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeAccesorieLugages).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeClothes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeClothes).ToList();
                    }

                    break;
                case "Montres & Bijoux":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeWatchJewelry))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeWatchJewelry).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeClothes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeClothes).ToList();
                    }

                    break;
                case "Equipement bébé":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeBabyEquipment))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeBabyEquipment).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeClothes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeClothes).ToList();
                    }

                    break;
                case "Vêtements bébé":
                    liste = liste.Where(m => m.RubriqueMode == model.RubriqueMode).ToList();
                    if (!string.IsNullOrWhiteSpace(model.TypeModeBabyClothes))
                    {
                        liste = liste.Where(m => m.TypeMode == model.TypeModeBabyClothes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.BrandModeClothes))
                    {
                        liste = liste.Where(m => m.BrandMode == model.BrandModeClothes).ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(model.SizeModeClothes))
                    {
                        liste = liste.Where(m => m.SizeMode == model.SizeModeClothes).ToList();
                    }
                    break;
            }

            var data = liste.Count();

            return Json(data, JsonRequestBehavior.AllowGet);

        }
    }
    }