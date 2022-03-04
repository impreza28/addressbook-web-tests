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

            if (app.Contacts.ContactIsFinded()) //���� �������  ������, �� ������ �����������
                {  }
            else
            {   // ���� �� ������ �������� �� �������, �� ������� �������
                ContactData newcontact = new ContactData("Test", "Test", "Test");
                app.Contacts.CreateContact(newcontact);
                app.Navigator.ReturnToHomePage();
            }

            ContactData contactupd = new ContactData("Test1", "Test1", "Test1");
            app.Contacts.SelectCheckboxContact()
                        .ModifyContact(contactupd); //�������� �������
            app.Navigator.ReturnToHomePage();
        }
    }
}
