using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LookAuKwat.Controllers
{
    
    public class HouseController : Controller
    {
        private IDal dal;
        public HouseController() : this(new Dal())
        {

        }

        public HouseController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        
        // GET: House
        public ActionResult Index( )
        {

            return View(new HouseViewModel());
        }
        
        public ActionResult AddIndex(HouseViewModel house)
        {
            switch (house.RubriqueHouse)
            {
                case "Ameublement":
                    return View("AddAmmeblement", house);

                case "Outils de table & reception":
                    return View("AddOutilsTable", house);

                case "Décoration":
                    return View("AddDecoration", house);

                case "Linge de maison":
                    return View("AddLinge", house);

                default:
                    return View("AddOther", house);

            }
        }

        public ActionResult AddAmmeblement(HouseViewModel house)
        {
           return View(house);
        }
        public ActionResult AddOutilsTable(HouseViewModel house)
        {
            return View(house);
        }
        public ActionResult AddDecoration(HouseViewModel house)
        {
            return View(house);
        }
        public ActionResult AddLinge(HouseViewModel house)
        {
            return View( house);
        }
        public ActionResult AddOther(HouseViewModel house)
        {
            return View(house);
        }

        public ActionResult AddFullModel(HouseViewModel house)
        {
            return View(house);
        }

        [HttpPost]
        public async Task<ActionResult> AddHouse(HouseViewModel house, ImageModelView userImage)
        {
            HouseModel model = new HouseModel()
            {
               
                Title = house.Title,
                Description = house.Description,
                RubriqueHouse = house.RubriqueHouse,
                Town = house.Town,
                Price = house.Price,
                Street = house.Street,
                ColorHouse = house.ColorHouse,
                FabricMaterialeHouse = house.FabricMaterialeHouse,
                StateHouse = house.StateHouse,
                TypeHouse = house.TypeHouse,
                DateAdd = DateTime.Now,
                SearchOrAskJob = house.SearchOrAskJob,


            };


            if (ModelState.IsValid)
            {

                using (var httpClient = new HttpClient())
                {

                    string userId = User.Identity.GetUserId();
                    ApplicationUser user = dal.GetUserByStrId(userId);

                    var fullAddress = $"{ model.Street /*+ model.Town + "," + ",Cameroon"*/}";
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
                        model.Category = new CategoryModel { CategoryName = "Maison" };
                        dal.AddHouse(model, latt, lonn);
                        //check if email or phone is confirm and update date of publish announce for agent pay
                        if ((user.EmailConfirmed == true || user.PhoneNumberConfirmed == true) && user.Date_First_Publish == null)
                        {
                            dal.Update_Date_First_Publish(user);
                        }
                        //string success = "Annonce ajoutée avec succès dans la liste !";
                        //return RedirectToAction("UserProfile", "Home",new { message= success });
                        return RedirectToAction("AddImage", "Job", new { id = model.id });
                    }


                }

            }
            ViewBag.Erreur = "Une erreur s'est produite lors de l'enregistrement de votre annonce";
            return View("AddFullModel",house);
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
                    else
                    {
                        ImageProcductModel picture = new ImageProcductModel
                        {
                            id = Guid.NewGuid(),
                            Image = "https://particulier-employeur.fr/wp-content/themes/fepem/img/general/avatar.png",
                            ImageMobile = "https://particulier-employeur.fr/wp-content/themes/fepem/img/general/avatar.png"
                        };
                        liste.Add(picture);
                    }

                }
                return liste;
            }
            else
            {
                ImageProcductModel picture = new ImageProcductModel
                {
                    id = Guid.NewGuid(),
                    Image = "https://particulier-employeur.fr/wp-content/themes/fepem/img/general/avatar.png",
                    ImageMobile = "https://particulier-employeur.fr/wp-content/themes/fepem/img/general/avatar.png"
                };
                liste.Add(picture);

            }
            return liste;
        }

        public ActionResult HouseDetails_PartialView(HouseModel model)
        {

            return PartialView(model);
        }

        [OutputCache(Duration = int.MaxValue, VaryByParam = "id")]
        public async Task< ActionResult> HouseDetail(int id)
        {
            HouseModel model = await dal.GetListHouseWithNoInclude().FirstOrDefaultAsync(e => e.id == id);
            model.ViewNumber++;
            dal.UpdateNumberView(model);
           
            return View(model);
        }

    }
}