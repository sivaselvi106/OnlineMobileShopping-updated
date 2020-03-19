using MobileShopping.Entity;
using System.Collections.Generic;
using MobileShopping.DAL;

namespace MobileShopping.BL
{
    public class BrandBL
    {
        BrandRepository brandRepository;
        public BrandBL()
        {
            brandRepository = new BrandRepository();
        }
        public void CreateBrand(Brand brand)
        {
            brandRepository.Create(brand);
        }
        public Brand GetMobile(int id)
        {
            return brandRepository.GetMobile(id);
        }
        public IEnumerable<Brand> GetBrand()
        {
            return brandRepository.GetBrand();
        }
        public void UpdateBrand(Brand brand)
        {
            brandRepository.UpdateBrand(brand);
        }

        public void DeleteBrand(int id)
        {
            brandRepository.DeleteBrand(id);
        }
    }
}
