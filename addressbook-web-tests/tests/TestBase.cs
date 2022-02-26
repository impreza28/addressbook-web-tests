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
    public class TestBase
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupApp()
        {
           // app = TestSuiteFixture.app;
           app = ApplicationManager.GetInstance();
            //app.Navigator.OpenHomePage();
            //app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}