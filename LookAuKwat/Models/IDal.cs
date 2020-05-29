using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookAuKwat.Models
{
    public interface IDal : IDisposable 
    {
        //User
        List<ApplicationUser> GetUsersList();
        ApplicationUser GetUserByStrId(string id);
        //Product
        IEnumerable<ProductModel> GetListProduct();
        IEnumerable<JobModel> GetListJob();
        void DeleteProduct(ProductModel product);
        IEnumerable<ProductModel> GetListUserProduct(string id);
        //Product Image
        void DeleteImage(ImageProcductModel image);
        List<ImageProcductModel> GetImageList();
        //job Category
        void AddJob(JobModel job, string lat, string lon);
        void EditJob(JobModel job, string lat, string lon);

        // Apartment category
        void AddAppartment(ApartmentRentalModel apart, string lat, string lon);
        void EditApartment(ApartmentRentalModel apart, string lat, string lon);
        IEnumerable<ApartmentRentalModel> GetListAppart();
    }
}