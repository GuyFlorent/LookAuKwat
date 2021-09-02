using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LookAuKwat.Models
{
    public class EventModel : ProductModel
    {
        [DisplayName("Rubrique")]
        public string RubriqueEvent { get; set; }
        [DisplayName("Type")]
        public string TypeEvent { get; set; }
        [DisplayName("La rencontre")]
        public string Sport_Game { get; set; }
        [DisplayName("Promoteur")]
        public string Artist_Name { get; set; }
        [DisplayName("Date")]
        public DateTime DateEvent { get; set; }
        [DisplayName("Heure de début")]
        public TimeSpan Hour { get; set; }
    }
}