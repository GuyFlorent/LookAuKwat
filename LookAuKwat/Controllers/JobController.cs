using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LookAuKwat.Controllers
{
    public class JobController : Controller
    {
        private IDal dal;
        public JobController() : this(new Dal())
        {

        }

        public JobController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: Job
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddJobs_PartialView()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> AddJobs_PartialView(JobViewModel job, ImageModelView userImage)
        {
            JobModel model = new JobModel()
            {
                 id = job.id,
            Title = job.Title,
            Description = job.Description,
            TypeContract = job.TypeContract,
            Town = job.Town,
            Price = job.Price,
            Street = job.Street,
            ActivitySector = job.ActivitySector,
            DateAdd = DateTime.Now,
            SearchOrAskJob = job.SearchOrAskJob,
            
            
        };
           

            if (ModelState.IsValid)
            {

                using (var httpClient = new HttpClient())
                {

                    string userId = User.Identity.GetUserId();
                    ApplicationUser user = dal.GetUserByStrId(userId);

                    var fullAddress = $"{model.Town+","+model.Street+",Cameroon"}";
                    var response = await httpClient.GetAsync("https://api.opencagedata.com/geocode/v1/json?q=" + fullAddress + "&key=a196040df44a4a41a471173aed07635c");
                  
                    if (response.IsSuccessStatusCode)
                    {
                   
                            var jsonn = await response.Content.ReadAsStringAsync();
                            var joo = JObject.Parse(jsonn);
                            var latt = (string)joo["results"][0]["geometry"]["lat"];
                            var lonn = (string)joo["results"][0]["geometry"]["lng"];

                        List<ImageProcductModel> images = ImageAdd(userImage);
                        
                        model.Images = images;
                        model.User = user;
                        model.Category = new CategoryModel { CategoryName = "Emploi" };
                        dal.AddJob(model,latt,lonn);

                        //if (userImage.ImageFile != null)
                        //{
                        //    string image = ImageAdd(userImage);
                        //    dal.AddJob(model, image, userId, latt, lonn);
                        //}
                        //else
                        //{
                        //    string image = "https://particulier-employeur.fr/wp-content/themes/fepem/img/general/avatar.png";
                        //    dal.AddJob(model, image, userId, latt, lonn);
                        //}

                        return RedirectToAction("ListUserInitiative_PartialView");
                        }


                    }

            }
            return View(job);
        }

        public ActionResult EditJob_PartialView(JobModel job)
        {
            int? id = job.id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (job == null)
            {
                return HttpNotFound();
            }
            JobViewModel model = new JobViewModel()
            {
                id = job.id,
                Title = job.Title,
                Description = job.Description,
                TypeContract = job.TypeContract,
                Town = job.Town,
                Price = job.Price,
                Street = job.Street,
                ActivitySector = job.ActivitySector,
                DateAdd = DateTime.Now,
                SearchOrAskJob = job.SearchOrAskJob,


            };

            return PartialView(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditJob(JobViewModel job, ImageModelView userImage)
        {
            JobModel model = new JobModel()
            {
                id = job.id,
                Title = job.Title,
                Description = job.Description,
                TypeContract = job.TypeContract,
                Town = job.Town,
                Price = job.Price,
                Street = job.Street,
                ActivitySector = job.ActivitySector,
                DateAdd = DateTime.Now,
                SearchOrAskJob = job.SearchOrAskJob,


            };


            if (ModelState.IsValid)
            {

                using (var httpClient = new HttpClient())
                {

                    string userId = User.Identity.GetUserId();
                    ApplicationUser user = dal.GetUserByStrId(userId);

                    var fullAddress = $"{model.Town + "," + model.Street + ",Cameroon"}";
                    var response = await httpClient.GetAsync("https://api.opencagedata.com/geocode/v1/json?q=" + fullAddress + "&key=a196040df44a4a41a471173aed07635c");

                    if (response.IsSuccessStatusCode)
                    {

                        var jsonn = await response.Content.ReadAsStringAsync();
                        var joo = JObject.Parse(jsonn);
                        var latt = (string)joo["results"][0]["geometry"]["lat"];
                        var lonn = (string)joo["results"][0]["geometry"]["lng"];

                        List<ImageProcductModel> images = EditAdd(userImage,model);

                        model.Images = images;
                        //model.User = user;
                        //model.Category = new CategoryModel { CategoryName = "Emploi" };
                        dal.EditJob(model, latt, lonn);

                        //if (userImage.ImageFile != null)
                        //{
                        //    string image = ImageAdd(userImage);
                        //    dal.AddJob(model, image, userId, latt, lonn);
                        //}
                        //else
                        //{
                        //    string image = "https://particulier-employeur.fr/wp-content/themes/fepem/img/general/avatar.png";
                        //    dal.AddJob(model, image, userId, latt, lonn);
                        //}

                        return RedirectToAction("ListUserInitiative_PartialView");
                    }


                }

            }
            return View(job);
        }

        public ActionResult JobDetails_PartialView(JobModel model)
        {

            return PartialView(model);
        }



        private List<ImageProcductModel> ImageAdd(ImageModelView userImage)
        {
            
            List<ImageProcductModel> liste = new List<ImageProcductModel>();
            foreach (var image in userImage.ImageFile)
            {

                if (image != null && image.ContentLength > 0)
                {


                    //Save image name path
                    string FileName = Path.GetFileNameWithoutExtension(image.FileName);

                    // save extension of image
                    string FileExtension = Path.GetExtension(image.FileName);

                    //Add a curent date to attached file name
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName + FileExtension;

                    //Create complete path to store in server
                    var path = Server.MapPath("~/UserImages/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    userImage.Image = $"/UserImages/{FileName}";
                    ImageProcductModel picture = new ImageProcductModel
                    {
                        Image = userImage.Image,
                        id = Guid.NewGuid(),
                        
                    };
                    liste.Add(picture);
                    FileName = Path.Combine(path, FileName);

                    image.SaveAs(FileName);

                }

            }
            return liste;

        }


        private List<ImageProcductModel> EditAdd(ImageModelView userImage, ProductModel product)
        {

            List<ImageProcductModel> liste = new List<ImageProcductModel>();
            foreach (var image in userImage.ImageFile)
            {

                if (image != null && image.ContentLength > 0)
                {


                    //Save image name path
                    string FileName = Path.GetFileNameWithoutExtension(image.FileName);

                    // save extension of image
                    string FileExtension = Path.GetExtension(image.FileName);

                    //Add a curent date to attached file name
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName + FileExtension;

                    //Create complete path to store in server
                    var path = Server.MapPath("~/UserImages/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    userImage.Image = $"/UserImages/{FileName}";
                    ImageProcductModel picture = new ImageProcductModel
                    {
                        Image = userImage.Image,
                        id = Guid.NewGuid(),
                        ProductId = product.id
                    };
                    liste.Add(picture);
                    FileName = Path.Combine(path, FileName);

                    image.SaveAs(FileName);

                }

            }
            return liste;

        }

        public async Task<JsonResult> ShowAddress(string term, string town)
        {
            using (var httpClient = new HttpClient())
            {
                var fullAddress = $"{term + "," + town + "," + "Cameroun" }";
                
                    var response2 = await httpClient.GetAsync("https://api.opencagedata.com/geocode/v1/json?q=" + fullAddress + "&key=a196040df44a4a41a471173aed07635c");
                    var data = await response2.Content.ReadAsStringAsync();

                    return Json(data, JsonRequestBehavior.AllowGet);
                
            }
        }


    }
}