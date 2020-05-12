using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public async Task<ActionResult> AddJobs_PartialView(JobViewModel job, ImageProcduct userImage)
        {
            Job model = new Job()
            {
                 id = job.id,
            Title = job.Title,
            Description = job.Description,
            TypeContract = job.TypeContract,
            Town = job.Town,
            Price = job.Price,
            Street = job.Street,
            ActivitySector = job.ActivitySector,
            DateAdd = job.DateAdd,
            SearchOrAskJob = job.SearchOrAskJob,
            
        };
           

            if (ModelState.IsValid)
            {

                using (var httpClient = new HttpClient())
                {
                    //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    //httpClient.DefaultRequestHeaders.Add("User-Agent", "User-Agent-Here");
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

                        List<ImageProcduct> images = ImageAdd(userImage);
                        model.Images = images;
                        model.Coordinate.Lat = latt;
                        model.Coordinate.Lon = lonn;
                        model.User = user;
                        model.Category.CategoryName = job.Category;
                        dal.AddJob(model);

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
            return View(model);
        }


        private List<ImageProcduct> ImageAdd(ImageProcduct userImage)
        {
            List<ImageProcduct> liste = new List<ImageProcduct>();
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

            //Get upload path from web.config
            // string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();

            //Create complete path to store in server
            var path = Server.MapPath("~/UserImages/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            userImage.Image = $"/UserImages/{FileName}";
                    liste.Add(userImage);
            FileName = Path.Combine(path, FileName);

            image.SaveAs(FileName);
           
                }
                
            }
            return liste;

        }


    }
}