using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MobileShopping.Entity
{
    public class Account
    {
        public string UserName { get; set; }
        [Key]
        public int UserId { get; set; }
        public string MailId { get; set; }
        public string Password { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public long MobileNo { get; set; }
        public string City { get; set; }
    }
}