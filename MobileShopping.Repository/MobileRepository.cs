using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileShopping.Entity;


namespace MobileShopping.DAL
{
    public class MobileRepository
    {
        public void Create(Mobile mobile)
        {
            using (AccountContext accountContext = new AccountContext())
            {
                accountContext.MobileDB.Add(mobile);
                accountContext.SaveChanges();
            }
        }
        public Mobile GetMobileId(int mobileId)
        {
            using (AccountContext accountContext = new AccountContext())
            {
               Mobile mobile =  accountContext.MobileDB.Find(mobileId);
                return mobile;
            }
           // return mobiles.Find(id => id.Id == mobileId);
        }
        public void UpdateMobile(Mobile mobile)
        {
            using(AccountContext accountContext = new AccountContext())
            {
                accountContext.SaveChanges();
            }
        }
        public void DeleteMobile(int id)
        {
            using (AccountContext accountContext = new AccountContext())
            {
                Mobile mobile = accountContext.MobileDB.Find(id);
                accountContext.MobileDB.Remove(mobile);
                accountContext.SaveChanges();
            }
        }
        public IEnumerable<Mobile> DisplayMobile()
        {
            using (AccountContext accountContext = new AccountContext())
            {
                IEnumerable<Mobile> mobile =accountContext.MobileDB.ToList();
                return mobile;
            }
        }
    }
}
