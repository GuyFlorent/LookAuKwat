using LookAuKwat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class contactUserViewModel
    {
       // [Required]
        [DisplayName("Votre nom")]
        
        public string NameSender { get; set; }
       // [Required]
        [DisplayName("Votre Sujet")]
       
        public string SubjectSender { get; set; }
        
        [DisplayName("Votre Email")]
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress(ErrorMessage = "Adresse Email n'est pas valide!!")]
        public string EmailSender { get; set; }
        //[Required]
        [DisplayName("Votre message")]
        
        public string Message { get; set; }
        public string Linkshare { get; set; }
        public string RecieverEmail { get; set; }
        public string RecieverName { get; set; }
        public string targetId { get; set; }
        public HttpPostedFileBase file { get; set; }
        public string attachFile { get; set; }
        public string Category { get; set; }

    }
}