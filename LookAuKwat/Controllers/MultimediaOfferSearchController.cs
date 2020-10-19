using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LookAuKwat.Controllers
{
    public class MultimediaOfferSearchController : Controller
    {

        private IDal dal;
        public MultimediaOfferSearchController() : this(new Dal())
        {

        }

        public MultimediaOfferSearchController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: MultimediaOfferSearch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchOfferMultimedia_PartialView(SeachJobViewModel model)
        {
            model.PriceMultimedia = 1000000000;
            return PartialView(model);
        }

        public ActionResult searchOfferMultimedia(SeachJobViewModel model, int? pageNumber, string sortBy)
        {
            model.CagtegorieSearch = "Multimedia";
            model.SearchOrAskJobJob = "J'offre";
            model.sortBy = sortBy;
            model.PageNumber = pageNumber;
            List<MultimediaModel> liste = dal.GetListMultimedia().Where(m => m.Category.CategoryName == model.CagtegorieSearch && 
            m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();

            if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia) && string.IsNullOrWhiteSpace(model.BrandMultimedia)
                && string.IsNullOrWhiteSpace(model.ModelMultimedia) && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                TempData["listeMulti"] = liste;
            }else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia) && string.IsNullOrWhiteSpace(model.BrandMultimedia)
                && string.IsNullOrWhiteSpace(model.ModelMultimedia) && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia) && string.IsNullOrWhiteSpace(model.BrandMultimedia)
               && string.IsNullOrWhiteSpace(model.ModelMultimedia) && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia) 
                && !string.IsNullOrWhiteSpace(model.BrandMultimedia)&& string.IsNullOrWhiteSpace(model.ModelMultimedia) 
                && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
               && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
               && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia 
                && m.Brand == model.BrandMultimedia && m.Model == model.ModelMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
              && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
              && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Brand == model.BrandMultimedia && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
              && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
              && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Brand == model.BrandMultimedia && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity
                && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
             && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
             && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Brand == model.BrandMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
             && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
             && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Brand == model.BrandMultimedia
                && m.Model == model.ModelMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
            && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
            && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Brand == model.BrandMultimedia
                && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
            && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
            && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Brand == model.BrandMultimedia
                && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
           && string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
           && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Model == model.ModelMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
          && string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
          && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Model == model.ModelMultimedia
                && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
         && string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
         && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Model == model.ModelMultimedia
                && m.Capacity == model.Capacity && m.Price < model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
        && string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
        && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
       && string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
       && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Capacity == model.Capacity
                && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
      && string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
      && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
     && string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
     && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
    && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
    && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
   && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
   && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                && m.Model == model.ModelMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
  && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
  && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
 && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
 && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Model == model.ModelMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Model == model.ModelMultimedia
                && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Model == model.ModelMultimedia
                && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Capacity == model.Capacity ).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Capacity == model.Capacity
                && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Brand == model.BrandMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Brand == model.BrandMultimedia && m.Model == model.ModelMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Brand == model.BrandMultimedia && m.Model == model.ModelMultimedia
                && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Brand == model.BrandMultimedia && m.Model == model.ModelMultimedia
                && m.Capacity == model.Capacity && m.Price < model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Model == model.ModelMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Model == model.ModelMultimedia && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Model == model.ModelMultimedia && m.Capacity == model.Capacity
                && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Capacity == model.Capacity).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Capacity == model.Capacity && m.Price <model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Model == model.ModelMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity && m.Price<= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Price < model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                &&  m.Price < model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Brand == model.BrandMultimedia && m.Model == model.ModelMultimedia
                && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Brand == model.BrandMultimedia && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Brand == model.BrandMultimedia && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Brand == model.BrandMultimedia && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <=  0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity ).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                && m.Model == model.ModelMultimedia && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia ).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Model == model.ModelMultimedia
                && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Brand == model.BrandMultimedia && m.Model == model.ModelMultimedia
                && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti"] = liste;
            }

            model.ListePro = new List<ProductModel>();
            return RedirectToAction("ResultSearch_PartialView", "Product", model);

        }

        public ActionResult ResultSearchOfferMultimedia_Jason(string town, string type,string brand,string modele,string capacity, int maxPrice)
        {
            SeachJobViewModel model = new SeachJobViewModel();
            model.TypeMultimedia = type;
            model.TownMultimedia = town;
            model.BrandMultimedia = brand;
            model.ModelMultimedia = modele;
            model.PriceMultimedia = maxPrice;
            model.Capacity = capacity;
            model.CagtegorieSearch = "Multimedia";
            model.SearchOrAskJobJob = "J'offre";
            List<MultimediaModel> liste = dal.GetListMultimedia().Where(m => m.Category.CategoryName == model.CagtegorieSearch && m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();

            if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia) && string.IsNullOrWhiteSpace(model.BrandMultimedia)
               && string.IsNullOrWhiteSpace(model.ModelMultimedia) && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia) && string.IsNullOrWhiteSpace(model.BrandMultimedia)
               && string.IsNullOrWhiteSpace(model.ModelMultimedia) && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia) && string.IsNullOrWhiteSpace(model.BrandMultimedia)
               && string.IsNullOrWhiteSpace(model.ModelMultimedia) && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
                && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
                && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
               && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
               && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Brand == model.BrandMultimedia && m.Model == model.ModelMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
              && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
              && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Brand == model.BrandMultimedia && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
              && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
              && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Brand == model.BrandMultimedia && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity
                && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
             && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
             && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Brand == model.BrandMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
             && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
             && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Brand == model.BrandMultimedia
                && m.Model == model.ModelMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
            && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
            && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Brand == model.BrandMultimedia
                && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
            && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
            && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Brand == model.BrandMultimedia
                && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
           && string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
           && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Model == model.ModelMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
          && string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
          && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Model == model.ModelMultimedia
                && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
         && string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
         && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Model == model.ModelMultimedia
                && m.Capacity == model.Capacity && m.Price < model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
        && string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
        && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
       && string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
       && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Capacity == model.Capacity
                && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
      && string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
      && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
     && string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
     && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
    && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
    && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
   && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
   && string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                && m.Model == model.ModelMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
  && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
  && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
 && !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
 && !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Model == model.ModelMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Model == model.ModelMultimedia
                && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Model == model.ModelMultimedia
                && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Capacity == model.Capacity
                && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Brand == model.BrandMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Brand == model.BrandMultimedia && m.Model == model.ModelMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Brand == model.BrandMultimedia && m.Model == model.ModelMultimedia
                && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Brand == model.BrandMultimedia && m.Model == model.ModelMultimedia
                && m.Capacity == model.Capacity && m.Price < model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Model == model.ModelMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Model == model.ModelMultimedia && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Model == model.ModelMultimedia && m.Capacity == model.Capacity
                && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Capacity == model.Capacity).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Capacity == model.Capacity && m.Price < model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Model == model.ModelMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Price < model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                && m.Price < model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Brand == model.BrandMultimedia && m.Model == model.ModelMultimedia
                && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Brand == model.BrandMultimedia && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Brand == model.BrandMultimedia && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Brand == model.BrandMultimedia && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Model == model.ModelMultimedia && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Town == model.TownMultimedia && m.Type == model.TypeMultimedia
                && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                && m.Model == model.ModelMultimedia && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia <= 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                && m.Capacity == model.Capacity).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& !string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Brand == model.BrandMultimedia
                && m.Capacity == model.Capacity && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && !string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Type == model.TypeMultimedia && m.Model == model.ModelMultimedia
                && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownMultimedia) && string.IsNullOrWhiteSpace(model.TypeMultimedia)
&& !string.IsNullOrWhiteSpace(model.BrandMultimedia) && !string.IsNullOrWhiteSpace(model.ModelMultimedia)
&& string.IsNullOrWhiteSpace(model.Capacity) && model.PriceMultimedia > 0)
            {
                liste = liste.Where(m => m.Brand == model.BrandMultimedia && m.Model == model.ModelMultimedia
                && m.Price <= model.PriceMultimedia).ToList();
                TempData["listeMulti_Json"] = liste;
            }

            model.ListePro = new List<ProductModel>();
            return RedirectToAction("ResultSearchJson", "Product", model);
        }
    }
    }