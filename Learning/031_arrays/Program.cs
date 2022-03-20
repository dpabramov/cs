using System;

namespace _031_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] trees = new string[3];
            trees[0] = "Ясень";
            trees[1] = "Липа";
            trees[2] = "Кедр";

            //можно сразу инициализировать массив
            int[] ages =
            {
                32,
                24,
                43
            };

            for (int i = 0; i < trees.Length; i++)
                Console.WriteLine($"{trees[i]} - возраст в годах: {ages[i]}");

            Console.ReadKey();
        }
    }
}
