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
    public class CreateGroup: AuthTestBase
    {

    [Test]
    public void Test_CreateGroup()
        {
            GroupData group = new GroupData("a");
            group.Header = "c";
            group.Footer = "b";

            List<GroupData> oldGroups = app.Groups.GetGroupList(); //список групп до создания новой

            app.Groups.CreateGroup(group);
            
            Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount()); //проверка списка (+1 группа)

            app.Navigator.ReturnToGroupsPage();
            app.Navigator.OpenHomePage();

            List<GroupData> newGroups = app.Groups.GetGroupList(); //список групп после создания новой
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //проверка списка
        }

        [Test]
        // тест-кейс создания группы с пустыми параметрами
        public void Test_EmptyCreateGroup()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //список групп до создания новой

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Groups.CreateGroup(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount()); //проверка списка
            app.Navigator.ReturnToGroupsPage();

            List<GroupData> newgroups = app.Groups.GetGroupList(); //список групп после создания новой
            oldGroups.Add(group);
            oldGroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldGroups, newgroups); //проверка списка (число групп увеличилось на 1)
        }

        [Test]
        // тест-кейс создания группы с пустыми параметрами
        public void Test_BadNameCreateGroup()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //список групп до создания новой

            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            app.Groups.CreateGroup(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount()); //проверка списка
            app.Navigator.OpenGroupsPage();


            List<GroupData> newgroups = app.Groups.GetGroupList(); //список групп после создания новой
           
            Assert.AreEqual(oldGroups.Count, newgroups.Count); //проверка списка, число групп не увеличилось
        }

    }
}
