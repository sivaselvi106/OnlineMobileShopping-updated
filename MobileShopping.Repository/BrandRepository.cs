using MobileShopping.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace MobileShopping.DAL
{
    public class BrandRepository
    {
        public void Create(Brand brand)
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                context.BrandDB.Add(brand);
                context.SaveChanges();
            }
        }
        //public Brand GetBrandId(int id)
        //{

        //    using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
        //    {
        //        Brand brand = context.BrandDB.Find(id);
        //        return brand;
        //    }
        //}
        public IEnumerable<Brand> GetBrand()
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                return context.BrandDB.ToList();
            }
        }
        public Brand GetMobile(int id)
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                List<Mobile> mobile = context.MobileDB.ToList();
                Brand product = context.BrandDB.Where(key => key.BrandId == id).SingleOrDefault();
                return product;
            }
        }
        public void UpdateBrand(Brand brand)
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                Brand updateBrand = context.BrandDB.Find(brand);
                context.Entry(brand).State = EntityState.Modified;
                //  updateBrand.BrandName = brand.BrandName;
                context.SaveChanges();
            }
        }
        public void DeleteBrand(int id)
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                Brand brand = context.BrandDB.Find(id);
                context.BrandDB.Remove(brand);
                context.SaveChanges();
            }
        }
    }
}
