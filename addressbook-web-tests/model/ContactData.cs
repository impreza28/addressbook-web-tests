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
    public class ContactData: IEquatable<ContactData>
    {
        private string firstname;
        private string middlename;
        private string lastname;

        public ContactData(string firstname, string middlename, string lastname)
        {
         this.firstname = firstname;
         this.middlename = middlename;
         this.lastname = lastname;

        }
        public ContactData(string firstname)
        {
            this.firstname = firstname;
        }
        public string Firstname
        {
            get
            {
                return firstname; 
            }
            set
            {
                firstname = value;
            }
        }
        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(other, this))
            {
                return true;
            }
            return Firstname == other.Firstname;
            return Lastname == other.Lastname;
        }
        public int GetHashCode()
        {
            return Firstname.GetHashCode();
            return Lastname.GetHashCode();
        }
    }
}
