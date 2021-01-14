using LookAuKwat.Models;
using LookAuKwat.ViewModel;
//using LookAuKwat.SignalR.Hubs;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task< ActionResult> UserProfile(int? ProductId, string message)
        {
            string id = User.Identity.GetUserId();
            ApplicationUser user = dal.GetUserByStrId(id);
            if (user.Email.StartsWith("Mtest") && user.PhoneNumberConfirmed == false)
            {
                return RedirectToAction("AddPhoneNumberFirstRegister", "Manage");
            }
            if (!string.IsNullOrWhiteSpace(message))
            {
                ViewBag.Succes = message;
            }
            if(ProductId != null)
            {
                var product = dal.GetListProductWhithNoInclude().FirstOrDefault(p => p.id == ProductId);
                if(product.Images.Count > 1)
                {
                    var im = product.Images.FirstOrDefault(m => m.Image == "https://particulier-employeur.fr/wp-content/themes/fepem/img/general/avatar.png");
                    if(im != null)
                    {
                      await  dal.DeleteImage(im);
                    }
                }
            }
            ViewBag.UserId = id;
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