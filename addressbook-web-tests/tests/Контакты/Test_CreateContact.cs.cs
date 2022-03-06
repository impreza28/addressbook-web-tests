using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateContact: AuthTestBase
    {

    [Test]
    public void Test_CreateContact()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList(); //список 

            ContactData contact = new ContactData("Firstname");
            contact.Middlename = "Middlename";
            contact.Lastname = "Lastname";

            app.Contacts.CreateContact(contact);
            app.Navigator.ReturnToHomePage();

            List<ContactData> newcontacts = app.Contacts.GetContactList(); //список групп после создания новой
            Assert.AreEqual(oldContacts.Count + 1, newcontacts.Count); //проверка списка (число групп увеличилось на 1)
        }

}
}
