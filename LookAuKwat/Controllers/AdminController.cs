using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using PagedList;
using RotativaHQ.MVC5;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using Twilio.Rest.Preview.Understand.Assistant.Task;

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
        public async Task< ActionResult> ListAllUser(SearchUser_Admin model, int? pageNumber, string sortBy)
        {
            ViewBag.PriceAscSort = String.IsNullOrEmpty(sortBy) ? "date desc" : "";
            ViewBag.DateAscSort = sortBy == "Plus anciennes" ? "date asc" : "";
           
            IEnumerable<ApplicationUser> liste = await dal.GetUsersList().ToListAsync();
           
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
        public async Task< ActionResult> ListAllAgents(SearchUser_Admin model, int? PageNumber, string sortBy)
        {
            ViewBag.PriceAscSort = String.IsNullOrEmpty(sortBy) ? "date desc" : "";
            ViewBag.DateAscSort = sortBy == "Plus anciennes" ? "date asc" : "";

            IEnumerable<ParrainModel> liste = await dal.GetParrainList().ToListAsync();
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
        public async Task< ActionResult> AddParrain(ParrainViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await dal.GetUsersList().FirstOrDefaultAsync(m => m.Email == model.Email);

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
        public async Task< ActionResult> DeletParrain(string userEmail)
        {
            var user = await dal.GetUsersList().FirstOrDefaultAsync(m => m.Email == userEmail);
            var parrain = await dal.GetParrainList().FirstOrDefaultAsync(m => m.Id == user.Parrain_Id);
            dal.DeletParrain(parrain);
            return View();
        }

        public async Task< ActionResult> Stat_Account_Agent(string userEmail, int? PageNumber, string sortBy)
        {
            var parrain = await dal.GetParrainList().FirstOrDefaultAsync(m => m.ParrainEmail == userEmail);
            List<DataUser_Agent> liste = new List<DataUser_Agent>();
            if(parrain != null)
            {
                List<ApplicationUser> Liste_All_User_Parraine = await dal.GetUsersList().Where(m => m.Parrain_Id == parrain.Id).ToListAsync();

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
                    var product =   dal.GetListProductWhithNoInclude().FirstOrDefault(m => m.User.Id== user.Id);

                    if (product != null)
                    {
                        data.ConfirmPublish = "oui";
                    }
                    else
                    {
                        data.ConfirmPublish = "non";
                       // user.Date_First_Publish = null;
                       // dal.UpdateUserByAdmin(user);
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
        public async Task< ActionResult> PrintOneReceipt(string email, string month)
        {
            string userEmail = email;
           
            var parrain = await dal.GetParrainList().FirstOrDefaultAsync(m => m.ParrainEmail == userEmail);
            var userr = await dal.GetUsersList().FirstOrDefaultAsync(m => m.Email == userEmail);
            List<DataUser_Agent> liste = new List<DataUser_Agent>();
            DateTime? date = null;
            DateTime? date2 = null;

            if (parrain != null)
            {


                List<ApplicationUser> Liste_All_User_Parraine = await dal.GetUsersList().Where(m => m.Parrain_Id == parrain.Id).ToListAsync();

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
                        date2 = new DateTime(2020, 11, 28, 0, 0, 0);
                        ViewBag.Month = "Decembre";
                        ViewBag.PromoDecembre = "Promo Décembre";
                        ViewBag.SuperPromoDecembre = "Promo de 50 utilisateurs";
                        Liste_All_User_Parraine = Liste_All_User_Parraine.Where(m => m.Date_First_Publish != null && m.Date_First_Publish >= date2 && m.Date_First_Publish <= date).ToList();
                        ViewBag.TotalpricePromo = Liste_All_User_Parraine.Where(m => (m.EmailConfirmed == true || m.PhoneNumberConfirmed == true) && m.Date_First_Publish != null).Count() * 200;

                        var total = Liste_All_User_Parraine.Where(m => (m.EmailConfirmed == true || m.PhoneNumberConfirmed == true) && m.Date_First_Publish != null).Count();
                        if(total >= 50)
                        {
                            ViewBag.TotalpricePromoSuper = Liste_All_User_Parraine.Where(m => (m.EmailConfirmed == true || m.PhoneNumberConfirmed == true) && m.Date_First_Publish != null).Count() * 200 * 2;

                        }
                        else
                        {
                            ViewBag.TotalpricePromoSuper = "Objectif de 50 inscrits non réalisé ";

                        }


                        break;
                }


                ViewBag.TotalWithAnnouce = Liste_All_User_Parraine.Where(m => (m.EmailConfirmed == true || m.PhoneNumberConfirmed == true) && m.Date_First_Publish != null).Count();
               
                ViewBag.Totalprice = Liste_All_User_Parraine.Where(m => (m.EmailConfirmed == true || m.PhoneNumberConfirmed == true) && m.Date_First_Publish != null).Count() * 100;

                var receipt = new ViewAsPdf("receipt_PartialView") { FileName = "Recu_" + parrain.ParrainFirstName + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf" };
                return receipt;
               
            }
            return View();
        }

        // clean image in product contain more thanone image
        //remove the one contain http

        //public ActionResult RemoveImage_ContainHttpIn_Alot()
        //{
        //    var Images = dal.GetImageList().Where(m => m.ImageMobile == "https://lookaukwat.azurewebsites.nethttps://particulier-employeur.fr/wp-content/themes/fepem/img/general/avatar.png").ToList();


        //    List<ImageProcductModel> list = new List<ImageProcductModel>();
        //    foreach (var image in Images)
        //    {

        //        image.ImageMobile = "https://particulier-employeur.fr/wp-content/themes/fepem/img/general/avatar.png";
        //        dal.UpdateImage(image);

        //    }

        //    // var number = list.Count;
        //    return View();
        //}

    }
}