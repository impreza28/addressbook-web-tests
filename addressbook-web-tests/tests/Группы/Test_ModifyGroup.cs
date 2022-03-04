using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ModifyGroup : AuthTestBase
    {

    [Test]
    public void Test_ModifyGroup()
        {

            app.Navigator.OpenGroupsPage();

            if (app.Groups.GroupIsFinded()) //���� ������  �������, �� ������ �����������
            { }
            else 
            {
                // ���� �� ����� ������ �� �������, �� ������� ������ Test
                GroupData group = new GroupData("Test", "Test", "Test");
                app.Groups.CreateGroup(group);
            }

            app.Navigator.OpenGroupsPage();

            GroupData updgroup = new GroupData("Test1", "Test1", "Test1");

            app.Groups.SelectCheckboxGroup()
                      .ModifyGroup(updgroup); //��������� ������
            app.Navigator.ReturnToGroupsPage();
        }

    }
}
