﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookAuKwat.Models
{
    public class VehiculeModel : ProductModel
    {
        public string RubriqueVehicule { get; set; }
        public string BrandVehicule { get; set; }
        public string ModelVehicule { get; set; }
        public string TypeVehicule { get; set; }
        public string PetrolVehicule { get; set; }
        public string FirstYearVehicule { get; set; }
        public string YearVehicule { get; set; }
        public string MileageVehicule { get; set; }
        public string NumberOfDoorVehicule { get; set; }
        public string ColorVehicule { get; set; }
        public string GearBoxVehicule { get; set; }
        public string ModelAccessoryAutoVehicule { get; set; }
        public string ModelAccessoryBikeVehicule { get; set; }
    }
}