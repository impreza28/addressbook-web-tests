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
        //private string name;
        //private string header;
        //private string footer;

        public GroupData(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
            //this.name = name;
            //this.header = header;
            //this.footer = footer;
        }
        public GroupData(string name)
        {
            Name = name;
            // this.name = name;
        }
        public string Name { get; set; }
        //{
        //    get
        //    {
        //        return name;
        //    }
        //    set
        //    {
        //        name = value;
        //    }
        //}
        public string Header {get; set;}
        //{
        //    get
        //    {
        //        return header;
        //    }
        //    set
        //    {
        //        header = value;
        //    }
        //}
        public string Footer { get; set; }
        //{
        //    get
        //    {
        //        return footer;
        //    }
        //    set
        //    {
        //        footer = value;
        //    }
        //}

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
            return "name=" +Name;
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
