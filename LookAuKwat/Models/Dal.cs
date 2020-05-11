using System;
using System.Collections.Generic;
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

        public void AddJob(Job job)
        {
           
            
            Category category = new Category
            {
                CategoryName = job.Category.CategoryName,
                SubCategoryName = job.Category.SubCategoryName
            };

            dbb.Categories.Add(category);
            job.Category = category;

            ProductCoordinate coordinate = new ProductCoordinate
            {
                Lat = job.Coordinate.Lat,
                Lon = job.Coordinate.Lon

            };
              dbb.ProductCoordinates.Add(coordinate);
            job.Category = category;

            dbb.Jobs.Add(job);
            dbb.SaveChanges();

        }

        public void Dispose()
        {
            dbb.Dispose();
        }
    }
}