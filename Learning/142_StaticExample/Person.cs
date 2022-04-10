using System;
using System.Collections.Generic;
using System.Text;

namespace _142_StaticExample
{
    class Person
    {
        public static string StringFormat { get; set; }

        static Person()
        {
            StringFormat = "{0}: {1}";
        }

        private string Properties
        {
            get
            {
                return string.Format(StringFormat, Name, Age);
            }
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public void WriteProperties()
        {
            Console.WriteLine(Properties);
        }
    }
}
