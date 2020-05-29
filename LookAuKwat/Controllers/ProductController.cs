using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
            var data2 = dal.GetListProduct().Select(m =>m.Coordinate);

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
            List<ProductCoordinateModel> data = new List<ProductCoordinateModel>() ;
            switch (modelresult.CagtegorieSearch)
            {
                case "Emploi":
                    
                    foreach (var element in result)
                    {
                        modelresult.ListePro.Add(element);
                    }
                    data = modelresult.ListePro.Select(s=>s.Coordinate).ToList();
                    break;
                case "Immobilier":

                    foreach (var element in resultImmobilier)
                    {
                        modelresult.ListePro.Add(element);
                    }
                    data = modelresult.ListePro.Select(s => s.Coordinate).ToList();
                    break;
            }


            if (modelresult.ListePro == null)
            {
                modelresult.ListePro = new List<ProductModel>();
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }


    }
}