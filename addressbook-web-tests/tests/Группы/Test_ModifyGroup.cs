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
    public class ModifyGroup : GroupTestBase
    {

        //[Test]
        //public void Test_ModifyGroup()
        //{

        //    app.Navigator.OpenGroupsPage();

        //    if (!app.Groups.GroupIsFinded()) // если ни одной группы не найдено, то создать группу Test
        //    {
        //        GroupData group = new GroupData("Test", "Test", "Test");
        //        app.Groups.CreateGroup(group);
        //    }

        //    List<GroupData> oldGroups = app.Groups.GetGroupList(); //список групп 


        //    GroupData updgroup = new GroupData("Test1", "Test1", "Test1"); //данные для изменения группы

        //    app.Groups.SelectCheckboxGroup(0)
        //              .ModifyGroup(updgroup); //изменение группы
        //    app.Navigator.ReturnToGroupsPage();
        //    Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount()); //проверка списка (кол-во в списке не изменилось)

        //    List<GroupData> newGroups = app.Groups.GetGroupList(); //список групп после модификации
        //    oldGroups[0].Name = updgroup.Name; //у элемента меняем имя в старом списке
        //    oldGroups.Sort();
        //    newGroups.Sort();
        //    Assert.AreEqual(oldGroups, newGroups); //сравнение списков

        //    foreach (GroupData group in newGroups)
        //    {
        //        if (group.Id == oldGroups[0].Id)
        //        {
        //            Assert.AreEqual(group.Name, updgroup.Name);
        //        }
        //    }
        //}

        [Test]
        public void Test_ModifyGroup()
        {

            app.Navigator.OpenGroupsPage();

            if (!app.Groups.GroupIsFinded()) // если ни одной группы не найдено, то создать группу Test
            {
                GroupData group = new GroupData("Test", "Test", "Test");
                app.Groups.CreateGroup(group);
            }

            List<GroupData> oldGroups = GroupData.GetAll(); //список групп 
            GroupData updgroup = new GroupData("Test1", "Test1", "Test1"); //данные для изменения группы
            GroupData toBeUpdated = oldGroups[0];




            //app.Groups.SelectGroup(toBeUpdated)
            app.Groups.Modify(toBeUpdated); //изменение группы
            app.Navigator.ReturnToGroupsPage();
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount()); //проверка списка (кол-во в списке не изменилось)

            List<GroupData> newGroups = GroupData.GetAll(); //список групп после модификации
            toBeUpdated.Name = updgroup.Name; 
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //сравнение списков

            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeUpdated.Id)
                {
                    Assert.AreEqual(group.Name, updgroup.Name);
                }
            }
        }

    }
}
