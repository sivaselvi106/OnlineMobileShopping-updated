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
        BrandBL brandBL = new BrandBL();
        public ActionResult AddBrand()
        {
            List<Brand> brands = brandBL.DropDown();
            ViewBag.brands = new SelectList(brands, "BrandId", "BrandName");
            return View();
        }
        [HttpPost]
        public ActionResult AddBrand(BrandViewModel brandViewModel)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(mapping =>
                {
                    mapping.CreateMap<BrandViewModel, Brand>();
                });
                IMapper mapper = config.CreateMapper();
                var brand = mapper.Map<BrandViewModel, Brand>(brandViewModel);
                brandBL.CreateMobile(brand);
                ViewBag.Message = "Brand details added";
                List<Brand> brands = brandBL.DropDown();
                ViewBag.brands = new SelectList(brands, "BrandId", "BrandName");
                ModelState.Clear();
                return RedirectToAction("");
            }
            else
            {
                ModelState.AddModelError("", "Some error occurred");
                return View(brandViewModel);
            }
        }
        public ActionResult EditBrand()
        {
            List<Brand> brands = brandBL.DropDown();
            ViewBag.brands = new SelectList(brands, "BrandId", "BrandName");
            return View();
        }
        [HttpPost]
        public ActionResult UpdateBrand(BrandViewModel brandViewModel)
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
                List<Brand> brands = brandBL.DropDown();
                ViewBag.brands = new SelectList(brands, "BrandId", "BrandName");
                return RedirectToAction("DisplayBrand");
            }
            else
            {
                ModelState.AddModelError("", "Some error occurred");
                return View();
            }
        }
        public ActionResult DeleteBrand(int id)
        {
            brandBL.DeleteBrand(id);
            return RedirectToAction("DisplayBrand");
        }
        public ActionResult DisplayBrand()
        {
            IEnumerable<Brand> list = brandBL.DisplayBrand();
            return View(list);
        }
    }
}