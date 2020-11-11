using LookAuKwat.Models;
using LookAuKwat.ViewModel;
//using LookAuKwat.SignalR.Hubs;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LookAuKwat.Controllers
{
    public class HomeController : Controller
    {
        private IDal dal;
        public HomeController() : this(new Dal())
        {

        }

        public HomeController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            
            string id = User.Identity.GetUserId();
            ApplicationUser user = dal.GetUserByStrId(id);
           
            return View(user);
        }
        [Authorize]
        public ActionResult UserProfile()
        {
           
            return View();
        }

        public ActionResult LegalMention()
        {
           
            return View();
        }

        public ActionResult Contact(string text)
        {
            ViewBag.text = text;
            return View();
        }
    }
}