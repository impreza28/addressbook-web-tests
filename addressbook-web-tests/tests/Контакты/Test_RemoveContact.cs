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
    public class RemoveContact : AuthTestBase
    {

    [Test]
    public void Test_RemoveContact()
        {

            if (app.Contacts.ContactIsFinded()) //���� �������  ������
            {
                app.Contacts.SelectCheckboxContact(); //������� �������

                //������� �������
                app.Contacts.RemoveContact();

                return;
            }
            else
            {   // ���� �� ������ �������� �� �������, �� ������� �������
                ContactData newcontact = new ContactData("Test", "Test", "Test");
                app.Contacts.CreateContact(newcontact);
                app.Navigator.ReturnToHomePage();

                app.Contacts.SelectCheckboxContact(); //������� �������

                //������� �������
                app.Contacts.RemoveContact();

                return;
            }
        }
    }
}
