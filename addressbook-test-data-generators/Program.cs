﻿using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using addressbook_web_tests;


namespace addressbook_test_data_gererators
{
    class Program
    {
        static void Main(string[] args)
        {
            string grouporcontact = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];
            StreamWriter writer = new StreamWriter(filename);


            if (grouporcontact == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }

                //if (format == "excel")
               // {
                   // WriteGroupsToExcelFile(groups, filename);
                //}
                //else


                //if (format == "csv")
                //{
                //    WriteGroupsToCsvFile(groups, writer);
               // }
                if (format == "xml")
                {
                    WriteGroupsToXMLFile(groups, writer);
                }
                else if (format == "json")
                {
                    WriteGroupsToJsonFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }

                writer.Close();

            }

            else if (grouporcontact == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();

                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(20)));
                }


                if (format == "xml")
                {
                    WriteContactsToXMLFile(contacts, writer);
                }
                else if (format == "json")
                {
                    WriteContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }

                writer.Close();


            }

            else
            {
                System.Console.Out.Write("Unrecognized subject " + grouporcontact);
            }

            //static void WriteGroupsToExcelFile(List<GroupData> groups, string filename)
            //{
            //    Excel.Application app = new Excel.Application();
            //    app.Visible = true;
            //    Excel.Workbook wb = app.Workbooks.Add();
            //    Excel.Worksheet sheet = wb.ActiveSheet;

            //    int row = 1;
            //    foreach (GroupData group in groups)
            //    {
            //        sheet.Cells[row, 1] = group.Name;
            //        sheet.Cells[row, 2] = group.Header;
            //        sheet.Cells[row, 3] = group.Footer;
            //        row++;
            //    }
            //    string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            //    File.Delete(fullPath);
            //    wb.SaveAs(fullPath);
            //    wb.Close();
            //    app.Visible = false;
            //    app.Quit();
            //}
            static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
            {
                foreach (GroupData group in groups)
                {
                    writer.WriteLine(String.Format("${0},${1},${2}",
                            group.Name, group.Header, group.Footer));
                }

            }
            //xml для групп
            static void WriteGroupsToXMLFile(List<GroupData> groups, StreamWriter writer)
            {
                new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
            }

            //json для групп
            static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
            {
                writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
            }

            //json для контактов
            static void WriteContactsToXMLFile(List<ContactData> contacts, StreamWriter writer)
            {
                new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
            }

            //json для контактов
            static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
            {
                writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
            }
        }
    }
}