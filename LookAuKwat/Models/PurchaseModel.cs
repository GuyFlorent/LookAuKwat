﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookAuKwat.Models
{
    public class PurchaseModel
    {
        public int Id { get; set; }
        public virtual CommandModel Command { get; set; }
        public virtual ProductModel product { get; set; }
        public int Quantities { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}