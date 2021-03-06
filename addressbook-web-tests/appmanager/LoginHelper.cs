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
    public class LoginHelper: HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) 
        { 
        }

        public void Login(AccountData account)
        {    //авторизация: логин+пароль
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account)) 
                {
                    return;
                }

                Logout();
            }
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {    //выход из профиля
            if (IsLoggedIn())   
            { 
                driver.FindElement(By.LinkText("Logout")).Click(); 
            }


        }
        public bool IsLoggedIn()
        {    //проверка отображения элемента logout
            return IsElementPresent(By.Name("logout"));
        }
        public bool IsLoggedIn(AccountData account)
        {    //проверка отображения имени залогиненного пользователя
            return IsLoggedIn()
                && GetLoggedUserName() == account.Username; //извлекает имя залогиненного пользователя
        }

        public string GetLoggedUserName()
        {
            string text=driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;//в переменную text записать значение тега b 

            return text.Substring(1, text.Length - 2); // обрезаем значение из тега b в начале на -1  и в конце на -1 символ
        }
    }
}
