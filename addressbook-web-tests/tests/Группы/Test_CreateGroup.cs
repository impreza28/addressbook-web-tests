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


        [Test, TestCaseSource("RandomGroupDataProvider")]


    public void Test_CreateGroup()
        {
            GroupData group = new GroupData("a");
            group.Header = "c";
            group.Footer = "b";

            List<GroupData> oldGroups = app.Groups.GetGroupList(); //������ ����� �� �������� �����

            app.Groups.CreateGroup(group);
            app.Navigator.ReturnToGroupsPage();
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount()); //�������� ������ (+1 ������)
            app.Navigator.OpenHomePage();

            List<GroupData> newGroups = app.Groups.GetGroupList(); //������ ����� ����� �������� �����
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //�������� ������
        }

        //[Test]
        //// ����-���� �������� ������ � ������� �����������
        //public void Test_EmptyCreateGroup()
        //{
        //    List<GroupData> oldGroups = app.Groups.GetGroupList(); //������ ����� �� �������� �����

        //    GroupData group = new GroupData("");
        //    group.Header = "";
        //    group.Footer = "";
        //    app.Groups.CreateGroup(group);
        //    app.Navigator.ReturnToGroupsPage();
        //    Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount()); //�������� ������

        //    List<GroupData> newgroups = app.Groups.GetGroupList(); //������ ����� ����� �������� �����
        //    oldGroups.Add(group);
        //    oldGroups.Sort();
        //    newgroups.Sort();
        //    Assert.AreEqual(oldGroups, newgroups); //�������� ������ (����� ����� ����������� �� 1)
        //}

        [Test]
        // ����-���� �������� ������ � ������� �����������
        public void Test_BadNameCreateGroup()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //������ ����� �� �������� �����

            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            app.Groups.CreateGroup(group);
            app.Navigator.OpenGroupsPage();
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount()); //�������� ������ (����� ����� �� �����������)


            List<GroupData> newgroups = app.Groups.GetGroupList(); //������ ����� ����� �������� �����
           
            Assert.AreEqual(oldGroups.Count, newgroups.Count); //�������� ������, ����� ����� �� �����������
        }

    }
}
