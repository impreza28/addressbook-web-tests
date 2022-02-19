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
    public class CreateContact:TestBase
    {

    [Test]
    public void Test_CreateContact()
        {
            navigationhelper.OpenHomePage();
            loginhelper.LoginAdmin(new AccountData("admin", "secret"));
            contacthelper.InitContactCreation();
            ContactData contact = new ContactData("Firstname");
            contact.Middlename = "Middlename";
            contact.Lastname = "Lastname";
            contacthelper.FillContactForm(contact);
            contacthelper.SubmitCreationContact();
            navigationhelper.OpenLinkHomePage();
        }

}
}