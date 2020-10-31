using LookAuKwat.Models;
using LookAuKwat.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LookAuKwat.Controllers
{
    public class VehiculeOfferSearchController : Controller
    {
        private IDal dal;
        public VehiculeOfferSearchController() : this(new Dal())
        {

        }

        public VehiculeOfferSearchController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        // GET: MultimediaOfferSearch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchOfferVehicule_PartialView(SeachJobViewModel model)
        {
            
            return PartialView(model);
        }

        public ActionResult searchOfferVehicule(SeachJobViewModel model, int? pageNumber, string sortBy)
        {
            if (pageNumber != null)
            {
                this.Session["pageVehicule"] = pageNumber;
                
                this.Session["modelVehicule"] = model;
                var modell = this.Session["modelVehiculeNewModel"] as SeachJobViewModel;
                if (modell != null)
                    model = modell;
                model.PageNumber = pageNumber;
            }
            else if (pageNumber == null)
            {
                var mod = this.Session["modelVehicule"] as SeachJobViewModel;
                if (mod != null && mod.TownVehicule == model.TownVehicule && mod.RubriqueVehicule == model.RubriqueVehicule &&
                    mod.BrandVehicule == model.BrandVehicule && mod.ModelVehicule == model.ModelVehicule)
                {
                    var page = this.Session["pageVehicule"] as int?;
                    var modell = this.Session["modelVehiculeNewModel"] as SeachJobViewModel;
                    if (modell != null)
                        model = modell;
                    model.PageNumber = page;
                }
                else if (mod != null && (mod.TownVehicule != model.TownVehicule || mod.RubriqueVehicule != model.RubriqueVehicule ||
                  mod.BrandVehicule != model.BrandVehicule || mod.ModelVehicule != model.ModelVehicule ))
                {
                    this.Session["modelVehiculeNewModel"] = model;
                    model.PageNumber = pageNumber;
                }

            }

            model.CagtegorieSearch = "Vehicule";
            model.SearchOrAskJobJob = "J'offre";
            model.sortBy = sortBy;
            
            List<VehiculeModel> liste = dal.GetListVehicule().Where(m => m.Category.CategoryName == model.CagtegorieSearch &&
            m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();

            if (string.IsNullOrWhiteSpace(model.TownVehicule) && string.IsNullOrWhiteSpace(model.RubriqueVehicule) && string.IsNullOrWhiteSpace(model.BrandVehicule)
                && string.IsNullOrWhiteSpace(model.ModelVehicule) )
            {
                TempData["listeVehicule"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownVehicule) && string.IsNullOrWhiteSpace(model.RubriqueVehicule) && string.IsNullOrWhiteSpace(model.BrandVehicule)
                && string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule).ToList();
                TempData["listeVehicule"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownVehicule) && !string.IsNullOrWhiteSpace(model.RubriqueVehicule) && string.IsNullOrWhiteSpace(model.BrandVehicule)
               && string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule && m.RubriqueVehicule == model.RubriqueVehicule).ToList();
                TempData["listeVehicule"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownVehicule) && !string.IsNullOrWhiteSpace(model.RubriqueVehicule) && !string.IsNullOrWhiteSpace(model.BrandVehicule)
              && string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule && m.RubriqueVehicule == model.RubriqueVehicule
                && m.BrandVehicule == model.BrandVehicule).ToList();
                TempData["listeVehicule"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownVehicule) && !string.IsNullOrWhiteSpace(model.RubriqueVehicule) && !string.IsNullOrWhiteSpace(model.BrandVehicule)
             && !string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule && m.RubriqueVehicule == model.RubriqueVehicule
                && m.BrandVehicule == model.BrandVehicule && m.ModelVehicule == model.ModelVehicule).ToList();
                TempData["listeVehicule"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownVehicule) && string.IsNullOrWhiteSpace(model.RubriqueVehicule) && !string.IsNullOrWhiteSpace(model.BrandVehicule)
            && string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule && m.BrandVehicule == model.BrandVehicule).ToList();
                TempData["listeVehicule"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownVehicule) && string.IsNullOrWhiteSpace(model.RubriqueVehicule) && !string.IsNullOrWhiteSpace(model.BrandVehicule)
          && !string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule && m.BrandVehicule == model.BrandVehicule
                && m.ModelVehicule == model.ModelVehicule).ToList();
                TempData["listeVehicule"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownVehicule) && string.IsNullOrWhiteSpace(model.RubriqueVehicule) && string.IsNullOrWhiteSpace(model.BrandVehicule)
         && !string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule && m.ModelVehicule == model.ModelVehicule).ToList();
                TempData["listeVehicule"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownVehicule) && !string.IsNullOrWhiteSpace(model.RubriqueVehicule) && string.IsNullOrWhiteSpace(model.BrandVehicule)
       && !string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule && m.RubriqueVehicule == model.RubriqueVehicule && m.ModelVehicule == model.ModelVehicule).ToList();
                TempData["listeVehicule"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownVehicule) && !string.IsNullOrWhiteSpace(model.RubriqueVehicule) && string.IsNullOrWhiteSpace(model.BrandVehicule)
      && string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.RubriqueVehicule == model.RubriqueVehicule ).ToList();
                TempData["listeVehicule"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownVehicule) && !string.IsNullOrWhiteSpace(model.RubriqueVehicule) && !string.IsNullOrWhiteSpace(model.BrandVehicule)
     && string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.RubriqueVehicule == model.RubriqueVehicule && m.BrandVehicule == model.BrandVehicule).ToList();
                TempData["listeVehicule"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownVehicule) && !string.IsNullOrWhiteSpace(model.RubriqueVehicule) && !string.IsNullOrWhiteSpace(model.BrandVehicule)
    && !string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.RubriqueVehicule == model.RubriqueVehicule && m.BrandVehicule == model.BrandVehicule
                && m.ModelVehicule == model.ModelVehicule).ToList();
                TempData["listeVehicule"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownVehicule) && !string.IsNullOrWhiteSpace(model.RubriqueVehicule) && string.IsNullOrWhiteSpace(model.BrandVehicule)
   && !string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.RubriqueVehicule == model.RubriqueVehicule && m.ModelVehicule == model.ModelVehicule).ToList();
                TempData["listeVehicule"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownVehicule) && string.IsNullOrWhiteSpace(model.RubriqueVehicule) && !string.IsNullOrWhiteSpace(model.BrandVehicule)
  && string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.BrandVehicule == model.BrandVehicule).ToList();
                TempData["listeVehicule"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownVehicule) && string.IsNullOrWhiteSpace(model.RubriqueVehicule) && !string.IsNullOrWhiteSpace(model.BrandVehicule)
 && !string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.BrandVehicule == model.BrandVehicule && m.ModelVehicule == model.ModelVehicule).ToList();
                TempData["listeVehicule"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownVehicule) && string.IsNullOrWhiteSpace(model.RubriqueVehicule) && string.IsNullOrWhiteSpace(model.BrandVehicule)
&& !string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.ModelVehicule.ToLower() == model.ModelVehicule).ToList();
                TempData["listeVehicule"] = liste;
            }


            model.ListePro = new List<ProductModel>();
            return RedirectToAction("ResultSearch_PartialView", "Product", model);

        }


        public ActionResult searchOfferVehicule_Json(string town, string rubrique, string brand, string modele)
        {
            SeachJobViewModel model = new SeachJobViewModel();
            model.TownVehicule = town;
            model.RubriqueVehicule = rubrique;
            model.BrandVehicule = brand;
            model.ModelVehicule = modele;
           
            model.CagtegorieSearch = "Vehicule";
            model.SearchOrAskJobJob = "J'offre";
            List<VehiculeModel> liste = dal.GetListVehicule().Where(m => m.Category.CategoryName == model.CagtegorieSearch &&
            m.SearchOrAskJob == model.SearchOrAskJobJob).ToList();

            if (string.IsNullOrWhiteSpace(model.TownVehicule) && string.IsNullOrWhiteSpace(model.RubriqueVehicule) && string.IsNullOrWhiteSpace(model.BrandVehicule)
                && string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                TempData["listeVehicule_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownVehicule) && string.IsNullOrWhiteSpace(model.RubriqueVehicule) && string.IsNullOrWhiteSpace(model.BrandVehicule)
                && string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule).ToList();
                TempData["listeVehicule_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownVehicule) && !string.IsNullOrWhiteSpace(model.RubriqueVehicule) && string.IsNullOrWhiteSpace(model.BrandVehicule)
               && string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule && m.RubriqueVehicule == model.RubriqueVehicule).ToList();
                TempData["listeVehicule_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownVehicule) && !string.IsNullOrWhiteSpace(model.RubriqueVehicule) && !string.IsNullOrWhiteSpace(model.BrandVehicule)
              && string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule && m.RubriqueVehicule == model.RubriqueVehicule
                && m.BrandVehicule == model.BrandVehicule).ToList();
                TempData["listeVehicule_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownVehicule) && !string.IsNullOrWhiteSpace(model.RubriqueVehicule) && !string.IsNullOrWhiteSpace(model.BrandVehicule)
             && !string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule && m.RubriqueVehicule == model.RubriqueVehicule
                && m.BrandVehicule == model.BrandVehicule && m.ModelVehicule == model.ModelVehicule).ToList();
                TempData["listeVehicule"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownVehicule) && string.IsNullOrWhiteSpace(model.RubriqueVehicule) && !string.IsNullOrWhiteSpace(model.BrandVehicule)
            && string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule && m.BrandVehicule == model.BrandVehicule).ToList();
                TempData["listeVehicule_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownVehicule) && string.IsNullOrWhiteSpace(model.RubriqueVehicule) && !string.IsNullOrWhiteSpace(model.BrandVehicule)
          && !string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule && m.BrandVehicule == model.BrandVehicule
                && m.ModelVehicule == model.ModelVehicule).ToList();
                TempData["listeVehicule_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownVehicule) && string.IsNullOrWhiteSpace(model.RubriqueVehicule) && string.IsNullOrWhiteSpace(model.BrandVehicule)
         && !string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule && m.ModelVehicule == model.ModelVehicule).ToList();
                TempData["listeVehicule_Json"] = liste;
            }
            else if (!string.IsNullOrWhiteSpace(model.TownVehicule) && !string.IsNullOrWhiteSpace(model.RubriqueVehicule) && string.IsNullOrWhiteSpace(model.BrandVehicule)
       && !string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.Town == model.TownVehicule && m.RubriqueVehicule == model.RubriqueVehicule && m.ModelVehicule == model.ModelVehicule).ToList();
                TempData["listeVehicule_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownVehicule) && !string.IsNullOrWhiteSpace(model.RubriqueVehicule) && string.IsNullOrWhiteSpace(model.BrandVehicule)
      && string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.RubriqueVehicule == model.RubriqueVehicule).ToList();
                TempData["listeVehicule_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownVehicule) && !string.IsNullOrWhiteSpace(model.RubriqueVehicule) && !string.IsNullOrWhiteSpace(model.BrandVehicule)
     && string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.RubriqueVehicule == model.RubriqueVehicule && m.BrandVehicule == model.BrandVehicule).ToList();
                TempData["listeVehicule_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownVehicule) && !string.IsNullOrWhiteSpace(model.RubriqueVehicule) && !string.IsNullOrWhiteSpace(model.BrandVehicule)
    && !string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.RubriqueVehicule == model.RubriqueVehicule && m.BrandVehicule == model.BrandVehicule
                && m.ModelVehicule == model.ModelVehicule).ToList();
                TempData["listeVehicule_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownVehicule) && !string.IsNullOrWhiteSpace(model.RubriqueVehicule) && string.IsNullOrWhiteSpace(model.BrandVehicule)
   && !string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.RubriqueVehicule == model.RubriqueVehicule && m.ModelVehicule == model.ModelVehicule).ToList();
                TempData["listeVehicule_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownVehicule) && string.IsNullOrWhiteSpace(model.RubriqueVehicule) && !string.IsNullOrWhiteSpace(model.BrandVehicule)
  && string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.BrandVehicule == model.BrandVehicule).ToList();
                TempData["listeVehicule_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownVehicule) && string.IsNullOrWhiteSpace(model.RubriqueVehicule) && !string.IsNullOrWhiteSpace(model.BrandVehicule)
 && !string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.BrandVehicule == model.BrandVehicule && m.ModelVehicule == model.ModelVehicule).ToList();
                TempData["listeVehicule_Json"] = liste;
            }
            else if (string.IsNullOrWhiteSpace(model.TownVehicule) && string.IsNullOrWhiteSpace(model.RubriqueVehicule) && string.IsNullOrWhiteSpace(model.BrandVehicule)
&& !string.IsNullOrWhiteSpace(model.ModelVehicule))
            {
                liste = liste.Where(m => m.ModelVehicule.ToLower() == model.ModelVehicule).ToList();
                TempData["listeVehicule_Json"] = liste;
            }

            model.ListePro = new List<ProductModel>();
            return RedirectToAction("ResultSearchJson", "Product", model);

        }
    }
}