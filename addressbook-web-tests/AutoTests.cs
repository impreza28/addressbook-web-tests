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
    public void ��2_��������_������()
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
    public void ��3_��������_��������()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            CreateNewContact();
            FillContactForm();
            SubmitCreation();
            OpenLinkHomePage();
        }

        private void OpenLinkHomePage()
        {   //������� �� ������ "home page" �� ������� ��������
            driver.FindElement(By.LinkText("home page")).Click();
        }

        private void FillContactForm()
        {   //���������� ������ ������ ��������
            driver.FindElement(By.Name("firstname")).SendKeys("1");
            driver.FindElement(By.Name("middlename")).SendKeys("2");
            driver.FindElement(By.Name("lastname")).SendKeys("3");
        }

        private void CreateNewContact()
        {   //������� �� ����� ���������� ������ ��������
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void ReturnToGroupsPage()
        {
            //������� �� ����� �����
            driver.FindElement(By.LinkText("group page")).Click();
        }

        private void SubmitCreation()
        {
            //������������� �������� 
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillGroupForm(GroupData group)
        {
            //���������� ������ ����� ������
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
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

        private void Login(AccountData account)
        {    //�����������: �����+������
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        private void OpenHomePage()
        {
            //�������� ����� addressbook
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
