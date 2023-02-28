using _11_Constructors.Models;
using System;

namespace _11_Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Вася", DateTimeOffset.Now, "Возле МКАДа");

            Presenter.WriteOut(person);

            Console.ReadKey();
        }
    }
}
