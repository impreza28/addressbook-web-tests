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
            List<ContactData> oldContacts = app.Contacts.GetContactList();  // ������   �����

            if (!app.Contacts.ContactIsFinded())
            {   // ���� �� ������ �������� �� �������, �� ������� �������
                ContactData newcontact = new ContactData("Test", "Test", "Test");
                app.Contacts.CreateContact(newcontact);
                app.Navigator.ReturnToHomePage();
            }

            app.Contacts.SelectCheckboxContact() //������� �������
                        .RemoveContact(); //������� �������

            List<ContactData> newContacts = app.Contacts.GetContactList(); //����� ������ ����� 
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts); //�������� ������ 
        }
    }
}
