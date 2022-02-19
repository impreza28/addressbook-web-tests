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
    public class ApplicationManager
    {

        protected IWebDriver driver;
        protected string baseURL;


        protected LoginHelper loginhelper;
        protected NavigationHelper navigationhelper;
        protected ContactHelper contacthelper;
        protected GroupHelper grouphelper;

        public ApplicationManager() 
        {
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            loginhelper = new LoginHelper(driver);
            navigationhelper = new NavigationHelper(driver,baseURL);
            contacthelper = new ContactHelper(driver);
            grouphelper = new GroupHelper(driver);

        }

        //закрытие браузера
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception) { }
        }
        public LoginHelper Auth 
        {
            get 
            { 
                return loginhelper; 
            }
        }
        public NavigationHelper Navigator
        {
           get 
            { 
                return navigationhelper; 
            }
        }
        public ContactHelper Contacts 
        {
            get 
            { 
                return contacthelper; 
            } 
        }
        public GroupHelper Groups 
        { 
            get 
            {
                return grouphelper;
            }
        }

    }
}
