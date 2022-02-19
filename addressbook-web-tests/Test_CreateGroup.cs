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
    public class CreateGroup: TestBase
    {


    [Test]
    public void Test_CreateGroup()
        {
            OpenHomePage();
            LoginAdmin(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("a");
            group.Header = "c";
            group.Footer = "b";
            FillGroupForm(group);
            SubmitCreation();
            ReturnToGroupsPage();
        }

}
}
