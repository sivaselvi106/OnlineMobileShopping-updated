using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileShopping.Models
{
    public class BrandViewModel
    {
        [Key]
        
        public int Id { get; set; }
        
        [Required]
        public string BrandName { get; set; }
    }
}