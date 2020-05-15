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


            foreach (var job in listjobs)
            {
                if(job != null)
                liste.Add(job);
            }
            foreach (var apart in listapart)
            {
                if(apart != null)
                liste.Add(apart);
            }
            return liste.Where(s => s.User == user);
        }

        public void EditJob(JobModel job, string lat, string lon)
        {
           foreach(var image in job.Images)
            {
                dbb.Entry(image).State = EntityState.Added;
            }
            ProductCoordinateModel coor = dbb.ProductCoordinates.Find(job.id);
            coor.Lat = lat;
            coor.Lon = lon;
            job.Coordinate = coor;
            dbb.Entry(job).State = EntityState.Added;
            dbb.SaveChanges();
        }
    }
}