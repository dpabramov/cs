using System;

namespace _044_Conteiners
{
    class Program
    {
        [Flags]
        enum Conteyner
        {
            None = 0,
            TwentyLitres = 1,
            FiveLiters = 1 << 1,
            OneLiters = 1 << 2
        };

        static void Main(string[] args)
        {
            //палитра с необходимыми типами емкостей
            Conteyner favoutitePalitra = Conteyner.None;
            int value;

            Console.Write("Введите объем товара для расфасовки: ");
            if (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Не удалось преобразовать в число."
                            + "\nПрограмма завершает свою работу...");
                Environment.Exit(1);
            }

            //определяем потребность в самых больших емкостях
            int quantityTwenty = value / 20;
            int ostatokTwenty = value % 20;
            
            //если такие емкости нужны взводим флаг
            if (quantityTwenty != 0)
                favoutitePalitra = Conteyner.TwentyLitres;

            //определяем потребность в средних емкостях
            int quantityFive = ostatokTwenty / 5;
            int ostatokFive = ostatokTwenty % 5;

            //если такие емкости нужны взводим флаг
            if (quantityFive != 0)
                favoutitePalitra = favoutitePalitra | Conteyner.FiveLiters;

            //определяем потребность в малых емкостях
            int quantityOne = ostatokFive / 1;
            int ostatokOne = ostatokFive % 1;

            //если такие емкости нужны взводим флаг
            if (quantityOne != 0)
                favoutitePalitra = favoutitePalitra | Conteyner.OneLiters;

            //вывод 
            Console.WriteLine($"Для расфасовки {value} литров необходимо: ");

            if(favoutitePalitra.HasFlag(Conteyner.TwentyLitres))
                Console.WriteLine($"{quantityTwenty} емкостей по 20 литров");

            if (favoutitePalitra.HasFlag(Conteyner.FiveLiters))
                Console.WriteLine($"{quantityFive} емкостей по 5 литров");

            if (favoutitePalitra.HasFlag(Conteyner.OneLiters))
                Console.WriteLine($"{quantityOne} емкостей по 1 литру");


            Console.ReadKey();
        }
    }
}
