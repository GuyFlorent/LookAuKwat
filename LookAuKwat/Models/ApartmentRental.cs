using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookAuKwat.Models
{
    public class ApartmentRental : Product
    {
        public double ApartSurface { get; set; }
        public double RoomNumber { get; set; }
        public string FurnitureOrNot { get; set; }
      
    }
}