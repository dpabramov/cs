using System;
using System.Collections.Generic;
using System.Text;

namespace _12_Nasledovanie
{
    class Person
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public virtual string PropertyString
        {
            get
            {
                return $"Имя:{Name}\nАдрес: {Address}";
            }
        }

        public Person(string name, string address)
        {
            Name = name;

            Address = address;
        }

        public Person()
        {

        }

        public void WriteProp()
        {
            Console.WriteLine(PropertyString);
        }
    }
}
