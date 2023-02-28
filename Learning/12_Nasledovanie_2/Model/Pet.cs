using System;
using System.Collections.Generic;
using System.Text;

namespace _12_Nasledovanie_2.Model
{
    class Pet
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public DateTimeOffset Birthday { get; set; }

        public virtual string PropString { get { return "Тип: {0}\nКличка: {1}\nДата рождения: {2}"; } }

        public Pet(string type, string name, DateTimeOffset birthday)
        {
            Type = type;

            Name = name;

            Birthday = birthday;
        }

        public Pet()
        {

        }

        public void WriteProp()
        {
            Console.WriteLine(PropString, Type, Name, Birthday);
        }

    }
}
