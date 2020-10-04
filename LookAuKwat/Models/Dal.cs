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

            foreach(var job in listjobs)
            {
                if (job != null)
                    liste.Add(job);
            }
            foreach (var apart in listapart)
            {
                if (apart != null)
                    liste.Add(apart);
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
            ProductCoordinateModel coor = dbb.ProductCoordinates.Find(job.id);
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
            ProductCoordinateModel coor = dbb.ProductCoordinates.Find(apart.id);
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
            userr.Email = user.Email;
            userr.PhoneNumber = user.PhoneNumber;
            dbb.SaveChanges();
        }

        public void UpdateNumberView(ProductModel product)
        {
            var product_To_Update = dbb.Products.FirstOrDefault(m => m.id == product.id);
            product_To_Update.ViewNumber = product.ViewNumber;
            dbb.SaveChanges();
        }
    }
}