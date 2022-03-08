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
            app.Navigator.OpenHomePage();
            List<ContactData> oldContacts = app.Contacts.GetContactList(); //список контактов

            ContactData contact = new ContactData("1");
            contact.Middlename = "2";
            contact.Lastname = "C";

            app.Contacts.CreateContact(contact);
            app.Navigator.ReturnToHomePage();

            List<ContactData> newContacts = app.Contacts.GetContactList(); //список контактов после создания новой

            oldContacts.Add(new ContactData(contact.Lastname + " "+contact.Firstname)); //добавить контакт в старый список в формате Lastname + " "+ Firstname
            oldContacts.Sort(); //сортировка старого списка
            newContacts.Sort(); // сортировка нового списка
                Assert.AreEqual(oldContacts, newContacts); //сравнение списков
      
        }

}
}
