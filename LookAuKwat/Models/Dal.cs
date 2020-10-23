using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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


        public List<ApplicationUser> GetUsersList()
        {
            return dbb.Users.ToList();
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
            return liste;

        }

        public IEnumerable<ProductModel> GetListUserProduct(string id)
        {
            ApplicationUser user = GetUserByStrId(id);
            List<ProductModel> liste = new List<ProductModel>();
            IEnumerable<JobModel> listjobs = dbb.Jobs.Include(s => s.Images)
                .Include(s => s.User)
                .Include(s => s.Category)
                .Include(s => s.Coordinate).ToList();
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
                    if (apart != null)
                        liste.Add(apart);
                }
            }
            if (listMulti.ToList().Count > 0)
            {
                foreach (var multi in listMulti)
                {
                    if (multi != null)
                        liste.Add(multi);
                }
            }
            if (listVehi.ToList().Count > 0)
            {
                foreach (var vehi in listVehi)
                {
                    if (vehi != null)
                        liste.Add(vehi);
                }
            }

            return liste.Where(s => s.User == user);
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

        public void DeleteImage(ImageProcductModel image)
        {
            dbb.Images.Remove(image);
            dbb.SaveChanges();
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

        public IEnumerable<MessageDetails> GetListMessage()
        {
            return dbb.Messages.ToList();
        }

        public void UpdateUserInformations(ApplicationUser user)
        {
            ApplicationUser userr = dbb.Users.FirstOrDefault(u => u.Id == user.Id);
            userr.FirstName = user.FirstName;
            userr.PhoneNumber = user.PhoneNumber;
            dbb.SaveChanges();
        }

        public void UpdateNumberView(ProductModel product)
        {
            var product_To_Update = dbb.Products.FirstOrDefault(m => m.id == product.id);
            product_To_Update.ViewNumber = product.ViewNumber;
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
            model.ModelAccessoryAutoVehicule = Vehi.ModelAccessoryAutoVehicule;
            model.ModelAccessoryBikeVehicule = Vehi.ModelAccessoryBikeVehicule;
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
    }
}