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
    public class ModifyContact : AuthTestBase
    {

    [Test]
    public void Test_ModifyContact()
        {
            ContactData contact = new ContactData("Test1");
            contact.Middlename = "Test1";
            contact.Lastname = "Test1";

            app.Contacts.ModifyContact(contact); 
            app.Navigator.ReturnToHomePage();
        }

    }
}
