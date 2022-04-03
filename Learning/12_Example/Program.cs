using System;

namespace _12_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Sanek", DateTimeOffset.Parse("2007-08-02"));
            person.WriteShortDescription();

            //выводит название типа данных (имя класса) с неймспейсом
            Console.WriteLine(person.ToString());

            Emploee emploee = new Emploee("Pashok", DateTimeOffset.Parse("1999-01-21"));
            emploee.EmploeeCode = "00001";
            emploee.HireDate = DateTimeOffset.Parse("2022-03-01");
            emploee.WriteShortDescription();
            Console.WriteLine(emploee.ToString());

            Console.ReadKey();
        }
    }
}
