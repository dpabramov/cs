using System;
using System.Collections.Generic;
using System.Text;

namespace _11_Constructors.Models
{
    class Person
    {
        public string Name { get; set; }

        public DateTimeOffset Birthday { get; set; }

        public string Address { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public Person(string name, DateTimeOffset birthday):this(name)
        {
            Birthday = birthday;
        }

        public Person(string name, DateTimeOffset birthday, string adress):this(name, birthday)
        {
            Address = adress;
        }

    }
}
