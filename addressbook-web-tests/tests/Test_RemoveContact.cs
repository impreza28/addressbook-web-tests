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
    public class RemoveContact : TestBase
    {

    [Test]
    public void Test_RemoveContact()
        {
            ContactData contact = new ContactData("Test");
            contact.Middlename = "Test";
            contact.Lastname = "Test";
            app.Contacts.CreateContact(contact);  //создание контакта Test

            app.Navigator.OpenLinkHomePage();

            app.Contacts.RemoveContact(); //удаление контакта Test
        }

    }
}
