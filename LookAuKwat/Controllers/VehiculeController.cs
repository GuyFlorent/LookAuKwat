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
    public class VehiculeController : Controller
    {

        private IDal dal;
        public VehiculeController() : this(new Dal())
        {

        }

        public VehiculeController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: Vehicule
        public ActionResult Index()
        {
            return View(new VehiculeViewModel());
        }

        public ActionResult AddVehicule_PartialView()
        {
            return PartialView(new VehiculeViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> AddVehicule(VehiculeViewModel Vehi, ImageModelView userImage)
        {
            List<string> brandList = new List<string>();
            brandList.Add(Vehi.BrandAccessoryAutoVehicule);
            brandList.Add(Vehi.BrandAccessoryBikeVehicule);

            brandList.Add(Vehi.BrandVehiculeAuto);
            brandList.Add(Vehi.BrandVehiculeBike);
            

            string Brand = null;
            foreach (var brand in brandList)
            {
                if (brand != null)
                {
                    Brand = brand;
                }
            }
            List<string> ModeleList = new List<string>();
            ModeleList.Add(Vehi.ModelVehiculeAutoEquipment);
            ModeleList.Add(Vehi.ModelVehiculeBike);
            ModeleList.Add(Vehi.ModelVehiculeBikeEquipment);
            ModeleList.Add(Vehi.ModelVehiculeHuyndrai);
            ModeleList.Add(Vehi.ModelVehiculeKia);
            ModeleList.Add(Vehi.ModelVehiculeMazda);
            ModeleList.Add(Vehi.ModelVehiculeMercedes);
            ModeleList.Add(Vehi.ModelVehiculeToyota);
           
          
            string Model = null;
            foreach (var modell in ModeleList)
            {
                if (modell != null)
                {
                    Model = modell;
                }
            }

            if(Vehi.SearchOrAskJobVehicule == "Je vends")
            {
                Vehi.SearchOrAskJobVehicule = "J'offre";
            }
            VehiculeModel model = new VehiculeModel()
            {
                id = Vehi.id,
                Title = Vehi.TitleVehicule,
                Description = Vehi.DescriptionVehicule,
                TypeVehicule = Vehi.TypeVehicule,
                Town = Vehi.TownVehicule,
                Price = Vehi.PriceVehicule,
                Street = Vehi.StreetVehicule,
                BrandVehicule = Brand,
                ModelVehicule = Model,
                RubriqueVehicule = Vehi.RubriqueVehicule,
                PetrolVehicule = Vehi.PetrolVehicule,
                FirstYearVehicule = Vehi.FirstYearVehicule,
                YearVehicule = Vehi.YearVehicule,
                MileageVehicule = Vehi.MileageVehicule,
                NumberOfDoorVehicule = Vehi.NumberOfDoorVehicule,
                ColorVehicule = Vehi.ColorVehicule,
                GearBoxVehicule = Vehi.GearBoxVehicule,
                DateAdd = DateTime.Now,
                SearchOrAskJob = Vehi.SearchOrAskJobVehicule,
                StateVehicule = Vehi.StateVehicule

             
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
                        model.Category = new CategoryModel { CategoryName = "Vehicule" };
                        dal.AddVehicule(model, latt, lonn);
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

        public ActionResult VehiculeDetails_PartialView(VehiculeModel model)
        {

            return PartialView(model);
        }

        [OutputCache(Duration = 3600, VaryByParam = "id")]
        public async Task< ActionResult> VehiculeDetail(int id)
        {
            VehiculeModel model =  await dal.GetListVehiculeWithNoInclude().FirstOrDefaultAsync(e => e.id == id);
            model.ViewNumber++;
            dal.UpdateNumberView(model);
           
            return View(model);
        }

        public ActionResult ListModelVehicule(string term)
        {
            var data = SelectListMethodVehicle.ModelVehiculeTotalList().Select(x => x.Value.ToLower()).Where(m => m.Contains(term.ToLower()));
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}