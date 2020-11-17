using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class DataUser_Agent
    {
        [DisplayName("Prenom")]
        public string FirstName { get; set; }
        [DisplayName("Téléphone")]
        public string Phone { get; set; }
        [DisplayName("Confirmation Email")]
        public string ConfirmEmail { get; set; }
        [DisplayName("Déposé annonce")]
        public string ConfirmPublish { get; set; }
        public string ConfirmPhoneNumber { get; set; }
        [DisplayName("Prix")]
        public int price { get; set; }
        [DisplayName("salaire total")]
        public int Totalprice { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateFirstPublish { get; set; }
        
    }
}