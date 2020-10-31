using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using Microsoft.Ajax.Utilities;
using PagedList;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
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
            && l.Town == model.Town && l.SearchOrAskJob == model.SearchOrAskJob && l.id != model.id).Take(4).ToList();
            return PartialView(similarList);
        }
        public ActionResult ListProduct()
        {
            IEnumerable<ProductModel> liste = dal.GetListProduct();
            return View(liste);
        }
        public ActionResult ListProduct_PartialView(int? pageNumber, string sortBy)
        {
          
            ViewBag.PriceAscSort = String.IsNullOrEmpty(sortBy) ? "Price desc" : "";
            ViewBag.PriceDescSort = sortBy == "Prix croissant" ? "Price asc" : "";
            ViewBag.DateAscSort = sortBy == "Plus anciennes" ? "date asc" : "";
            ViewBag.DateDescSort = sortBy == "Plus recentes" ? "date desc" : "";
            IEnumerable<ProductModel> liste = dal.GetListProduct();
          
            ViewBag.number = liste.Count();
            switch (sortBy)
            {
                case "Price desc":
                    liste = liste.OrderByDescending(m => m.Price);
                    break;
                case "Price asc":
                    liste = liste.OrderBy(m=>m.Price);
                    break;
                case "date desc":
                    liste = liste.OrderByDescending(m => m.id);
                    break;
                case "date asc":
                    liste = liste.OrderBy(m => m.id);
                    break;
                default:
                    liste = liste.OrderByDescending(x => x.id);
                    break;
            }

            return PartialView(liste.ToPagedList(pageNumber ?? 1, 10));
        }

        public ActionResult SearchAskProduct_PartialView(AskJobViewModel model)
        {
            return PartialView(model);
        }
            public ActionResult ResultSearchAskProduct_PartialView(AskJobViewModel model, int? pageNumber, string sortBy)
        {
            string searchOrAsk = "Je recherche";
            //ViewBag.PriceAscSort = String.IsNullOrEmpty(sortBy) ? "Price desc" : "";
            //ViewBag.PriceDescSort = sortBy == "Prix croissant" ? "Price asc" : "";
            //ViewBag.DateAscSort = sortBy == "Plus anciennes" ? "date asc" : "";
            //ViewBag.DateDescSort = sortBy == "Plus recentes" ? "date desc" : "";
            model.sortBy = sortBy;
            List < ProductModel> liste = dal.GetListProduct().ToList();
            if (model.TitleSearchAsk == null && model.CagtegorieSearchAsk == null
                && model.TownSearchAsk == null)
            {
                liste = liste.Where(m => m.SearchOrAskJob == searchOrAsk).ToList();
                TempData["listeSearchAsk"] = liste;
            }
            else if (model.TitleSearchAsk != null && model.CagtegorieSearchAsk != null
                && model.TownSearchAsk != null)
            {


                 liste = liste.Where(m => m.SearchOrAskJob == searchOrAsk
                  && m.Category.CategoryName == model.CagtegorieSearchAsk && m.Town == model.TownSearchAsk && m.Title.ToLower().Contains(model.TitleSearchAsk.ToLower())
                  || m.Description.ToLower().Contains(model.TitleSearchAsk.ToLower())).ToList();
                TempData["listeSearchAsk"] = liste;
            }
            else if(model.TitleSearchAsk == null && model.CagtegorieSearchAsk != null
                && model.TownSearchAsk != null)
            {
                liste = liste.Where(m => m.SearchOrAskJob == searchOrAsk
               && m.Category.CategoryName == model.CagtegorieSearchAsk && m.Town == model.TownSearchAsk).ToList();
                TempData["listeSearchAsk"] = liste;
            }
            else if (model.TitleSearchAsk == null && model.CagtegorieSearchAsk == null
               && model.TownSearchAsk != null)
            {
                liste = liste.Where(m => m.SearchOrAskJob == searchOrAsk &&  m.Town == model.TownSearchAsk).ToList();
                TempData["listeSearchAsk"] = liste;
            }
            else if (model.TitleSearchAsk == null && model.CagtegorieSearchAsk != null
              && model.TownSearchAsk == null)
            {
                liste = liste.Where(m => m.SearchOrAskJob == searchOrAsk && m.Category.CategoryName == model.CagtegorieSearchAsk).ToList();
                TempData["listeSearchAsk"] = liste;
            }
            else if (model.TitleSearchAsk != null && model.CagtegorieSearchAsk == null
             && model.TownSearchAsk != null)
            {
                liste = liste.Where(m => m.SearchOrAskJob == searchOrAsk && m.Town == model.TownSearchAsk && m.Title.ToLower().Contains(model.TitleSearchAsk.ToLower())
                 || m.Description.ToLower().Contains(model.TitleSearchAsk.ToLower())).ToList();
                TempData["listeSearchAsk"] = liste;
            }
            else if (model.TitleSearchAsk != null && model.CagtegorieSearchAsk != null
           && model.TownSearchAsk == null)
            {
                liste = liste.Where(m => m.SearchOrAskJob == searchOrAsk && m.Category.CategoryName == model.CagtegorieSearchAsk && m.Title.ToLower().Contains(model.TitleSearchAsk.ToLower())
                || m.Description.ToLower().Contains(model.TitleSearchAsk.ToLower())).ToList();
                TempData["listeSearchAsk"] = liste;
            }
            else if (model.TitleSearchAsk != null && model.CagtegorieSearchAsk == null
          && model.TownSearchAsk == null)
            {
                liste = liste.Where(m => m.SearchOrAskJob == searchOrAsk && m.Title.ToLower().Contains(model.TitleSearchAsk.ToLower())
                || m.Description.ToLower().Contains(model.TitleSearchAsk.ToLower())).ToList();
                TempData["listeSearchAsk"] = liste;
            }
            //switch (sortBy)
            //{
            //    case "Price desc":
            //        liste = liste.OrderByDescending(m => m.Price).ToList();
            //        break;
            //    case "Price asc":
            //        liste = liste.OrderBy(m => m.Price).ToList();
            //        break;
            //    case "date desc":
            //        liste = liste.OrderByDescending(m => m.id).ToList();
            //        break;
            //    case "date asc":
            //        liste = liste.OrderBy(m => m.id).ToList();
            //        break;
            //    default:
            //        liste = liste.OrderByDescending(x => x.id).ToList();
            //        break;
            //}

            return RedirectToAction("ResultSearch_PartialView", model );
        }

        public ActionResult ResultSearchAsk_Jason(string category, string town, string title)
        {
            string searchOrAsk = "Je recherche";
            AskJobViewModel model = new AskJobViewModel();
            model.CagtegorieSearchAsk = category;
            model.TownSearchAsk = town;
            model.TitleSearchAsk = title;

            List<ProductModel> liste = dal.GetListProduct().ToList();
            if ( string.IsNullOrWhiteSpace(model.TitleSearchAsk) && string.IsNullOrWhiteSpace(model.CagtegorieSearchAsk)
                && string.IsNullOrWhiteSpace(model.TownSearchAsk))
            {
                liste = liste.Where(m => m.SearchOrAskJob == searchOrAsk).ToList();
                TempData["listeSearchAsk_json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TitleSearchAsk) && !string.IsNullOrWhiteSpace(model.CagtegorieSearchAsk)
                && !string.IsNullOrWhiteSpace(model.TownSearchAsk))
            {


                liste = liste.Where(m => m.SearchOrAskJob == searchOrAsk
                 && m.Category.CategoryName == model.CagtegorieSearchAsk && m.Town == model.TownSearchAsk && (m.Title.ToLower().Contains(model.TitleSearchAsk.ToLower())
                 || m.Description.ToLower().Contains(model.TitleSearchAsk.ToLower()))).ToList();
                TempData["listeSearchAsk_json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TitleSearchAsk) && !string.IsNullOrWhiteSpace(model.CagtegorieSearchAsk)
                && !string.IsNullOrWhiteSpace(model.TownSearchAsk))
            {
                liste = liste.Where(m => m.SearchOrAskJob == searchOrAsk
               && m.Category.CategoryName == model.CagtegorieSearchAsk && m.Town == model.TownSearchAsk).ToList();
                TempData["listeSearchAsk_json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TitleSearchAsk) && string.IsNullOrWhiteSpace(model.CagtegorieSearchAsk)
               && !string.IsNullOrWhiteSpace(model.TownSearchAsk))
            {
                liste = liste.Where(m => m.SearchOrAskJob == searchOrAsk && m.Town == model.TownSearchAsk).ToList();
                TempData["listeSearchAsk_json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TitleSearchAsk) && !string.IsNullOrWhiteSpace(model.CagtegorieSearchAsk)
              && string.IsNullOrWhiteSpace(model.TownSearchAsk))
            {
                liste = liste.Where(m => m.SearchOrAskJob == searchOrAsk && m.Category.CategoryName == model.CagtegorieSearchAsk).ToList();
                TempData["listeSearchAsk_json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TitleSearchAsk) && string.IsNullOrWhiteSpace(model.CagtegorieSearchAsk)
             && !string.IsNullOrWhiteSpace(model.TownSearchAsk))
            {
                liste = liste.Where(m => m.SearchOrAskJob == searchOrAsk && m.Town == model.TownSearchAsk &&( m.Title.ToLower().Contains(model.TitleSearchAsk.ToLower())
                 || m.Description.ToLower().Contains(model.TitleSearchAsk.ToLower()))).ToList();
                TempData["listeSearchAsk_json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TitleSearchAsk) && !string.IsNullOrWhiteSpace(model.CagtegorieSearchAsk)
           && string.IsNullOrWhiteSpace(model.TownSearchAsk))
            {
                liste = liste.Where(m => m.SearchOrAskJob == searchOrAsk && m.Category.CategoryName == model.CagtegorieSearchAsk && (m.Title.ToLower().Contains(model.TitleSearchAsk.ToLower())
                || m.Description.ToLower().Contains(model.TitleSearchAsk.ToLower()))).ToList();
                TempData["listeSearchAsk_json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TitleSearchAsk) && string.IsNullOrWhiteSpace(model.CagtegorieSearchAsk)
          && string.IsNullOrWhiteSpace(model.TownSearchAsk))
            {
                liste = liste.Where(m => m.SearchOrAskJob == searchOrAsk && (m.Title.ToLower().Contains(model.TitleSearchAsk.ToLower())
                || m.Description.ToLower().Contains(model.TitleSearchAsk.ToLower()))).ToList();
                TempData["listeSearchAsk_json"] = liste;
            }
            return RedirectToAction("ResultSearchJson", model);
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
                DateAdd = s.DateAdd.ToString(),
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
        public ActionResult ResultSearch_PartialView(SeachJobViewModel modelresult, int? pageNumber, string sortBy, AskJobViewModel model)
        {

            if (modelresult.CagtegorieSearch != null)
            {


                switch (modelresult.CagtegorieSearch)
                {
                    case "Emploi":
                        try
                        {

                            var result = TempData["listeJob"] as List<JobModel>;
                            if(result != null)
                            foreach (var element in result)
                            {
                                modelresult.ListePro.Add(element);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        break;
                    case "Immobilier":
                        try
                        {
                            var resultImmobilier = TempData["listeApart"] as List<ApartmentRentalModel>;
                            if(resultImmobilier != null)
                            foreach (var element in resultImmobilier)
                            {
                                modelresult.ListePro.Add(element);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        break;

                    case "Multimedia":
                        try
                        {
                            var resultMultimedia = TempData["listeMulti"] as List<MultimediaModel>;
                            if(resultMultimedia != null)
                            foreach (var element in resultMultimedia)
                            {
                                modelresult.ListePro.Add(element);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        break;

                    case "Vehicule":
                        try
                        {
                            var resultVehicule = TempData["listeVehicule"] as List<VehiculeModel>;
                            if(resultVehicule != null)
                            foreach (var element in resultVehicule)
                            {
                                modelresult.ListePro.Add(element);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        break;
                    case "Mode":
                        try
                        {
                            var resultMode = TempData["listeMode"] as List<ModeModel>;
                            if (resultMode != null)
                                foreach (var element in resultMode)
                                {
                                    modelresult.ListePro.Add(element);
                                }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        break;
                }


                if (modelresult.ListePro == null)
                {
                    modelresult.ListePro = new List<ProductModel>();
                }

                switch (sortBy)
                {
                    case "Price desc":
                        modelresult.ListePro = modelresult.ListePro.OrderByDescending(m => m.Price).ToList();
                        modelresult.ListeProPagedList = modelresult.ListePro.ToPagedList(pageNumber ?? 1, 2);
                        break;
                    case "Price asc":
                        modelresult.ListePro = modelresult.ListePro.OrderBy(m => m.Price).ToList();
                        modelresult.ListeProPagedList = modelresult.ListePro.ToPagedList(pageNumber ?? 1, 2);
                        break;
                    case "date desc":
                        modelresult.ListePro = modelresult.ListePro.OrderByDescending(m => m.id).ToList();
                        modelresult.ListeProPagedList = modelresult.ListePro.ToPagedList(pageNumber ?? 1, 2);
                        break;
                    case "date asc":
                        modelresult.ListePro = modelresult.ListePro.OrderBy(m => m.id).ToList();
                        modelresult.ListeProPagedList = modelresult.ListePro.ToPagedList(pageNumber ?? 1, 2);
                        break;
                    default:
                        modelresult.ListePro = modelresult.ListePro.OrderByDescending(x => x.id).ToList();
                        modelresult.ListeProPagedList = modelresult.ListePro.ToPagedList(pageNumber ?? 1, 2);
                        break;
                }
                return PartialView(modelresult);
            }
            else 
            {

               modelresult = new SeachJobViewModel();
                modelresult.ListePro = new List<ProductModel>();
                modelresult.CagtegorieSearch = "AskSearch";
                try
                {

                    var result = TempData["listeSearchAsk"] as List<ProductModel>;
                    if(result != null)
                    {
 foreach (var element in result)
                    {
                        modelresult.ListePro.Add(element);
                    }
                    }
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                switch (sortBy)
                {
                    case "Price desc":
                        modelresult.ListePro = modelresult.ListePro.OrderByDescending(m => m.Price).ToList();
                        modelresult.ListeProPagedList = modelresult.ListePro.ToPagedList(pageNumber ?? 1, 10);
                        break;
                    case "Price asc":
                        modelresult.ListePro = modelresult.ListePro.OrderBy(m => m.Price).ToList();
                        modelresult.ListeProPagedList = modelresult.ListePro.ToPagedList(pageNumber ?? 1, 10);
                        break;
                    case "date desc":
                        modelresult.ListePro = modelresult.ListePro.OrderByDescending(m => m.id).ToList();
                        modelresult.ListeProPagedList = modelresult.ListePro.ToPagedList(pageNumber ?? 1, 10);
                        break;
                    case "date asc":
                        modelresult.ListePro = modelresult.ListePro.OrderBy(m => m.id).ToList();
                        modelresult.ListeProPagedList = modelresult.ListePro.ToPagedList(pageNumber ?? 1, 10);
                        break;
                    default:
                        modelresult.ListePro = modelresult.ListePro.OrderByDescending(x => x.id).ToList();
                        modelresult.ListeProPagedList = modelresult.ListePro.ToPagedList(pageNumber ?? 1, 10);
                        break;
                }

                return PartialView(modelresult);
            }
            
            // modelresult.ListePro = TempData["listeJob"] as List<ProductModel>;
            // modelresult.ListePro = dal.GetListProduct().Where(r => r.Title.IndexOf(modelresult.TitleJobSearch, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();

          

            
        }

        public JsonResult ResultSearchJson(SeachJobViewModel modelresult, AskJobViewModel model)
        {
            List<JobModel> result = TempData["listeJobJson"] as List<JobModel>;
            List<MultimediaModel> resultMultimedia = TempData["listeMulti_Json"] as List<MultimediaModel>;
            List<VehiculeModel> resultVehicule = TempData["listeVehicule_Json"] as List<VehiculeModel>;
            List<ModeModel> resultMode = TempData["listeMode_json"] as List<ModeModel>;
            List<ProductModel> resultSearchAsk = TempData["listeSearchAsk_json"] as List<ProductModel>;
            List<ApartmentRentalModel> resultImmobilier = TempData["listeApartJson"] as List<ApartmentRentalModel>;
            List<DataJsonProductViewModel> data = new List<DataJsonProductViewModel>() ;
            if (modelresult.CagtegorieSearch != null)
            {

                switch (modelresult.CagtegorieSearch)
                {
                    case "Emploi":
                        if(result!= null)
                        foreach (var element in result)
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
                            DateAdd = s.DateAdd.ToString(),
                            Images = s.Images.Select(o => o.Image).ToList(),
                            User = s.User,
                            Street = s.Street,
                            Town = s.Town
                        }).ToList();
                        break;
                    case "Immobilier":
                        if(resultImmobilier != null)
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
                            DateAdd = s.DateAdd.ToString(),
                            Images = s.Images.Select(o => o.Image).ToList(),
                            User = s.User,
                            Street = s.Street,
                            Town = s.Town
                        }).ToList();
                        break;

                    case "Multimedia":
                        if(resultMultimedia != null)
                        foreach (var element in resultMultimedia)
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
                            DateAdd = s.DateAdd.ToString(),
                            Images = s.Images.Select(o => o.Image).ToList(),
                            User = s.User,
                            Street = s.Street,
                            Town = s.Town
                        }).ToList();
                        break;

                    case "Vehicule":
                        if(resultVehicule != null)
                        foreach (var element in resultVehicule)
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
                            DateAdd = s.DateAdd.ToString(),
                            Images = s.Images.Select(o => o.Image).ToList(),
                            User = s.User,
                            Street = s.Street,
                            Town = s.Town
                        }).ToList();
                        break;
                    case "Mode":
                        if (resultMode != null)
                            foreach (var element in resultMode)
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
                            DateAdd = s.DateAdd.ToString(),
                            Images = s.Images.Select(o => o.Image).ToList(),
                            User = s.User,
                            Street = s.Street,
                            Town = s.Town
                        }).ToList();
                        break;
                }
            }
            else
            {
                modelresult = new SeachJobViewModel();
                modelresult.ListePro = new List<ProductModel>();
                try
                {
                    foreach (var element in resultSearchAsk)
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
                    DateAdd = s.DateAdd.ToString(),
                    Images = s.Images.Select(o => o.Image).ToList(),
                    User = s.User,
                    Street = s.Street,
                    Town = s.Town
                }).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                
            }

            if (modelresult.ListePro == null)
            {
                modelresult.ListePro = new List<ProductModel>();
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult ContactProductUser_PartialView(contactUserViewModel vm)
        {
         
                return PartialView (vm);
           
        }
        [HttpPost]
        public async Task< ActionResult> ContactProductUser(contactUserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
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
                    ViewBag.Message = "Message envoyé avec succès ";
                }catch(Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" désolé il y'a un problème {ex.Message}";
                }
            }

            return PartialView("ContactProductUser_PartialView",vm);
        }

      
        private async Task configSendGridasync(contactUserViewModel message)
        {

            
            var apikey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            //var apiKey = ConfigurationManager.AppSettings["mailPasswordSendGrid"];
            var client = new SendGridClient(apikey);
            var from = new EmailAddress("contact@lookaukwat.com", message.NameSender +"(NoReply Here)");
            var subject = message.SubjectSender;
            var to = new EmailAddress(message.RecieverEmail, message.RecieverName);
            var plainTextContent = "<a href='lookaukwat.azurewebsites.net'><img src=" + @Url.Content("~/UserImage/lookaukwat_logo.jpg") + " alt='lien vers le site' style='height: 50px;' /><br/><br/> <strong style='height: 20px;'>LookAuKwat</strong></a> " +
                "Hello <br/><br/> vous avez un nouveau message sur votre annonce dans <strong style='color:blue;Height:20px;'> LookAuKwat! </strong> <br/> " +
               " <a href =\"" + message.Linkshare + "\">" + message.Linkshare + "</a> <br/>" + message.Message+ " <br/>" + "<br/>"
               + "Vous pouvez lui répondre aussi sur son email suivant : "+" <a href =\"mailto:" + message.EmailSender + "\">" + message.EmailSender + "</a>";

            var htmlContent = "<a href='lookaukwat.azurewebsites.net'><img src=" + @Url.Content("~/UserImage/lookaukwat_logo.jpg") + " alt='lien vers le site' style='height: 50px;' /><br/><br/> <strong style='height: 20px;'>LookAuKwat</strong></a> "
               + "Hello <br/><br/> vous avez un nouveau message sur votre annonce dans <strong style='color:blue;Height:20px;'> LookAuKwat! </strong> <br/> " +
               " <a href =\"" + message.Linkshare + "\">" + message.Linkshare + "</a> <br/>" + message.Message + " <br/>" + "<br/>"
               + "Vous pouvez lui répondre aussi sur son email suivant : " + " <a href =\"mailto:" + message.EmailSender + "\">" + message.EmailSender + "</a>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            
           List< string >files = AttachFileMessage(message);
            if (files != null)
            {
                byte[] byteData = System.IO.File.ReadAllBytes(files[1]);
                var Content = Convert.ToBase64String(byteData);
                msg.AddAttachment(files[0], Content); 
            //        new List<SendGrid.Helpers.Mail.Attachment>
            //{
            //    new SendGrid.Helpers.Mail.Attachment
            //    {
            //        Content = Convert.ToBase64String(byteData),
            //        Filename = file,
                   
            //        Disposition = "attachment"
            //    }
            //};
            }
               
            var response = await client.SendEmailAsync(msg);

            //message.Message = "Hello <br/> vous avez un nouveau message sur votre annonce dans LookAuKwat! <br/> " +
            //   " <a href =\"" + message.Linkshare + "\">" + message.Linkshare + "</a> <br/>"+ message.Message;
            //var myMessage = new SendGridMessage();
            //myMessage.AddTo(message.user);
            //myMessage.From = new System.Net.Mail.MailAddress(
            //                    message.EmailSender, message.NameSender);
            //myMessage.Subject = message.SubjectSender;
            //myMessage.Text = message.Message;
            //myMessage.Html = message.Message;
            //string file = AttachFileMessage(message);
            //if (file != null)
            //{
            //    myMessage.AddAttachment(file);
            //}


            //if (message.file != null)
            //{

            //    //Save image name path
            //    string FileName = Path.GetFileNameWithoutExtension(message.file.FileName);

            //    // save extension of image
            //    string FileExtension = Path.GetExtension(message.file.FileName);

            //    //Add a curent date to attached file name
            //    FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName + FileExtension;

            //    //Create complete path to store in server
            //    var path = Server.MapPath("~/UserImage/");
            //    if (!Directory.Exists(path))
            //    {
            //        Directory.CreateDirectory(path);
            //    }
            //    message.attachFile = $"/UserImage/{FileName}";

            //    FileName = Path.Combine(path, FileName);

            //    message.file.SaveAs(FileName);

            //}
            // myMessage.AddAttachment("C:/Users/wangu/OneDrive/Bureau/LOGEMENT/barman.png");

            //var credentials = new NetworkCredential(
            //           ConfigurationManager.AppSettings["mailAccountSendGrid"],
            //           ConfigurationManager.AppSettings["mailPasswordSendGrid"]
            //           );

            //// Create a Web transport for sending email.
            //var transportWeb = new Web(credentials);

            //// Send the email.
            //if (transportWeb != null)
            //{

            //   await transportWeb.DeliverAsync(myMessage);

            //}
            //else
            //{
            //    Trace.TraceError("Failed to create Web transport.");
            //    await Task.FromResult(0);
            //}

        }

        private List<string> AttachFileMessage(contactUserViewModel contact)
        {
            List<string> list = new List<string>();
            if (contact.file != null)
            {
               
                //Save image name path
                string FileName = Path.GetFileNameWithoutExtension(contact.file.FileName);
               
                // save extension of image
                string FileExtension = Path.GetExtension(contact.file.FileName);

                //Add extension to attached file name
                FileName = FileName + FileExtension;

                //name for mail attachement
                string NameMailAttachement = FileName;
                list.Add(NameMailAttachement);

                //Add a curent date to attached file name
                FileName = DateTime.Now.ToString("yyyyMMdd") + "-"+FileName;

                //Create complete path to store in server
                var path = Server.MapPath("~/UserImage/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                contact.attachFile = $"/UserImage/{FileName}";

                FileName = Path.Combine(path, FileName);

                contact.file.SaveAs(FileName);
                list.Add(FileName);
                return list;
            }
            else
                return null;
        }
    }
}