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
    public class GroupData 
        : IEquatable<GroupData>, //функция сравнения
        IComparable<GroupData>
    {

        public GroupData(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;

        }
        public GroupData(string name)
        {
            Name = name;
        }

        public GroupData() {}

        public string Name { get; set; }

        public string Header {get; set;}

        public string Footer { get; set; }


        public string Id { get; set; }

        public bool Equals(GroupData other) //реализация сравнения 
        { if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(other, this))
            {
                return true;
            }
            return Name == other.Name; //проверяются только имена групп
        }
        public override int GetHashCode() //оптимизация сравнения
        {
            return Name.GetHashCode();
        }
        public override string ToString() //возвращает строковое значение
        {
            return "name=" + Name + ", header=" + Header + ", footer=" + Footer;
        }

        public int CompareTo(GroupData other) 
        { 
            if(Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
    }
}
