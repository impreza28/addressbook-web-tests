﻿using System;
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
        {
            InitModifyContact();
            FillContactForm(contact);
            //driver.FindElement(By.Name("firstname")).SendKeys("Test1");
            //driver.FindElement(By.Name("middlename")).SendKeys("Test1");
            //driver.FindElement(By.Name("lastname")).SendKeys("Test1");
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
        { //удаление контакта Test
            SelectContactTest();
            InitContactDelete();
            AcceptContactDelete();
            return this;
        }

        public ContactHelper InitContactCreation()
        {   //инициация создания нового ноктакта
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SelectContactTest()
        {//выбор контакта Test
            driver.FindElement(By.XPath("//input[@title=\'Select (Test Test)\']")).Click();
            return this;
        }

        public ContactHelper InitContactDelete()
        {// инициация удаления контакта
            driver.FindElement(By.XPath("//input[@value=\'Delete\']")).Click();
            return this;
        }

        public ContactHelper AcceptContactDelete()
        {//подтверждение удаления контакта
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {   //заполнение формы нового ноктакта
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
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
