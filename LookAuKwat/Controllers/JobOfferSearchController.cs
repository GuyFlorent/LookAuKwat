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
        public ActionResult ResultSearchOfferJob_PartialView(SeachJobViewModel model)
        {
            //SeachJobViewModel model1 = new SeachJobViewModel();
            //model1.ListePro = new List<ProductModel>();
            //var lii = dal.GetListProduct();
            //foreach (var li in dal.GetListProduct())
            //{
            //    if (!string.IsNullOrWhiteSpace(li.Title))
            //        model1.ListePro.Add(li);
            //}

            if (!string.IsNullOrWhiteSpace(model.TitleJobSearch))
            {

                model.ListePro = dal.GetListProduct().Where(r => r.Title.IndexOf(model.TitleJobSearch, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
               
            }
            else

                model.ListePro = new List<ProductModel>();
            return RedirectToAction("ResultSearch_PartialView","Product", model);
        }
    }
}