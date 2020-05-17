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
        void DeleteProduct(ProductModel product);
        IEnumerable<ProductModel> GetListUserProduct(string id);
        //Product Image
        void DeleteImage(ImageProcductModel image);
        List<ImageProcductModel> GetImageList();
        //Work Category
        void AddJob(JobModel job, string lat, string lon);
        void EditJob(JobModel job, string lat, string lon);
    }
}