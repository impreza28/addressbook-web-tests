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

        public ContactHelper SubmitUpdateContact()
        {//подтверждение изменепния контакта
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitModifyContact()
        {//инициация изменения контакта
            driver.FindElement(By.XPath("(//img[@alt=\'Edit\'])[1]")).Click();
            return this;
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
            return this;
        }


        public List<ContactData> GetContactList()
        {  //формирование списка контактов  
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.OpenHomePage();

            //ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));

            IList<IWebElement> TdLastname = driver.FindElements(By.XPath("//table[@id='maintable']//td[2]"));
            IList<IWebElement> TdFirstname = driver.FindElements(By.XPath("//table[@id='maintable']//td[3]"));

            for (int i=0;i< TdLastname.Count();i++)
            {
                contacts.Add(new ContactData(TdFirstname[i].Text,"", TdLastname[i].Text));

            }
            return contacts;
        }
    }
}
