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
    public class Test
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
    public void Дз2_Создание_группы()
    {
            //переход на главную страницу
        driver.Navigate().GoToUrl(baseURL);
            //авторизация: логин+пароль
        driver.FindElement(By.Name("user")).SendKeys("admin");
        driver.FindElement(By.Name("pass")).SendKeys("secret");
        driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            //переход на форму групп
        driver.FindElement(By.LinkText("groups")).Click();
            //создание новой группы
        driver.FindElement(By.Name("new")).Click();
            //заполнение данных новой группы
        driver.FindElement(By.Name("group_name")).SendKeys("test1");
        driver.FindElement(By.Name("group_header")).SendKeys("test1");
        driver.FindElement(By.Name("group_footer")).SendKeys("test1");
            //подтверждение создания новой группы
        driver.FindElement(By.Name("submit")).Click();
            //переход на форму групп
        driver.FindElement(By.LinkText("group page")).Click();

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
