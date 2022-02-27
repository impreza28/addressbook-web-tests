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
    public class NavigationHelper: HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager) 
        {
            this.baseURL = baseURL;
        }

        public void ReturnToHomePage()
        {   //переход по ссылке "home page" на главную страницу
            driver.FindElement(By.LinkText("home page")).Click();
        }
        public void ReturnToGroupsPage()
        {
            //переход на форму групп
            driver.FindElement(By.LinkText("group page")).Click();
            if (driver.Url == baseURL + "group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
        }
        public void OpenGroupsPage()
        {
            //переход на форму групп
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void OpenHomePage()
        {
            //открытие сайта addressbook
            if (driver.Url == baseURL && IsElementPresent(By.Name("add")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }

    }
}
