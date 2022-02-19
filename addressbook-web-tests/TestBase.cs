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


        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();
        }


        protected void OpenLinkHomePage()
        {   //переход по ссылке "home page" на главную страницу
            driver.FindElement(By.LinkText("home page")).Click();
        }

        protected void CreateNewContact()
        {   //переход на форму добавление нового контакта
            driver.FindElement(By.LinkText("add new")).Click();
        }

        protected void ReturnToGroupsPage()
        {
            //переход на форму групп
            driver.FindElement(By.LinkText("group page")).Click();
        }

        protected void SubmitCreation()
        {
            //подтверждение создания 
            driver.FindElement(By.Name("submit")).Click();
        }

        protected void InitGroupCreation()
        {
            //создание новой группы
            driver.FindElement(By.Name("new")).Click();
        }

        protected void GoToGroupsPage()
        {
            //переход на форму групп
            driver.FindElement(By.LinkText("groups")).Click();
        }

        protected void LoginAdmin(AccountData account)
        {    //авторизация: логин+пароль
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        protected void FillContactForm(ContactData contact)
        {   //заполнение формы нового ноктакта
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
        }

        protected void FillGroupForm(GroupData group)
        {
            //заполнение формы новой группы
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }
        protected void OpenHomePage()
        {
            //открытие сайта addressbook
            driver.Navigate().GoToUrl(baseURL);
        }
    }
}