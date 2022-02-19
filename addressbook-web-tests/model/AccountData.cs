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
    public class AccountData : TestBase
    {
        private string username;
        private string password;

        public AccountData(string username, string password)
        {
        this.username = username;
        this.password = password;
        }

        public string Username
        {
            get 
            { 
                return username; 
            } 
            set 
            { 
                username = value; 
            } 
        }
        public string Password

        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }


    }
}
