using System;

namespace _033_Hex_Bynary
{
    class Program
    {
        static void Main(string[] args)
        {
            //вывести числа от 0 до 256 в 16-ричном и 2-ичном форматах
            for (int i = 0; i < 256; i++)
                Console.WriteLine($"{i}\t" + Convert.ToString(i, 16).PadLeft(2, '0')
                                + "\t" + Convert.ToString(i, 2).PadLeft(8, '0'));

            Console.ReadKey();
        }
    }
}
