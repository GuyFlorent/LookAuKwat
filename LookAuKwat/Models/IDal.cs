using LookAuKwat.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LookAuKwat.Models
{
    public interface IDal : IDisposable 
    {
        //User
        IQueryable<ApplicationUser> GetUsersList();
        ApplicationUser GetUserByStrId(string id);
        void UpdateUserInformations(ApplicationUser user);
        bool User_Email_Already_Exist(string number);
        bool User_Number_Already_Exist(string email);
        void Update_Date_First_Publish(ApplicationUser user);
        void UpdateUserByAdmin(ApplicationUser user);
        void DeleteUserByAdmin(ApplicationUser user);
        //Parrain
        IQueryable<ParrainModel> GetParrainList();
        IQueryable<ApplicationUser> GetParrainList_WithRole();
        void  AddParrain(ParrainModel model);
        void  DeletParrain(string ParrainEmail);
        //Product
        IEnumerable<ProductModel> GetListProduct();
        IEnumerable<int> GetListIdProduct();
        IQueryable<ProductModel> GetListProductWhithNoInclude();
        List<ProductToDisplay> GetListProductToDisplay();
        IEnumerable<ProductModel> GetListAskProduct();
        IEnumerable<JobModel> GetListJob();
        IQueryable<JobModel> GetListJobWithNoInclude();
         void UpdateNumberView(ProductModel product);
        void DeleteProduct(ProductModel product);
        IEnumerable<ProductModel> GetListUserProduct(string id);
        //Product Image
        Task DeleteImage(ImageProcductModel image);
        List<ImageProcductModel> GetImageList();
        void UpdateImage(ImageProcductModel image);
        //job Category
        void AddJob(JobModel job, string lat, string lon);
        void EditJob(JobModel job, string lat, string lon);

        // Apartment category
        void AddAppartment(ApartmentRentalModel apart, string lat, string lon);
        void EditApartment(ApartmentRentalModel apart, string lat, string lon);
        IEnumerable<ApartmentRentalModel> GetListAppart();
        IQueryable<ApartmentRentalModel> GetListAppartWithNoInclude();

        //For message model
        IEnumerable<MessageDetails> GetListMessage();

        //For Multimedia model
        void AddMultimedia(MultimediaModel model, string lat, string lon);
        void EditMultimedia(MultimediaModel model, string lat, string lon);
        IEnumerable<MultimediaModel> GetListMultimedia();
        IQueryable<MultimediaModel> GetListMultimediaWithNoInclude();

        //For Vehicule model
        void AddVehicule(VehiculeModel model, string lat, string lon);
        void EditVehicule(VehiculeModel model, string lat, string lon);
        IEnumerable<VehiculeModel> GetListVehicule();
        IQueryable<VehiculeModel> GetListVehiculeWithNoInclude();

        //For Mode model
        void AddMode(ModeModel model, string lat, string lon);
        void EditMode(ModeModel model, string lat, string lon);
        IEnumerable<ModeModel> GetListMode();
        IQueryable<ModeModel> GetListModeWithNoInclude();
       

        // for House model
        void AddHouse(HouseModel model, string lat, string lon);
        void EditHouse(HouseModel model, string lat, string lon);
        IEnumerable<HouseModel> GetListHouse();
        IQueryable<HouseModel> GetListHouseWithNoInclude();
        Task<HouseModel> GetHouseWithNoInclude(int id);
        void AddImage(ProductModel model);

        //For Event model
        IQueryable<EventModel> GetListEventWithNoInclude();

        //For Divers model
        IQueryable<DiversModel> GetListDiversWithNoInclude();

        //For provider

        IEnumerable<SelectListItem> GetProviderList();

    }
}