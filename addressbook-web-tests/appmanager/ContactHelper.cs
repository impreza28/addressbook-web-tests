using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper CreateContact(ContactData contact)
        {// создание нового контакта
            manager.Contacts.InitContactCreation()
                .FillContactForm(contact)
                .SubmitCreationContact();
            return this;
        }


        public ContactHelper ModifyContact(ContactData contact)
        { //изменение данных контакта
            InitModifyContact();
            FillContactForm(contact);
            SubmitUpdateContact();
            return this;
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//table[@id='maintable']//td[2]")).Count();
        }

        public ContactHelper SubmitUpdateContact()
        {//подтверждение изменепния контакта
            driver.FindElement(By.Name("update")).Click();
            contactCache = null; //очистка кэша
            return this;
        }

        public ContactHelper InitModifyContact()
        {//инициация изменения контакта (старый)
            driver.FindElement(By.XPath("(//img[@alt=\'Edit\'])[1]")).Click();

            return this;
        }
        public void InitContactModify(int index)
        {//инициация изменения контакта (новый)
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[7].FindElement(By.TagName("a")).Click();
            //driver.FindElements(By.XPath("//img[@alt=\'Edit\']"))[1].Click();

        }


        public ContactHelper RemoveContact()
        { //удаление контакта
            InitContactRemove();
            SubmitContactRemove();
            return this;
        }

        public ContactHelper InitContactCreation()
        {   //инициация создания нового ноктакта
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public bool ContactIsFinded()
        {//проверка отображения любого контакта
           return IsElementPresent(By.Name("selected[]"));
        }

        public ContactHelper SelectCheckboxContact(int index)
        {// нажатие на чекбокс контакта
         //driver.FindElement(By.Name("selected[]")).Click();
         driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            //driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper InitContactRemove()
        {// инициация удаления контакта
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SubmitContactRemove()
        {//подтверждение удаления контакта
            driver.SwitchTo().Alert().Accept();
            contactCache = null; //очистка кэша
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {   //заполнение формы нового ноктакта

            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }
        public ContactHelper SubmitCreationContact()
        {
            //подтверждение создания 
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null; //очистка кэша
            return this;
        }


        public ContactData GetContactInfoFromEditForm(int index)
        {//получение данных контакта с формы контакта
            //manager.Navigator.OpenHomePage();
            InitContactModify(0); //инициируем редактирование контакта с index=0

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string homePhone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");


            return new ContactData(firstName, lastName)
            { 
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                HomePhone2 = homePhone2,
                Fax = fax,
                Email1 = email1,
                Email2 = email2,
                Email3 = email3
            };
        }

        public ContactData GetContactInfoFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                                           .FindElements(By.TagName("td"));
            string firstname = cells[2].Text;
            string lastname = cells[1].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstname, lastname)
             {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        private List<ContactData> contactCache = null; //пустой кэш

        public List<ContactData> GetContactList()
        {  //формирование списка контактов  
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();

                //List<ContactData> contacts = new List<ContactData>();
                manager.Navigator.OpenHomePage();

                //ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));

                IList<IWebElement> TdLastname = driver.FindElements(By.XPath("//table[@id='maintable']//td[2]"));
                IList<IWebElement> TdFirstname = driver.FindElements(By.XPath("//table[@id='maintable']//td[3]"));

                for (int i = 0; i < TdLastname.Count(); i++)
                {
                    contactCache.Add(new ContactData(TdLastname[i].Text, TdFirstname[i].Text));
                }
            }
            return new List<ContactData>(contactCache);
        }
    }
}
