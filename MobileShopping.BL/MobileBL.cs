using MobileShopping.DAL;
using MobileShopping.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShopping.BL
{
    public class MobileBL
    {
        MobileRepository mobileRepository = new MobileRepository();
        public void CreateMobile(Mobile mobile)
        {
            mobileRepository.Create(mobile);
        }
        public void UpdateMobile(Mobile mobile)
        {
            mobileRepository.UpdateMobile(mobile);
        }
        public void DeleteMobile(int id)
        {
            mobileRepository.DeleteMobile(id);
        }
        public IEnumerable<Mobile> DisplayDetails()
        {
            return mobileRepository.DisplayMobile();
        }
        public Mobile GetMobileId(int id)
        {
            return mobileRepository.GetMobileId(id);
        }
    }
}
