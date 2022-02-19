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
            app.navigation.OpenHomePage();
            app.auth.LoginAdmin(new AccountData("admin", "secret"));
            app.contacts.InitContactCreation();
            ContactData contact = new ContactData("Firstname");
            contact.Middlename = "Middlename";
            contact.Lastname = "Lastname";
            app.contacts.FillContactForm(contact);
            app.contacts.SubmitCreationContact();
            app.navigation.OpenLinkHomePage();
        }

}
}
