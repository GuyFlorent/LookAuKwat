using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult searchOfferMode(SeachJobViewModel model, int? pageNumber, string sortBy)
        {
            ////save same page when refresh page in ajax
            //if (pageNumber != null)
            //{
            //    this.Session["pageMode"] = pageNumber;
            //    if (model != null)
            //        if (model.PriceMode == 0)
            //        {
            //            model.PriceMode = 1000000000;
            //        }

            //    this.Session["modelMode"] = model;
            //    var modell = this.Session["modelModeNewModel"] as SeachJobViewModel;
            //    if (modell != null)
            //        model = modell;
            //    model.PageNumber = pageNumber;
            //}
            //else if (pageNumber == null)
            //{
            //    var mod = this.Session["modelMode"] as SeachJobViewModel;
            //    if (mod != null && mod.TownMode == model.TownMode && mod.RubriqueMode == model.RubriqueMode &&
            //        mod.TypeModeClothes == model.TypeModeClothes && mod.TypeModeShoes == model.TypeModeShoes &&
            //        mod.TypeModeWatchJewelry == model.TypeModeWatchJewelry && mod.TypeModeBabyEquipment == model.TypeModeBabyEquipment
            //        && mod.TypeModeBabyClothes == model.TypeModeBabyClothes && mod.BrandModeClothes == model.BrandModeClothes
            //        && mod.BrandModeShoes == model.BrandModeShoes && mod.SizeModeClothes == model.SizeModeClothes
            //        && mod.SizeModeShoes == model.SizeModeShoes && mod.PriceMode == model.PriceMode && mod.StateMode == model.StateMode
            //        && mod.ColorMode == model.ColorMode)
            //    {
            //        var page = this.Session["pageMode"] as int?;
            //        var modell = this.Session["modelModeNewModel"] as SeachJobViewModel;
            //        if (modell != null)
            //            model = modell;
            //        model.PageNumber = page;
            //    }
            //    else if (mod != null && (mod.TownMode != model.TownMode || mod.RubriqueMode != model.RubriqueMode ||
            //        mod.TypeModeClothes != model.TypeModeClothes || mod.TypeModeShoes != model.TypeModeShoes ||
            //        mod.TypeModeWatchJewelry != model.TypeModeWatchJewelry || mod.TypeModeBabyEquipment != model.TypeModeBabyEquipment
            //        || mod.TypeModeBabyClothes != model.TypeModeBabyClothes || mod.BrandModeClothes != model.BrandModeClothes
            //        || mod.BrandModeShoes != model.BrandModeShoes || mod.SizeModeClothes != model.SizeModeClothes
            //        || mod.SizeModeShoes != model.SizeModeShoes || mod.PriceMode != model.PriceMode || mod.StateMode != model.StateMode
            //        || mod.ColorMode != model.ColorMode))
            //    {
            //        this.Session["modelModeNewModel"] = model;
            //        model.PageNumber = pageNumber;
            //    }

            //}
            ViewBag.PriceAscSort = String.IsNullOrEmpty(sortBy) ? "Price desc" : "";
            ViewBag.PriceDescSort = sortBy == "Prix croissant" ? "Price asc" : "";
            ViewBag.DateAscSort = sortBy == "Plus anciennes" ? "date asc" : "";
            ViewBag.DateDescSort = sortBy == "Plus recentes" ? "date desc" : "";

            model.CagtegorieSearch = "Mode";
            model.SearchOrAskJobJob = "J'offre";
            model.sortBy = sortBy;
            model.PageNumber = pageNumber;
            
            List<ModeModel> liste = dal.GetListMode().Where(m => m.Category.CategoryName == model.CagtegorieSearch &&
            m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();
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
            TempData["listeMode"] = liste;

            model.ListePro = new List<ProductModel>();

            model.ListeProMode = TempData["listeMode"] as List<ModeModel>;

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


        public ActionResult searchOfferMode_Json(string rubrique, string town, string typeClothes, string typeShoes, string typeLuggages,
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
           


            List<ModeModel> liste = dal.GetListMode().Where(m => m.Category.CategoryName == model.CagtegorieSearch &&
            m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();
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
            TempData["listeMode_json"] = liste;



            model.ListePro = new List<ProductModel>();
            return RedirectToAction("ResultSearchJson", "Product", model);

        }
    }
    }