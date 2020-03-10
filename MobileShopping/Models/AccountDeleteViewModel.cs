using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileShopping.Models
{
    public class AccountDeleteViewModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z][a-zA-Z\\s]+$", ErrorMessage = "Not a valid name")]
        [MinLength(4), MaxLength(25)]
        public string UserName { get; set; }

        [Key]
        [Required]
        public int UserId { get; set; }

        [Required]
        //[RegularExpression("^[\\w-_\\.+]*[\\w-_\\.]\\@([\\w]+\\.)+[\\w]+[\\w]$", ErrorMessage = "Not Valid EmailId")]
        [EmailAddress]
        public string MailId { get; set; }

    }
}