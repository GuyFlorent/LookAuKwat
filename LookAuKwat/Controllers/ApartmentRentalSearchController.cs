using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LookAuKwat.Controllers
{
    public class ApartmentRentalSearchController : Controller
    {

        private IDal dal;
        public ApartmentRentalSearchController() : this(new Dal())
        {

        }

        public ApartmentRentalSearchController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: ApartmentRentalSearch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchOfferAppart_PartialView(SeachJobViewModel model)
        {

            return PartialView(model);
        }
        
        public ActionResult searchOfferAppart(SeachJobViewModel model)
        {
            model.CagtegorieSearch = "Immobilier";
            model.SearchOrAskJobJob = "J'offre";
            List<ApartmentRentalModel> liste = dal.GetListAppart().Where(m => m.Category.CategoryName == model.CagtegorieSearch && m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();

            if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
                && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
                && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {

                TempData["listeApart"] = liste;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
                && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
                && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
                && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
                && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
                && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
                && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                && r.Town == model.TownSearch).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
                && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
                && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                && r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface).ToList();
                TempData["listeJob"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
                && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
                && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                && r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MinApartSurface).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
               && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
               && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                && r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MinApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
               && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
               && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                && r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MinApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
               && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
               && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                && r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MinApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
               && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
               && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Town == model.TownSearch).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
              && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
              && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
            && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
            && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
           && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
           && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
              && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
              && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface >= model.MinApartSurface).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
              && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
              && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface >= model.MinApartSurface
                && r.ApartSurface <= model.MaxApartSurface).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
              && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
              && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface >= model.MinApartSurface
                && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface >= model.MinApartSurface
                && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface >= model.MinApartSurface
                && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type
                && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface <= model.MaxApartSurface).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
            && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
            && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
            && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
            && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
            && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
            && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Type == model.Type).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
           && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
           && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
            && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
            && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
          && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
          && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
         && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
         && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
         && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
         && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
         && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
         && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
         && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
         && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
        && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
        && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
        && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
        && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
        && model.MinApartSurface <=0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
        && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                 && r.ApartSurface <= model.MaxApartSurface).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                 && r.FurnitureOrNot == model.FurnitureOrNot).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                 && r.Type == model.Type).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                 && r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
        && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
        && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface
                && r.ApartSurface <= model.MaxApartSurface).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface
                && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
     && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
     && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface
                && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
     && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
     && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface
                && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type
                && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface <= model.MaxApartSurface).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.FurnitureOrNot == model.FurnitureOrNot).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
     && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
     && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
    && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
    && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApart"] = list;
            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
    && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
    && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch 
                && r.Type == model.Type).ToList();

                TempData["listeApart"] = list;
            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
   && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
   && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.RoomNumber >= model.RoomNumber
                && r.Type == model.Type).ToList();

                TempData["listeApart"] = list;
            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.RoomNumber >= model.RoomNumber).ToList();


                TempData["listeApart"] = list;
            }

            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
        && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
        && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
        && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
        && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
        && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
        && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface
                && r.Type == model.Type ).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface 
                && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
     && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
     && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.RoomNumber >= model.RoomNumber
               ).ToList();
                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
    && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
    && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
    && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
    && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.FurnitureOrNot == model.FurnitureOrNot).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
   && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
   && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
   && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
   && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.Type == model.Type).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.Type == model.Type && 
                r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface  &&
                r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
   && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
   && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.FurnitureOrNot == model.FurnitureOrNot).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.FurnitureOrNot == model.FurnitureOrNot).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
 && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
 && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type
                && r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.FurnitureOrNot == model.FurnitureOrNot && r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Type == model.Type).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApart"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApart"] = list;

            }
            model.ListePro = new List<ProductModel>();
            return RedirectToAction("ResultSearch_PartialView", "Product", model);
        }


        public ActionResult ResultSearchOfferApart_Jason(string type, string town, int minSurface, int maxSurface, string furnitureOrNot, int roomNumber, int minPrice, int maxPrice)
        {
            SeachJobViewModel model = new SeachJobViewModel();
            model.Type = type;
            model.TownSearch = town;
            model.MinApartSurface = minSurface;
            model.MaxApartSurface = maxSurface;
            model.PriceMinSearch = minPrice;
            model.PriceMaxSearch = maxPrice;
            model.FurnitureOrNot = furnitureOrNot;
            model.RoomNumber = roomNumber;
            model.CagtegorieSearch = "Immobilier";
            model.SearchOrAskJobJob = "J'offre";
            List<ApartmentRentalModel> liste = dal.GetListAppart().Where(m => m.Category.CategoryName == model.CagtegorieSearch && m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();

            if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
               && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
               && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {

                TempData["listeApartJson"] = liste;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
                && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
                && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
                && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
                && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
                && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
                && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                && r.Town == model.TownSearch).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
                && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
                && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                && r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
                && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
                && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                && r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MinApartSurface).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
               && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
               && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                && r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MinApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
               && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
               && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                && r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MinApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
               && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
               && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Price <= model.PriceMaxSearch
                && r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MinApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                 && r.ApartSurface <= model.MaxApartSurface).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                 && r.FurnitureOrNot == model.FurnitureOrNot).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                 && r.Type == model.Type).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                 && r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
               && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
               && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Town == model.TownSearch).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
              && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
              && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
            && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
            && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
           && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
           && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
              && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
              && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface >= model.MinApartSurface).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
              && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
              && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface >= model.MinApartSurface
                && r.ApartSurface <= model.MaxApartSurface).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
              && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
              && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface >= model.MinApartSurface
                && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface >= model.MinApartSurface
                && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface >= model.MinApartSurface
                && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type
                && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface <= model.MaxApartSurface).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
            && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
            && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
            && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
            && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
             && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
             && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
            && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
            && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Type == model.Type).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
           && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
           && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch > 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
            && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
            && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price >= model.PriceMinSearch && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && string.IsNullOrWhiteSpace(model.TownSearch)
          && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
          && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
         && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
         && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
         && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
         && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
         && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
         && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
         && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
         && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
        && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
        && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch > 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
        && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
        && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Price <= model.PriceMaxSearch && r.Town == model.TownSearch
                && r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
        && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
        && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface
                && r.ApartSurface <= model.MaxApartSurface).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface
                && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
     && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
     && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface
                && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
     && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
     && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface >= model.MinApartSurface
                && r.ApartSurface <= model.MaxApartSurface && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type
                && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface <= model.MaxApartSurface).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.FurnitureOrNot == model.FurnitureOrNot).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
     && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
     && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
    && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
    && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApartJson"] = list;
            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
    && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
    && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch
                && r.Type == model.Type).ToList();

                TempData["listeApartJson"] = list;
            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
   && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
   && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.RoomNumber >= model.RoomNumber
                && r.Type == model.Type).ToList();

                TempData["listeApartJson"] = list;
            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && !string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Town == model.TownSearch && r.RoomNumber >= model.RoomNumber).ToList();


                TempData["listeApartJson"] = list;
            }

            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
        && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
        && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
        && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
        && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface > 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.ApartSurface <= model.MaxApartSurface
                && r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
        && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
        && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.FurnitureOrNot == model.FurnitureOrNot).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
       && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
       && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface
                && r.Type == model.Type).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
      && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
      && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface
                && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
     && model.MinApartSurface > 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
     && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.RoomNumber >= model.RoomNumber
               ).ToList();
                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
    && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
    && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
    && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
    && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.FurnitureOrNot == model.FurnitureOrNot).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
   && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
   && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.FurnitureOrNot == model.FurnitureOrNot
                && r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
   && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
   && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.Type == model.Type).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface && r.Type == model.Type &&
                r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface > 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.ApartSurface >= model.MinApartSurface &&
                r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
   && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
   && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.FurnitureOrNot == model.FurnitureOrNot).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.FurnitureOrNot == model.FurnitureOrNot).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
 && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
 && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.FurnitureOrNot == model.FurnitureOrNot && r.Type == model.Type
                && r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && !string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.FurnitureOrNot == model.FurnitureOrNot && r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber <= 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Type == model.Type).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && !string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.Type == model.Type && r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApartJson"] = list;

            }
            else if (model.PriceMinSearch <= 0 && model.PriceMaxSearch <= 0 && string.IsNullOrWhiteSpace(model.TownSearch)
  && model.MinApartSurface <= 0 && model.MaxApartSurface <= 0 && string.IsNullOrWhiteSpace(model.FurnitureOrNot)
  && string.IsNullOrWhiteSpace(model.Type) && model.RoomNumber > 0)
            {
                List<ApartmentRentalModel> list = liste.Where(r => r.RoomNumber >= model.RoomNumber).ToList();

                TempData["listeApartJson"] = list;

            }
            model.ListePro = new List<ProductModel>();
            return RedirectToAction("ResultSearchJson", "Product", model);

        }
    }
}