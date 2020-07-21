﻿using LookAuKwat.Models;
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
    public class ApartmentRentalController : Controller
    {
        private IDal dal;
        public ApartmentRentalController() : this(new Dal())
        {

        }

        public ApartmentRentalController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: ApartmentRental
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddApartment_PartialView()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> AddAppartment(ApartmentRentalViewModel apart, ImageModelView userImage)
        {
            ApartmentRentalModel model = new ApartmentRentalModel()
            {
                id = apart.Id,
                Title = apart.TitleAppart,
                Description = apart.DescriptionAppart,
                ApartSurface = apart.ApartSurface,
                Town = apart.TownAppart,
                Price = apart.PriceAppart,
                Street = apart.StreetAppart,
                FurnitureOrNot = apart.FurnitureOrNot,
                RoomNumber = apart.RoomNumber,
                DateAdd = DateTime.Now.ToString(),
                SearchOrAskJob = apart.SearchOrAskJobAppart,
                Type = apart.Type

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

                        List<ImageProcductModel> images = ImageAdd(userImage);

                        model.Images = images;
                        model.User = user;
                        model.Category = new CategoryModel { CategoryName = "Immobilier" };
                        dal.AddAppartment(model, latt, lonn);


                        return RedirectToAction("GetListProductByUser_PartialView", "User");
                    }


                }

            }
            return View(apart);
        }

        public ActionResult EditApartment_PartialView(ApartmentRentalModel apart)
        {

            if (apart.id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (apart == null)
            {
                return HttpNotFound();
            }
            ApartmentRentalViewModel model = new ApartmentRentalViewModel()
            {
                Id = apart.id,
                TitleAppart = apart.Title,
                DescriptionAppart = apart.Description,
                FurnitureOrNot = apart.FurnitureOrNot,
                TownAppart = apart.Town,
                PriceAppart = apart.Price,
                StreetAppart = apart.Street,
                RoomNumber = apart.RoomNumber,
                SearchOrAskJobAppart = apart.SearchOrAskJob,
                Type = apart.Type,
                listeImageappart = apart.Images

            };

            return PartialView(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditApartment(ApartmentRentalViewModel apart, ImageModelView userImage)
        {


         

                string userId = User.Identity.GetUserId();
                ApplicationUser user = dal.GetUserByStrId(userId);
               
                ApartmentRentalModel model = new ApartmentRentalModel()
                {
                    id = apart.Id,
                    Title = apart.TitleAppart,
                    Description = apart.DescriptionAppart,
                    ApartSurface = apart.ApartSurface,
                    Town = apart.TownAppart,
                    Price = apart.PriceAppart,
                    Street = apart.StreetAppart,
                    FurnitureOrNot = apart.FurnitureOrNot,
                    RoomNumber = apart.RoomNumber,
                    Type = apart.Type,
                    DateAdd = DateTime.Now.ToString(),
                    SearchOrAskJob = apart.SearchOrAskJobAppart,
                    Category = new CategoryModel { CategoryName = "Immobilier" },
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

                        dal.EditApartment(model, latt, lonn);


                        return RedirectToAction("GetListProductByUser_PartialView", "User");
                    }


                }

            
            return View(apart);
        }

        public ActionResult ApartmentDetails_PartialView(ApartmentRentalModel model)
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


        public ActionResult ApartDetail(int id)
        {
            ApartmentRentalModel model = dal.GetListAppart().FirstOrDefault(e => e.id == id);
            return View(model);
        }
    }
}