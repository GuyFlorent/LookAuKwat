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
    public class ApartmentRentalSearchController : Controller
    {

        private IDal dal;
        public ApartmentRentalSearchController() : this(new Dal())
        {

        }

        public ApartmentRentalSearchController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: ApartmentRentalSearch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FilterSearchAppart(SeachJobViewModel model)
        {

            return View(model);
        }

        public ActionResult SearchOfferAppart_PartialView(SeachJobViewModel model)
        {

            return PartialView(model);
        }
        
        public ActionResult searchOfferAppart(SeachJobViewModel model, int? pageNumber, string sortBy)
        {
            

            ViewBag.PriceAscSort = String.IsNullOrEmpty(sortBy) ? "Price desc" : "";
            ViewBag.PriceDescSort = sortBy == "Prix croissant" ? "Price asc" : "";
            ViewBag.DateAscSort = sortBy == "Plus anciennes" ? "date asc" : "";
            ViewBag.DateDescSort = sortBy == "Plus recentes" ? "date desc" : "";

            model.CagtegorieSearch = "Immobilier";
            model.SearchOrAskJobJob = "J'offre";
            model.sortBy = sortBy;
            model.PageNumber = pageNumber;
            List<ApartmentRentalModel> liste = dal.GetListAppartWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch && m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();

            if(!string.IsNullOrWhiteSpace( model.TownSearch))
            {
                liste = liste.Where(m => m.Town == model.TownSearch).ToList();
            }
            if (!string.IsNullOrWhiteSpace(model.Type))
            {
                liste = liste.Where(m => m.Type == model.Type).ToList();
            }
            if (model.MaxApartSurface > 0 && model.MinApartSurface >= 0 && model.MaxApartSurface > model.MinApartSurface)
            {
                liste = liste.Where(m => m.ApartSurface <= model.MaxApartSurface && m.ApartSurface >= model.MinApartSurface).ToList();
            }
            else if(model.MinApartSurface >= 0)
            {
                liste = liste.Where(m => m.ApartSurface >= model.MinApartSurface).ToList();
            }
            else if (model.MaxApartSurface > 0)
            {
                liste = liste.Where(m => m.ApartSurface <= model.MaxApartSurface).ToList();
            }

            if (model.PriceMaxSearch > 0 && model.PriceMinSearch >= 0 && model.PriceMinSearch > model.PriceMinSearch)
            {
                liste = liste.Where(m => m.Price <= model.PriceMaxSearch && m.Price >= model.PriceMinSearch).ToList();
            }
            else if (model.PriceMinSearch >= 0)
            {
                liste = liste.Where(m => m.Price >= model.PriceMinSearch).ToList();
            }
            else if (model.PriceMaxSearch > 0)
            {
                liste = liste.Where(m => m.Price <= model.PriceMaxSearch).ToList();
            }

            if(model.Type != "Terrain à vendre")
            {
                if(model.RoomNumber > 0)
                {
                    liste = liste.Where(m => m.RoomNumber == model.RoomNumber).ToList();
                }
                if (model.FurnitureOrNot != null)
                {
                    liste = liste.Where(m => m.FurnitureOrNot != model.FurnitureOrNot).ToList();
                }
            }



            model.ListePro = new List<ProductModel>();

            model.ListeProAppart =liste;

            switch (model.sortBy)
            {
                case "Price desc":
                    model.ListeProAppart = model.ListeProAppart.OrderByDescending(m => m.Price).ToList();
                    model.ListeProPagedList = model.ListeProAppart.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "Price asc":
                    model.ListeProAppart = model.ListeProAppart.OrderBy(m => m.Price).ToList();
                    model.ListeProPagedList = model.ListeProAppart.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "date desc":
                    model.ListeProAppart = model.ListeProAppart.OrderByDescending(m => m.id).ToList();
                    model.ListeProPagedList = model.ListeProAppart.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "date asc":
                    model.ListeProAppart = model.ListeProAppart.OrderBy(m => m.id).ToList();
                    model.ListeProPagedList = model.ListeProAppart.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                default:
                    model.ListeProAppart = model.ListeProAppart.OrderByDescending(x => x.id).ToList();
                    model.ListeProPagedList = model.ListeProAppart.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
            }


            return View("FilterSearchAppart", model);
            // return RedirectToAction("ResultSearch_PartialView", "Product", model);
        }


        public ActionResult ResultSearchOfferApart_Jason(string type, string town, int minSurface, int maxSurface, string furnitureOrNot, int roomNumber, int minPrice, int maxPrice)
        {
            
            SeachJobViewModel model = new SeachJobViewModel();
            model.Type = type;
            model.TownSearch = town;
            model.MinApartSurface = minSurface;
            model.MaxApartSurface = maxSurface;
            model.PriceMinSearch = minPrice;
            model.PriceMaxSearch = maxPrice;
            model.FurnitureOrNot = furnitureOrNot;
            model.RoomNumber = roomNumber;
            model.CagtegorieSearch = "Immobilier";
            model.SearchOrAskJobJob = "J'offre";
            List<ApartmentRentalModel> liste = dal.GetListAppartWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch && m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();

            if (!string.IsNullOrWhiteSpace(model.TownSearch))
            {
                liste = liste.Where(m => m.Town == model.TownSearch).ToList();
            }
            if (!string.IsNullOrWhiteSpace(model.Type))
            {
                liste = liste.Where(m => m.Type == model.Type).ToList();
            }
            if (model.MaxApartSurface > 0 && model.MinApartSurface >= 0 && model.MaxApartSurface > model.MinApartSurface)
            {
                liste = liste.Where(m => m.ApartSurface <= model.MaxApartSurface && m.ApartSurface >= model.MinApartSurface).ToList();
            }
            else if (model.MinApartSurface >= 0)
            {
                liste = liste.Where(m => m.ApartSurface >= model.MinApartSurface).ToList();
            }
            else if (model.MaxApartSurface > 0)
            {
                liste = liste.Where(m => m.ApartSurface <= model.MaxApartSurface).ToList();
            }

            if (model.PriceMaxSearch > 0 && model.PriceMinSearch >= 0 && model.PriceMinSearch > model.PriceMinSearch)
            {
                liste = liste.Where(m => m.Price <= model.PriceMaxSearch && m.Price >= model.PriceMinSearch).ToList();
            }
            else if (model.PriceMinSearch >= 0)
            {
                liste = liste.Where(m => m.Price >= model.PriceMinSearch).ToList();
            }
            else if (model.PriceMaxSearch > 0)
            {
                liste = liste.Where(m => m.Price <= model.PriceMaxSearch).ToList();
            }

            if (model.Type != "Terrain à vendre")
            {
                if (model.RoomNumber > 0)
                {
                    liste = liste.Where(m => m.RoomNumber == model.RoomNumber).ToList();
                }
                if (model.FurnitureOrNot != null)
                {
                    liste = liste.Where(m => m.FurnitureOrNot != model.FurnitureOrNot).ToList();
                }
            }

            TempData["listeApartJson"] = liste;
            model.ListePro = new List<ProductModel>();
            return RedirectToAction("ResultSearchJson", "Product", model);

        }

        public JsonResult ResultSearchOfferApartSpan_Jason(string type, string town, int minSurface, int maxSurface, string furnitureOrNot, int roomNumber, int minPrice, int maxPrice)
        {

            SeachJobViewModel model = new SeachJobViewModel();
            model.Type = type;
            model.TownSearch = town;
            model.MinApartSurface = minSurface;
            model.MaxApartSurface = maxSurface;
            model.PriceMinSearch = minPrice;
            model.PriceMaxSearch = maxPrice;
            model.FurnitureOrNot = furnitureOrNot;
            model.RoomNumber = roomNumber;
            model.CagtegorieSearch = "Immobilier";
            model.SearchOrAskJobJob = "J'offre";
            List<ApartmentRentalModel> liste = dal.GetListAppartWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch && m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();

            if (!string.IsNullOrWhiteSpace(model.TownSearch))
            {
                liste = liste.Where(m => m.Town == model.TownSearch).ToList();
            }
            if (!string.IsNullOrWhiteSpace(model.Type))
            {
                liste = liste.Where(m => m.Type == model.Type).ToList();
            }
            if (model.MaxApartSurface > 0 && model.MinApartSurface >= 0 && model.MaxApartSurface > model.MinApartSurface)
            {
                liste = liste.Where(m => m.ApartSurface <= model.MaxApartSurface && m.ApartSurface >= model.MinApartSurface).ToList();
            }
            else if (model.MinApartSurface >= 0)
            {
                liste = liste.Where(m => m.ApartSurface >= model.MinApartSurface).ToList();
            }
            else if (model.MaxApartSurface > 0)
            {
                liste = liste.Where(m => m.ApartSurface <= model.MaxApartSurface).ToList();
            }

            if (model.PriceMaxSearch > 0 && model.PriceMinSearch >= 0 && model.PriceMinSearch > model.PriceMinSearch)
            {
                liste = liste.Where(m => m.Price <= model.PriceMaxSearch && m.Price >= model.PriceMinSearch).ToList();
            }
            else if (model.PriceMinSearch >= 0)
            {
                liste = liste.Where(m => m.Price >= model.PriceMinSearch).ToList();
            }
            else if (model.PriceMaxSearch > 0)
            {
                liste = liste.Where(m => m.Price <= model.PriceMaxSearch).ToList();
            }

            if (model.Type != "Terrain à vendre")
            {
                if (model.RoomNumber > 0)
                {
                    liste = liste.Where(m => m.RoomNumber == model.RoomNumber).ToList();
                }
                if (model.FurnitureOrNot != null)
                {
                    liste = liste.Where(m => m.FurnitureOrNot != model.FurnitureOrNot).ToList();
                }
            }

            var data = liste.Count();

            return Json(data, JsonRequestBehavior.AllowGet);

        }
    }
}