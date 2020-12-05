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
    public class MultimediaController : Controller
    {
        private IDal dal;
        public MultimediaController() : this(new Dal())
        {

        }

        public MultimediaController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: Multimedia
        public ActionResult Index()
        {
            return View(new MultimediaViewModel());
        }
        public ActionResult IndexRoute(MultimediaViewModel model)
        {
            switch (model.TypeMultimedia)
            {
                case "Informatique":
                    return View("InformaticBrandModel", model);

                case "Consoles de jeux":
                    return View("GameConsoleBrandModel", model);

                case "Jeux video":
                    return View("GameBrandModel", model);

                case "Téléphonie":
                    return View("PhoneBrandModel", model);
                case "Accésoires téléphonie":
                    return View("AddOther", model);
                case "Téléviseur":
                    return View("TvBrandModel", model);
                case "Son":
                    return View("SonBrandModel", model);
                case "Image & Camera vidéo":
                    return View("AddOther", model);
                case "Photocopieuse":
                    return View("AddOther", model);

                default:
                    return View("Autre", model);

            }
        }
        public ActionResult InformaticBrandModel(MultimediaViewModel model)
        {
            return View(model);
        }
        public ActionResult  GameConsoleBrandModel(MultimediaViewModel model)
        {
            return View(model);
        }
        public ActionResult GameBrandModel(MultimediaViewModel model)
        {
            return View(model);
        }
        public ActionResult PhoneBrandModel(MultimediaViewModel model)
        {
            return View(model);
        }
        public ActionResult TvBrandModel(MultimediaViewModel model)
        {
            return View(model);
        }
        public ActionResult SonBrandModel(MultimediaViewModel model)
        {
            return View(model);
        }
        public ActionResult AddOther(MultimediaViewModel model)
        {
            return View(model);
        }
        public ActionResult Autre(MultimediaViewModel model)
        {
            return View(model);
        }

        public ActionResult AddFullModel(MultimediaViewModel model)
        {
            return View(model);
        }
        
        public ActionResult AddMultimedia_PartialView()
        {
            return PartialView(new MultimediaViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> AddMultimedia(MultimediaViewModel multi, ImageModelView userImage)
        {
            List<string> brandList = new List<string>();
            brandList.Add(multi.BrandConsoleGame);
            brandList.Add(multi.BrandInformatiquePhotocopi);
            
            brandList.Add(multi.BrandPhoneAccesories);
            brandList.Add(multi.BrandSon);
            brandList.Add(multi.BrandTv);

            string Brand = null;
            foreach (var brand in brandList)
            {
                if (brand != null)
                {
                    Brand = brand;
                }
            }
            List<string> ModeleList = new List<string>();
            ModeleList.Add(multi.ModelAlcatelPhoneAccesorie);
            ModeleList.Add(multi.ModelApplePhoneAccesorie);
            ModeleList.Add(multi.ModelAzusPhoneAccesorie);
            ModeleList.Add(multi.ModelConsoleGame);
            ModeleList.Add(multi.ModelHonorPhoneAccesorie);
            ModeleList.Add(multi.ModelHTCPhoneAccesorie);
            ModeleList.Add(multi.ModelHuaweiPhoneAccesorie);
            ModeleList.Add(multi.ModelInformatiquePhotocopy);
            ModeleList.Add(multi.ModelLenovoPhoneAccesorie);
            ModeleList.Add(multi.ModelLGPhoneAccesorie);
            ModeleList.Add(multi.ModelMicrosoftPhoneAccesorie);
            ModeleList.Add(multi.ModelMotorolaPhoneAccesorie);
            ModeleList.Add(multi.ModelOnePlusPhoneAccesorie);
            ModeleList.Add(multi.ModelOtherMultimedia);
            ModeleList.Add(multi.ModelSamsungPhoneAccesorie);
            ModeleList.Add(multi.ModelSon);
            ModeleList.Add(multi.ModelSonyPhoneAccesorie);
            ModeleList.Add(multi.ModelTV);
            ModeleList.Add(multi.ModelWikoPhoneAccesorie);
            ModeleList.Add(multi.ModelXaomiPhoneAccesorie);
            ModeleList.Add(multi.ModelZTEPhoneAccesorie);

            string Model = null;
            foreach (var modell in ModeleList)
            {
                if (modell != null)
                {
                    Model = modell;
                }
            }
            MultimediaModel model = new MultimediaModel()
            {
                id = multi.id,
                Title = multi.TitleMultimedia,
                Description = multi.DescriptionMultimedia,
                Type = multi.TypeMultimedia,
                Town = multi.TownMultimedia,
                Price = multi.PriceMultimedia,
                Street = multi.StreetMultimedia,
                Brand = Brand,
                Model = Model,
                Capacity = multi.Capacity,
                DateAdd = DateTime.Now,
                SearchOrAskJob = multi.SearchOrAskJobMultimedia,

            };
            string success = null;

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
                        model.Category = new CategoryModel { CategoryName = "Multimedia" };
                        dal.AddMultimedia(model, latt, lonn);
                        //check if email or phone is confirm and update date of publish announce for agent pay
                        if ((user.EmailConfirmed == true || user.PhoneNumberConfirmed == true) && user.Date_First_Publish == null)
                        {
                            dal.Update_Date_First_Publish(user);
                        }

                        // success = "Annonce ajoutée avec succès dans la liste !";
                        //return RedirectToAction("UserProfile", "Home", new { message = success });
                        // return RedirectToAction("GetListProductByUser_PartialView", "User");
                        return RedirectToAction("AddImage", "Job", new { id = model.id });
                    }


                }

            }
            success = "Désolé une erreur s'est produite!";
            return RedirectToAction("UserProfile", "Home", new { message = success });
        }

        public ActionResult EditMultimedia_PartialView(MultimediaModel multi)
        {

            if (multi.id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (multi == null)
            {
                return HttpNotFound();
            }
            MultimediaViewModel model = new MultimediaViewModel()
            {
                id = multi.id,
                TitleMultimedia = multi.Title,
                DescriptionMultimedia = multi.Description,
                TypeMultimedia = multi.Type,
                TownMultimedia = multi.Town,
                PriceMultimedia = multi.Price,
                StreetMultimedia = multi.Street,
              //  Brand = multi.Brand,
                DateAdd = DateTime.Now,
                SearchOrAskJobMultimedia = multi.SearchOrAskJob,
                listeImage = multi.Images

            };

            return PartialView(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditMultimedia_PartialView(MultimediaViewModel multi, ImageModelView userImage)
        {
            List<string> brandList = new List<string>();
            brandList.Add(multi.BrandConsoleGame);
            brandList.Add(multi.BrandInformatiquePhotocopi);
            
            brandList.Add(multi.BrandPhoneAccesories);
            brandList.Add(multi.BrandSon);
            brandList.Add(multi.BrandTv);

            string Brand = null;
            foreach(var brand in brandList)
            {
                if (brand != null)
                {
                    Brand = brand;
                }
            }
            List<string> ModeleList = new List<string>();
            ModeleList.Add(multi.ModelAlcatelPhoneAccesorie);
            ModeleList.Add(multi.ModelApplePhoneAccesorie);
            ModeleList.Add(multi.ModelAzusPhoneAccesorie);
            ModeleList.Add(multi.ModelConsoleGame);
            ModeleList.Add(multi.ModelHonorPhoneAccesorie);
            ModeleList.Add(multi.ModelHTCPhoneAccesorie);
            ModeleList.Add(multi.ModelHuaweiPhoneAccesorie);
            ModeleList.Add(multi.ModelInformatiquePhotocopy);
            ModeleList.Add(multi.ModelLenovoPhoneAccesorie);
            ModeleList.Add(multi.ModelLGPhoneAccesorie);
            ModeleList.Add(multi.ModelMicrosoftPhoneAccesorie);
            ModeleList.Add(multi.ModelMotorolaPhoneAccesorie);
            ModeleList.Add(multi.ModelOnePlusPhoneAccesorie);
            ModeleList.Add(multi.ModelOtherMultimedia);
            ModeleList.Add(multi.ModelSamsungPhoneAccesorie);
            ModeleList.Add(multi.ModelSon);
            ModeleList.Add(multi.ModelSonyPhoneAccesorie);
            ModeleList.Add(multi.ModelTV);
            ModeleList.Add(multi.ModelWikoPhoneAccesorie);
            ModeleList.Add(multi.ModelXaomiPhoneAccesorie);
            ModeleList.Add(multi.ModelZTEPhoneAccesorie);

            string Model = null;
            foreach(var model in ModeleList)
            {
                if(model != null)
                {
                    Model = model;
                }
            }

            if (ModelState.IsValid)
            {

                string userId = User.Identity.GetUserId();
                ApplicationUser user = dal.GetUserByStrId(userId);
                MultimediaModel model = new MultimediaModel()
                {
                    id = multi.id,
                    Title = multi.TitleMultimedia,
                    Description = multi.DescriptionMultimedia,
                    Type = multi.TypeMultimedia,
                    Town = multi.TownMultimedia,
                    Price = multi.PriceMultimedia,
                    Street = multi.StreetMultimedia,
                    Brand = Brand,
                    Model = Model,
                    DateAdd = DateTime.Now,
                    SearchOrAskJob = multi.SearchOrAskJobMultimedia,
                    Category = new CategoryModel { CategoryName = "Multimedia" },
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

                        List<ImageProcductModel> images = ImageEdit(userImage, model);

                        model.Images = images;

                        dal.EditMultimedia(model, latt, lonn);


                        return RedirectToAction("GetListProductByUser_PartialView", "User");
                    }


                }

            }
            return View(multi);
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
                            Image = "https://particulier-employeur.fr/wp-content/themes/fepem/img/general/avatar.png"
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
                    Image = "https://particulier-employeur.fr/wp-content/themes/fepem/img/general/avatar.png"
                };
                liste.Add(picture);

            }
            return liste;
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
                foreach (var im in picture)
                {
                    liste.Add(im);
                }

            }
            return liste;
        }

        public ActionResult MultimediaDetails_PartialView(MultimediaModel model)
        {

            return PartialView(model);
        }

        public ActionResult MultimediaDetail(int id)
        {
            MultimediaModel model = dal.GetListMultimediaWithNoInclude().FirstOrDefault(e => e.id == id);
            model.ViewNumber++;
            dal.UpdateNumberView(model);
            if (model.Images.Count > 1)
            {
                model.Images = model.Images.Where(m => !m.Image.StartsWith("http")).ToList();
            }
            return View(model);
        }

        public ActionResult ListModelMultimedia(string term)
        {
            var data = SelectListMethod.ModelTotalList().Select(x =>x.Value.ToLower()).Where(m=>m.Contains(term.ToLower()));
            return Json(data, JsonRequestBehavior.AllowGet);
        }


    }
}