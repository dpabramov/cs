using _12_Nasledovanie_2.Model;
using System;

namespace _12_Nasledovanie_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Pet pet = new Pet()
            {
                Type = "Кот",
                Name = "Мурка",
                Birthday = DateTimeOffset.Parse("01.01.2022")
            };

            //pet.WriteProp();

            Dog dog = new Dog()
            {
                Type = "Собака",
                Name = "Бим",
                Birthday = DateTimeOffset.Parse("01.01.2020"),
                Poroda = "Овчарка"

            };

            //dog.WriteProp();

            Pet superdog = new Dog()
            {
                Type = "СуперСобака",
                Name = "Лайка",
                Birthday = DateTimeOffset.Parse("01.01.2020"),
                Poroda = "Дворняжка"

            };

            //superdog.WriteProp();

            ((Dog)superdog).Poroda = "Такса";

            //((Dog)superdog).WriteProp();

            Pet[] pets = new Pet[3];
            pets[0] = pet;
            pets[1] = dog;
            pets[2] = new Dog()
            {
                Type = "Осел",
                Name = "Иа",
                Birthday = DateTimeOffset.Parse("01.01.2020"),
                Poroda = "Кавказский осел"

            };

            foreach (var pety in pets)
            {
                
                if (pety is Dog)
                {
                    Console.WriteLine("Dog!!!");
                    pety.WriteProp();
                }
                else if (pety is Pet)
                {
                    Console.WriteLine("Pet!!!");
                    pety.WriteProp();
                }


            } 

            Console.ReadKey();

        }
    }
}
