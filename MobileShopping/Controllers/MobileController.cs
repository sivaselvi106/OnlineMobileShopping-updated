using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileShopping.BL;
using MobileShopping.DAL;
using MobileShopping.Entity;
using MobileShopping.Models;
using AutoMapper;
using System.Web.Security;


namespace MobileShopping.Controllers
{
    public class MobileController : Controller
    {
        MobileBL mobileBL;
        BrandBL brandBL;
        public MobileController()
        {
            mobileBL = new MobileBL();
            brandBL = new BrandBL();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            try
            {
                ViewBag.brands = new SelectList(brandBL.GetBrand(), "BrandId", "BrandName");
                return View();
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MobileViewModel mobileViewModel)
        {
            try
            {
                ViewBag.brands = new SelectList(brandBL.GetBrand(), "BrandId", "BrandName");
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(mapping =>
                    {
                        mapping.CreateMap<MobileViewModel, Mobile>();
                    });
                    IMapper mapper = config.CreateMapper();
                    var mobile = mapper.Map<MobileViewModel, Mobile>(mobileViewModel);
                    //Mobile mobile = new Mobile();
                    ////mobile.BrandName = mobileViewModel.BrandName;
                    //mobile.Id = mobileViewModel.Id;
                    //mobile.BatteryCapacity = mobileViewModel.BatteryCapacity;
                    //mobile.Color = mobileViewModel.Color;
                    //mobile.DisplaySize = mobileViewModel.DisplaySize;
                    //mobile.MobileModel = mobileViewModel.MobileModel;
                    //mobile.Pixel = mobileViewModel.Pixel;
                    //mobile.Price = mobileViewModel.Price;
                    //mobile.Processor = mobileViewModel.Processor;
                    //mobile.RAM = mobileViewModel.RAM;
                    //mobile.Slimness = mobileViewModel.Slimness;
                    //mobile.Storage = mobileViewModel.Storage;
                    mobileBL.CreateMobile(mobile);
                    ViewBag.Message = "Mobile details added";
                    ModelState.Clear();
                    return RedirectToAction("Display");
                }
                else
                {
                    ModelState.AddModelError("", "Some error occurred");
                    return View(mobileViewModel);
                }

            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
        [Authorize(Roles = "Admin")]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.brands = new SelectList(brandBL.GetBrand(), "BrandId", "BrandName");
                Mobile mobile = mobileBL.GetMobileId(id);
                return View(mobile);
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MobileViewModel mobileViewModel)
        {
            try
            {

            if (ModelState.IsValid)
            {
                    ViewBag.brands = new SelectList(brandBL.GetBrand(), "BrandId", "BrandName");
                    var config = new MapperConfiguration(mapping =>
                {
                    mapping.CreateMap<MobileViewModel, Mobile>();
                });
                IMapper mapper = config.CreateMapper();
                    var mobile = mapper.Map<MobileViewModel, Mobile>(mobileViewModel);
                mobileBL.UpdateMobile(mobile);
                return RedirectToAction("Display");
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
      //  [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id)
        {
            try
            {

            mobileBL.DeleteMobile(id);
            return RedirectToAction("Display");
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }
      //  [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Display()
        {
            try
            {

            }
            catch
            {

            }
            IEnumerable<Mobile> list = mobileBL.DisplayDetails();
            return View(list);
        }
    }
}