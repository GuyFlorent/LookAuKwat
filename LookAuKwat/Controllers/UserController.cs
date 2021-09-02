using LookAuKwat.Models;
using LookAuKwat.ViewModel;
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

        public  ActionResult GetListProductByUser_PartialView(string id)
        {
            //string id = User.Identity.GetUserId();
            if (!string.IsNullOrWhiteSpace(id))
            {
                IEnumerable<ProductModel> liste =  dal.GetListProductWhithNoInclude().Where(m=>m.User.Id== id).OrderByDescending(m =>m.DateAdd).ToList();
                return PartialView(liste);
            }
            
            return PartialView();
        }
        [Authorize]
        public ActionResult UserDetails()
        {
            string id = User.Identity.GetUserId();
            ApplicationUser user = dal.GetUserByStrId(id);
            var testt1 = User.IsInRole(MyRoleConstant.RoleAgent);
            var testt2 = User.IsInRole(MyRoleConstant.RoleAdmin);
            var testt3 = User.IsInRole(MyRoleConstant.Role_Old_Agent);
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
        public JsonResult Checked_IfNumber_AlreadyExist(RegisterViewModel user)
        {
            bool result = !dal.User_Number_Already_Exist(user.Phone);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //for first register sms chech ,number
        public JsonResult Checked_IfNumber_AlreadyExist_FirstRegister(AddPhoneNumberViewModel model)
        {
            bool result = !dal.User_Number_Already_Exist(model.Number);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Checked_IfEmail_AlreadyExist(RegisterViewModel user)
        {
            bool result = !dal.User_Email_Already_Exist(user.Email);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}