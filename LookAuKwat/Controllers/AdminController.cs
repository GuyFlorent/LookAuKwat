using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace LookAuKwat.Controllers
{
    public class AdminController : Controller
    {
        private IDal dal;
        public AdminController() : this(new Dal())
        {

        }

        public AdminController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListAllUser(SearchUser_Admin model, int? pageNumber, string sortBy)
        {
            ViewBag.PriceAscSort = String.IsNullOrEmpty(sortBy) ? "date desc" : "";
            ViewBag.DateAscSort = sortBy == "Plus anciennes" ? "date asc" : "";
           
            IEnumerable<ApplicationUser> liste = dal.GetUsersList();
           
            if (!string.IsNullOrWhiteSpace(model.term))
            {
                liste = liste.Where(m => m.FirstName != null && m.FirstName.ToLower().Contains(model.term.ToLower())
                || (m.Email != null && m.Email.ToLower().Contains(model.term.ToLower())));
            }
            
            ViewBag.number = liste.Count();
            switch (sortBy)
            {
         
                case "date desc":
                    liste = liste.OrderByDescending(m => m.Id);
                    break;
                case "date asc":
                    liste = liste.OrderBy(m => m.Id);
                    break;
                default:
                    liste = liste.OrderByDescending(x => x.Id);
                    break;
            }
            ViewBag.NumberOfUser = liste.Count();
            return View(liste.ToPagedList(pageNumber ?? 1, 10));
        }
        public ActionResult ListAllAgents(SearchUser_Admin model, int? PageNumber, string sortBy)
        {
            ViewBag.PriceAscSort = String.IsNullOrEmpty(sortBy) ? "date desc" : "";
            ViewBag.DateAscSort = sortBy == "Plus anciennes" ? "date asc" : "";

            IEnumerable<ParrainModel> liste = dal.GetParrainList();
            if (!string.IsNullOrWhiteSpace(model.term))
            {
                liste = liste.Where(m => m.ParrainEmail.ToLower().Contains(model.term.ToLower())
                || m.ParrainFirstName.ToLower().Contains(model.term.ToLower()));
            }

            ViewBag.number = liste.Count();
            switch (sortBy)
            {

                case "date desc":
                    liste = liste.OrderByDescending(m => m.Id);
                    break;
                case "date asc":
                    liste = liste.OrderBy(m => m.Id);
                    break;
                default:
                    liste = liste.OrderByDescending(x => x.Id);
                    break;
            }

            return View(liste.ToPagedList(PageNumber ?? 1, 10));
        }
        public ActionResult SearchUser_PartialView(SearchUser_Admin model)
        {
            return PartialView(model);
        }

        public ActionResult AddParrain_PartialView(ParrainViewModel model)
        {
            return PartialView(model);
        }
        public ActionResult AddParrain(ParrainViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = dal.GetUsersList().FirstOrDefault(m => m.Email == model.Email);

                if(user != null)
                {
                    var parrain = new ParrainModel()
                    {
                        Date_createParrain = DateTime.Now,
                        ParrainEmail = user.Email,
                        ParrainFirstName = user.FirstName
                    };
                    dal.AddParrain(parrain);
                    return RedirectToAction("ListAllAgents");
                }
                else
               
                return RedirectToAction("ListAllAgents");
            }
            return RedirectToAction("ListAllAgents");
        }
        public ActionResult DeletParrain(string userEmail)
        {
            var user = dal.GetUsersList().FirstOrDefault(m => m.Email == userEmail);
            var parrain = dal.GetParrainList().FirstOrDefault(m => m.Id == user.Parrain_Id);
            dal.DeletParrain(parrain);
            return View();
        }

        public ActionResult Stat_Account_Agent(string userEmail, int? PageNumber, string sortBy)
        {
            var parrain = dal.GetParrainList().FirstOrDefault(m => m.ParrainEmail == userEmail);
            List<DataUser_Agent> liste = new List<DataUser_Agent>();
            if(parrain != null)
            {
                List<ApplicationUser> Liste_All_User_Parraine = dal.GetUsersList().Where(m => m.Parrain_Id == parrain.Id).ToList();
            foreach(var user in Liste_All_User_Parraine)
                {
                    DataUser_Agent data = new DataUser_Agent();
                    data.FirstName = user.FirstName;
                    data.Phone = user.PhoneNumber;
                    if(user.EmailConfirmed == true)
                    {
                        data.ConfirmEmail = "oui";
                    }
                    else
                    {
                        data.ConfirmEmail = "non";
                    }
                    if (user.PhoneNumberConfirmed == true)
                    {
                        data.ConfirmPhoneNumber = "oui";
                    }
                    else
                    {
                        data.ConfirmPhoneNumber = "non";
                    }
                    var product = dal.GetListProduct().FirstOrDefault(m => m.User == user);

                    if (product != null)
                    {
                        data.ConfirmPublish = "oui";
                    }
                    else
                    {
                        data.ConfirmPublish = "non";
                    }
                    if(data.ConfirmPublish == "oui" && (data.ConfirmEmail == "oui" || data.ConfirmPhoneNumber =="oui") )
                    {
                        data.price = 100;
                        data.DateFirstPublish = user.Date_First_Publish;
                    }
                    else
                    {
                        data.price = 0;
                        data.DateFirstPublish = null;
                    }
                    
                    data.DateCreation = user.Date_Create_Account;
                    liste.Add(data);
                }

                ViewBag.Totalprice = liste.Sum(m => m.price);
                ViewBag.FirstName = parrain.ParrainFirstName;
                return View(liste.ToPagedList(PageNumber ?? 1, 10));
            }

            
            return View(liste.ToPagedList(PageNumber ?? 1, 10));
        }

        public ActionResult UpdateUserInformations(string id)
        {
            ApplicationUser user = dal.GetUserByStrId(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult UpdateUserInformations(ApplicationUser user)
        {
            dal.UpdateUserByAdmin(user);

            return RedirectToAction("ListAllUser");
        }
        public ActionResult DeleteUser(string id)
        {
            ApplicationUser user = dal.GetUserByStrId(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult DeleteUser(ApplicationUser user)
        {
            dal.DeleteUserByAdmin(user);

            return RedirectToAction("ListAllUser");
        }

    }
}