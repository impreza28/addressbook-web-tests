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
    public class RemoveGroup:AuthTestBase
    {

    [Test]
    public void Test_RemoveGroup()
        {
            
            
            app.Navigator.OpenGroupsPage();

            List<GroupData> oldGroups = app.Groups.GetGroupList(); 


            if (!app.Groups.GroupIsFinded())
            {
                // если ни одной группы не найдено, то создать группу Test
                GroupData group = new GroupData("Test", "Test", "Test");
                app.Groups.CreateGroup(group);
            }
            app.Navigator.OpenGroupsPage();
            app.Groups.SelectCheckboxGroup()
                      .RemoveGroup(); //удаление группы
            app.Navigator.ReturnToGroupsPage();

            List<GroupData> newgroups = app.Groups.GetGroupList(); //список групп после создания новой
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newgroups); //проверка списка (число групп увеличилось на 1)
        }

    }
}
