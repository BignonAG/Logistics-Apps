using NUnit.Framework;
using Pyvvo.Logistics.Core;
using Pyvvo.Logistics.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyvvo.Logistics.Test
{
    public class AuthenticationUnitTest
    {
        private readonly ICoreAccountLogin  _coreAccountLogin;
        public AuthenticationUnitTest(ICoreAccountLogin coreAccountLogin )
        {
            _coreAccountLogin = coreAccountLogin;
        }

        //[Test]
        //public void SignIn()
        //{
        //    var AccountLogin = new AccountLogin();
        //    AccountLogin.CreatedOn = DateTime.Now;
        //    AccountLogin.Email = "Kenneth@humaapi.com";
        //    AccountLogin.Password = "TITOTOY";
        //    AccountLogin.User = new User();
        //    AccountLogin.User.IsActive = true;
        //    AccountLogin.User.CreateDon = DateTime.Now;
        //    AccountLogin.User.Role = new Role();
        //    AccountLogin.User.Role.CreatedOn = DateTime.Now;
        //    AccountLogin.User.Role.Name = "SuperAdmin";
        //    AccountLogin.User.Role.IsActive = true;

        //    var AccountLoginCore = new AccountLoginCore();
        //    var isCreated = AccountLoginCore.Create(AccountLogin).Result;
        //    string token = null;
        //    if (isCreated != null)
        //    {
        //        token = AccountLoginCore.GenerateToken(AccountLogin.Email);
        //    }
        //    Assert.IsNotNull(token);
        //}

        [Test]
        public void StoreAccountLoginWithExistingUserRole()
        {
            var AccountLogin = new AccountLogin();
            AccountLogin.Email = "unitest@mail.fr";
            AccountLogin.Password = "Password";

            var AccountLoginCore = _coreAccountLogin;
            var token = AccountLoginCore.SignUp(AccountLogin).Result;
            Assert.IsNotNull(token);
        }

    }
}
