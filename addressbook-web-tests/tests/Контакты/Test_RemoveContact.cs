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
    public class RemoveContact : AuthTestBase
    {

    [Test]
    public void Test_RemoveContact()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();  // список   групп

            if (!app.Contacts.ContactIsFinded())
            {   // если ни одного контакта не найдено, то создать контакт
                ContactData newcontact = new ContactData("Test", "Test", "Test");
                app.Contacts.CreateContact(newcontact);
                app.Navigator.ReturnToHomePage();
            }

            app.Contacts.SelectCheckboxContact() //выбрать контакт
                        .RemoveContact(); //удалить контакт

            List<ContactData> newContacts = app.Contacts.GetContactList(); //новый список групп 
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts); //проверка списка 
        }
    }
}
