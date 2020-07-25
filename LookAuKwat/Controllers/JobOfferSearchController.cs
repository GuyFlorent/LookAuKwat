using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using Newtonsoft.Json;
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

        public ActionResult SearchOfferJob_PartialView(SeachJobViewModel model)
        {
            
            return PartialView(model);
        }
      
        public ActionResult ResultSearchOfferJob_PartialView(SeachJobViewModel model, int? pageNumber, string sortBy)
        {
            //SeachJobViewModel model1 = new SeachJobViewModel();
            //model1.ListePro = new List<ProductModel>();
            //var lii = dal.GetListProduct();
            //foreach (var li in dal.GetListProduct())
            //{
            //    if (!string.IsNullOrWhiteSpace(li.Title))
            //        model1.ListePro.Add(li);
            //}
         
            model.CagtegorieSearch = "Emploi";
            model.SearchOrAskJobJob = "J'offre";
            model.sortBy = sortBy;
            model.PageNumber = pageNumber;
            List<JobModel> liste = dal.GetListJob().Where(m => m.Category.CategoryName == model.CagtegorieSearch && m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();

            if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <=0 && string.IsNullOrWhiteSpace(model.TownSearch)
                && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
                { 


              //  TempData["listeJob"] = liste.Where(r => r.Title.IndexOf(model.TitleSearch, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
                TempData["listeJob"] = liste;


            }
             else if(model.PriceMinSearch > 0 && model.PriceMaxSearch <=0 && string.IsNullOrWhiteSpace(model.TownSearch)
                && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price >= model.PriceMinSearch).ToList();
                TempData["listeJob"] = list;  
                    
            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
               && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch).ToList();
                TempData["listeJob"] = list;

            }

            else if(model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
               && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
              && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                && r.Town == model.TownSearch && r.TypeContract == model.TypeContractJob ).ToList();
                TempData["listeJob"] = list;

            }

            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
             && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                && r.Town == model.TownSearch && r.TypeContract == model.TypeContractJob && r.ActivitySector == model.ActivitySectorJob).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
            && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
           && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch).ToList();
                TempData["listeJob"] = list;

            }

            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
          && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch && r.TypeContract == model.TypeContractJob).ToList();
                TempData["listeJob"] = list;

            }

            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
          && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch && r.TypeContract == model.TypeContractJob
                && r.ActivitySector == model.ActivitySectorJob).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
         && string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Town == model.TownSearch).ToList();
                TempData["listeJob"] = list;

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
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
       && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Town == model.TownSearch && r.TypeContract == model.TypeContractJob).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
      && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Town == model.TownSearch && r.Price >= model.PriceMinSearch).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
      && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.Town == model.TownSearch && r.Price >= model.PriceMinSearch && r.TypeContract == model.TypeContractJob).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
     && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
    && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob && r.Price <= model.PriceMaxSearch).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
   && !string.IsNullOrWhiteSpace(model.TypeContractJob) && string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob && r.Price <= model.PriceMaxSearch
                && r.Price >= model.PriceMinSearch).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob && r.Price <= model.PriceMaxSearch
                && r.Price >= model.PriceMinSearch && r.ActivitySector == model.ActivitySectorJob).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob && r.Price <= model.PriceMaxSearch
                 && r.ActivitySector == model.ActivitySectorJob).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
 && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob 
                && r.Price >= model.PriceMinSearch && r.ActivitySector == model.ActivitySectorJob).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
 && !string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.TypeContract == model.TypeContractJob
                && r.ActivitySector == model.ActivitySectorJob).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
&& string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob ).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
&& string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Town == model.TownSearch).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
&& string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Town == model.TownSearch
                && r.Price <= model.PriceMaxSearch).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
&& string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Town == model.TownSearch
                && r.Price <= model.PriceMaxSearch && r.Price >= model.PriceMinSearch).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
&& string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Price <= model.PriceMaxSearch).ToList();

                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
&& string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Price <= model.PriceMaxSearch
                && r.Price >= model.PriceMinSearch).ToList();

                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
&& string.IsNullOrWhiteSpace(model.TypeContractJob) && !string.IsNullOrWhiteSpace(model.ActivitySectorJob))
            {
                List<JobModel> list = liste.Where(r => r.ActivitySector == model.ActivitySectorJob && r.Price >= model.PriceMinSearch).ToList();

                TempData["listeJob"] = list;

            }

            model.ListePro = new List<ProductModel>();
            return RedirectToAction("ResultSearch_PartialView","Product", model);
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