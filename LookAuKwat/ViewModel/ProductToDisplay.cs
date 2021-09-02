using LookaukwatApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class ProductToDisplay
    {
        public int id { get; set; }
        [DisplayName("Titre")]
        public string Title { get; set; }
       
        [DisplayName("Ville")]
        public string Town { get; set; }

        [DisplayName("Pays")]
        public string Country { get; set; }
        public string Description { get; set; }
        [DisplayName("Quartier")]
        public string Street { get; set; }
        public string SearchOrAskJob { get; set; }
       
        [DisplayName("Prix")]
        public int Price { get; set; }
        [DisplayName("Date d'ajout")]
        public DateTime DateAdd { get; set; }
        public string Date { get => ConvertDate(DateAdd); }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public bool IsLookaukwat { get; set; }
        public string ProductCountry { get; set; }
        public string MoneySymbol { get => StaticListConvertMoney.GetSymbol(ProductCountry); }
        private string ConvertDate(DateTime date)
        {
            TimeSpan elapsTime = DateTime.Now - date;
            string period = null;
            int time = 0;

            if (elapsTime.TotalMinutes < 60)
            {
                time = elapsTime.Minutes;
                period = "minutes";
            }
            else if (elapsTime.TotalMinutes > 60 && elapsTime.TotalMinutes < 1440)
            {
                time = elapsTime.Hours;
                period = "Heures";
            }
            else if (elapsTime.TotalMinutes > 1440)
            {
                time = elapsTime.Days;
                period = "Jours";
            }

            return "Ajoutée il y'a " + time.ToString() + " " + period;
        }
    }
}