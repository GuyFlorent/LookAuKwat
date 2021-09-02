using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LookAuKwat.Models
{
    public class MultimediaModel : ProductModel
    {
        [DisplayName("Rubrique")]
        [Column("TypeMultimedia")]
        public string Type { get; set; }
        [DisplayName("Marque")]
        public string Brand { get; set; }
        [DisplayName("Modèle")]
        public string Model { get; set; }
        [DisplayName("Capacité de stockage")]
        public string Capacity { get; set; }
    }
}