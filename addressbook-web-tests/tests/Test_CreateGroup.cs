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
            app.navigation.OpenHomePage();
            app.auth.LoginAdmin(new AccountData("admin", "secret"));
            app.navigation.GoToGroupsPage();
            app.groups.InitGroupCreation();
            GroupData group = new GroupData("a");
            group.Header = "c";
            group.Footer = "b";
            app.groups.FillGroupForm(group);
            app.groups.SubmitCreationGroup();
            app.navigation.ReturnToGroupsPage();
        }

}
}
