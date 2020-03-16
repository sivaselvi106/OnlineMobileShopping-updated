using MobileShopping.Entity;
using System.Collections.Generic;
using MobileShopping.DAL;

namespace MobileShopping.BL
{
    public class BrandBL
    {
        BrandRepository brandRepository = new BrandRepository();
        public void CreateMobile(Brand brand)
        {
            brandRepository.Create(brand);
        }

        public Brand GetBrandId(int id)
        {
            return brandRepository.GetBrandId(id);
        }

        public void UpdateBrand(Brand brand)
        {
            brandRepository.UpdateBrand(brand);
        }

        public void DeleteBrand(int id)
        {
            brandRepository.DeleteBrand(id);
        }
        public IEnumerable<Brand> DisplayBrand()
        {

            return brandRepository.Display();
        }
        public List<Brand> DropDown()
        {
            return brandRepository.DropDownList();
        }
    }
}
