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
    public class VehiculeOfferSearchController : Controller
    {
        private IDal dal;
        public VehiculeOfferSearchController() : this(new Dal())
        {

        }

        public VehiculeOfferSearchController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: MultimediaOfferSearch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FilterSearchVehicule(SeachJobViewModel model)
        {

            return View(model);
        }
        public ActionResult SearchOfferVehicule_PartialView(SeachJobViewModel model)
        {
            
            return PartialView(model);
        }

       // [OutputCache(Duration = 300, VaryByParam = "TownVehicule;RubriqueVehicule;BrandVehicule;ModelVehicule;pageNumber;sortBy")]
        public async Task< ActionResult> searchOfferVehicule(SeachJobViewModel model, int? pageNumber, string sortBy)
        {
            
            ViewBag.PriceAscSort = String.IsNullOrEmpty(sortBy) ? "Price desc" : "";
            ViewBag.PriceDescSort = sortBy == "Prix croissant" ? "Price asc" : "";
            ViewBag.DateAscSort = sortBy == "Plus anciennes" ? "date asc" : "";
            ViewBag.DateDescSort = sortBy == "Plus recentes" ? "date desc" : "";

            model.CagtegorieSearch = "Vehicule";
            model.SearchOrAskJobJob = "J'offre";
            model.sortBy = sortBy;
            model.PageNumber = pageNumber;
            List<VehiculeModel> liste = await dal.GetListVehiculeWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch &&
            m.SearchOrAskJob == model.SearchOrAskJobJob).ToListAsync();

            if (!string.IsNullOrWhiteSpace(model.TownVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.RubriqueVehicule))
            {
                liste = liste.Where(m => m.TypeVehicule == model.RubriqueVehicule).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.BrandVehicule))
            {
                liste = liste.Where(m => m.BrandVehicule == model.BrandVehicule).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.ModelVehicule == model.ModelVehicule).ToList();
            }

            

            model.ListePro = new List<ProductModel>();

            model.ListeProVehicule = liste;

            switch (model.sortBy)
            {
                case "Price desc":
                    model.ListeProVehicule = model.ListeProVehicule.OrderByDescending(m => m.Price).ToList();
                    model.ListeProPagedList = model.ListeProVehicule.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "Price asc":
                    model.ListeProVehicule = model.ListeProVehicule.OrderBy(m => m.Price).ToList();
                    model.ListeProPagedList = model.ListeProVehicule.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "date desc":
                    model.ListeProVehicule = model.ListeProVehicule.OrderByDescending(m => m.DateAdd).ToList();
                    model.ListeProPagedList = model.ListeProVehicule.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "date asc":
                    model.ListeProVehicule = model.ListeProVehicule.OrderBy(m => m.DateAdd).ToList();
                    model.ListeProPagedList = model.ListeProVehicule.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                default:
                    model.ListeProVehicule = model.ListeProVehicule.OrderByDescending(x => x.DateAdd).ToList();
                    model.ListeProPagedList = model.ListeProVehicule.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
            }


            return View("FilterSearchVehicule", model);
            // return RedirectToAction("ResultSearch_PartialView", "Product", model);

        }


        public async Task< JsonResult> searchOfferVehicule_Json(string town, string rubrique, string brand, string modele)
        {
            SeachJobViewModel model = new SeachJobViewModel();
            model.TownVehicule = town;
            model.RubriqueVehicule = rubrique;
            model.BrandVehicule = brand;
            model.ModelVehicule = modele;
           
            model.CagtegorieSearch = "Vehicule";
            model.SearchOrAskJobJob = "J'offre";
            List<VehiculeModel> liste = await dal.GetListVehiculeWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch &&
            m.SearchOrAskJob == model.SearchOrAskJobJob).ToListAsync();

            if (!string.IsNullOrWhiteSpace(model.TownVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.RubriqueVehicule))
            {
                liste = liste.Where(m => m.TypeVehicule == model.RubriqueVehicule).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.BrandVehicule))
            {
                liste = liste.Where(m => m.BrandVehicule == model.BrandVehicule).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.ModelVehicule == model.ModelVehicule).ToList();
            }

            //TempData["listeVehicule_Json"] = liste;
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

        public async Task< JsonResult> searchOfferVehiculeSpan_Json(string town, string rubrique, string brand, string modele)
        {
            SeachJobViewModel model = new SeachJobViewModel();
            model.TownVehicule = town;
            model.RubriqueVehicule = rubrique;
            model.BrandVehicule = brand;
            model.ModelVehicule = modele;

            model.CagtegorieSearch = "Vehicule";
            model.SearchOrAskJobJob = "J'offre";
            List<VehiculeModel> liste = await dal.GetListVehiculeWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch &&
            m.SearchOrAskJob == model.SearchOrAskJobJob).ToListAsync();

            if (!string.IsNullOrWhiteSpace(model.TownVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.RubriqueVehicule))
            {
                liste = liste.Where(m => m.TypeVehicule == model.RubriqueVehicule).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.BrandVehicule))
            {
                liste = liste.Where(m => m.BrandVehicule == model.BrandVehicule).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.ModelVehicule == model.ModelVehicule).ToList();
            }

            var data = liste.Count();

            return Json(data, JsonRequestBehavior.AllowGet);

        }
    }
}