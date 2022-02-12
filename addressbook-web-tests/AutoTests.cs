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
    [TestFixture]
    public class Tests
    {
    private IWebDriver driver;
    private StringBuilder verificationErrors;
    private string baseURL;
    private bool acceptNextAlert = true;


    [SetUp]
    public void SetupTest()
    {
        driver = new ChromeDriver();
        //driver = new FirefoxDriver();
        baseURL = "http://localhost/addressbook/";
        verificationErrors = new StringBuilder();
    }

    [Test]
    public void ƒз2_—оздание_группы()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("a");
            group.Header = "c";
            group.Footer = "b";
            FillGroupForm(group);
            SubmitCreation();
            ReturnToGroupsPage();
        }

    [Test]
    public void ƒз3_—оздание_контакта()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            CreateNewContact();
            FillContactForm();
            SubmitCreation();
            OpenLinkHomePage();
        }

        private void OpenLinkHomePage()
        {   //переход по ссылке "home page" на главную страницу
            driver.FindElement(By.LinkText("home page")).Click();
        }

        private void FillContactForm()
        {   //заполнение данных нового контакта
            driver.FindElement(By.Name("firstname")).SendKeys("1");
            driver.FindElement(By.Name("middlename")).SendKeys("2");
            driver.FindElement(By.Name("lastname")).SendKeys("3");
        }

        private void CreateNewContact()
        {   //переход на форму добавление нового контакта
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void ReturnToGroupsPage()
        {
            //переход на форму групп
            driver.FindElement(By.LinkText("group page")).Click();
        }

        private void SubmitCreation()
        {
            //подтверждение создани€ 
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillGroupForm(GroupData group)
        {
            //заполнение данных новой группы
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        private void InitGroupCreation()
        {
            //создание новой группы
            driver.FindElement(By.Name("new")).Click();
        }

        private void GoToGroupsPage()
        {
            //переход на форму групп
            driver.FindElement(By.LinkText("groups")).Click();
        }

        private void Login(AccountData account)
        {    //авторизаци€: логин+пароль
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        private void OpenHomePage()
        {
            //открытие сайта addressbook
            driver.Navigate().GoToUrl(baseURL);
        }

        private bool IsElementPresent(By by)
    {
        try
        {
            driver.FindElement(by);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    private bool IsAlertPresent()
    {
        try
        {
            driver.SwitchTo().Alert();
            return true;
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }

    private string CloseAlertAndGetItsText()
    {
        try
        {
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            if (acceptNextAlert)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }
            return alertText;
        }
        finally
        {
            acceptNextAlert = true;
        }
    }
}
}
