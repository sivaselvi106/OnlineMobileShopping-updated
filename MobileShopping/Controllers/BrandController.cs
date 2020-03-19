using AutoMapper;
using MobileShopping.Entity;
using MobileShopping.Models;
using System.Web.Mvc;
using MobileShopping.BL;
using System.Collections.Generic;

namespace MobileShopping.Controllers
{
    public class BrandController : Controller
    {
        BrandBL brandBL;
        public BrandController()
        {
            brandBL = new BrandBL();
        }
        [Authorize(Roles = "Admin")]

        public ActionResult AddBrand()
        {   
            return View();
        }
        [HttpPost]
        public ActionResult AddBrand(BrandViewModel brandViewModel)
        { 
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(mapping =>
                    {
                        mapping.CreateMap<BrandViewModel, Brand>();
                    });
                    IMapper mapper = config.CreateMapper();
                    var brand = mapper.Map<BrandViewModel, Brand>(brandViewModel);
                    brandBL.CreateBrand(brand);
                    ViewBag.Message = "Brand details added";
                    ModelState.Clear();
                    return RedirectToAction(nameof(DisplayBrand));
                }
                else
                {
                    ModelState.AddModelError("", "Some error occurred");
                    return View(brandViewModel);
                }
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
        [Authorize(Roles = "Admin")]

        public ActionResult EditBrand(int id)
        {
            try
            {
                Brand brands = brandBL.GetBrand(id);
                return View(brands);
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
          
        }
        [HttpPost]
        public ActionResult UpdateBrand(BrandViewModel brandViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(mapping =>
                    {
                        mapping.CreateMap<BrandViewModel, Brand>();
                    });
                    IMapper mapper = config.CreateMapper();
                    var brand = mapper.Map<BrandViewModel, Brand>(brandViewModel);
                    brandBL.UpdateBrand(brand);
                    return RedirectToAction(nameof(DisplayBrand));
                }
                else
                {
                    ModelState.AddModelError("", "Some error occurred");
                    return View();
                }
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
           
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteBrand(int id)
        {
            try
            {
                brandBL.DeleteBrand(id);
                return RedirectToAction("DisplayBrand");
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
           
        }
        public ActionResult DisplayBrand()
        {
            try
            {

            IEnumerable<Brand> list = brandBL.DisplayBrand();
            return View(list);
            }
            catch
            { 
                return RedirectToAction("Error", "Error");
            }
        }
    }
}