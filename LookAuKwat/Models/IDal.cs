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
        bool User_Email_Already_Exist(string number);
        bool User_Number_Already_Exist(string email);
        void Update_Date_First_Publish(ApplicationUser user);
        void UpdateUserByAdmin(ApplicationUser user);
        void DeleteUserByAdmin(ApplicationUser user);
        //Parrain
        List<ParrainModel> GetParrainList();
        void  AddParrain(ParrainModel model);
        void  DeletParrain(ParrainModel model);
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

        //For Mode model
        void AddMode(ModeModel model, string lat, string lon);
        void EditMode(ModeModel model, string lat, string lon);
        IEnumerable<ModeModel> GetListMode();
    }
}