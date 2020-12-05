using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LookAuKwat.Controllers
{
    public class JobOfferSearchController : Controller
    {
        private IDal dal;
        public JobOfferSearchController() : this(new Dal())
        {

        }

        public JobOfferSearchController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: JobOfferSearch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FilterSearchJob(SeachJobViewModel model)
        {

            return View(model);
        }

        public ActionResult SearchOfferJob_PartialView(SeachJobViewModel model)
        {
            
            return PartialView(model);
        }
      
        public ActionResult ResultSearchOfferJob_PartialView(SeachJobViewModel model, int? pageNumber, string sortBy)
        {

            ViewBag.PriceAscSort = String.IsNullOrEmpty(sortBy) ? "Price desc" : "";
            ViewBag.PriceDescSort = sortBy == "Prix croissant" ? "Price asc" : "";
            ViewBag.DateAscSort = sortBy == "Plus anciennes" ? "date asc" : "";
            ViewBag.DateDescSort = sortBy == "Plus recentes" ? "date desc" : "";

            model.CagtegorieSearch = "Emploi";
            model.SearchOrAskJobJob = "J'offre";
            model.sortBy = sortBy;
            model.PageNumber = pageNumber;


            List<JobModel> liste = dal.GetListJobWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch && m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();

            if (!string.IsNullOrWhiteSpace(model.TownSearch))
            {
                liste = liste.Where(m => m.Town == model.TownSearch).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.TypeContractJob))
            {
                liste = liste.Where(m =>m.TypeContract!=null && m.TypeContract == model.TypeContractJob).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                liste = liste.Where(m =>m.ActivitySector!= null && m.ActivitySector == model.ActivitySectorJob).ToList();
            }

            if(model.PriceMaxSearch >= 0 && model.PriceMinSearch >= 0 && model.PriceMaxSearch > model.PriceMinSearch)
            {
                liste = liste.Where(m => m.Price >= model.PriceMinSearch && m.Price <= model.PriceMaxSearch).ToList();
            }else if (model.PriceMinSearch >= 0)
            {
                liste = liste.Where(m => m.Price >= model.PriceMinSearch).ToList();
            } else if (model.PriceMaxSearch >= 0)
            {
                liste = liste.Where(m => m.Price <= model.PriceMaxSearch).ToList();
            }



                model.ListePro = new List<ProductModel>();

            model.ListeProJob = liste;

            switch (model.sortBy)
            {
                case "Price desc":
                    model.ListeProJob = model.ListeProJob.OrderByDescending(m => m.Price).ToList();
                    model.ListeProPagedList = model.ListePro.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "Price asc":
                    model.ListeProJob = model.ListeProJob.OrderBy(m => m.Price).ToList();
                    model.ListeProPagedList = model.ListePro.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "date desc":
                    model.ListeProJob = model.ListeProJob.OrderByDescending(m => m.id).ToList();
                    model.ListeProPagedList = model.ListePro.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                case "date asc":
                    model.ListeProJob = model.ListeProJob.OrderBy(m => m.id).ToList();
                    model.ListeProPagedList = model.ListePro.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
                default:
                    model.ListeProJob = model.ListeProJob.OrderByDescending(x => x.id).ToList();
                    model.ListeProPagedList = model.ListeProJob.ToPagedList(model.PageNumber ?? 1, 10);
                    break;
            }

            foreach (var mode in model.ListeProPagedList)
            {
                if (mode.Images.Count > 1)
                {
                    mode.Images = mode.Images.Where(m => !m.Image.StartsWith("http")).ToList();
                }
            }

            return View("FilterSearchJob", model);

        }




        public ActionResult ResultSearchOfferJob_Jason(string sector, string town, string contract, int minPrice, int maxPrice)
       {
            SeachJobViewModel model = new SeachJobViewModel();
            model.ActivitySectorJob = sector;
            model.TownSearch = town;
            model.TypeContractJob = contract;
            model.PriceMinSearch = minPrice;
            model.PriceMaxSearch = maxPrice;
            model.CagtegorieSearch = "Emploi";
            model.SearchOrAskJobJob = "J'offre";
            List<JobModel> liste = dal.GetListJobWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch && m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();

            if (!string.IsNullOrWhiteSpace(model.TownSearch))
            {
                liste = liste.Where(m => m.Town == model.TownSearch).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.TypeContractJob))
            {
                liste = liste.Where(m => m.TypeContract != null && m.TypeContract == model.TypeContractJob).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                liste = liste.Where(m => m.ActivitySector != null && m.ActivitySector == model.ActivitySectorJob).ToList();
            }

            if (model.PriceMaxSearch >= 0 && model.PriceMinSearch >= 0 && model.PriceMaxSearch > model.PriceMinSearch)
            {
                liste = liste.Where(m => m.Price >= model.PriceMinSearch && m.Price <= model.PriceMaxSearch).ToList();
            }
            else if (model.PriceMinSearch >= 0)
            {
                liste = liste.Where(m => m.Price >= model.PriceMinSearch).ToList();
            }
            else if (model.PriceMaxSearch >= 0)
            {
                liste = liste.Where(m => m.Price <= model.PriceMaxSearch).ToList();
            }

   
            TempData["listeJobJson"] = liste;
            model.ListePro = new List<ProductModel>();
            return RedirectToAction("ResultSearchJson", "Product", model);
        }
        public JsonResult ResultJobSpan_Jason(string sector, string town, string contract, int minPrice, int maxPrice)
        {
            SeachJobViewModel model = new SeachJobViewModel();
            model.ActivitySectorJob = sector;
            model.TownSearch = town;
            model.TypeContractJob = contract;
            model.PriceMinSearch = minPrice;
            model.PriceMaxSearch = maxPrice;
            model.CagtegorieSearch = "Emploi";
            model.SearchOrAskJobJob = "J'offre";
            List<JobModel> liste = dal.GetListJobWithNoInclude().Where(m => m.Category.CategoryName == model.CagtegorieSearch && m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();

            if (!string.IsNullOrWhiteSpace(model.TownSearch))
            {
                liste = liste.Where(m => m.Town == model.TownSearch).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.TypeContractJob))
            {
                liste = liste.Where(m => m.TypeContract != null && m.TypeContract == model.TypeContractJob).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                liste = liste.Where(m => m.ActivitySector != null && m.ActivitySector == model.ActivitySectorJob).ToList();
            }

            if (model.PriceMaxSearch >= 0 && model.PriceMinSearch >= 0 && model.PriceMaxSearch > model.PriceMinSearch)
            {
                liste = liste.Where(m => m.Price >= model.PriceMinSearch && m.Price <= model.PriceMaxSearch).ToList();
            }
            else if (model.PriceMinSearch >= 0)
            {
                liste = liste.Where(m => m.Price >= model.PriceMinSearch).ToList();
            }
            else if (model.PriceMaxSearch >= 0)
            {
                liste = liste.Where(m => m.Price <= model.PriceMaxSearch).ToList();
            }

            var data = liste.Count();
           return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}




