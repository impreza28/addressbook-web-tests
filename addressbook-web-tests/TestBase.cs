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
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;
        private bool acceptNextAlert = true;

        protected LoginHelper loginhelper;
        protected NavigationHelper navigationhelper;
        protected ContactHelper contacthelper;
        protected GroupHelper grouphelper;



        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();
            loginhelper = new LoginHelper(driver);
            navigationhelper = new NavigationHelper(driver, baseURL);
            contacthelper = new ContactHelper(driver);
            grouphelper = new GroupHelper(driver);
        }
    }
}