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
    public class ModifyGroup : TestBase
    {

    [Test]
    public void Test_ModifyGroup()
        {
            GroupData group = new GroupData("Test");
            group.Header = "Test";
            group.Footer = "Test";
            app.Groups.CreateGroup(group); //создание группы Test

            app.Navigator.ReturnToGroupsPage();

            GroupData updgroup = new GroupData("Test1");
            updgroup.Header = "Test1";
            updgroup.Footer = "Test1";

            app.Groups.ModifyGroup(updgroup);//изменение группы Test
        }

    }
}
