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
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allNames;
        private string allPhones;
        private string allEmails;
        private string allDetails;
        private string allBirthday;
        private string allAnniversary;
        private string allPhonesDetails;


        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public ContactData()
        {
        }
        //блок основной информации о контакте
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }


        //блок Telephone
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }

        //блок емейлы +ДР
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string BirthdayDay { get; set; }
        public string BirthdayMonth { get; set; }
        public string BirthdayYear { get; set; }
        public string AnniversaryDay { get; set; }
        public string AnniversaryMonth { get; set; }
        public string AnniversaryYear { get; set; }

        //блок Secondary
        public string Address2 { get; set; }
        public string HomePhone2 { get; set; }
        public string Notes { get; set; }


        public string AllNames
        {
            get
            {
                if (allNames != null)
                {
                    return CleanUp(allNames);
                }
                else
                {
                    return (CleanUp(Firstname) + CleanUp(Middlename) + CleanUp(Lastname)).Trim();
                }
            }
            set
            {
                allNames = value;
            }
        }

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
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(HomePhone2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllPhonesDetails
        {
            get
            {
                if (allPhonesDetails != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(Fax)).Trim();
                }
            }
            set
            {
                allPhonesDetails = value;
            }
        }


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
        public string AllBirthday
        {
            get
            {
                if (allBirthday != null)
                {
                    return allBirthday;
                }
                else
                {
                    return (CleanUpDetails(BirthdayDay) + CleanUpDetails(BirthdayMonth) + CleanUpDetails(BirthdayYear)).Trim();
                }
            }
            set
            {
                allBirthday = value;
            }
        }

        public string AllAnniversary
        {
            get
            {
                if (allAnniversary != null)
                {
                    return allAnniversary;
                }
                else
                {
                    return (CleanUpDetails(AnniversaryDay) + CleanUpDetails(AnniversaryMonth) + CleanUpDetails(AnniversaryYear)).Trim();
                }
            }
            set
            {
                allAnniversary = value;
            }
        }
        public string AllDetails
        {
           get
            {
                if (allDetails != null)
                {
                    return CleanUpDetails(allDetails);
               }
               else
               {
                    return (CleanUpDetails(Firstname) + 
                           CleanUpDetails(Middlename) + 
                           CleanUpDetails(Lastname) + 
                           CleanUpDetails(Nickname) + 
                           CleanUpDetails(Title) +
                           CleanUpDetails(Company) + 
                           CleanUpDetails(Address) +
                           CleanUpDetails(HomePhone) +
                           CleanUpDetails(MobilePhone) +
                           CleanUpDetails(WorkPhone) +
                           CleanUpDetails(Fax) +
                           CleanUpDetails(Email1) +
                           CleanUpDetails(Email2) +
                           CleanUpDetails(Email3) +
                           CleanUpDetails(Homepage) +
                           CleanUpDetails(AllBirthday) +
                           CleanUpDetails(AllAnniversary) +
                           CleanUpDetails(Address2) +
                           CleanUpDetails(HomePhone2) +
                           CleanUpDetails(Notes))
                           .Trim();
               }
           }
          set
            {
                allDetails = value;
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

        private string CleanUpDetails(string i)
        {
            if (i == null || i == "")
            {
                return "";
            }
            //return i.Replace(" ", "").Replace("H:", "").Replace("M:", "").Replace("W:", "").Replace("F:", "")
                //.Replace("Homepage:", "").Replace("Birthday", "").Replace("Anniversary", "").Replace("P:", "") + "\r\n";
            return i.Replace(" ", "").Replace("h:", "").Replace("m:", "").Replace("w:", "").Replace("f:", "")
                .Replace("homepage:", "").Replace("birthday", "").Replace("anniversary", "").Replace("p:", "").Replace(".", "").Replace("\r", "").Replace("\n", "");
        }

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
