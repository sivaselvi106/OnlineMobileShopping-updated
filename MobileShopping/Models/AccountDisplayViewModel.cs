using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileShopping.Models
{
    public class AccountDisplayViewModel
    {
        public string UserName { get; set; }
        //public int UserId { get; set; }
        public string MailId { get; set; }
       // public string Password { get; set; }
      //  public DateTime? CreateDate { get; set; }
      //  public DateTime? UpdatedDate { get; set; }
      //  public DateTime? LastLoginTime { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public long MobileNo { get; set; }
        public string City { get; set; }
    }
}