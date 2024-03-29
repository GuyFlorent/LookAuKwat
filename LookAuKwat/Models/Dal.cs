﻿using AngleSharp;
using LookAuKwat.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LookAuKwat.Models
{
    public class Dal : IDal
    {
        private ApplicationDbContext dbb;

        public Dal()
        {
            dbb = new ApplicationDbContext();
        }

        public ApplicationUser GetUserByStrId(string id)
        {

            if (!string.IsNullOrWhiteSpace(id))
                return dbb.Users.FirstOrDefault(u => u.Id == id);
            return null;
        }


        public IQueryable<ApplicationUser> GetUsersList()
        {
            return dbb.Users.AsQueryable();
        }

        public void AddJob(JobModel job, string lat, string lon)
        {
           
            
            CategoryModel category = new CategoryModel
            {
                CategoryName = job.Category.CategoryName,
                
            };

           // dbb.Categories.Add(category);
            job.Category = category;

            ProductCoordinateModel coordinate = new ProductCoordinateModel
            {
                Lat = lat,
                Lon = lon

            };
             // dbb.ProductCoordinates.Add(coordinate);
            job.Coordinate = coordinate;

            dbb.Jobs.Add(job);
            dbb.SaveChanges();

        }

        public void Dispose()
        {
            dbb.Dispose();
        }

        public IEnumerable<int> GetListIdProduct()
        {
            return dbb.Products.Select(s => s.id);
        }
        public IEnumerable<ProductModel> GetListProduct()
        {
            List<ProductModel> liste = new List<ProductModel>();
            IEnumerable<JobModel> listjobs = dbb.Jobs.Include(s => s.Images)
                .Include(s=>s.User)
                .Include(s=>s.Category)
                .Include(s=>s.Coordinate).ToList();
            IEnumerable<ApartmentRentalModel> listapart = dbb.ApartmentRentals.Include(s => s.Images)
                .Include(s => s.User)
                .Include(s => s.Category)
                .Include(s => s.Coordinate).ToList();
            IEnumerable<MultimediaModel> listMulti = dbb.Multimedia.Include(s => s.Images)
                .Include(s => s.User)
                .Include(s => s.Category)
                .Include(s => s.Coordinate).ToList();
            IEnumerable<VehiculeModel> listVehi = dbb.Vehicules.Include(s => s.Images)
               .Include(s => s.User)
               .Include(s => s.Category)
               .Include(s => s.Coordinate).ToList();
            IEnumerable<ModeModel> listMode = dbb.Modes.Include(s => s.Images)
              .Include(s => s.User)
              .Include(s => s.Category)
              .Include(s => s.Coordinate).ToList();
            IEnumerable<HouseModel> listHouse = dbb.Houses.Include(s => s.Images)
              .Include(s => s.User)
              .Include(s => s.Category)
              .Include(s => s.Coordinate).ToList();

            foreach (var job in listjobs)
            {
                if (job != null)
                    liste.Add(job);
            }
            foreach (var apart in listapart)
            {
                if (apart != null)
                    liste.Add(apart);
            }
            foreach (var multi in listMulti)
            {
                if (multi != null)
                    liste.Add(multi);
            }
            foreach (var vehi in listVehi)
            {
                if (vehi != null)
                    liste.Add(vehi);
            }
            foreach (var mode in listMode)
            {
                if (mode != null)
                    liste.Add(mode);
            }
            foreach (var house in listHouse)
            {
                if (house != null)
                    liste.Add(house);
            }
            return liste;

        }

        public  IQueryable<ProductModel> GetListProductWhithNoInclude()
        {
           
            return   dbb.Products.AsQueryable();

        }

        public List<ProductToDisplay> GetListProductToDisplay()
        {

            return dbb.Products.Select(s => new ProductToDisplay
            {
                id = s.id,
                DateAdd = s.DateAdd,
                CategoryName = s.Category.CategoryName,
                Image = s.Images.Select(i => i.ImageMobile).FirstOrDefault(),
                Price = s.Price,
                Title = s.Title,
                Description = s.Description,
                Street = s.Street,
                SearchOrAskJob = s.SearchOrAskJob,
                Town = s.Town,
                IsLookaukwat = s.IsLookaukwat,
                Country = s.ProductCountry,
                ProductCountry = s.ProductCountry
            }).ToList();

        }

        public IEnumerable<ProductModel> GetListUserProduct(string id)
        {
            //ApplicationUser user = GetUserByStrId(id);
            List<ProductModel> liste = new List<ProductModel>();
            IEnumerable<JobModel> listjobs = dbb.Jobs.Where(s => s.User.Id == id).ToList();
            IEnumerable<ApartmentRentalModel> listapart = dbb.ApartmentRentals.Where(s => s.User.Id == id).ToList();
            IEnumerable<MultimediaModel> listMulti = dbb.Multimedia.Where(s => s.User.Id == id).ToList();
            IEnumerable<VehiculeModel> listVehi = dbb.Vehicules.Where(s => s.User.Id == id).ToList();
            IEnumerable<ModeModel> listMode = dbb.Modes.Where(s => s.User.Id == id).ToList();
            IEnumerable<HouseModel> listHouse = dbb.Houses.Where(s => s.User.Id == id).ToList();

            if (listjobs.ToList().Count > 0)
            {
                foreach (var job in listjobs)
                {
                    if (job != null && !liste.Contains(job))
                        liste.Add(job);
                }
            }
            if(listapart.ToList().Count > 0)
            {
                foreach (var apart in listapart)
                {
                    if (apart != null && !liste.Contains(apart))
                        liste.Add(apart);
                }
            }
            if (listMulti.ToList().Count > 0)
            {
                foreach (var multi in listMulti)
                {
                    if (multi != null && !liste.Contains(multi))
                        liste.Add(multi);
                }
            }
            if (listVehi.ToList().Count > 0)
            {
                foreach (var vehi in listVehi)
                {
                    if (vehi != null && !liste.Contains(vehi))
                        liste.Add(vehi);
                }
            }
            if (listMode.ToList().Count > 0)
            {
                foreach (var mode in listMode)
                {
                    if (mode != null && !liste.Contains(mode))
                        liste.Add(mode);
                }
            }
            if (listHouse.ToList().Count > 0)
            {
                foreach (var house in listHouse)
                {
                    if (house != null && !liste.Contains(house))
                        liste.Add(house);
                }
            }

            return liste;
        }

        public void EditJob(JobModel job, string lat, string lon)
        {
            //foreach (var image in job.Images)
            //{
            //    var img = dbb.Images.Where(s => s.ProductId == job.id);
            //    foreach (var im in img)
            //    {
            //        im.Image = image.Image;
            //    }

            //}
            ProductCoordinateModel coor = dbb.ProductCoordinates.Find(job.Coordinate.id);
            coor.Lat = lat;
            coor.Lon = lon;

            CategoryModel cate = dbb.Categories.FirstOrDefault(s => s.CategoryName == job.Category.CategoryName);

            JobModel model = dbb.Jobs.FirstOrDefault(s => s.id == job.id);
            model.Title = job.Title;
            model.SearchOrAskJob = job.SearchOrAskJob;
            model.Price = job.Price;
            model.Street = job.Street;
            model.Town = job.Town;
            model.Coordinate = coor;
            model.User = job.User;
            model.TypeContract = job.TypeContract;
            model.ActivitySector = job.ActivitySector;
            model.DateAdd = job.DateAdd;
            model.Category = cate;
            model.Images = job.Images;
            model.Description = job.Description;
            dbb.SaveChanges();
        }

        public async Task DeleteImage(ImageProcductModel image)
        {
            dbb.Images.Remove(image);
           await dbb.SaveChangesAsync();
        }

        public List<ImageProcductModel> GetImageList()
        {
            return dbb.Images.ToList();
        }

        public void DeleteProduct(ProductModel product)
        {
            dbb.Products.Remove(product);
            dbb.SaveChanges();
        }

        public IEnumerable<JobModel> GetListJob()
        {
            IEnumerable<JobModel> listjobs = dbb.Jobs.Include(s => s.Images)
               .Include(s => s.User)
               .Include(s => s.Category)
               .Include(s => s.Coordinate).ToList();
            return listjobs;
        }
        public IQueryable<JobModel> GetListJobWithNoInclude()
        {
            
            return dbb.Jobs.AsQueryable();
        }

        public void AddAppartment(ApartmentRentalModel apart, string lat, string lon)
        {
            CategoryModel category = new CategoryModel
            {
                CategoryName = apart.Category.CategoryName,

            };

            // dbb.Categories.Add(category);
            apart.Category = category;

            ProductCoordinateModel coordinate = new ProductCoordinateModel
            {
                Lat = lat,
                Lon = lon

            };
            // dbb.ProductCoordinates.Add(coordinate);
            apart.Coordinate = coordinate;

            dbb.ApartmentRentals.Add(apart);
            dbb.SaveChanges();
        }

        public void EditApartment(ApartmentRentalModel apart, string lat, string lon)
        {
            ProductCoordinateModel coor = dbb.ProductCoordinates.Find(apart.Coordinate.id);
            coor.Lat = lat;
            coor.Lon = lon;

            CategoryModel cate = dbb.Categories.FirstOrDefault(s => s.CategoryName == apart.Category.CategoryName);

            ApartmentRentalModel model = dbb.ApartmentRentals.FirstOrDefault(s => s.id == apart.id);
            model.Title = apart.Title;
            model.SearchOrAskJob = apart.SearchOrAskJob;
            model.Price = apart.Price;
            model.Street = apart.Street;
            model.Town = apart.Town;
            model.Coordinate = coor;
            model.User = apart.User;
            model.FurnitureOrNot = apart.FurnitureOrNot;
            model.RoomNumber = apart.RoomNumber;
            model.ApartSurface = apart.ApartSurface;
            model.DateAdd = apart.DateAdd;
            model.Category = cate;
            model.Images = apart.Images;
            model.Description = apart.Description;

            dbb.SaveChanges();
        }

        public IEnumerable<ApartmentRentalModel> GetListAppart()
        {
            IEnumerable<ApartmentRentalModel> listapart = dbb.ApartmentRentals.Include(s => s.Images)
              .Include(s => s.User)
              .Include(s => s.Category)
              .Include(s => s.Coordinate).ToList();
            return listapart;
        }

        public IQueryable<ApartmentRentalModel> GetListAppartWithNoInclude()
        {
           
            return dbb.ApartmentRentals.AsQueryable();
        }


        public IEnumerable<MessageDetails> GetListMessage()
        {
            return dbb.Messages.ToList();
        }

        public void UpdateUserInformations(ApplicationUser user)
        {
            ApplicationUser userr = dbb.Users.FirstOrDefault(u => u.Id == user.Id);
            userr.FirstName = user.FirstName;
           
            dbb.SaveChanges();
        }

        public void UpdateNumberView(ProductModel product)
        {
           // var product_To_Update = dbb.Products.FirstOrDefault(m => m.id == product.id);
           // product_To_Update.ViewNumber = product.ViewNumber;
            dbb.SaveChanges();
        }

        public IEnumerable<ProductModel> GetListAskProduct()
        {
            List<ProductModel> liste = new List<ProductModel>();
            IEnumerable<JobModel> listjobs = dbb.Jobs.Include(s => s.Images)
                .Include(s => s.User)
                .Include(s => s.Category)
                .Include(s => s.Coordinate).ToList();
            IEnumerable<ApartmentRentalModel> listapart = dbb.ApartmentRentals.Include(s => s.Images)
                .Include(s => s.User)
                .Include(s => s.Category)
                .Include(s => s.Coordinate).ToList();

            foreach (var job in listjobs)
            {
                if (job != null)
                    liste.Add(job);
            }
            foreach (var apart in listapart)
            {
                if (apart != null)
                    liste.Add(apart);
            }
            return liste.Where(m => m.SearchOrAskJob == "Je recherche");
        }

        public void AddMultimedia(MultimediaModel model, string lat, string lon)
        {
            CategoryModel category = new CategoryModel
            {
                CategoryName = model.Category.CategoryName,

            };

            // dbb.Categories.Add(category);
            model.Category = category;

            ProductCoordinateModel coordinate = new ProductCoordinateModel
            {
                Lat = lat,
                Lon = lon

            };
            // dbb.ProductCoordinates.Add(coordinate);
            model.Coordinate = coordinate;

            dbb.Multimedia.Add(model);
            dbb.SaveChanges();
        }

        public void EditMultimedia(MultimediaModel multi, string lat, string lon)
        {
            ProductCoordinateModel coor = dbb.ProductCoordinates.Find(multi.id);
            coor.Lat = lat;
            coor.Lon = lon;

            CategoryModel cate = dbb.Categories.FirstOrDefault(s => s.CategoryName == multi.Category.CategoryName);

            MultimediaModel model = dbb.Multimedia.FirstOrDefault(s => s.id == multi.id);
            model.Title = multi.Title;
            model.SearchOrAskJob = multi.SearchOrAskJob;
            model.Price = multi.Price;
            model.Street = multi.Street;
            model.Town = multi.Town;
            model.Coordinate = coor;
            model.User = multi.User;
            model.Type = multi.Type;
            model.Brand = multi.Brand;
            model.Model = multi.Model;
            model.Capacity = multi.Capacity;
            model.DateAdd = multi.DateAdd;
            model.Category = cate;
            model.Images = multi.Images;
            model.Description = multi.Description;

            dbb.SaveChanges();
        }

        public IEnumerable<MultimediaModel> GetListMultimedia()
        {
            IEnumerable<MultimediaModel> listMulti = dbb.Multimedia.Include(s => s.Images)
               .Include(s => s.User)
               .Include(s => s.Category)
               .Include(s => s.Coordinate).ToList();
            return listMulti;
        }

        public IQueryable<MultimediaModel> GetListMultimediaWithNoInclude()
        {
            
            return dbb.Multimedia.AsQueryable();
        }

        public void AddVehicule(VehiculeModel model, string lat, string lon)
        {

            CategoryModel category = new CategoryModel
            {
                CategoryName = model.Category.CategoryName,

            };

            // dbb.Categories.Add(category);
            model.Category = category;

            ProductCoordinateModel coordinate = new ProductCoordinateModel
            {
                Lat = lat,
                Lon = lon

            };
            // dbb.ProductCoordinates.Add(coordinate);
            model.Coordinate = coordinate;

            dbb.Vehicules.Add(model);
            dbb.SaveChanges();
        }

        public void EditVehicule(VehiculeModel Vehi, string lat, string lon)
        {
            ProductCoordinateModel coor = dbb.ProductCoordinates.Find(Vehi.Coordinate.id);
            coor.Lat = lat;
            coor.Lon = lon;

            CategoryModel cate = dbb.Categories.FirstOrDefault(s => s.CategoryName == Vehi.Category.CategoryName);

            VehiculeModel model = dbb.Vehicules.FirstOrDefault(s => s.id == Vehi.id);
            model.id = Vehi.id;
            model.Title = Vehi.Title;
            model.Description = Vehi.Description;
            model.TypeVehicule = Vehi.TypeVehicule;
            model.Town = Vehi.Town;
            model.Price = Vehi.Price;
            model.Street = Vehi.Street;
            model.BrandVehicule = Vehi.BrandVehicule;
            model.ModelVehicule = Vehi.ModelVehicule;
            model.RubriqueVehicule = Vehi.RubriqueVehicule;
            model.PetrolVehicule = Vehi.PetrolVehicule;
            model.FirstYearVehicule = Vehi.FirstYearVehicule;
            model.YearVehicule = Vehi.YearVehicule;
            model.MileageVehicule = Vehi.MileageVehicule;
            model.NumberOfDoorVehicule = Vehi.NumberOfDoorVehicule;
            model.ColorVehicule = Vehi.ColorVehicule;
            model.GearBoxVehicule = Vehi.GearBoxVehicule;
            //model.ModelAccessoryAutoVehicule = Vehi.ModelAccessoryAutoVehicule;
            //model.ModelAccessoryBikeVehicule = Vehi.ModelAccessoryBikeVehicule;
            model.DateAdd = DateTime.Now;
            model.SearchOrAskJob = Vehi.SearchOrAskJob;

            dbb.SaveChanges();
        }

        public IEnumerable<VehiculeModel> GetListVehicule()
        {
            IEnumerable<VehiculeModel> listMulti = dbb.Vehicules.Include(s => s.Images)
               .Include(s => s.User)
               .Include(s => s.Category)
               .Include(s => s.Coordinate).ToList();
            return listMulti;
        }

        public IQueryable<VehiculeModel> GetListVehiculeWithNoInclude()
        {
           
            return dbb.Vehicules.AsQueryable();
        }

        public void AddMode(ModeModel model, string lat, string lon)
        {
            CategoryModel category = new CategoryModel
            {
                CategoryName = model.Category.CategoryName,

            };

            // dbb.Categories.Add(category);
            model.Category = category;

            ProductCoordinateModel coordinate = new ProductCoordinateModel
            {
                Lat = lat,
                Lon = lon

            };
            // dbb.ProductCoordinates.Add(coordinate);
            model.Coordinate = coordinate;

            dbb.Modes.Add(model);
            dbb.SaveChanges();
        }

        public void EditMode(ModeModel model, string lat, string lon)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ModeModel> GetListMode()
        {
            IEnumerable<ModeModel> listMode = dbb.Modes.Include(s => s.Images)
                .Include(s => s.User)
                .Include(s => s.Category)
                .Include(s => s.Coordinate).ToList();
            return listMode;
        }

        public IQueryable<ModeModel> GetListModeWithNoInclude()
        {
           
            return dbb.Modes.AsQueryable(); ;
        }

        public bool User_Number_Already_Exist(string number)
        {
             ApplicationUser cli = dbb.Users.FirstOrDefault(m => m.PhoneNumber == number);
            if (cli == null)
                return false;
            return true;
        }
        public bool User_Email_Already_Exist(string email)
        {
            ApplicationUser cli = dbb.Users.FirstOrDefault(m => m.Email == email);
            if (cli == null)
                return false;
            return true;
        }
        
         public IQueryable<ParrainModel> GetParrainList()
        {
             return dbb.Parrains.AsQueryable();
        }
        public IQueryable<ApplicationUser> GetParrainList_WithRole()
        {
            var Roles = dbb.Roles.FirstOrDefault(s => s.Name == MyRoleConstant.RoleAgent);


           return dbb.Users.Where(u => u.Roles.FirstOrDefault().RoleId == Roles.Id).AsQueryable();

           // return dbb.Parrains.AsQueryable();
        }

        public void AddParrain(ParrainModel model)
        {

            dbb.Parrains.Add(model);

            // add agent role to old agent
            var user = dbb.Users.FirstOrDefault(m => m.Email == model.ParrainEmail);
            var userStore = new UserStore<ApplicationUser>(dbb);
            var usermanager = new ApplicationUserManager(userStore);

            var roleStore = new RoleStore<IdentityRole>(dbb);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            usermanager.AddToRole(user.Id, MyRoleConstant.RoleAgent);


            dbb.SaveChanges();
        }

        public void DeletParrain(string ParrainEmail)
        {
            var user = dbb.Users.FirstOrDefault(m => m.Email == ParrainEmail);
            var Roles = dbb.Roles.FirstOrDefault(s => s.Name == MyRoleConstant.RoleAgent);

            var userRoles = Roles.Users.FirstOrDefault(s => s.UserId == user.Id);

            if (userRoles != null)
                Roles.Users.Remove(userRoles);

            // add old agent role to old agent

            var userStore = new UserStore<ApplicationUser>(dbb);
            var usermanager = new ApplicationUserManager(userStore);

            var roleStore = new RoleStore<IdentityRole>(dbb);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            usermanager.AddToRole(user.Id, MyRoleConstant.Role_Old_Agent);

            // dbb.Parrains.Remove(model);
            dbb.SaveChanges();
        }

        public void Update_Date_First_Publish(ApplicationUser user)
        {
            ApplicationUser userr = dbb.Users.FirstOrDefault(u => u.Id == user.Id);
            userr.Date_First_Publish = DateTime.Now;
            dbb.SaveChanges();
        }

        public void UpdateUserByAdmin(ApplicationUser user)
        {
            //ApplicationUser userr = dbb.Users.FirstOrDefault(u => u.Id == user.Id);
            //userr.FirstName = user.FirstName;
            //userr.PhoneNumber = user.PhoneNumber;
            //userr.Email = user.Email;
            dbb.SaveChanges();
        }

        public void DeleteUserByAdmin(ApplicationUser user)
        {
            ApplicationUser userr = dbb.Users.FirstOrDefault(u => u.Id == user.Id);
            dbb.Users.Remove(userr);
            dbb.SaveChanges();
        }

        public void AddHouse(HouseModel model, string lat, string lon)
        {
            CategoryModel category = new CategoryModel
            {
                CategoryName = model.Category.CategoryName,

            };

            // dbb.Categories.Add(category);
            model.Category = category;

            ProductCoordinateModel coordinate = new ProductCoordinateModel
            {
                Lat = lat,
                Lon = lon

            };
            // dbb.ProductCoordinates.Add(coordinate);
            model.Coordinate = coordinate;

            dbb.Houses.Add(model);
            dbb.SaveChanges();
        }

        public void EditHouse(HouseModel model, string lat, string lon)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HouseModel> GetListHouse()
        {
            IEnumerable<HouseModel> listHouse = dbb.Houses.Include(s => s.Images)
                 .Include(s => s.User)
                 .Include(s => s.Category)
                 .Include(s => s.Coordinate).ToList();
            return listHouse;
        }

        public IQueryable<HouseModel> GetListHouseWithNoInclude()
        {
            
            return dbb.Houses.AsQueryable();
        }
        public async Task<HouseModel> GetHouseWithNoInclude(int id)
        {
            return await dbb.Houses.FirstOrDefaultAsync(s => s.id == id);
        }
        public void AddImage(ProductModel model)
        {
            var product = dbb.Products.FirstOrDefault(m => m.id == model.id);
            product.Images = model.Images;
            dbb.SaveChanges();
        }

        public void UpdateImage(ImageProcductModel image)
        {
            dbb.SaveChanges();
        }

        public IQueryable<EventModel> GetListEventWithNoInclude()
        {

            return dbb.Events.AsQueryable();
        }

        public IEnumerable<SelectListItem> GetProviderList()
        {
            var role = dbb.Roles.FirstOrDefault(s => s.Name == MyRoleConstant.RoleProvider);
            var listProvier = dbb.Users.Where(u => u.Roles.FirstOrDefault().RoleId == role.Id).ToList();
            IList<SelectListItem> list = new List<SelectListItem>();
            foreach(var provider in listProvier)
            {
                list.Add(new SelectListItem { Text = provider.FirstName, Value = provider.Id });
            }
            return list;
        }

        public IQueryable<DiversModel> GetListDiversWithNoInclude()
        {
            return dbb.Divers.AsQueryable();
        }
    }
}