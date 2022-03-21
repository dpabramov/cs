using System;

namespace _035_Palitra
{
    class Program
    {
        [Flags]
        enum Palitra
        {
            None = 0,
            Black = 1,
            Blue = 1 << 1,
            Cyan = 1 << 2,
            Grey = 1 << 3,
            Green = 1 << 4,
            Magenta = 1 << 5,
            Red = 1 << 6,
            White = 1 << 7
        }

        static void Main(string[] args)
        {
            //полная палитра
            Palitra palitra = (Palitra)255;
            Palitra favouritePalitra = Palitra.None;
            Palitra unFavourutePalitra;

            //выбранные значения запомним в переменную
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Введите любимый цвет:");
                Palitra inputPalitra = (Palitra)Enum.Parse(typeof(Palitra), Console.ReadLine());
                favouritePalitra = favouritePalitra | inputPalitra;
            }

            //невыбранные значения получим путем исключающего ИЛИ
            unFavourutePalitra = palitra ^ favouritePalitra;

            Console.WriteLine("Любимая палитра: " + favouritePalitra);
            Console.WriteLine("Нелюбимая палитра: " + unFavourutePalitra);

            Console.ReadKey();
        }

        static void WriteToBynary(int argument)
        {
            Console.WriteLine(Convert.ToString(argument, 2).PadLeft(8, '0'));
        }
    }
}

