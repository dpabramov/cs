using System;

namespace _053_switch
{
    class Program
    {
        enum Color { Red, Green, Blue }
        static void Main(string[] args)
        {
            //Random random = new Random();
            //int rand = random.Next(0, 4);
            Color color = (Color)(new Random()).Next(0, 4);

            switch (color)
            {
                case Color.Blue:
                    Console.WriteLine("Сгенерирован синий цвет");
                    break;
                case Color.Green:
                    Console.WriteLine("Сгенерирован зеленый цвет");
                    break;
                case Color.Red:
                    Console.WriteLine("Сгенерирован красный цвет");
                    break;
                default:
                    Console.WriteLine("Сгенерирован неизвестный цвет");
                    break;
            }

            Console.ReadKey();
        }
    }
}
