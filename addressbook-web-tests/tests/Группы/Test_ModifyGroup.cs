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

        //    if (!app.Groups.GroupIsFinded()) // ���� �� ����� ������ �� �������, �� ������� ������ Test
        //    {
        //        GroupData group = new GroupData("Test", "Test", "Test");
        //        app.Groups.CreateGroup(group);
        //    }

        //    List<GroupData> oldGroups = app.Groups.GetGroupList(); //������ ����� 


        //    GroupData updgroup = new GroupData("Test1", "Test1", "Test1"); //������ ��� ��������� ������

        //    app.Groups.SelectCheckboxGroup(0)
        //              .ModifyGroup(updgroup); //��������� ������
        //    app.Navigator.ReturnToGroupsPage();
        //    Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount()); //�������� ������ (���-�� � ������ �� ����������)

        //    List<GroupData> newGroups = app.Groups.GetGroupList(); //������ ����� ����� �����������
        //    oldGroups[0].Name = updgroup.Name; //� �������� ������ ��� � ������ ������
        //    oldGroups.Sort();
        //    newGroups.Sort();
        //    Assert.AreEqual(oldGroups, newGroups); //��������� �������

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

            if (!app.Groups.GroupIsFinded()) // ���� �� ����� ������ �� �������, �� ������� ������ Test
            {
                GroupData group = new GroupData("Test", "Test", "Test");
                app.Groups.CreateGroup(group);
            }

            List<GroupData> oldGroups = GroupData.GetAll(); //������ ����� 
            GroupData updgroup = new GroupData("Test1", "Test1", "Test1"); //������ ��� ��������� ������
            GroupData toBeUpdated = oldGroups[0];




            //app.Groups.SelectGroup(toBeUpdated)
            app.Groups.Modify(toBeUpdated); //��������� ������
            app.Navigator.ReturnToGroupsPage();
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount()); //�������� ������ (���-�� � ������ �� ����������)

            List<GroupData> newGroups = GroupData.GetAll(); //������ ����� ����� �����������
            toBeUpdated.Name = updgroup.Name; 
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //��������� �������

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
