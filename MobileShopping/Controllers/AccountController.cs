using System.Web.Mvc;
using MobileShopping.Entity;
using MobileShopping.Models;
using MobileShopping.BL;
using System.Collections.Generic;
using AutoMapper;
using System;
using System.Web.Security;
using System.Web;

namespace MobileShopping.Controllers
{
    public class AccountController : Controller
    {
        AccountBL accountBL;
     
        public AccountController()
        {
        accountBL= new AccountBL();
      
        }
        [HttpGet]
      //  [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
      //  [AllowAnonymous]
        public ActionResult SignUp(SignUpModel signUpModel)
        {
            try
            {

            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(mapping =>
                {
                    mapping.CreateMap<SignUpModel, Account>();
                });
                IMapper mapper = config.CreateMapper();
                var account = mapper.Map<SignUpModel, Account>(signUpModel);
                account.Role = "user";
                accountBL.SignUp(account);
                ViewBag.Message = "Successfully registered";
                ModelState.Clear();
                return RedirectToAction("Login");
               // Account account = new Account();
               // account.UserName = signUpModel.UserName;
               //// account.UserId = signUpModel.UserId;
               // account.MailId = signUpModel.MailId;
               // account.Password = signUpModel.Password;
               // account.MobileNo = signUpModel.MobileNo;
               // account.CreateDate = DateTime.Now;
               // account.UpdatedDate = DateTime.Now;
               // account.LastLoginTime = DateTime.Now;
               // account.Gender = signUpModel.Gender;
               // account.Age = signUpModel.Age;
               // account.City = signUpModel.City;
            }
            }
            catch
            {
                ModelState.AddModelError("", "Some error occurred");
                View("Error");
             }
            return View(signUpModel);
        }
        [HttpGet]
     //   [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
     //   [AllowAnonymous]

        public ActionResult Login(LoginModel loginModel)
        {
            var config = new MapperConfiguration(mapping =>
            {
                mapping.CreateMap<LoginModel, Account>();
            });
            IMapper mapper = config.CreateMapper();
            var user = mapper.Map<LoginModel, Account>(loginModel);
            user.LastLoginTime = DateTime.Now;  
            //Account user = new Account();
            //user.MailId = loginModel.MailId;
            //user.Password = loginModel.Password;
            var result = accountBL.Login(user);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(user.MailId, false);
                var authTicket = new FormsAuthenticationTicket(1, user.MailId, DateTime.Now, DateTime.Now.AddMinutes(60), false, result.Role);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("Index","Home");
            }
            else
            {
            ModelState.AddModelError("", "Invalid login credentials");
            return View(user);
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
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
               // account.LastLoginTime = DateTime.Now;
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
        public ActionResult UserDetails()
        {
            IEnumerable<Account> list = accountBL.DisplayUsers();
            return View(list);
        }
    }
}
