using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{

    [TestFixture]
    public class Test_Login: TestBase

    {
        [Test]
        // авторизация с корретными данными
        public void LoginWhithValidCredentials() 
        {
            AccountData account = new AccountData("admin", "secret");
            app.Navigator.OpenHomePage();

            app.Auth.Logout();

            app.Auth.Login(account);

            Assert.IsTrue(app.Auth.IsLoggedIn(account));

        }

        [Test]
        //авторизация с неверным паролем
        public void LoginWhithInvalidCredentials()
        {
            AccountData account = new AccountData("admin", "12345");

            app.Navigator.OpenHomePage();
            app.Auth.Logout();

            app.Auth.Login(account);

            Assert.IsFalse(app.Auth.IsLoggedIn(account));

        }

    }
}
