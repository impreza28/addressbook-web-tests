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
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;

namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateGroup: GroupTestBase
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
                new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"tests\Группы\groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"tests\Группы\groups.json"));
        }

        //public static IEnumerable<GroupData> GroupDataFromExcelFile()
        //{
        //    List<GroupData> groups = new List<GroupData>();
        //    Excel.Application app = new Excel.Application();
        //    Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));
        //    Excel.Worksheet sheet = wb.ActiveSheet;
        //    Excel.Range range = sheet.UsedRange;
        //    for (int i = 1; i <= range.Rows.Count; i++)
        //    {
        //        groups.Add(new GroupData()
        //        {
        //            Name = range.Cells[i, 1].Value,
        //            Header = range.Cells[i, 2].Value,
        //            Footer = range.Cells[i, 3].Value
        //        });
        //    }
        //    wb.Close();
        //    app.Visible = false;
        //    app.Quit();
        //    return groups;
        //}

        [Test, TestCaseSource("GroupDataFromJsonFile")]

        public void Test_CreateGroup(GroupData group)
        {

            List<GroupData> oldGroups = GroupData.GetAll(); //список групп до создания новой

            app.Groups.CreateGroup(group);
            app.Navigator.OpenGroupsPage();
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount()); //проверка списка (+1 группа)
            app.Navigator.OpenHomePage();

            List<GroupData> newGroups = GroupData.GetAll(); //список групп после создания новой
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

        [Test]
        // тест-кейс создания группы с пустыми параметрами
        public void Test_DBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUI = app.Groups.GetGroupList(); //список групп 
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));


            start = DateTime.Now;
            List<GroupData> fromDb = GroupData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

        }


    }
}
