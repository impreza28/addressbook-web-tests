using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class TestBase
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {

            app = new ApplicationManager();
            app.Navigator.OpenHomePage();
            app.Auth.LoginAdmin(new AccountData("admin", "secret"));
        }
        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
          }
    }
}