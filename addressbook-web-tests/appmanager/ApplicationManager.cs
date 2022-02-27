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
        public string baseURL;


        protected LoginHelper loginhelper;
        protected NavigationHelper navigationhelper;
        protected ContactHelper contacthelper;
        protected GroupHelper grouphelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        //private ApplicationManager app;


        public ApplicationManager() 
        {
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";

            loginhelper = new LoginHelper(this);
            navigationhelper = new NavigationHelper(this, baseURL);
            contacthelper = new ContactHelper(this);
            grouphelper = new GroupHelper(this);

        }

        //деструктор для остановки браузера
        ~ApplicationManager() 
        {
            try
            {
                driver.Quit();
            }
            catch (Exception) { }
        }

        public static ApplicationManager GetInstance() 
        {
            if (! app.IsValueCreated) 
            {
                ApplicationManager newInctance = new ApplicationManager();

                newInctance.Navigator.OpenHomePage();
                app.Value = newInctance;
            }
            return app.Value;
        }

        public IWebDriver Driver 
        {
            get { return driver; }
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

        // public string get_baseURL()
        // { 
        //   return baseURL;
        // }

    }
}
