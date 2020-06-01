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
            DateAdd = DateTime.Now.ToString(),
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


                        return RedirectToAction("GetListProductByUser_PartialView","User");
                        }


                    }

            }
            return View(job);
        }

        public ActionResult EditJob_PartialView(JobModel job)
        {
             
            if (job.id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (job == null)
            {
                return HttpNotFound();
            }
            JobEditViewModel model = new JobEditViewModel()
            {
                JobEditid = job.id,
                TitleJob = job.Title,
                DescriptionJob = job.Description,
                TypeContractJob = job.TypeContract,
                TownJob = job.Town,
                PriceJob = job.Price,
                StreetJob = job.Street,
                ActivitySectorJob = job.ActivitySector,
                DateAddJob = DateTime.Now.ToString(),
                SearchOrAskJobJob = job.SearchOrAskJob,
                listeImageJob = job.Images

            };

            return PartialView(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditJob(JobEditViewModel job, ImageModelView userImage)
        {
           

            if (ModelState.IsValid)
            {

                string userId = User.Identity.GetUserId();
                ApplicationUser user = dal.GetUserByStrId(userId);
                JobModel model = new JobModel()
                {
                    id = job.JobEditid,
                    Title = job.TitleJob,
                    Description = job.DescriptionJob,
                    TypeContract = job.TypeContractJob,
                    Town = job.TownJob,
                    Price = job.PriceJob,
                    Street = job.StreetJob,
                    ActivitySector = job.ActivitySectorJob,
                    DateAdd = DateTime.Now.ToString(),
                    SearchOrAskJob = job.SearchOrAskJobJob,
                    Category = new CategoryModel { CategoryName = "Emploi" },
                    User = user

                };

                using (var httpClient = new HttpClient())
                {

                   

                    var fullAddress = $"{model.Street}";
                    var response = await httpClient.GetAsync("https://api.opencagedata.com/geocode/v1/json?q=" + fullAddress + "&key=a196040df44a4a41a471173aed07635c");

                    if (response.IsSuccessStatusCode)
                    {

                        var jsonn = await response.Content.ReadAsStringAsync();
                        var joo = JObject.Parse(jsonn);
                        var latt = (string)joo["results"][0]["geometry"]["lat"];
                        var lonn = (string)joo["results"][0]["geometry"]["lng"];

                        List<ImageProcductModel> images = ImageEdit(userImage,model);

                        model.Images = images;
                       
                        dal.EditJob(model, latt, lonn);

                       
                        return RedirectToAction("GetListProductByUser_PartialView", "User");
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
            if (userImage.ImageFile != null)
            {


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
                        var path = Server.MapPath("~/UserImage/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        userImage.Image = $"/UserImage/{FileName}";
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
            else
            {
                ImageProcductModel picture = new ImageProcductModel
                {
                    id = Guid.NewGuid(),
                    Image = "https://particulier-employeur.fr/wp-content/themes/fepem/img/general/avatar.png"
                };
                liste.Add(picture);

            }return liste;
        }


        private List<ImageProcductModel> ImageEdit(ImageModelView userImage, ProductModel product)
        {

            List<ImageProcductModel> liste = new List<ImageProcductModel>();
            if (userImage.ImageFile != null)
            {

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
                        var path = Server.MapPath("~/UserImage/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        userImage.Image = $"/UserImage/{FileName}";
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
            else
            {
               // Guid guid = new Guid(userImage.id);
                List<ImageProcductModel> picture = dal.GetImageList().Where(s => s.ProductId == product.id).ToList();
                   foreach(var im in picture)
                {
                    liste.Add(im);
                }
                
            }return liste;
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

        public ActionResult JobDetail(int id)
        {
            JobModel model = dal.GetListJob().FirstOrDefault(e => e.id == id);
            return View(model);
        }
        

    }
}