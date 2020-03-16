using System.Web.Mvc;
using MobileShopping.Entity;
using MobileShopping.DAL;
using MobileShopping.Models;
using MobileShopping.BL;
using System.Collections.Generic;
using AutoMapper;
using System;

namespace MobileShopping.Controllers
{
    public class AccountController : Controller
    {
        AccountBL accountBL;
        public AccountController()
        {
        accountBL= new AccountBL();

        }
        public ActionResult UserDetails()
        {
            IEnumerable<Account> list = accountBL.DisplayUsers();
            return View(list);
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult SignUp(SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                //var config = new MapperConfiguration(mapping =>
                //{
                //    mapping.CreateMap<SignUpModel, Account>();
                //});
                //IMapper mapper = config.CreateMapper();
                //var account = mapper.Map<SignUpModel, Account>(signUpModel);
                Account account = new Account();
                account.UserName = signUpModel.UserName;
               // account.UserId = signUpModel.UserId;
                account.MailId = signUpModel.MailId;
                account.Password = signUpModel.Password;
                account.MobileNo = signUpModel.MobileNo;
                account.CreateDate = DateTime.Now;
                account.UpdatedDate = DateTime.Now;
                account.LastLoginTime = DateTime.Now;
                account.Gender = signUpModel.Gender;
                account.Age = signUpModel.Age;
                account.City = signUpModel.City;
                accountBL.SignUp(account);
                ViewBag.Message = "Successfully registered";
                ModelState.Clear();
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "Some error occurred");
                return View(signUpModel);
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            //var config = new MapperConfiguration(mapping =>
            //{
            //    mapping.CreateMap<LoginModel, Account>();
            //});
            //IMapper mapper = config.CreateMapper();
            //var user = mapper.Map<LoginModel, Account>(loginModel);
            Account user = new Account();
            user.MailId = loginModel.MailId;
            user.Password = loginModel.Password;
            var result = accountBL.Login(user);
            if (result != null)
            {
                Session["MailId"] = result.MailId.ToString();
                Session["Password"] = result.Password.ToString();
                return View("DisplayUsers");
            }
            ViewBag.Message = string.Format("Mail Id and password is incorrect");
            return View(user);
        }

        public ActionResult EditUser(int UserId) //Edit                             
        {
            Account user = accountBL.GetUserId(UserId);
            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateUser(SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account();
                account.UserName = signUpModel.UserName;
                account.UserId = signUpModel.UserId;
                account.MailId = signUpModel.MailId;
                account.Password = signUpModel.Password;
                account.MobileNo = signUpModel.MobileNo;
               // account.CreateDate = DateTime.Now;
                account.UpdatedDate = DateTime.Now;
                account.LastLoginTime = DateTime.Now;
                account.Gender = signUpModel.Gender;
                account.Age = signUpModel.Age;
                account.City = signUpModel.City;
                accountBL.EditUser(account);
                return RedirectToAction("UserDetails");
            }
            else
            {
                ModelState.AddModelError("", "Some error occurred");
                return View();
            }
        }
        public ActionResult DeleteUser(int id) //Delete
        {
            accountBL.DeleteUser(id);
            return RedirectToAction("UserDetails");
        }
    }
}
