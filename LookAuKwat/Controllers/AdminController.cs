using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using PagedList;
using RotativaHQ.MVC5;
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
                    var product = dal.GetListProductWhithNoInclude().FirstOrDefault(m => m.User== user);

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

                ViewBag.Email = userEmail;
                ViewBag.Totalprice = liste.Sum(m => m.price);
                ViewBag.FirstName = parrain.ParrainFirstName;
                return View(liste.ToPagedList(PageNumber ?? 1, 20));
            }

            
            return View(liste.ToPagedList(PageNumber ?? 1, 20));
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


        //Print receipt of each client

        public ActionResult receipt_PartialView(PrintViewModel print )
        {
      
            return View();
        }
        public ActionResult PrintOneReceipt(string email, string month)
        {
            string userEmail = email;
           
            var parrain = dal.GetParrainList().FirstOrDefault(m => m.ParrainEmail == userEmail);
            var userr = dal.GetUsersList().FirstOrDefault(m => m.Email == userEmail);
            List<DataUser_Agent> liste = new List<DataUser_Agent>();
            DateTime? date = null;
            DateTime? date2 = null;

            if (parrain != null)
            {


                List<ApplicationUser> Liste_All_User_Parraine = dal.GetUsersList().Where(m => m.Parrain_Id == parrain.Id).ToList();

                ViewBag.Email = userEmail;
                ViewBag.ParainId = parrain.Id;

                ViewBag.TotalWithNoAnnouce = Liste_All_User_Parraine.Where(m => (m.EmailConfirmed == true || m.PhoneNumberConfirmed == true) && m.Date_First_Publish == null).Count();
                ViewBag.FirstName = parrain.ParrainFirstName;
                ViewBag.Number = userr.PhoneNumber;
                ViewBag.TotalParrainage = Liste_All_User_Parraine.Count();
                ViewBag.NoConfirmNoAnnounce = Liste_All_User_Parraine.Where(m => m.EmailConfirmed == false && m.PhoneNumberConfirmed == false).Count();
                switch (month)
                {
                    case "Janvier":
                        date = new DateTime(2021, 1, 27, 0, 0, 0);
                        date2 = new DateTime(2020, 12, 27, 0, 0, 0);
                        Liste_All_User_Parraine = Liste_All_User_Parraine.Where(m => m.Date_First_Publish != null && m.Date_First_Publish >= date2 && m.Date_First_Publish <= date).ToList();
                        break;
                    case "Février":
                        date = new DateTime(2021, 2, 27, 0, 0, 0);
                        date2 = new DateTime(2021, 1, 27, 0, 0, 0);
                        liste = liste.Where(m => m.DateFirstPublish != null && m.DateFirstPublish >= date2 && m.DateFirstPublish <= date).ToList();
                        break;
                    case "Mars":
                        date = new DateTime(2021, 3, 27, 0, 0, 0);
                        date2 = new DateTime(2021, 2, 27, 0, 0, 0);
                        liste = liste.Where(m => m.DateFirstPublish != null && m.DateFirstPublish >= date2 && m.DateFirstPublish <= date).ToList();
                        break;
                    case "Avril":
                        date = new DateTime(2021, 4, 27, 0, 0, 0);
                        date2 = new DateTime(2021, 3, 27, 0, 0, 0);
                        liste = liste.Where(m => m.DateFirstPublish != null && m.DateFirstPublish >= date2 && m.DateFirstPublish <= date).ToList();
                        break;
                    case "Mai":
                        date = new DateTime(2021, 5, 27, 0, 0, 0);
                        date2 = new DateTime(2021, 4, 27, 0, 0, 0);
                        liste = liste.Where(m => m.DateFirstPublish != null && m.DateFirstPublish >= date2 && m.DateFirstPublish <= date).ToList();
                        break;
                    case "Juin":
                        date = new DateTime(2021, 6, 27, 0, 0, 0);
                        date2 = new DateTime(2021, 5, 27, 0, 0, 0);
                        liste = liste.Where(m => m.DateFirstPublish != null && m.DateFirstPublish >= date2 && m.DateFirstPublish <= date).ToList();
                        break;
                    case "Juillet":
                        date = new DateTime(2021, 7, 27, 0, 0, 0);
                        date2 = new DateTime(2021, 6, 27, 0, 0, 0);
                        liste = liste.Where(m => m.DateFirstPublish != null && m.DateFirstPublish >= date2 && m.DateFirstPublish <= date).ToList();
                        break;
                    case "Août":
                        date = new DateTime(2021, 8, 27, 0, 0, 0);
                        date2 = new DateTime(2021, 7, 27, 0, 0, 0);
                        liste = liste.Where(m => m.DateFirstPublish != null && m.DateFirstPublish >= date2 && m.DateFirstPublish <= date).ToList();
                        break;
                    case "Septembre":
                        date = new DateTime(2021, 9, 27, 0, 0, 0);
                        date2 = new DateTime(2021, 8, 27, 0, 0, 0);
                        liste = liste.Where(m => m.DateFirstPublish != null && m.DateFirstPublish >= date2 && m.DateFirstPublish <= date).ToList();
                        break;
                    case "Octobre":
                        date = new DateTime(2021, 10, 27, 0, 0, 0);
                        date2 = new DateTime(2021, 9, 27, 0, 0, 0);
                        ViewBag.Month = "Octobre";
                        liste = liste.Where(m => m.DateFirstPublish != null && m.DateFirstPublish >= date2 && m.DateFirstPublish <= date).ToList();
                        break;
                    case "Novembre":
                        date = new DateTime(2020, 11, 27, 0, 0, 0);
                        date2 = new DateTime(2020, 10, 27, 0, 0, 0);
                        ViewBag.Month = "Novembre";
                        Liste_All_User_Parraine = Liste_All_User_Parraine.Where(m => m.Date_First_Publish != null && m.Date_First_Publish >= date2 && m.Date_First_Publish <= date).ToList();
                        break;
                    case "Decembre":
                        date = new DateTime(2020, 12, 27, 0, 0, 0);
                        date2 = new DateTime(2020, 11, 27, 0, 0, 0);
                        ViewBag.Month = "Decembre";
                        Liste_All_User_Parraine = Liste_All_User_Parraine.Where(m => m.Date_First_Publish != null && m.Date_First_Publish >= date2 && m.Date_First_Publish <= date).ToList();
                        break;
                }


                ViewBag.TotalWithAnnouce = Liste_All_User_Parraine.Where(m => (m.EmailConfirmed == true || m.PhoneNumberConfirmed == true) && m.Date_First_Publish != null).Count();
                ViewBag.Totalprice = Liste_All_User_Parraine.Where(m => (m.EmailConfirmed == true || m.PhoneNumberConfirmed == true) && m.Date_First_Publish != null).Count() * 100;

                var receipt = new ViewAsPdf("receipt_PartialView") { FileName = "Recu_" + parrain.ParrainFirstName + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf" };
                return receipt;
               
            }
            return View();
        }

    }
}