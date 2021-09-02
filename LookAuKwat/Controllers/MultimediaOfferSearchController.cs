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
    public class MultimediaOfferSearchController : Controller
    {

        private IDal dal;
        public MultimediaOfferSearchController() : this(new Dal())
        {

        }

        public MultimediaOfferSearchController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: MultimediaOfferSearch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FilterSearchMultimedia(SeachJobViewModel model)
        {

            return View(model);
        }

        public ActionResult SearchOfferMultimedia_PartialView(SeachJobViewModel model)
        {
            model.PriceMultimedia = 1000000000;
            return PartialView(model);
        }

        //[OutputCache(Duration = 300, VaryByParam = "TownMultimedia;TypeMultimedia;BrandMultimedia;ModelMultimedia;Capacity;PriceMultimedia;pageNumber;sortBy")]
        public async Task< ActionResult> searchOfferMultimedia(SeachJobViewModel model, int? pageNumber, string sortBy)
        {

           
            ViewBag.PriceAscSort = String.IsNullOrEmpty(sortBy) ? "Price desc" : "";
            ViewBag.PriceDescSort = sortBy == "Prix croissant" ? "Price asc" : "";
            ViewBag.DateAscSort = sortBy == "Plus anciennes" ? "date asc" : "";
            ViewBag.DateDescSort = sortBy == "Plus recentes" ? "date desc" : "";

            model.CagtegorieSearch = "Multimedia";
            model.SearchOrAskJobJob = "J'offre";
            model.sortBy = sortBy;
            model.PageNumber = pageNumber;

            List<MultimediaModel> liste = await dal.GetListMultimediaWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch && 
            m.SearchOrAskJob == model.SearchOrAskJobJob).ToListAsync();

            if (!string.IsNullOrWhiteSpace(model.TownMultimedia))
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.TypeMultimedia))
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.BrandMultimedia))
            {
                liste = liste.Where(m => m.Brand == model.BrandMultimedia).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.ModelMultimedia))
            {
                liste = liste.Where(m => m.Model == model.ModelMultimedia).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.Capacity))
            {
                liste = liste.Where(m => m.Capacity == model.Capacity).ToList();
            }

            if (model.PriceMultimedia >  0)
            {
                liste = liste.Where(m => m.Price < model.PriceMultimedia).ToList();
            }

           

            model.ListePro = new List<ProductModel>();

            model.ListeProMulti = liste;

            switch (model.sortBy)
            {
                case "Price desc":
                    model.ListeProMulti = model.ListeProMulti.OrderByDescending(m => m.Price).ToList();
                    model.ListeProPagedList = model.ListeProMulti.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "Price asc":
                    model.ListeProMulti = model.ListeProMulti.OrderBy(m => m.Price).ToList();
                    model.ListeProPagedList = model.ListeProMulti.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "date desc":
                    model.ListeProMulti = model.ListeProMulti.OrderByDescending(m => m.DateAdd).ToList();
                    model.ListeProPagedList = model.ListeProMulti.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "date asc":
                    model.ListeProMulti = model.ListeProMulti.OrderBy(m => m.DateAdd).ToList();
                    model.ListeProPagedList = model.ListeProMulti.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                default:
                    model.ListeProMulti = model.ListeProMulti.OrderByDescending(x => x.DateAdd).ToList();
                    model.ListeProPagedList = model.ListeProMulti.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
            }


            return View("FilterSearchMultimedia", model);

            // return RedirectToAction("ResultSearch_PartialView", "Product", model);

        }

        public async Task<JsonResult> ResultSearchOfferMultimedia_Jason(string town, string type,string brand,string modele,string capacity, int maxPrice)
        {
            SeachJobViewModel model = new SeachJobViewModel();
            model.TypeMultimedia = type;
            model.TownMultimedia = town;
            model.BrandMultimedia = brand;
            model.ModelMultimedia = modele;
            model.PriceMultimedia = maxPrice;
            model.Capacity = capacity;
            model.CagtegorieSearch = "Multimedia";
            model.SearchOrAskJobJob = "J'offre";
            List<MultimediaModel> liste = await dal.GetListMultimediaWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch && m.SearchOrAskJob == model.SearchOrAskJobJob).ToListAsync();

            if (!string.IsNullOrWhiteSpace(model.TownMultimedia))
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.TypeMultimedia))
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.BrandMultimedia))
            {
                liste = liste.Where(m => m.Brand == model.BrandMultimedia).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.ModelMultimedia))
            {
                liste = liste.Where(m => m.Model == model.ModelMultimedia).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.Capacity))
            {
                liste = liste.Where(m => m.Capacity == model.Capacity).ToList();
            }

            if (model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Price < model.PriceMultimedia).ToList();
            }


            // TempData["listeMulti_Json"] = liste;
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

        public async Task< JsonResult> ResultSearchOfferMultimediaSpan_Jason(string town, string type, string brand, string modele, string capacity, int maxPrice)
        {
            SeachJobViewModel model = new SeachJobViewModel();
            model.TypeMultimedia = type;
            model.TownMultimedia = town;
            model.BrandMultimedia = brand;
            model.ModelMultimedia = modele;
            model.PriceMultimedia = maxPrice;
            model.Capacity = capacity;
            model.CagtegorieSearch = "Multimedia";
            model.SearchOrAskJobJob = "J'offre";
            List<MultimediaModel> liste = await dal.GetListMultimediaWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch && m.SearchOrAskJob == model.SearchOrAskJobJob).ToListAsync();

            if (!string.IsNullOrWhiteSpace(model.TownMultimedia))
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.TypeMultimedia))
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.BrandMultimedia))
            {
                liste = liste.Where(m => m.Brand == model.BrandMultimedia).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.ModelMultimedia))
            {
                liste = liste.Where(m => m.Model == model.ModelMultimedia).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.Capacity))
            {
                liste = liste.Where(m => m.Capacity == model.Capacity).ToList();
            }

            if (model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Price < model.PriceMultimedia).ToList();
            }


            var data = liste.Count();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
    }