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
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {

        public ContactData(string firstname, string middlename, string lastname)
        {
         Firstname = firstname;
         Middlename = middlename;
         Lastname = lastname;

        }
        public ContactData(string firstname)
        {
            Firstname = firstname;
        }
        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }


        public bool Equals(ContactData other) //реализация сравнения 
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(other, this))
            {
                return true;
            }

            return ((Firstname == other.Firstname) && (Lastname == other.Lastname));
        }


        public override int GetHashCode()
        {
            return Firstname.GetHashCode() & Lastname.GetHashCode();
        }

        public override string ToString() //возвращает строковое значение
        {
            return "Lastname / Firstname=" + Lastname + Firstname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Firstname.CompareTo(other.Firstname); //& Lastname.CompareTo(other.Lastname);
        }
    }
}
