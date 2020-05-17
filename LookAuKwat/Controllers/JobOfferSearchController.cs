using LookAuKwat.Models;
using LookAuKwat.ViewModel;
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

        public ActionResult ResultSearchOfferJob_PartialView(SeachJobViewModel model)
        {
            return View();
        }
    }
}