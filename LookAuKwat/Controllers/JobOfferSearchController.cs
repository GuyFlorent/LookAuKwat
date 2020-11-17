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

            ////save same page when refresh page in ajax
            //if (pageNumber != null)
            //{
            //    this.Session["pageJob"] = pageNumber;

            //    this.Session["modelJob"] = model;
            //    var modell = this.Session["modelJobNew"] as SeachJobViewModel;
            //    if (modell != null)
            //        model = modell;
            //    model.PageNumber = pageNumber;
            //}
            //else if (pageNumber == null)
            //{
            //    var mod = this.Session["modelJob"] as SeachJobViewModel;
            //    if (mod != null && mod.PriceMinSearch == model.PriceMinSearch && mod.PriceMaxSearch == model.PriceMaxSearch &&
            //        mod.TownSearch == model.TownSearch && mod.TypeContractJob == model.TypeContractJob &&
            //        mod.ActivitySectorJob == model.ActivitySectorJob)
            //    {
            //        var page = this.Session["pageJob"] as int?;
            //        var modell = this.Session["modelJobNew"] as SeachJobViewModel;
            //        if (modell != null)
            //            model = modell;
            //        model.PageNumber = page;
            //    }
            //    else if (mod != null && (mod.PriceMinSearch != model.PriceMinSearch || mod.PriceMaxSearch != model.PriceMaxSearch ||
            //      mod.TownSearch != model.TownSearch || mod.TypeContractJob != model.TypeContractJob ||
            //      mod.ActivitySectorJob != model.ActivitySectorJob ))
            //    {
            //        this.Session["modelJobNew"] = model;
            //        model.PageNumber = pageNumber;
            //    }

            //}
            ViewBag.PriceAscSort = String.IsNullOrEmpty(sortBy) ? "Price desc" : "";
            ViewBag.PriceDescSort = sortBy == "Prix croissant" ? "Price asc" : "";
            ViewBag.DateAscSort = sortBy == "Plus anciennes" ? "date asc" : "";
            ViewBag.DateDescSort = sortBy == "Plus recentes" ? "date desc" : "";

            model.CagtegorieSearch = "Emploi";
            model.SearchOrAskJobJob = "J'offre";
            model.sortBy = sortBy;
            model.PageNumber = pageNumber;


            List<JobModel> liste = dal.GetListJob().Where(m => m.Category.CategoryName == model.CagtegorieSearch && m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();

                if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
                    && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {


                //  TempData["listeJob"] = liste.Where(r => r.Title.IndexOf(model.TitleSearch, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
                model.ListeProJob = liste;


                }
                else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
                   && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.Price >= model.PriceMinSearch).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
                   && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch).ToList();
                model.ListeProJob = list;

                }

                else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
                   && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
                  && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                    && r.Town == model.TownSearch && r.TypeContract == model.TypeContractJob).ToList();
                model.ListeProJob = list;

                }

                else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
                 && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                    && r.Town == model.TownSearch && r.TypeContract == model.TypeContractJob && r.ActivitySector == model.ActivitySectorJob).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
                && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
               && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch).ToList();
                model.ListeProJob = list;

                }

                else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
              && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch && r.TypeContract == model.TypeContractJob).ToList();
                model.ListeProJob = list;

                }

                else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
              && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch && r.TypeContract == model.TypeContractJob
                    && r.ActivitySector == model.ActivitySectorJob).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
             && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.Town == model.TownSearch).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
            && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.Town == model.TownSearch && r.Price >= model.PriceMinSearch).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
            && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.Town == model.TownSearch && r.TypeContract == model.TypeContractJob).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
           && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.Town == model.TownSearch && r.TypeContract == model.TypeContractJob).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
          && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.Town == model.TownSearch && r.Price >= model.PriceMinSearch).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
          && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.Town == model.TownSearch && r.Price >= model.PriceMinSearch && r.TypeContract == model.TypeContractJob).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
         && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
        && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob && r.Price <= model.PriceMaxSearch).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
       && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob && r.Price <= model.PriceMaxSearch
                    && r.Price >= model.PriceMinSearch).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
      && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob && r.Price <= model.PriceMaxSearch
                    && r.Price >= model.PriceMinSearch && r.ActivitySector == model.ActivitySectorJob).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
      && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob && r.Price <= model.PriceMaxSearch
                     && r.ActivitySector == model.ActivitySectorJob).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
     && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob
                    && r.Price >= model.PriceMinSearch && r.ActivitySector == model.ActivitySectorJob).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
     && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob
                    && r.ActivitySector == model.ActivitySectorJob).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
    && string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
    && string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Town == model.TownSearch).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
    && string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Town == model.TownSearch
                    && r.Price <= model.PriceMaxSearch).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
    && string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Town == model.TownSearch
                    && r.Price <= model.PriceMaxSearch && r.Price >= model.PriceMinSearch).ToList();
                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
    && string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Price <= model.PriceMaxSearch).ToList();

                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
    && string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Price <= model.PriceMaxSearch
                    && r.Price >= model.PriceMinSearch).ToList();

                model.ListeProJob = list;

                }
                else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
    && string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                {
                    List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Price >= model.PriceMinSearch).ToList();

                model.ListeProJob = list;

                }

                model.ListePro = new List<ProductModel>();
           


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
            List<JobModel> liste = dal.GetListJob().Where(m => m.Category.CategoryName == model.CagtegorieSearch && m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();


            if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
                && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {


                //  TempData["listeJob"] = liste.Where(r => r.Title.IndexOf(model.TitleSearch, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
                TempData["listeJobJson"] = liste;


            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
               && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price >= model.PriceMinSearch).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
               && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch).ToList();
                TempData["listeJobJson"] = list;

            }

            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
               && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
              && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                && r.Town == model.TownSearch && r.TypeContract == model.TypeContractJob).ToList();
                TempData["listeJobJson"] = list;

            }

            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
             && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                && r.Town == model.TownSearch && r.TypeContract == model.TypeContractJob && r.ActivitySector == model.ActivitySectorJob).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
            && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
           && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch).ToList();
                TempData["listeJobJson"] = list;

            }

            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
          && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch && r.TypeContract == model.TypeContractJob).ToList();
                TempData["listeJobJson"] = list;

            }

            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
          && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch && r.TypeContract == model.TypeContractJob
                && r.ActivitySector == model.ActivitySectorJob).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
         && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Town == model.TownSearch).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
        && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Town == model.TownSearch && r.Price >= model.PriceMinSearch).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
        && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Town == model.TownSearch && r.TypeContract == model.TypeContractJob).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
       && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Town == model.TownSearch && r.TypeContract == model.TypeContractJob).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
      && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Town == model.TownSearch && r.Price >= model.PriceMinSearch).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
      && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Town == model.TownSearch && r.Price >= model.PriceMinSearch && r.TypeContract == model.TypeContractJob).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
     && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
    && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob && r.Price <= model.PriceMaxSearch).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
   && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob && r.Price <= model.PriceMaxSearch
                && r.Price >= model.PriceMinSearch).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob && r.Price <= model.PriceMaxSearch
                && r.Price >= model.PriceMinSearch && r.ActivitySector == model.ActivitySectorJob).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob && r.Price <= model.PriceMaxSearch
                 && r.ActivitySector == model.ActivitySectorJob).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
 && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob
                && r.Price >= model.PriceMinSearch && r.ActivitySector == model.ActivitySectorJob).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
 && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob
                && r.ActivitySector == model.ActivitySectorJob).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
&& string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
&& string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Town == model.TownSearch).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
&& string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Town == model.TownSearch
                && r.Price <= model.PriceMaxSearch).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
&& string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Town == model.TownSearch
                && r.Price <= model.PriceMaxSearch && r.Price >= model.PriceMinSearch).ToList();
                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
&& string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Price <= model.PriceMaxSearch).ToList();

                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
&& string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Price <= model.PriceMaxSearch
                && r.Price >= model.PriceMinSearch).ToList();

                TempData["listeJobJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
&& string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Price >= model.PriceMinSearch).ToList();

                TempData["listeJobJson"] = list;

            }

            model.ListePro = new List<ProductModel>();
            return RedirectToAction("ResultSearchJson", "Product", model);
        }
        }
}