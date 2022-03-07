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
                // ���� �� ����� ������ �� �������, �� ������� ������ Test
                GroupData group = new GroupData("Test", "Test", "Test");
                app.Groups.CreateGroup(group);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();  // ������   �����

            app.Groups.SelectCheckboxGroup(0) // ������� ������ � index=0
                      .RemoveGroup(); //�������� ������
            app.Navigator.ReturnToGroupsPage();

            List<GroupData> newGroups = app.Groups.GetGroupList(); //����� ������ ����� 
            oldGroups.RemoveAt(0); // ������� �� ������� ������ ������ � index=0

            Assert.AreEqual(oldGroups, newGroups); //��������� �������
        }

    }
}
