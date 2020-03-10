using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileShopping.Models
{
    public class AccountEditViewModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z][a-zA-Z\\s]+$", ErrorMessage = "Not a valid name")]
        [MinLength(4), MaxLength(25)]
        public string UserName { get; set; }
        public int UserId { get; set; }
        [EmailAddress]
        public string MailId { get; set; }
        [Required]
        [MinLength(10)]
        public string Password { get; set; }

        public DateTime UpdatedDate
        {
            get
            {
                return DateTime.Now;
            }
        }
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [RegularExpression(@"^([789]\d{9})$", ErrorMessage = "Invalid Mobile Number.")]
        public long MobileNo { get; set; }
        public string City { get; set; }
    }
}