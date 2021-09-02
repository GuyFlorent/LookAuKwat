using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Hosting;
using Twilio.Rest.Chat.V2.Service.User;
using WebGrease.Css.Extensions;

[assembly: OwinStartupAttribute(typeof(LookAuKwat.Startup))]
namespace LookAuKwat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // app.MapSignalR();
          //  PopulateRole();
        }

        private void PopulateRole()
        {
            var db = new ApplicationDbContext();
            //if(!db.Roles.Any(x => x.Name == MyRoleConstant.RoleAdmin))
            //{
            //    db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(MyRoleConstant.RoleAdmin));
            //    db.SaveChanges();
            //}

            //if (!db.Roles.Any(x => x.Name == MyRoleConstant.RoleAgent))
            //{
            //    db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(MyRoleConstant.RoleAgent));
            //    db.SaveChanges();

            //}

            //if (!db.Roles.Any(x => x.Name == MyRoleConstant.Role_Old_Agent))
            //{
            //    db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(MyRoleConstant.Role_Old_Agent));
            //    db.SaveChanges();

            //}

            //if (!db.Roles.Any(x => x.Name == MyRoleConstant.RoleProvider))
            //{
            //    db.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(MyRoleConstant.RoleProvider));
            //    db.SaveChanges();

            //}

            var product = db.Products.ToList();
            foreach (var prop in product)
            {
                
                prop.IsActive = true;

            }
            db.SaveChanges();


            //var user = db.Users.First(s => s.Email == "wan@gmail.com");

            //var Roles = db.Roles.FirstOrDefault(s => s.Name == MyRoleConstant.RoleAdmin);

            //var userRoles = Roles.Users.FirstOrDefault(s => s.UserId == user.Id);

            //if (userRoles != null)
            //    Roles.Users.Remove(userRoles);



            //var userStore = new UserStore<ApplicationUser>(db);
            //var usermanager = new ApplicationUserManager(userStore);

            //var roleStore = new RoleStore<IdentityRole>(db);
            //var roleManager = new RoleManager<IdentityRole>(roleStore);

            //var user = db.Users.First(s => s.Email == "mbalemoniquemarcella@gmail.com");
            //var user1 = db.Users.First(s => s.Email == "maloumhamidou238@gmail.com");
            //var user2 = db.Users.First(s => s.Email == "dootyaaron@gmail.com");
            //var user3 = db.Users.First(s => s.Email == "odestinengossiba@gmail.com");
            //var user4 = db.Users.First(s => s.Email == "juromonkam@gmail.com");
            //var user5 = db.Users.First(s => s.Email == "larissazomo446@gmail.com");
            //var user6 = db.Users.First(s => s.Email == "nembotromeo@gmail.com");
            //var user7 = db.Users.First(s => s.Email == "ebanga.yannick@yahoo.fr");
            //var user8 = db.Users.First(s => s.Email == "bkstyle0905@gmail.com");
            //var user9 = db.Users.First(s => s.Email == "contact@lookaukwat.com");
            //var user10 = db.Users.First(s => s.Email == "wangueujunior23@gmail.com");
            //var user11 = db.Users.First(s => s.Email == "danielnoukeu05@gmail.com");

            //usermanager.AddToRole(user.Id, MyRoleConstant.RoleAgent);
            //usermanager.AddToRole(user1.Id, MyRoleConstant.RoleAgent);
            //usermanager.AddToRole(user2.Id, MyRoleConstant.RoleAgent);
            //usermanager.AddToRole(user3.Id, MyRoleConstant.RoleAgent);
            //usermanager.AddToRole(user4.Id, MyRoleConstant.RoleAgent);
            //usermanager.AddToRole(user5.Id, MyRoleConstant.Role_Old_Agent);
            //usermanager.AddToRole(user6.Id, MyRoleConstant.RoleAgent);
            //usermanager.AddToRole(user7.Id, MyRoleConstant.RoleAgent);
            //usermanager.AddToRole(user8.Id, MyRoleConstant.RoleAgent);
            //usermanager.AddToRole(user9.Id, MyRoleConstant.RoleAgent);
            //usermanager.AddToRole(user9.Id, MyRoleConstant.RoleAdmin);
            //usermanager.AddToRole(user10.Id, MyRoleConstant.RoleAgent);
            //usermanager.AddToRole(user10.Id, MyRoleConstant.RoleAdmin);
            //usermanager.AddToRole(user11.Id, MyRoleConstant.RoleAgent);
            //db.SaveChanges();




        }
    }
}
