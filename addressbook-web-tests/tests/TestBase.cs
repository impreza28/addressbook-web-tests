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
        public void SetupTest()
        {

            app = new ApplicationManager();

            //driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            //baseURL = "http://localhost/addressbook/";
            //verificationErrors = new StringBuilder();
            //loginhelper = new LoginHelper(driver);
            //navigationhelper = new NavigationHelper(driver, baseURL);
            //contacthelper = new ContactHelper(driver);
            //grouphelper = new GroupHelper(driver);
        }
        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
          }
    }
}