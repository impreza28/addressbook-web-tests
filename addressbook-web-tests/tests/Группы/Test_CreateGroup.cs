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

            List<GroupData> oldGroups = app.Groups.GetGroupList(); //������ ����� �� �������� �����

            app.Groups.CreateGroup(group);
            app.Navigator.ReturnToGroupsPage();
            app.Navigator.OpenHomePage();

            List<GroupData> newgroups = app.Groups.GetGroupList(); //������ ����� ����� �������� �����
            Assert.AreEqual(oldGroups.Count+1, newgroups.Count); //�������� ������ (����� ����� ����������� �� 1)
        }

        [Test]
        // ����-���� �������� ������ � ������� �����������
        public void Test_EmptyCreateGroup()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //������ ����� �� �������� �����

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Groups.CreateGroup(group);
            app.Navigator.ReturnToGroupsPage();
            app.Navigator.OpenHomePage();

            List<GroupData> newgroups = app.Groups.GetGroupList(); //������ ����� ����� �������� �����
            Assert.AreEqual(oldGroups.Count + 1, newgroups.Count); //�������� ������ (����� ����� ����������� �� 1)
        }

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


            List<GroupData> newgroups = app.Groups.GetGroupList(); //������ ����� ����� �������� �����
            Assert.AreEqual(oldGroups.Count + 1, newgroups.Count); //�������� ������ (����� ����� ����������� �� 1)
        }

    }
}
