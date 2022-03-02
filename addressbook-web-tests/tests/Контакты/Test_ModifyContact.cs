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

            if (app.Contacts.ContactIsFinded()) //если контакт  найден, то выбрать контакт
                {
                app.Contacts.SelectCheckboxContact();

                ContactData contactupd = new ContactData("Test3");
                contactupd.Middlename = "Test2";
                contactupd.Lastname = "Test2";

                //изменить контакт
                app.Contacts.ModifyContact(contactupd);
                app.Navigator.ReturnToHomePage();
                return;
                }
            else
            {   // если ни одного контакта не найдено, то создать контакт
                ContactData newcontact = new ContactData("Test", "Test", "Test");
                app.Contacts.CreateContact(newcontact);
                app.Navigator.ReturnToHomePage();

                app.Contacts.SelectCheckboxContact();
                //изменить контакт
                ContactData contactupd = new ContactData("Test1", "Test1", "Test1");
                app.Contacts.ModifyContact(contactupd);
                app.Navigator.ReturnToHomePage();

                return;
            }

        }

    }
}
