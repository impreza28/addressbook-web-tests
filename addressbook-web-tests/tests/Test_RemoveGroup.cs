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
    public class RemoveGroup:TestBase
    {

    [Test]
    public void Test_RemoveGroup()
        {
            GroupData group = new GroupData("Test");
            group.Header = "Test";
            group.Footer = "Test";
            app.Groups.CreateGroup(group);
            app.Navigator.ReturnToGroupsPage();
            app.Groups.RemoveGroup();
        }

    }
}
