﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using addressbook_web_tests;

namespace addressbook_test_data_gererators
{
     class Program
    {
        static void Main (string[] args)
        {
            int count= Convert.ToInt32 (args[0]);
            StreamWriter writer = new StreamWriter (args[1]);
            for(int i = 0; i < count; i++)
            {
                writer.WriteLine (String.Format("${0},${1},${2}", 
                    TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(10)));
            }
            writer.Close ();
        }
    }
}