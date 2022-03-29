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
    public class ContactInformation : AuthTestBase
    {

        [Test]
        public void Test_ContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInfoFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInfoFromEditForm(0);

            //сравнение
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void Test_ContactInfoDetails()
        {
            ContactData allInfoEditForm = app.Contacts.GetContactInfoFromEditForm(0);
            string allDetails = app.Contacts.GetContactInfoFromDetails(0);
            string stringEditForm = app.Contacts.GetContactStringFromDetails(allInfoEditForm);

            Assert.AreEqual(allDetails, stringEditForm);
        }
    }
}