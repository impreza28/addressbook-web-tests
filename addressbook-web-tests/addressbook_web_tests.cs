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
    public void ��2_��������_������()
        {
            OpenHomePage();
            Login();
            GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm();
            SubmitGroupCreation();
            ReturnToGroupsPage();
        }

        private void ReturnToGroupsPage()
        {
            //������� �� ����� �����
            driver.FindElement(By.LinkText("group page")).Click();
        }

        private void SubmitGroupCreation()
        {
            //������������� �������� ����� ������
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillGroupForm()
        {
            //���������� ������ ����� ������
            driver.FindElement(By.Name("group_name")).SendKeys("test1");
            driver.FindElement(By.Name("group_header")).SendKeys("test1");
            driver.FindElement(By.Name("group_footer")).SendKeys("test1");
        }

        private void InitGroupCreation()
        {
            //�������� ����� ������
            driver.FindElement(By.Name("new")).Click();
        }

        private void GoToGroupsPage()
        {
            //������� �� ����� �����
            driver.FindElement(By.LinkText("groups")).Click();
        }

        private void Login()
        {    //�����������: �����+������
            driver.FindElement(By.Name("user")).SendKeys("admin");
            driver.FindElement(By.Name("pass")).SendKeys("secret");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        private void OpenHomePage()
        {
            //������� �� ������� ��������
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
