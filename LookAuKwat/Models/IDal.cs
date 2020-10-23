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
        void UpdateUserInformations(ApplicationUser user);
        //Product
        IEnumerable<ProductModel> GetListProduct();
        IEnumerable<ProductModel> GetListAskProduct();
        IEnumerable<JobModel> GetListJob();
        void UpdateNumberView(ProductModel product);
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

        //For message model
        IEnumerable<MessageDetails> GetListMessage();

        //For Multimedia model
        void AddMultimedia(MultimediaModel model, string lat, string lon);
        void EditMultimedia(MultimediaModel model, string lat, string lon);
        IEnumerable<MultimediaModel> GetListMultimedia();

        //For Vehicule model
        void AddVehicule(VehiculeModel model, string lat, string lon);
        void EditVehicule(VehiculeModel model, string lat, string lon);
        IEnumerable<VehiculeModel> GetListVehicule();
    }
}