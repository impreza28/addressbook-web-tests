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
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            //Middlename = middlename;
            Lastname = lastname;

        }
        //public ContactData(string firstname)
        //{
        //    Firstname = firstname;
        //}
        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Fax { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    //return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(Fax)).Trim();
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }


        public string AllEmails 
           {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                  return (CleanUp(Email1) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
               allEmails = value;
            }
        }

        private string CleanUp(string i)
        {
            if (i == null || i == "")
            {
                return "";
            }
            return i.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        //private string CleanUp(string phone) 
        //{
        //    if (phone == null || phone == "")
        //    { 
        //        return ""; 
        //    }
        //    return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        //}



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

            return Firstname == other.Firstname && Lastname == other.Lastname;

        }


        public override int GetHashCode()
        {
            return Lastname.GetHashCode() & Firstname.GetHashCode();
        }

        public override string ToString() //возвращает строковое значение
        {
            return "Lastname / Firstname=" + Lastname + " "+Firstname;
        }

        public int CompareTo(ContactData other)
        {
                if (Object.ReferenceEquals(other, null))
                {
                    return 1;
                }

                int i = Lastname.CompareTo(other.Lastname);
                if (i != 0)
                {
                    return i;
                }
                else
                {
                    return Firstname.CompareTo(other.Firstname);
                }

                //  int i= Firstname.CompareTo(other.Firstname); //& Lastname.CompareTo(other.Lastname);
                // return i;


        }
    }
}
