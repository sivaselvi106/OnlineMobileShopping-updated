using System.Web.Mvc;
using MobileShopping.Entity;
using MobileShopping.DAL;
using MobileShopping.Models;
using System;
using MobileShopping.BL;
using System.Collections.Generic;
using System.Linq;

namespace MobileShopping.Controllers
{
    public class AccountController : Controller
    {
        AccountBL accountBL = new AccountBL();
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
                Account account = new Account();
                account.UserName = signUpModel.UserName;
                account.UserId = signUpModel.UserId;
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
        [HttpGet]
        public ActionResult EditUser(string mailId) //Edit                             
        {
            Account user = accountBL.GetUserId(mailId);
            return View(user);
        }
        [HttpPost]
        public ActionResult UpdateUser(AccountEditViewModel accountEditViewModel)
        {
            if (ModelState.IsValid)
            {
                Account user = new Account();
                user.MailId = accountEditViewModel.MailId;
                    accountBL.EditUser(user);
                    ViewBag.Message = "User details updated successfully";
                    ModelState.Clear();
                    return RedirectToAction("UserDetails");
           }
           return View();             
        }
        public ActionResult DeleteUser(AccountDeleteViewModel accountDeleteViewModel) //Delete
        {
            Account account = new Account();
            account.MailId = accountDeleteViewModel.MailId;
            accountBL.DeleteUser(account);
            return RedirectToAction(nameof(UserDetails));
            //  AccountContext accountContext = new AccountContext();
            //Account user = accountContext.AccountDB.Find(userId);
            //accountContext.AccountDB.Remove(user);
            //accountContext.SaveChanges();
            //TempData["Message"] = "User updated successfully";
            //return RedirectToAction("Display");
        }
    }
}
