using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }


        public GroupHelper CreateGroup(GroupData group)
        {// создание новой группы
            manager.Navigator.OpenGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitCreationGroup();
            return this;
        }


        public GroupHelper ModifyGroup(GroupData group)
        {// изменение группы
            InitGroupModify();
            ModifyGroupForm(group);
            SubmitUpdateGroup();
            return this;
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count();
        }

        public GroupHelper ModifyGroupForm(GroupData group)
        {//изменение данных группы

            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper RemoveGroup()
        {//удаление группы
            InitRemoveGroup();
            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.OpenGroupsPage();
            SelectGroup(group.Id);
            InitRemoveGroup();
            manager.Navigator.ReturnToGroupsPage();
            return this;
        }//удаление группы
           
        public GroupHelper SelectCheckboxGroup(int index)
        {// нажатие на чекбокс любой группы
            driver.FindElement(By.XPath("(//input[@name='selected[]'])["+ (index+1) +"]")).Click();
            return this;
        }

        public GroupHelper SelectGroup(string id)
        {// нажатие на чекбокс любой группы
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }

        public bool GroupIsFinded() 
        {// проверка наличия любой группы на форме Групп
            return IsElementPresent(By.Name("selected[]"));
        }


        public GroupHelper SubmitUpdateGroup()
        {// подтверждение изменения группы
            driver.FindElement(By.Name("update")).Click();
            groupCache = null; //очистка кэша в GetGroupList
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
            groupCache = null; //очистка кэша в GetGroupList
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
            groupCache=null; //очистка кэша в GetGroupList
            return this;
        }

        private List<GroupData> groupCache = null; //кэш

        public List<GroupData> GetGroupList()
        {  //формирование списка групп  
            if(groupCache == null) //если кэш чист, то заполняем кэш
            {
                groupCache = new List<GroupData>();

                manager.Navigator.OpenGroupsPage();

                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group")); //список элементов

                foreach (IWebElement element in elements)
                {
                    //groupCache.Add(new GroupData(element.Text));
                    groupCache.Add(new GroupData (element.Text)
                    { Id = element.FindElement(By.TagName("input")).GetAttribute("value") });
                }
            }    

           return new List<GroupData>(groupCache);
        }


    }
}
