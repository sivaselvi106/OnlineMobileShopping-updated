using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MobileShopping.Entity
{
    public class Mobile
    {
        [Required]
        public string BrandName { get; set; }
        [Key]
        public int Id { get; set; }
        [Required]
        public string MobileModel { get; set; }
        [Required]
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
        public string Color { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
