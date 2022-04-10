using System;

namespace _142_StaticExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Дима";
            person.Age = 45;
            person.WriteProperties();

            Person.StringFormat = "Имя: {0}, возраст: {1}";
            
            Person person2 = new Person();
            person2.Name = "Саша";
            person2.Age = 15;
            person2.WriteProperties();


            Person person3 = new Person();
            person3.Name = "Паша";
            person3.Age = 25;
            person3.WriteProperties();

            Console.ReadKey();
        }
    }
}
