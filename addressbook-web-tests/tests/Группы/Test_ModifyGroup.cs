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
    public class ModifyGroup : AuthTestBase
    {

    [Test]
    public void Test_ModifyGroup()
        {

            app.Navigator.OpenGroupsPage();

            if (!app.Groups.GroupIsFinded()) // ���� �� ����� ������ �� �������, �� ������� ������ Test
            {  
                GroupData group = new GroupData("Test", "Test", "Test");
                app.Groups.CreateGroup(group);
            }
           
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //������ ����� 

            GroupData updgroup = new GroupData("Test1", "Test1", "Test1"); //������ ��� ��������� ������

            app.Groups.SelectCheckboxGroup(0)
                      .ModifyGroup(updgroup); //��������� ������
            app.Navigator.ReturnToGroupsPage();
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount()); //�������� ������ (���-�� � ������ �� ����������)

            List<GroupData> newgroups = app.Groups.GetGroupList(); //������ ����� ����� �����������
            oldGroups[0].Name = updgroup.Name; //� �������� ������ ��� � ������ ������
            oldGroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldGroups, newgroups); //��������� �������
        }

    }
}
