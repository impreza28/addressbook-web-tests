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
    public class RemoveGroup:AuthTestBase
    {

    [Test]
    public void Test_RemoveGroup()
        {
            app.Navigator.OpenGroupsPage();

            if (app.Groups.GroupIsFinded()) //если группа  найдена, то выбрать группу
            {
                app.Groups.SelectCheckboxGroup() 
                          .RemoveGroup(); //удаление группы
                app.Navigator.ReturnToGroupsPage();
                return;
            }
            else
            {
                // если ни одной группы не найдено, то создать группу Test
                GroupData group = new GroupData("Test", "Test", "Test");
                app.Groups.CreateGroup(group);

                app.Navigator.OpenGroupsPage();
                app.Groups.SelectCheckboxGroup()
                          .RemoveGroup(); //удаление группы 
                app.Navigator.ReturnToGroupsPage();
                return;
            }
        }

    }
}
