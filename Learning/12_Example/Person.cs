using System;
using System.Collections.Generic;
using System.Text;

namespace _12_Example
{
    class Person
    {
        public string Name { get; set; }

        public DateTimeOffset DayOfBirth { get; set; }

        public virtual string ShortDescription
        {
            //вначале выводится название типа данных (имя класса)
            get
            {
                return $"Type: {GetType().Name}; \nName: {Name}; \nDayOfBirth: {DayOfBirth:dd-MM-yyyy}.";
            }
        }

        public Person(string name, DateTimeOffset dayOfBirth)
        {
            Name = name;
            DayOfBirth = dayOfBirth;
        }

        public void WriteShortDescription()
        {
            Console.WriteLine(ShortDescription);
        }
    }
}

