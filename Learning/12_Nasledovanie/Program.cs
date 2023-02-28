using System;

namespace _12_Nasledovanie
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Dima", "Khabarovsk");
            
            person.WriteProp();

            var doctor = new Doctor("Pasha", "Volgograd", "Хирург");

            doctor.WriteProp();

            Console.ReadKey();

        }
    }
}
