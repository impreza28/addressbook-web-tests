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
    public class ModifyContact : AuthTestBase
    {

    [Test]
    public void Test_ModifyContact()
        {

            if (!app.Contacts.ContactIsFinded()) // если ни одного контакта не найдено, то создать контакт
            {   
                ContactData newContact = new ContactData("Test", "Test");
                app.Contacts.CreateContact(newContact);
                app.Navigator.ReturnToHomePage();
            }


            List<ContactData> oldContacts = app.Contacts.GetContactList(); //список текущих контактов 

            ContactData updContact = new ContactData("Test1", "Test1");
            app.Contacts.SelectCheckboxContact(0)
                        .ModifyContact(updContact); //изменить контакт
            app.Navigator.ReturnToHomePage();
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount()); //проверка списка (число контактов не изменилось)

            List<ContactData> newContacts = app.Contacts.GetContactList(); //список новых контактов 
            oldContacts[0].Firstname = updContact.Firstname; //у элемента меняем имя в старом списке
            oldContacts[0].Lastname = updContact.Lastname; //у элемента меняем имя в старом списке
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts); //сравнение списков
        }
    }
}
