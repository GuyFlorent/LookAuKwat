using LookAuKwat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class contactUserViewModel
    {
        [DisplayName("Votre nom")]
        public string NameSender { get; set; }
        [DisplayName("Votre Sujet")]
        public string SubjectSender { get; set; }
        [DisplayName("Votre Email")]
        public string EmailSender { get; set; }
        [DisplayName("Votre méssage")]
        public string Message { get; set; }
        public string user { get; set; }
    }
}