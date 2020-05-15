using LookAuKwat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public JsonResult listProductReturnJson()
        {
            IEnumerable<ProductModel> data = dal.GetListProduct();


            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}