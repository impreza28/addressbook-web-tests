using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class GroupHelper: HelperBase
    {

        public GroupHelper(ApplicationManager manager): base(manager)
        {

        }


        public GroupHelper CreateGroup(GroupData group)
        {// создание новой группы
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitCreationGroup();
            return this;
        }

        public GroupHelper ModifyGroup(GroupData group)
        {// изменение группы
            SelectGroupTest();
            InitGroupModify();
            ModifyGroupForm(group);
            SubmitUpdateGroup();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public GroupHelper ModifyGroupForm(GroupData group)
        {//изменение данных группы

            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }


        public GroupHelper RemoveGroupTest()
        {//удаление группы
            manager.Navigator.GoToGroupsPage();
            driver.FindElement(By.XPath("//input[@title='Select (Test)']")).Click();
            InitRemoveGroup();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public GroupHelper SelectGroupTest()
        {//выбор группы Test
            driver.FindElement(By.XPath("//input[@title='Select (Test)']")).Click();
            return this;
        }

        public GroupHelper SubmitUpdateGroup()
        {// подтверждение изменения группы
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModify()
        { //инициация редактирования группы
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper InitRemoveGroup()
        {// нажать "Удалить группы"
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            //инициация создания новой группы
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            //заполнение формы новой группы
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }
        public GroupHelper SubmitCreationGroup()
        {
            //подтверждение создания 
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
       

    }
}
