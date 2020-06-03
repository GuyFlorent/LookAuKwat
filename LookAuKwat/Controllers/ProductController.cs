using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using Microsoft.Ajax.Utilities;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LookAuKwat.Controllers
{
    public class ProductController : Controller
    {
        private IDal dal;
        public ProductController() : this(new Dal())
        {

        }

        public ProductController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SimilarProduct_PartialView(ProductModel model)
        {
            List<ProductModel> similarList = dal.GetListProduct().Where(l => l.Category.CategoryName == model.Category.CategoryName
            && l.Town == model.Town && l.Title != model.Title).Take(4).ToList();
            return PartialView(similarList);
        }
        public ActionResult ListProduct()
        {
            IEnumerable<ProductModel> liste = dal.GetListProduct();
            return View(liste);
        }
        public ActionResult ListProduct_PartialView()
        {
            IEnumerable<ProductModel> liste = dal.GetListProduct().OrderByDescending(m=>m.DateAdd);
            return PartialView(liste);
        }
        public JsonResult listAllProductReturnJson()
        {
            var data2 = dal.GetListProduct().Select(s => new DataJsonProductViewModel
            {
                Title = s.Title,
                Coordinate = s.Coordinate,
                id = s.id,
                Price = s.Price,
                Description = s.Description,
                DateAdd = s.DateAdd,
                Images = s.Images.Select(o => o.Image).ToList(),
                User = s.User,
                Street = s.Street,
                Town = s.Town,
                Category = s.Category
            }).ToList();

            return Json(data2, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listProductReturnJson()
        {
            IEnumerable<int> data1 = dal.GetListProduct().Select(s =>s.id);


            return Json(data1, JsonRequestBehavior.AllowGet);
        }


        public JsonResult listProductImageReturnJson()
        {
            IEnumerable<Guid> data2 = dal.GetImageList().Select(s => s.id);


            return Json(data2, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteImage(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                Guid guid = new Guid(id);
                ImageProcductModel img = dal.GetImageList().FirstOrDefault(s=>s.id==guid);
                if (img == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                dal.DeleteImage(img);

                //Delete file from the file system
                var path = img.Image;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        [HttpPost]
        public JsonResult DeleteProduct(int id)
        {
            try
            {
                ProductModel pro = dal.GetListProduct().FirstOrDefault(s => s.id == id);
                if (pro == null)
                {

                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //delete files from the file system

                foreach (var item in pro.Images)
                {
                    String path = item.Image;
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                dal.DeleteProduct(pro);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        //result of every search product
        public ActionResult ResultSearch_PartialView(SeachJobViewModel modelresult)
        {
           

            switch (modelresult.CagtegorieSearch)
            {
                case "Emploi":
                     var result= TempData["listeJob"] as List<JobModel>;
                    foreach(var element in result)
                    {
                        modelresult.ListePro.Add(element);
                    }
                   
                    break;
                case "Immobilier":
                    var resultImmobilier = TempData["listeApart"] as List<ApartmentRentalModel>;
                    foreach (var element in resultImmobilier)
                    {
                        modelresult.ListePro.Add(element);
                    }

                    break;
            }


            if (modelresult.ListePro == null)
            {
                modelresult.ListePro = new List<ProductModel>();
            }


            // modelresult.ListePro = TempData["listeJob"] as List<ProductModel>;
            // modelresult.ListePro = dal.GetListProduct().Where(r => r.Title.IndexOf(modelresult.TitleJobSearch, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();



            return PartialView(modelresult);
        }

        public JsonResult ResultSearchJson(SeachJobViewModel modelresult)
        {
            List<JobModel> result = TempData["listeJobJson"] as List<JobModel>;
            List<ApartmentRentalModel> resultImmobilier = TempData["listeApartJson"] as List<ApartmentRentalModel>;
            List<DataJsonProductViewModel> data = new List<DataJsonProductViewModel>() ;
            switch (modelresult.CagtegorieSearch)
            {
                case "Emploi":
                    
                    foreach (var element in result)
                    {
                        modelresult.ListePro.Add(element);
                    }
                    data = modelresult.ListePro.Select(s=>new DataJsonProductViewModel
                    { Title = s.Title,
                    Coordinate = s.Coordinate, id = s.id, Price = s.Price, Description = s.Description, DateAdd = s.DateAdd,
                    Images = s.Images.Select(o=>o.Image).ToList(), User = s.User, Street = s.Street, Town = s.Town}).ToList();
                    break;
                case "Immobilier":

                    foreach (var element in resultImmobilier)
                    {
                        modelresult.ListePro.Add(element);
                    }
                    data = modelresult.ListePro.Select(s => new DataJsonProductViewModel
                    {
                        Title = s.Title,
                        Coordinate = s.Coordinate,
                        id = s.id,
                        Price = s.Price,
                        Description = s.Description,
                        DateAdd = s.DateAdd,
                        Images = s.Images.Select(o => o.Image).ToList(),
                        User = s.User,
                        Street = s.Street,
                        Town = s.Town
                    }).ToList();
                    break;
            }


            if (modelresult.ListePro == null)
            {
                modelresult.ListePro = new List<ProductModel>();
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ContactProductUser_PartialView(contactUserViewModel vm)
        {
            
            return PartialView(vm);
        }
        [HttpPost]
        public async Task< ActionResult> ContactProductUser(contactUserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await configSendGridasync(vm);
                //try
                //{
                //    MailMessage msz = new MailMessage();
                //    msz.From = new MailAddress(vm.EmailSender);//Email which you are getting 
                //                                         //from contact us page 
                //    msz.To.Add(vm.user);//Where mail will be sent 
                //    msz.Subject = vm.SubjectSender;
                //    msz.Body = vm.Message;
                //    SmtpClient smtp = new SmtpClient();
                //smtp.UseDefaultCredentials = false;
                //    smtp.Host = "smtp.gmail.com";

                //    smtp.Port = 587;

                //    smtp.Credentials = new NetworkCredential("wangueujunior23@gmail.com", "florent23");

                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //    smtp.EnableSsl = true;

                //    smtp.Send(msz);

                //    ModelState.Clear();
                //    ViewBag.Message = "Méssage envoyé avec succès ";
                //}
                //catch (Exception ex)
                //{

                //    ModelState.Clear();
                //    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                //}
            }

            return PartialView("ContactProductUser_PartialView",vm);
        }

      
        private async Task configSendGridasync(contactUserViewModel message)
        {
            message.Message = "Hello <br/> vous avez un nouveau message sur votre annonce dans LookAuKwat! <br/> " +
               " <a href =\"" + message.Linkshare + "\">" + message.Linkshare + "</a> <br/>"+ message.Message;
            var myMessage = new SendGridMessage();
            myMessage.AddTo(message.user);
            myMessage.From = new System.Net.Mail.MailAddress(
                                message.EmailSender, message.NameSender);
            myMessage.Subject = message.SubjectSender;
            myMessage.Text = message.Message;
            myMessage.Html = message.Message;

            var credentials = new NetworkCredential(
                       ConfigurationManager.AppSettings["mailAccountSendGrid"],
                       ConfigurationManager.AppSettings["mailPasswordSendGrid"]
                       );

            // Create a Web transport for sending email.
            var transportWeb = new Web(credentials);

            // Send the email.
            if (transportWeb != null)
            {

               await transportWeb.DeliverAsync(myMessage);

            }
            else
            {
                Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }
        }
    }
}