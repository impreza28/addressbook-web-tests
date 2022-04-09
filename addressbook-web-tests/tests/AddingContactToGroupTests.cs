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
    public class AddingContactToGroupTests: AuthTestBase
    {
    [Test]
    public void Test_AddingContactToGroupTests()
        {
            GroupData group = GroupData.GetAll()[0];

            ContactData.GetAll().Add()
        }
    }
}
