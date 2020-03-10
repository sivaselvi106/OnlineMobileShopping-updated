using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileShopping.Models
{
    public class LoginModel
    {
        
        [Required]
        [EmailAddress]
        public string MailId { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}