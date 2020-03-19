using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                context.MobileDB.Add(mobile);
                context.SaveChanges();
            }
        }
        public IEnumerable<Mobile> GetBrand(int brandId)
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                List<Mobile> result = context.MobileDB.
                              Where(x => x.BrandId == brandId).ToList();
                return result;
            }
        }
        public IEnumerable<Mobile> DisplayMobile()
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                List<Mobile> mobile = context.MobileDB.Include("Brand").ToList();
                return mobile;
            }
        }
        public Mobile GetMobileId(int mobileId)
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
               Mobile mobile =  context.MobileDB.Find(mobileId);
                return mobile;
            }
           // return mobiles.Find(id => id.Id == mobileId);
        }
        public void UpdateMobile(Mobile mobile)
        {
            using(OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                Mobile updateMobile = context.MobileDB.Find(mobile.Id);
                context.Entry(mobile).State = EntityState.Modified;
                // updateMobile.BrandName = mobile.BrandName;
                //updateMobile.Id =mobile.Id;
                //updateMobile.BatteryCapacity = mobile.BatteryCapacity;
                //updateMobile.Color = mobile.Color;
                //updateMobile.DisplaySize= mobile.DisplaySize;
                //updateMobile.MobileModel = mobile.MobileModel;
                //updateMobile.Pixel =  mobile.Pixel ;
                //updateMobile.Price= mobile.Price ;
                //updateMobile.Processor =  mobile.Processor;
                //updateMobile.RAM = mobile.RAM ;
                //updateMobile.Slimness= mobile.Slimness;
                //updateMobile.Storage = mobile.Storage;
                context.SaveChanges();
            }
        }
        public void DeleteMobile(int id)
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                Mobile mobile = context.MobileDB.Find(id);
                context.MobileDB.Remove(mobile);
                context.SaveChanges();
            }
        }
    }
}
