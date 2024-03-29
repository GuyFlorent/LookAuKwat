﻿using LookAuKwat.Models;
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
    public class ModeController : Controller
    {
        private IDal dal;
        public ModeController() : this(new Dal())
        {

        }

        public ModeController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: Mode
        public ActionResult Index()
        {
            return View(new ModeViewModel());
        }

        public ActionResult AddMode_PartialView()
        {
            return PartialView(new ModeViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> AddMode(ModeViewModel mode, ImageModelView userImage)
        {

            bool isLookAuKwat = false;
            bool isParticuler = false;
            bool isPromotion = false;
            if (User.IsInRole(MyRoleConstant.RoleAdmin) || (User.IsInRole(MyRoleConstant.Role_SuperAgent)))
            {
                isLookAuKwat = true;
                isPromotion = true;

            }
            else
            {
                isParticuler = true;
            }

            if (mode.Stock == 0)
            {
                mode.Stock = 1;
            }


            List<string> TypeList = new List<string>();
            TypeList.Add(mode.TypeModeAccesorieLugages);
            TypeList.Add(mode.TypeModeBabyClothes);
            TypeList.Add(mode.TypeModeBabyEquipment);
            TypeList.Add(mode.TypeModeClothes);
            TypeList.Add(mode.TypeModeShoes);
            TypeList.Add(mode.TypeModeWatchJewelry);

           

            string type = null;
            foreach (var brand in TypeList)
            {
                if (brand != null)
                {
                    type = brand;
                }
            }
            List<string> BrandList = new List<string>();
            BrandList.Add(mode.BrandModeClothes);
            BrandList.Add(mode.BrandModeShoes);
           

            string Brand = null;
            foreach (var modell in BrandList)
            {
                if (modell != null)
                {
                    Brand = modell;
                }
            }

            List<string> SizeList = new List<string>();
            SizeList.Add(mode.SizeModeClothes);
            SizeList.Add(mode.SizeModeShoes);


            string Size = null;
            foreach (var modell in SizeList)
            {
                if (modell != null)
                {
                    Size = modell;
                }
            }
            if (mode.SearchOrAskMode == "Je vends")
            {
                mode.SearchOrAskMode = "J'offre";
            }
            ModeModel model = new ModeModel()
            {
                id = mode.id,
                Title = mode.TitleMode,
                Description = mode.DescriptionMode,
                RubriqueMode = mode.RubriqueMode,
                Town = mode.TownMode,
                Price = mode.PriceMode,
                Street = mode.StreetMode,
                BrandMode = Brand,
                TypeMode = type,
                SizeMode = Size,
                StateMode = mode.StateMode,
                UniversMode = mode.UniversMode,
                ColorMode = mode.ColorMode,
                DateAdd = DateTime.Now,
                SearchOrAskJob = mode.SearchOrAskMode,
                IsActive = true,
                IsLookaukwat = isLookAuKwat,
                IsParticulier = isParticuler,
                IsPromotion = isPromotion,
                Provider_Id = mode.Provider_Id,
                Stock_Initial = mode.Stock,
                Stock = mode.Stock,
                ProductCountry = mode.ProductCountry,
            };
            string success = null;

            if (ModelState.IsValid)
            {

                using (var httpClient = new HttpClient())
                {

                    string userId = User.Identity.GetUserId();
                    ApplicationUser user = dal.GetUserByStrId(userId);

                    var fullAddress = $"{model.Street /*+ ","+ model.Town + ",Cameroun"*/}";
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
                        model.Category = new CategoryModel { CategoryName = "Mode" };
                        dal.AddMode(model, latt, lonn);
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

        public ActionResult ModeDetails_PartialView(ModeModel model)
        {

            return PartialView(model);
        }

        [OutputCache(Duration = 3600, VaryByParam = "id")]
        public async Task< ActionResult> ModeDetail(int id)
        {
            ModeModel model =await dal.GetListModeWithNoInclude().FirstOrDefaultAsync(e => e.id == id);
            model.Coordinate.Lat = model.Coordinate.Lat.Replace(",", ".");
            model.Coordinate.Lon = model.Coordinate.Lon.Replace(",", ".");
            model.ViewNumber++;
            dal.UpdateNumberView(model);
           
            return View(model);
        }

    }
}