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
            navigationhelper.OpenHomePage();
            loginhelper.LoginAdmin(new AccountData("admin", "secret"));
            navigationhelper.GoToGroupsPage();
            grouphelper.InitGroupCreation();
            GroupData group = new GroupData("a");
            group.Header = "c";
            group.Footer = "b";
            grouphelper.FillGroupForm(group);
            grouphelper.SubmitCreationGroup();
            navigationhelper.ReturnToGroupsPage();
        }

}
}
