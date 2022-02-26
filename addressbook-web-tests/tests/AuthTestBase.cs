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
    public class AuthTestBase: TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            // app = TestSuiteFixture.app;
            app.Auth.Login(new AccountData("admin", "secret"));

            //app.Navigator.OpenHomePage();
            //app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
