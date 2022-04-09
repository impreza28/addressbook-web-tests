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

        public ContactHelper InitOpenDetailsContact(int index)
        {
            driver.FindElement(By.XPath("//img[@alt='Details']")).Click();
            return this;
        }

        public ContactData GetContactInfoFromEditForm(int index)
        {//получение данных контакта с формы контакта

            string firstname, middlename, lastname, allNames;
            //manager.Navigator.OpenHomePage();
            InitContactModify(0); //инициируем редактирование контакта с index=0

            // блок основной информации о контакте
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
           // string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            //string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            //string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            //блок Telephone
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            //string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            //блок емейлы +ДР
            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData()
            {
                Firstname = firstName,
                Lastname = lastName,
                Middlename = middleName,
                //блок основной информации о контакте
                // Nickname = nickname,
                // Company = company,
                // Title = title,
                Address = address,

                //блок Telephone
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                //Fax = fax,
                //блок емейлы +ДР
                Email1 = email1,
                Email2 = email2,
                Email3 = email3

            };
        }

        public string GetContactStringFromDetails(ContactData allDetails)
        {
            string firstname, middlename, lastname, address, homephone, mobilephone, workphone, email1, email2, email3;


            string allNames = null;
            string allPhones = null;
            string allEmails = null;
            string Details;

            firstname = allDetails.Firstname;
            middlename = allDetails.Middlename;
            lastname = allDetails.Lastname;
            address = allDetails.Address;

            homephone = allDetails.HomePhone;
            mobilephone = allDetails.MobilePhone;
            workphone = allDetails.WorkPhone;

            email1 = allDetails.Email1;
            email2 = allDetails.Email2;
            email3 = allDetails.Email3;


            //условия для написания строки ФИО - allNames

            // если заполнено всё ФИО
            if (allDetails.Firstname != "" && allDetails.Middlename != "" && allDetails.Lastname != "")
            {
                allNames = firstname + " " + middlename + " " + lastname;
            }
            // если не заполнен Firstname
            else if (allDetails.Firstname == "" && allDetails.Middlename != "" && allDetails.Lastname != "")
            {
                allNames = middlename + " " + lastname;
            }
            // если не заполнен Middlename
            else if (allDetails.Firstname != "" && allDetails.Middlename == "" && allDetails.Lastname != "")
            {
                allNames = firstname + " " + lastname;
            }
            // если не заполнен Lastname
            else if (allDetails.Firstname != "" && allDetails.Middlename != "" && allDetails.Lastname == "")
            {
                allNames = firstname + " " + middlename;
            }

            // если не заполнен Firstname и Middlename
            else if (allDetails.Firstname == "" && allDetails.Middlename == "" && allDetails.Lastname != "")
            { allNames = lastname; }

            // если не заполнен Firstname и Lastname
            else if (allDetails.Firstname == "" && allDetails.Middlename != "" && allDetails.Lastname == "")
            { allNames = middlename; }

            // если не заполнен Middlename и Lastname
            else if (allDetails.Firstname != "" && allDetails.Middlename == "" && allDetails.Lastname == "")
            { allNames = firstname; }

            // если не заполнен ФИО
            else if (allDetails.Firstname == "" && allDetails.Middlename == "" && allDetails.Lastname == "")
            { allNames = ""; }


            //условия для написания строки адреса

            //если allNames и Address заполнен
            if (allNames != "" && allDetails.Address != "")
            {
                address = "\r\n" + allDetails.Address;
            }
            //если Address не заполнен
            else if (allNames != "" && allDetails.Address == "")
            {
                address = "";
            }
            //если allNames не заполнен
            else if (allNames == "" && allDetails.Address != "")
            {
                address = allDetails.Address;
            }

            // запись в общую строку
            Details = allNames + address;


            //условия для написания строки телефонов - allPhones


            // если заполнен ФИО/адрес и все телефоны
            if (Details != "" && allDetails.HomePhone != "" && allDetails.MobilePhone != "" && allDetails.WorkPhone != "")
            {
                allPhones = "\r\n\r\n" + "H:" + " " + homephone + "\r\n" + "M:" +" "+ mobilephone + "\r\n" + "W:" +" "+ workphone;
            }

            // если заполнен ФИО/адрес и не заполнен HomePhone
            else if (Details != "" && allDetails.HomePhone == "" && allDetails.MobilePhone != "" && allDetails.WorkPhone != "")
            {
                allPhones = "\r\n\r\n" + "M:" + " " + mobilephone + "\r\n" + "W:" + " " + workphone;
            }
            // если заполнен ФИО/адрес и не заполнен MobilePhone
            else if (Details != "" && allDetails.HomePhone != "" && allDetails.MobilePhone == "" && allDetails.WorkPhone != "")
            {
                allPhones = "\r\n\r\n" + "H:" + " " + homephone + "\r\n" + "W:" + " " + workphone;
            }
            // если заполнен ФИО/адрес и не заполнен WorkPhone
            else if (Details != "" && allDetails.HomePhone != "" && allDetails.MobilePhone != "" && allDetails.WorkPhone == "")
            {
                allPhones = "\r\n\r\n" + "H:" + " " + homephone + "\r\n" + "M:" + " " + mobilephone;
            }
            // если заполнен ФИО/адрес и не заполнен HomePhone и MobilePhone
            else if (Details != "" && allDetails.HomePhone == "" && allDetails.MobilePhone == "" && allDetails.WorkPhone != "")
            {
                allPhones = "\r\n\r\n" + "W:" + " " + workphone;
            }
            // если заполнен ФИО/адрес и не заполнен HomePhone и WorkPhone
            else if (Details != "" && allDetails.HomePhone == "" && allDetails.MobilePhone != "" && allDetails.WorkPhone == "")
            {
                allPhones = "\r\n\r\n" +  "M:" + " " + mobilephone;
            }
            // если заполнен ФИО/адрес и не заполнен HomePhone и WorkPhone
            else if (Details != "" && allDetails.HomePhone != "" && allDetails.MobilePhone == "" && allDetails.WorkPhone == "")
            {
                allPhones = "\r\n\r\n" + "H:" + " " + homephone;
            }
            // если заполнен ФИО/адрес и не заполнены телефоны
            else if (Details != "" && allDetails.HomePhone == "" && allDetails.MobilePhone == "" && allDetails.WorkPhone == "")
            {
                allPhones = "";
            }



            // если не заполнен ФИО/адрес и все телефоны
            if (Details == "" && allDetails.HomePhone != "" && allDetails.MobilePhone != "" && allDetails.WorkPhone != "")
            {
                allPhones = "H:" + " " + homephone + "\r\n" + "M:" + " " + mobilephone + "\r\n" + "W:" + " " + workphone;
            }

            // если не заполнен ФИО/адрес и не заполнен HomePhone
            else if (Details == "" && allDetails.HomePhone == "" && allDetails.MobilePhone != "" && allDetails.WorkPhone != "")
            {
                allPhones = "M:" + " " + mobilephone + "\r\n" + "W:" + " " + workphone;
            }
            // если не заполнен ФИО/адрес и не заполнен MobilePhone
            else if (Details == "" && allDetails.HomePhone != "" && allDetails.MobilePhone == "" && allDetails.WorkPhone != "")
            {
                allPhones = "H:" + " " + homephone + "\r\n" + "W:" + " " + workphone;
            }
            // если не заполнен ФИО/адрес и не заполнен WorkPhone
            else if (Details == "" && allDetails.HomePhone != "" && allDetails.MobilePhone != "" && allDetails.WorkPhone == "")
            {
                allPhones = "H:" + " " + homephone + "\r\n" + "M:" + " " + mobilephone;
            }
            // если не заполнен ФИО/адрес и не заполнен HomePhone и MobilePhone
            else if (Details == "" && allDetails.HomePhone == "" && allDetails.MobilePhone == "" && allDetails.WorkPhone != "")
            {
                allPhones = "W:" + " " + workphone;
            }
            // если не заполнен ФИО/адрес и не заполнен HomePhone и WorkPhone
            else if (Details == "" && allDetails.HomePhone == "" && allDetails.MobilePhone != "" && allDetails.WorkPhone == "")
            {
                allPhones = "M:" + " " + mobilephone;
            }
            // если не заполнен ФИО/адрес и не заполнен HomePhone и WorkPhone
            else if (Details == "" && allDetails.HomePhone != "" && allDetails.MobilePhone == "" && allDetails.WorkPhone == "")
            {
                allPhones = "H:" + " " + homephone;
            }
            // если не заполнен ФИО/адрес и не заполнены телефоны
            else if (Details == "" && allDetails.HomePhone == "" && allDetails.MobilePhone == "" && allDetails.WorkPhone == "")
            {
                allPhones = "";
            }


            // запись в общую строку
            Details = allNames + address+ allPhones;





            //условия для написания строки е-мейлов - allEmails


            // если заполнен ФИО/адрес/телефон и все Emails
            if (Details != "" && allDetails.Email1 != "" && allDetails.Email2 != "" && allDetails.Email3 != "")
            {
                allEmails = "\r\n\r\n" + email1 + "\r\n" + email2 + "\r\n"  + email3;
            }

            // если заполнен ФИО/адрес/телефон и не заполнен Email1
            else if (Details != "" && allDetails.Email1 == "" && allDetails.Email2 != "" && allDetails.Email3 != "")
            {
                allEmails = "\r\n\r\n" + email2 + "\r\n" + email3;
            }
            // если заполнен ФИО/адрес/телефон и не заполнен Email2
            else if (Details != "" && allDetails.Email1 != "" && allDetails.Email2 == "" && allDetails.Email3 != "")
            {
                allEmails = "\r\n\r\n" + email1 + "\r\n" + email3;
            }
            // если заполнен ФИО/адрес/телефон и не заполнен Email3
            else if (Details != "" && allDetails.Email1 != "" && allDetails.Email2 != "" && allDetails.Email3 == "")
            {
                allEmails = "\r\n\r\n"  + email1 + "\r\n" + email2;
            }
            // если заполнен ФИО/адрес/телефон и не заполнен Email1 и Email2
            else if (Details != "" && allDetails.Email1 == "" && allDetails.Email2 == "" && allDetails.Email3 != "")
            {
                allEmails = "\r\n\r\n"  + email3;
            }
            // если заполнен ФИО/адрес/телефон и не заполнен Email1 и Email3
            else if (Details != "" && allDetails.Email1 == "" && allDetails.Email2 != "" && allDetails.Email3 == "")
            {
                allEmails = "\r\n\r\n"  + email2;
            }
            // если заполнен ФИО/адрес/телефон и не заполнен Email2 и Email3
            else if (Details != "" && allDetails.Email1 != "" && allDetails.Email2 == "" && allDetails.Email3 == "")
            {
                allEmails = "\r\n\r\n"  + email1;
            }
            // если заполнен ФИО/адрес/телефон и не заполнены телефоны
            else if (Details != "" && allDetails.Email1 == "" && allDetails.Email2 == "" && allDetails.Email3 == "")
            {
                allEmails = "";
            }



            // если не заполнен ФИО/адрес/телефон и все телефоны
            if (Details == "" && allDetails.Email1 != "" && allDetails.Email2 != "" && allDetails.Email3 != "")
            {
                allEmails = email1 + "\r\n" + email2 + "\r\n" + email3;
            }

            // если не заполнен ФИО/адрес/телефон и не заполнен Email1
            else if (Details == "" && allDetails.Email1 == "" && allDetails.Email2 != "" && allDetails.Email3 != "")
            {
                allEmails = email2 + "\r\n" + email3;
            }
            // если не заполнен ФИО/адрес/телефон и не заполнен Email2
            else if (Details == "" && allDetails.Email1 != "" && allDetails.Email2 == "" && allDetails.Email3 != "")
            {
                allEmails = email1 + "\r\n" +email3;
            }
            // если не заполнен ФИО/адрес/телефон и не заполнен Email3
            else if (Details == "" && allDetails.Email1 != "" && allDetails.Email2 != "" && allDetails.Email3 == "")
            {
                allEmails = email1 + "\r\n" + email2;
            }
            // если не заполнен ФИО/адрес/телефон и не заполнен Email1 и Email2
            else if (Details == "" && allDetails.Email1 == "" && allDetails.Email2 == "" && allDetails.Email3 != "")
            {
                allEmails = email3;
            }
            // если не заполнен ФИО/адрес/телефон и не заполнен Email1 и Email3
            else if (Details == "" && allDetails.Email1 == "" && allDetails.Email2 != "" && allDetails.Email3 == "")
            {
                allEmails = email2;
            }
            // если не заполнен ФИО/адрес/телефон и не заполнен Email2 и Email3
            else if (Details == "" && allDetails.Email1 != "" && allDetails.Email2 == "" && allDetails.Email3 == "")
            {
                allEmails = email1;
            }
            // если не заполнен ФИО/адрес/телефон и не заполнены е-мейлы
            else if (Details == "" && allDetails.Email1 == "" && allDetails.Email2 == "" && allDetails.Email3 == "")
            {
                allEmails = "";
            }


            // запись в общую строку 
            Details = allNames + address + allPhones + allEmails;


            return Details;


        }



        public string GetContactInfoFromDetails(int index)
        {
            {
                string allDetails;
                manager.Navigator.OpenHomePage();
                InitOpenDetailsContact(0);
                allDetails = driver.FindElement(By.Id("content")).Text;
                return allDetails;
            }
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
