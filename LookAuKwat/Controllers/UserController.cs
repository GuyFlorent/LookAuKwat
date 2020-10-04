using LookAuKwat.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LookAuKwat.Controllers
{
    public class UserController : Controller
    {
        private IDal dal;
        public UserController() : this(new Dal())
        {

        }

        public UserController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetListProductByUser_PartialView()
        {
            string id = User.Identity.GetUserId();
            if (!string.IsNullOrWhiteSpace(id))
            {
                IEnumerable<ProductModel> liste = dal.GetListUserProduct(id).OrderByDescending(m =>m.DateAdd
                );
                return PartialView(liste);
            }
            
            return PartialView();
        }

        public ActionResult UserDetails()
        {
            string id = User.Identity.GetUserId();
            ApplicationUser user = dal.GetUserByStrId(id);
            return View(user);
        }
        public ActionResult UpdateUserInformations(string id)
        {
            ApplicationUser user = dal.GetUserByStrId(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult UpdateUserInformations(ApplicationUser user)
        {
            dal.UpdateUserInformations(user);

            return RedirectToAction("UserDetails");
        }
    }
}