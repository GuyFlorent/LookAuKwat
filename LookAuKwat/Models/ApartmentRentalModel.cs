using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookAuKwat.Models
{
    public class ApartmentRentalModel : ProductModel
    {
        public int ApartSurface { get; set; }
        public int RoomNumber { get; set; }
        public string FurnitureOrNot { get; set; }
        public string Type { get; set; }
      
    }
}