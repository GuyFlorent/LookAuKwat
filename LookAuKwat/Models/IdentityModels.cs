﻿using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LookAuKwat.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        public int? Parrain_Id { get; set; }
        [DisplayName("Date de création de compte")]
        public DateTime Date_Create_Account { get; set; }
        [DisplayName("Date de 1er publication")]
        public DateTime? Date_First_Publish { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ProductCoordinateModel> ProductCoordinates { get; set; }
        public DbSet<JobModel> Jobs { get; set; }
        public DbSet<ImageProcductModel> Images { get; set; }
        public DbSet<ApartmentRentalModel> ApartmentRentals { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<MessageDetails> Messages { get; set; }
        public DbSet<MultimediaModel> Multimedia { get; set; }
        public DbSet<VehiculeModel> Vehicules { get; set; }
        public DbSet<ModeModel> Modes { get; set; }
        public DbSet<ParrainModel> Parrains { get; set; }
        public DbSet<HouseModel> Houses { get; set; }
        public DbSet<EventModel> Events { get; set; }
        //for command and purchase
        public DbSet<CommandModel> Commands { get; set; }
        public DbSet<PurchaseModel> Purchases { get; set; }
        public DbSet<DeliveredAdressModel> DeliveredAdresses { get; set; }
        public DbSet<TrackingCommandModel> TrackingCommands { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<FollowModel> Follows { get; set; }
        public DbSet<DiversModel> Divers { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}