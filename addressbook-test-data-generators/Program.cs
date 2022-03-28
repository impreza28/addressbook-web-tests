using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using addressbook_web_tests;

namespace addressbook_test_data_gererators
{
     class Program
    {
        static void Main (string[] args)
        {
            int count = Convert.ToInt32 (args[0]);
            StreamWriter writer = new StreamWriter (args[1]);
            string format = args[3];

            List<GroupData> groups = new List<GroupData> ();


            for (int i = 0; i < count; i++)
            {
                groups.Add (new GroupData ()
                {   Name= TestBase.GenerateRandomString(10),
                    Header = TestBase.GenerateRandomString(100),
                    Footer = TestBase.GenerateRandomString(100)
                });
            }

           if (format == "csv")
            {
                WriteGroupsToCsvFile(groups, writer);
            }
                else if (format == "xml")
                {
                 WriteGroupsToXMLFile(groups, writer);
                 }
            else
            {
                System.Console.Out.Write("Unrecognized format" + format);
            }

            writer.Close ();
        }
        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach(GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                        group.Name, group.Header, group.Footer));
            }

        }
        static void WriteGroupsToXMLFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
    }
}