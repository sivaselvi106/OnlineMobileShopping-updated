using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileShopping.Models
{
    public class MobileViewModel
    {
        [Required]
        public string BrandName { get; set; }
        [Required]
       
        public int Id { get; set; }
        [Required]
        public string MobileModel { get; set; }
        public string Processor { get; set; }
        [Required]
        public string RAM { get; set; }
        [Required]
        public string Storage { get; set; }
        [Required]
        public string DisplaySize { get; set; }
        [Required]
        public string Slimness { get; set; }
        [Required]
        public string Pixel { get; set; }
        [Required]
        public string BatteryCapacity { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public double Price { get; set; }
    }
}