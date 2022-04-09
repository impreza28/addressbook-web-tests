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
    public class RemoveGroup: GroupTestBase
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

            List<GroupData> oldGroups = GroupData.GetAll();  // список   групп
            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved); //удаление группы
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount()); //проверка списка (-1 группа)

            List<GroupData> newGroups = GroupData.GetAll(); //новый список групп 
            
            oldGroups.RemoveAt(0); // удалить из старого списка группу с index=0

            Assert.AreEqual(oldGroups, newGroups); //сравнение списков

            foreach(GroupData group in newGroups) //проверка, что удален элемент с тем самым Id из SelectCheckboxGroup
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);

            }    
        }

    }
}
