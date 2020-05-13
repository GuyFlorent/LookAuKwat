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
        //Work Category
        void AddJob(Job job, string lat, string lon);
    }
}