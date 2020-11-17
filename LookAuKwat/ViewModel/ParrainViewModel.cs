using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LookAuKwat.ViewModel
{
    public class ParrainViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}