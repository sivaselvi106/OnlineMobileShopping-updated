using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileShopping.BL;
using MobileShopping.DAL;
using MobileShopping.Entity;
using MobileShopping.Models;

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
                Mobile mobile = new Mobile();
                mobile.BrandName = mobileViewModel.BrandName;
                mobile.Id = mobileViewModel.Id;
                mobile.BatteryCapacity = mobileViewModel.BatteryCapacity;
                mobile.Color = mobileViewModel.Color;
                mobile.DisplaySize = mobileViewModel.DisplaySize;
                mobile.MobileModel = mobileViewModel.MobileModel;
                mobile.Pixel = mobileViewModel.Pixel;
                mobile.Price = mobileViewModel.Price;
                mobile.Processor = mobileViewModel.Processor;
                mobile.RAM = mobileViewModel.RAM;
                mobile.Slimness = mobileViewModel.Slimness;
                mobile.Storage = mobileViewModel.Storage;
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
                Mobile mobile = new Mobile();
                mobile.BrandName = mobileViewModel.BrandName;
                mobile.Id = mobileViewModel.Id;
                mobile.BatteryCapacity = mobileViewModel.BatteryCapacity;
                mobile.Color = mobileViewModel.Color;
                mobile.DisplaySize = mobileViewModel.DisplaySize;
                mobile.MobileModel = mobileViewModel.MobileModel;
                mobile.Pixel = mobileViewModel.Pixel;
                mobile.Price = mobileViewModel.Price;
                mobile.Processor = mobileViewModel.Processor;
                mobile.RAM = mobileViewModel.RAM;
                mobile.Slimness = mobileViewModel.Slimness;
                mobile.Storage = mobileViewModel.Storage;
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
            IEnumerable<Mobile> list=mobileBL.DisplayDetails();
            return View(list);
        }
        //[HttpGet]
        //[ActionName("Create")]
        //public ActionResult Create()
        //{
        //    return View();
        //}
        ////public ActionResult Create(Mobile mobile)
        ////{
        ////    mobileRepository.AddMobile(mobile);
        ////    TempData["Message"] = "Mobile added successfully!!!";
        ////    return RedirectToAction("Display");
        ////}
        ////public ActionResult Create_Post()
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        Mobile mobile = new Mobile();
        ////        UpdateModel(mobile);
        ////        mobileRepository.AddMobile(mobile);
        ////        TempData["Message"] = "Mobile added successfully!!!";
        ////        return RedirectToAction("Display");
        ////    }
        ////    return View();
        ////}
        //[HttpPost]
        //[ActionName("Create")]
        //public ActionResult Create_Post()
        //{
        //    Mobile mobile = new Mobile();
        //    TryUpdateModel(mobile);
        //    if (ModelState.IsValid)
        //    {
        //        mobileRepository.AddMobile(mobile);
        //        TempData["Message"] = "Mobile added successfully!!!";
        //        return RedirectToAction("Display");
        //    }
        //    return View();
        //}

        //public ActionResult Delete(int id)
        //{
        //    mobileRepository.DeleteMobile(id);
        //    TempData["Message"] = "Mobile deleted successfully";
        //    return RedirectToAction("Display");
        //}

        //public ActionResult Edit(int id)
        //{
        //    Mobile mobile = mobileRepository.GetMobileId(id);
        //    return View(mobile);
        //}
        //[HttpPost]
        //public ActionResult Update(Mobile mobile)
        //{
        //    mobileRepository.UpdateMobile(mobile);
        //    TempData["Message"] = "Updated successfully";
        //    return RedirectToAction("Display");
        //}

    }
}