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

            if (!app.Groups.GroupIsFinded())
            {
                // если ни одной группы не найдено, то создать группу Test
                GroupData group = new GroupData("Test", "Test", "Test");
                app.Groups.CreateGroup(group);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();  // список   групп

            app.Groups.SelectCheckboxGroup(0) // выбрать группу с index=0
                      .RemoveGroup(); //удаление группы
            app.Navigator.ReturnToGroupsPage();

            List<GroupData> newGroups = app.Groups.GetGroupList(); //новый список групп 
            oldGroups.RemoveAt(0); // удалить из старого списка группу с index=0

            Assert.AreEqual(oldGroups, newGroups); //сравнение списков
        }

    }
}
