﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileShopping.Entity;
using MobileShopping.DAL;

namespace MobileShopping.BL
{
    public class AccountBL
    {
        AccountRepository accountRepository;
        public AccountBL()
        {

       accountRepository = new AccountRepository();
        }
        public void SignUp(Account user)
        {
            accountRepository.SignUp(user);
        }
        public Account Login(Account user)
        {
            return accountRepository.Login(user);
        }

        public IEnumerable<Account> DisplayUsers()
        {
            
            return accountRepository.DisplayUsers();
        }
        public void EditUser(Account user)
        {
           accountRepository.UpdateUser(user);
        }
        public void DeleteUser(int id)
        {
            accountRepository.DeleteUser(id);
        }
        public IEnumerable<Account> GetUserDetail(Account account)
        {
            IEnumerable<Account> user = accountRepository.GetUserDetails(account);
            return user;
        }
        public Account GetUserId(int id)
        {
            return accountRepository.GetUserId(id);
        }

    }
}
