using MobileShopping.Entity;
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
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string BrandName { get; set; }
        public IEnumerable<Mobile> Mobiles { get; set; }
    }
}