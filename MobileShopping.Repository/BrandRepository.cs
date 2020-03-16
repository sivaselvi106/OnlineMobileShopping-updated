using MobileShopping.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Brand GetBrandId(int id)
        {

            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                Brand brand = context.BrandDB.Find(id);
                return brand;
            }
        }

        public void UpdateBrand(Brand brand)
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                Brand updateBrand = context.BrandDB.Find(brand);
                updateBrand.BrandName = brand.BrandName;
                context.SaveChanges();
            }
        }
        public IEnumerable<Brand> Display()
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                List<Brand> brand = context.BrandDB.ToList();
                return brand;
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
        public List<Brand> DropDownList()
        {
            using (OnlineMobileShoppingContext context = new OnlineMobileShoppingContext())
            {
                List<Brand> brands = context.BrandDB.ToList();
                return brands;
            }
        }

    }
}
