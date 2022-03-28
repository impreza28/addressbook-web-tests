using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
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


        public static IEnumerable<GroupData> RandomGroupDataProvider() 
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++) 
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                { 
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile() 
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines) 
            {
                string[]  parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                { 
                Header = parts[1],
                Footer = parts[2]
                });

            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromXMLFile()
        {

            return (List<GroupData>) 
                new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));
        }

        [Test, TestCaseSource("GroupDataFromXMLFile")]


        public void Test_CreateGroup(GroupData group)
        {
            //GroupData group = new GroupData("a");
            //group.Header = "c";
            //group.Footer = "b";

            List<GroupData> oldGroups = app.Groups.GetGroupList(); //список групп до создания новой

            app.Groups.CreateGroup(group);
            app.Navigator.ReturnToGroupsPage();
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount()); //проверка списка (+1 группа)
            app.Navigator.OpenHomePage();

            List<GroupData> newGroups = app.Groups.GetGroupList(); //список групп после создания новой
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //проверка списка
        }

        //[Test]
        //// тест-кейс создания группы с пустыми параметрами
        //public void Test_EmptyCreateGroup()
        //{
        //    List<GroupData> oldGroups = app.Groups.GetGroupList(); //список групп до создания новой

        //    GroupData group = new GroupData("");
        //    group.Header = "";
        //    group.Footer = "";
        //    app.Groups.CreateGroup(group);
        //    app.Navigator.ReturnToGroupsPage();
        //    Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount()); //проверка списка

        //    List<GroupData> newgroups = app.Groups.GetGroupList(); //список групп после создания новой
        //    oldGroups.Add(group);
        //    oldGroups.Sort();
        //    newgroups.Sort();
        //    Assert.AreEqual(oldGroups, newgroups); //проверка списка (число групп увеличилось на 1)
        //}

        [Test]
        // тест-кейс создания группы с пустыми параметрами
        public void Test_BadNameCreateGroup()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //список групп до создания новой

            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            app.Groups.CreateGroup(group);
            app.Navigator.OpenGroupsPage();
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount()); //проверка списка (число групп не увеличилось)


            List<GroupData> newgroups = app.Groups.GetGroupList(); //список групп после создания новой
           
            Assert.AreEqual(oldGroups.Count, newgroups.Count); //проверка списка, число групп не увеличилось
        }

    }
}
