using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileShopping.Entity;

namespace MobileShopping.DAL
{
    public class OnlineMobileShoppingContext : DbContext
    {
        public DbSet<Account> AccountDB { get; set; }
        public DbSet<Mobile> MobileDB { get; set; }
        public DbSet<Brand> BrandDB { get; set; }
    }
    public class AccountRepository
    {
        public void SignUp(Account user)
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                context.AccountDB.Add(user);
                context.SaveChanges();
            }
        }

        public IEnumerable<Account> DisplayUsers()
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                List<Account> user = context.AccountDB.ToList();
                return user;
            }
        }
        public Account Login(Account account)
        {
            OnlineMobileShoppingContext context = new OnlineMobileShoppingContext();
            var result = context.AccountDB.Where(user => user.MailId == account.MailId && user.Password == account.Password).FirstOrDefault();
            return result;
        }

        public IEnumerable<Account> GetUserDetails(Account user)
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                //Account account = GetUserId(user.MailId);
                var result = context.AccountDB.Where(Value => Value.MailId == user.MailId);
                return result;
            }

        }

        public void UpdateUser(Account user)
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                Account updateUser = GetUserId(user.MailId);
                updateUser.UserName = user.UserName;
                updateUser.MailId = user.MailId;
                updateUser.Password = user.Password;
                // updateUser.UpdatedDate = user.UpdatedDate;
                updateUser.MobileNo = user.MobileNo;
                updateUser.LastLoginTime = user.LastLoginTime;
                updateUser.Gender = user.Gender;
                updateUser.City = user.City;
                updateUser.Age = user.Age;
                context.SaveChanges();
            }
        }
        public void DeleteUser(Account user)
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                context.AccountDB.Remove(user);
                context.SaveChanges();
            }
        }
        public Account GetUserId(string Id)
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                Account user = context.AccountDB.Find(Id);
                return user;
            }

        }
    }
}
