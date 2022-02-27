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
            SelectOrCreateContact();
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
            SelectOrCreateContact();
            InitContactRemove();
            SubmitContactRemove();
            return this;
        }

        public ContactHelper InitContactCreation()
        {   //инициация создания нового ноктакта
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SelectOrCreateContact()
        {// 
            if (ContactIsFinded()) //если контакт  найден, то выбрать контакт
            {
                driver.FindElement(By.Name("selected[]")).Click();
                return this;
            }

            // если ни одного контакта не найдено, то создать контакт
            ContactData contact = new ContactData("Test", "Test", "Test");

            CreateContact(contact);
            manager.Navigator.ReturnToHomePage();
            SelectCheckboxContact();
            return this;
        }

        public bool ContactIsFinded()
        {//проверка отображения любого контакта
           return IsElementPresent(By.Name("selected[]"));
        }

        public ContactHelper SelectCheckboxContact()
        {// нажатие на чекбокс любого контакта
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }

        public ContactHelper InitContactRemove()
        {// инициация удаления контакта
            driver.FindElement(By.XPath("//input[@value=\'Delete\']")).Click();
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


    }
}
