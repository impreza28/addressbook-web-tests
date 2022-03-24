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

        public static IEnumerable<ContactData> RandomGroupDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30))
                {
                    Lastname = GenerateRandomString(100)
                });
            }
            return contacts;
        }


        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void Test_CreateContact()
        {
            app.Navigator.OpenHomePage();
            List<ContactData> oldContacts = app.Contacts.GetContactList(); //������ ���������

            ContactData contact = new ContactData("1", "C");
            contact.Middlename = "2";

            app.Contacts.CreateContact(contact);
            app.Navigator.ReturnToHomePage();
            Assert.AreEqual(oldContacts.Count+1, app.Contacts.GetContactCount()); //�������� ������ (����� ��������� ����������� +1)

            List<ContactData> newContacts = app.Contacts.GetContactList(); //������ ��������� ����� �������� �����

            oldContacts.Add(contact); //�������� ������� � ������ ������ � ������� Lastname + " "+ Firstname
            oldContacts.Sort(); //���������� ������� ������
            newContacts.Sort(); // ���������� ������ ������
            Assert.AreEqual(oldContacts, newContacts); //��������� �������
      
        }

}
}
