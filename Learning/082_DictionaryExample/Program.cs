using System;
using System.Collections.Generic;

namespace _082_DictionaryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> contries = new Dictionary<int, string>
            {
                { 1, "Russia" },
                { 2, "China" },
                { 3, "India" },
                { 4, "Serbia" }
            };

            foreach(KeyValuePair<int, string> el in contries)
            {
                Console.WriteLine($"{el.Key} - {el.Value}");
            }

            string country = contries[2];
            Console.WriteLine($"Вторая страна - {country}");

            //редактируем запись
            contries[2] = "Spain";
            Console.WriteLine($"Вторая страна после редактирования- {contries[2]}");

            //удалим одну запись
            contries.Remove(3);
            //смотрим что осталось
            foreach (KeyValuePair<int, string> el in contries)
            {
                Console.WriteLine($"{el.Key} - {el.Value}");
            }

            Console.ReadKey();
                        
        }
    }
}
