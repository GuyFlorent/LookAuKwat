using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookAuKwat.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public bool IsByLookaukwat { get; set; }
        public virtual ProductModel Product { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}