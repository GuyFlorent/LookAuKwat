using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using Microsoft.Ajax.Utilities;
using PagedList;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Twilio.Jwt.AccessToken;

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

      //  [OutputCache(Duration = 10000, VaryByParam = "id;CategoryName")]
        public ActionResult SimilarProduct_PartialView(ProductModel model)
        {
            //var ran = new Random();
            List<ProductModel> similarList =  dal.GetListProductWhithNoInclude().Where(l => l.Category.CategoryName == model.Category.CategoryName
            && l.Town == model.Town && l.SearchOrAskJob == model.SearchOrAskJob && l.id != model.id).OrderBy(x => Guid.NewGuid()).Take(6).ToList();
            return PartialView( similarList);
        }
        public ActionResult ListProduct()
        {
            IEnumerable<ProductModel> liste =  dal.GetListProductWhithNoInclude();
            return View(liste);
        }

       // [OutputCache(Duration = 300, VaryByParam = "TownAllProduct;SearchTermAllProduct;pageNumber;sortBy")]
        public ActionResult  SearchAllProoduct(SeachJobViewModel model, int? pageNumber, string sortBy)
        {
            ViewBag.PriceAscSort = String.IsNullOrEmpty(sortBy) ? "Price desc" : "";
            ViewBag.PriceDescSort = sortBy == "Prix croissant" ? "Price asc" : "";
            ViewBag.DateAscSort = sortBy == "Plus anciennes" ? "date asc" : "";
            ViewBag.DateDescSort = sortBy == "Plus recentes" ? "date desc" : "";
            //IQueryable<ProductModel> liste =  dal.GetListProductWhithNoInclude();
            List<ProductToDisplay> liste =  dal.GetListProductToDisplay();
           
            if (!string.IsNullOrWhiteSpace(model.TownAllProduct))
            {
                liste =  liste.Where(m => m.Town != null && m.Town == model.TownAllProduct).ToList();
            }
            if (!string.IsNullOrWhiteSpace(model.SearchTermAllProduct))
            {
                liste =  liste.Where(m => (m.Title!=null && m.Title.ToLower().Contains(model.SearchTermAllProduct.ToLower()))
                || (m.Description!=null && m.Description.ToLower().Contains(model.SearchTermAllProduct.ToLower())) || 
               (m.Street!=null && m.Street.ToLower().Contains(model.SearchTermAllProduct.ToLower())) || 
               (m.SearchOrAskJob!=null && m.SearchOrAskJob.ToLower().Contains(model.SearchTermAllProduct.ToLower()))).ToList();
            }
            ViewBag.number = liste.Count();
            switch (sortBy)
            {
                case "Price desc":
                    liste = liste.OrderByDescending(m => m.Price).ToList();
                    break;
                case "Price asc":
                    liste = liste.OrderBy(m => m.Price).ToList();
                    break;
                case "date desc":
                    liste = liste.OrderByDescending(m => m.id).ToList();
                    break;
                case "date asc":
                    liste = liste.OrderBy(m => m.id).ToList();
                    break;
                default:
                    liste = liste.OrderByDescending(x => x.id).ToList();
                    break;
            }

            //model.ListeProduct = liste;
            //model.PageNumber = pageNumber;

            model.ListeProductPagedList = liste.ToPagedList(pageNumber ?? 1, 10);
            return View("ListeAllProduct", model); 
        }

        
        public ActionResult ListeAllProduct(SeachJobViewModel model)
        {
          
            return View(model);
        }
        public ActionResult SearchAllProduct_PartialView(SeachJobViewModel model)
        {
          
            return PartialView(model);
        }

        public ActionResult SearchAllProductMapView_PartialView(SeachJobViewModel model)
        {

            return PartialView(model);
        }

        //for ask only ask
        public ActionResult SearchAskProduct_PartialView(AskJobViewModel model)
        {
            return PartialView(model);
        }

        public ActionResult FilterSearchAskProduct(AskJobViewModel model)
        {
            return View(model);
        }
        public ActionResult ResultSearchAskProduct_PartialView(AskJobViewModel model, int? pageNumber, string sortBy)
        {
            string searchOrAsk = "Je recherche";
            ViewBag.PriceAscSort = String.IsNullOrEmpty(sortBy) ? "Price desc" : "";
            ViewBag.PriceDescSort = sortBy == "Prix croissant" ? "Price asc" : "";
            ViewBag.DateAscSort = sortBy == "Plus anciennes" ? "date asc" : "";
            ViewBag.DateDescSort = sortBy == "Plus recentes" ? "date desc" : "";
            model.sortBy = sortBy;
            model.PageNumber = pageNumber;
            List < ProductModel> liste = dal.GetListProduct().Where(m =>m.SearchOrAskJob == searchOrAsk).ToList();

            if (!string.IsNullOrWhiteSpace(model.TownSearchAsk))
            {
                liste = liste.Where(m => m.Town != null && m.Town == model.TownSearchAsk).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.CagtegorieSearchAsk))
            {
                liste = liste.Where(m => m.Category != null && m.Category.CategoryName == model.CagtegorieSearchAsk).ToList();
            }

            if (!string.IsNullOrWhiteSpace(model.TitleSearchAsk))
            {
                liste = liste.Where(m => m.Title != null && m.Title.ToLower().Contains(model.TitleSearchAsk.ToLower())
                  || m.Description != null && m.Description.ToLower().Contains(model.TitleSearchAsk.ToLower())).ToList();
            }

            model.ListePro = liste;

            switch (sortBy)
            {
                case "Price desc":
                    liste = liste.OrderByDescending(m => m.Price).ToList();
                    model.ListeProPagedList = liste.ToPagedList(pageNumber ?? 1, 10);
                    break;
                case "Price asc":
                    liste = liste.OrderBy(m => m.Price).ToList();
                    model.ListeProPagedList = liste.ToPagedList(pageNumber ?? 1, 10);
                    break;
                case "date desc":
                    liste = liste.OrderByDescending(m => m.id).ToList();
                    model.ListeProPagedList = liste.ToPagedList(pageNumber ?? 1, 10);
                    break;
                case "date asc":
                    liste = liste.OrderBy(m => m.id).ToList();
                    model.ListeProPagedList = liste.ToPagedList(pageNumber ?? 1, 10);
                    break;
                default:
                    liste = liste.OrderByDescending(x => x.id).ToList();
                    model.ListeProPagedList = liste.ToPagedList(pageNumber ?? 1, 10);
                    break;
            }
           
           

            return View("FilterSearchAskProduct", model );
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


            public ActionResult listAllProductViewMapReturnJson(SeachJobViewModel model)
        {
            //List<ProductModel> liste = dal.GetListProductWhithNoInclude().ToList();
            //if (!string.IsNullOrWhiteSpace(model.TownAllProduct))
            //{
            //    liste = liste.Where(m => m.Town == model.TownAllProduct).ToList();
            //}
            //if (!string.IsNullOrWhiteSpace(model.SearchTermAllProduct))
            //{
            //    liste = liste.Where(m => m.Title != null && m.Title.ToLower().Contains(model.SearchTermAllProduct.ToLower())
            //    || m.Description != null && m.Description.ToLower().Contains(model.SearchTermAllProduct.ToLower()) ||
            //    m.Street.ToLower().Contains(model.SearchTermAllProduct.ToLower()) ||
            //    m.SearchOrAskJob.ToLower().Contains(model.SearchTermAllProduct.ToLower())).ToList();
           // }
            

            return View(model);
        }

        public async Task< JsonResult> listAllProductViewMapReturnJsonn(string term, string town)
        {
            List<ProductModel> liste = await dal.GetListProductWhithNoInclude().ToListAsync();
            if (!string.IsNullOrWhiteSpace(town))
            {
                liste = liste.Where(m => m.Town == town).ToList();
            }
            if (!string.IsNullOrWhiteSpace(term))
            {
                liste =  liste.Where(m => (m.Title!=null && m.Title.ToLower().Contains(term.ToLower()))
                || (m.Description!=null && m.Description.ToLower().Contains(term.ToLower())) || 
               (m.Street!=null && m.Street.ToLower().Contains(term.ToLower())) || 
               (m.SearchOrAskJob!=null && m.SearchOrAskJob.ToLower().Contains(term.ToLower()))).ToList();
            }
            var data2 = liste.Select(s => new DataJsonProductViewModel
            {
                Title = s.Title,
                Lat = s.Coordinate.Lat,
                Lon = s.Coordinate.Lon,
                id = s.id,
                Images = s.Images.Select(o => o.Image).FirstOrDefault(),
                Town = s.Town,
                Category = s.Category.CategoryName
            }).ToList();

            return Json(data2, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listAllProductSpanReturnJson(string town, string term)
        {
            List<ProductModel> liste = dal.GetListProductWhithNoInclude().ToList();
            if (!string.IsNullOrWhiteSpace(town))
            {
                liste = liste.Where(m => m.Town == town).ToList();
            }
            if (!string.IsNullOrWhiteSpace(term))
            {
                liste = liste.Where(m => (m.Title != null && m.Title.ToLower().Contains(term.ToLower()))
                 || (m.Description != null && m.Description.ToLower().Contains(term.ToLower())) ||
                (m.Street != null && m.Street.ToLower().Contains(term.ToLower())) ||
                (m.SearchOrAskJob != null && m.SearchOrAskJob.ToLower().Contains(term.ToLower()))).ToList();
            }
            var data2 = liste.Count();

            return Json(data2, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listProductReturnJson()
        {
            IEnumerable<int> data1 = dal.GetListIdProduct();


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
                ImageProcductModel img = dal.GetImageList().FirstOrDefault(s => s.id == guid);
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
        public async Task <JsonResult> DeleteProduct(int id)
        {
           

                try
                {


                string requestUri = "https://lookaukwatapi.azurewebsites.net/api/Product/?id=" + id;
                using (HttpClient client = new HttpClient())
                {

                    var result = await client.DeleteAsync(requestUri);
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Created";
                        return Json(new { Result = "OK" });
                    }
                    else
                    {
                        ViewBag.Message = "Failed";
                        return Json(new { Result = "Failed" });
                    }

                }


                //ProductModel pro = dal.GetListProductWhithNoInclude().FirstOrDefault(s => s.id == id);
                //if (pro == null)
                //{

                //    Response.StatusCode = (int)HttpStatusCode.NotFound;
                //    return Json(new { Result = "Error" });
                //}

                ////delete files from the file system
                //String path = null;
                //    foreach (var item in pro.Images)
                //    {
                //        if (item.Image.StartsWith("http"))
                //        {
                //            path = item.Image;
                //            dal.DeleteImage(item);
                //        }
                //        else
                //        {
                //            path = Request.MapPath(item.Image);
                //            dal.DeleteImage(item);
                //        }

                //        if (System.IO.File.Exists(path))
                //        {
                //            System.IO.File.Delete(path);
                //        }
                //    }

                //    dal.DeleteProduct(pro);


                //return Json(new { Result = "OK" });
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
            List<HouseModel> resultHouse = TempData["listeHouse_json"] as List<HouseModel>;
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
                            Lat = s.Coordinate.Lat,
                            Lon = s.Coordinate.Lon,
                            id = s.id,
                            Images = s.Images.Select(o => o.Image).FirstOrDefault(),
                            Town = s.Town,
                            Category = s.Category.CategoryName
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
                            Lat = s.Coordinate.Lat,
                            Lon = s.Coordinate.Lon,
                            id = s.id,
                            Images = s.Images.Select(m =>m.Image).FirstOrDefault(),
                            Town = s.Town,
                            Category = s.Category.CategoryName
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
                            Lat = s.Coordinate.Lat,
                            Lon = s.Coordinate.Lon,
                            id = s.id,
                            Images = s.Images.Select(o => o.Image).FirstOrDefault(),
                            Town = s.Town,
                            Category = s.Category.CategoryName
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
                            Lat = s.Coordinate.Lat,
                            Lon = s.Coordinate.Lon,
                            id = s.id,
                            Images = s.Images.Select(o => o.Image).FirstOrDefault(),
                            Town = s.Town,
                            Category = s.Category.CategoryName
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
                            Lat = s.Coordinate.Lat,
                            Lon = s.Coordinate.Lon,
                            id = s.id,
                            Images = s.Images.Select(o => o.Image).FirstOrDefault(),
                            Town = s.Town,
                            Category = s.Category.CategoryName
                            
                        }).ToList();
                        break;
                         case "Maison":
                        if (resultHouse != null)
                            foreach (var element in resultHouse)
                            {
                                modelresult.ListePro.Add(element);
                            }
                        data = modelresult.ListePro.Select(s => new DataJsonProductViewModel
                        {
                            Title = s.Title,
                            Lat = s.Coordinate.Lat,
                            Lon = s.Coordinate.Lon,
                            id = s.id,
                            Images = s.Images.Select(o => o.Image).FirstOrDefault(),
                            Town = s.Town,
                            Category = s.Category.CategoryName
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
                    Lat = s.Coordinate.Lat,
                    Lon = s.Coordinate.Lon,
                    id = s.id,
                    Images = s.Images.Select(o => o.Image).FirstOrDefault(),
                    Town = s.Town,
                    Category = s.Category.CategoryName
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

        [HttpPost]
        public async Task<ActionResult> ContactUs(contactUserViewModel vm)
        {
            string text = null;
            if (ModelState.IsValid)
            {
                try
                {


                   await configSendGridasync(vm);
                    
                    text = "Message envoyé avec succès ";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    text = $" désolé il y'a un problème {ex.Message}";
                }
            }

            return RedirectToAction("Contact", "Home", new { text = text });
        }

        private async Task configSendGridasync(contactUserViewModel message)
        {

            var apikey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            //var apiKey = ConfigurationManager.AppSettings["mailPasswordSendGrid"];
            var client = new SendGridClient(apikey);
            var from = new EmailAddress("contact@lookaukwat.com", message.NameSender + "(Ne pas répondre ici)");
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