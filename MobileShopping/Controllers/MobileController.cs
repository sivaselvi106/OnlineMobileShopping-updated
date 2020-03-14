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

namespace MobileShopping.Controllers
{
    public class MobileController : Controller
    {
        MobileBL mobileBL = new MobileBL();
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MobileViewModel mobileViewModel)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(mapping =>
                {
                    mapping.CreateMap<MobileViewModel, Mobile>();
                });
                IMapper mapper = config.CreateMapper();
                var mobile = mapper.Map<MobileViewModel, Mobile>(mobileViewModel);
                //Mobile mobile = new Mobile();
                //mobile.BrandName = mobileViewModel.BrandName;
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
        public ActionResult Edit(int id)
        {
            Mobile mobile = mobileBL.GetMobileId(id);
            return View(mobile);
        }
        [HttpPost]
        public ActionResult Update(MobileViewModel mobileViewModel)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(mapping =>
                {
                    mapping.CreateMap<MobileViewModel, Mobile>();
                });
                IMapper mapper = config.CreateMapper();
                var mobile = mapper.Map<MobileViewModel, Mobile>(mobileViewModel);
                //Mobile mobile = new Mobile();
                //mobile.BrandName = mobileViewModel.BrandName;
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
                mobileBL.UpdateMobile(mobile);
                return RedirectToAction("Display");
            }
            else
            {
                ModelState.AddModelError("", "Some error occurred");
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            mobileBL.DeleteMobile(id);
            return RedirectToAction("Display");
        }
        public ActionResult Display()
        {
            IEnumerable<Mobile> list = mobileBL.DisplayDetails();
            return View(list);
        }
    }
}