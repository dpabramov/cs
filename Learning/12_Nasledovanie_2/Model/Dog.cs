using System;
using System.Collections.Generic;
using System.Text;

namespace _12_Nasledovanie_2.Model
{
    class Dog : Pet
    {
        public string Poroda { get; set; }

        public override string PropString
        {
            get
            {
                return base.PropString + $"\nпорода {Poroda}";
            }
        }

        public Dog(string type, string name, DateTimeOffset birthday, string poroda)
                :base(type, name,birthday)
        {
            Poroda = poroda;
        }

        public Dog()
        {
        }
    }
}
