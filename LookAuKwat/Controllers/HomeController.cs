using LookAuKwat.Models;
using LookAuKwat.ViewModel;
//using LookAuKwat.SignalR.Hubs;
using Microsoft.AspNet.Identity;
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

       
        [OutputCache(Duration = int.MaxValue)]
        public ActionResult About()
        {
            return View();
        }
        [Authorize]
        public async Task< ActionResult> UserProfile(int? ProductId, string message, int? pageNumber)
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

            List<ProductModel> liste = new List<ProductModel>();

            if (User.IsInRole(MyRoleConstant.RoleAdmin) || (User.IsInRole(MyRoleConstant.Role_SuperAgent)))
            {
                liste = dal.GetListProductWhithNoInclude().Where(m => m.IsLookaukwat && m.IsActive).OrderByDescending(m => m.DateAdd).ToList();

            }
            else
            {
                liste = dal.GetListProductWhithNoInclude().Where(m => m.User.Id == id && m.IsActive).OrderByDescending(m => m.DateAdd).ToList();
            }

            SeachJobViewModel model = new SeachJobViewModel();
            model.ListeProductUserPagedList = liste.ToPagedList(pageNumber ?? 1, 5);
            // ViewBag.UserId = id;
            return View(model);
        }

        [OutputCache(Duration = int.MaxValue)]
        public ActionResult LegalMention()
        {
           
            return View();
        }
        [OutputCache(Duration = int.MaxValue, VaryByParam = "text")]
        public ActionResult Contact(string text)
        {
            ViewBag.text = text;
            return View();
        }
    }
}