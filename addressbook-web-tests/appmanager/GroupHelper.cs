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
            SelectOrCreateGroup();
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
            SelectCheckboxGroup();
            InitRemoveGroup();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public GroupHelper SelectCheckboxGroup()
        {// нажатие на чекбокс любой группы
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }
        public GroupHelper SelectOrCreateGroup()
        {// выбор группы или её создание
            if (GroupIsFinded()) //если группа  найдена, то выбрать группу
            {
                driver.FindElement(By.Name("selected[]")).Click();
                return this;
            }

            // если ни одной группы не найдено, то создать группу Test
            GroupData group = new GroupData("Test", "Test", "Test");
            CreateGroup(group);
            manager.Navigator.GoToGroupsPage();
            SelectCheckboxGroup();
            return this;
        }

        public bool GroupIsFinded() 
        {// проверка наличия любой группы на форме Групп
            return IsElementPresent(By.Name("selected[]"));
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
