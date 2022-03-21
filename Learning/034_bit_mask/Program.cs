using System;

namespace _034_bit_mask
{
    class Program
    {
        [Flags]
        enum WindDirect
        {
            None = 0,
            North = 1,
            East = 1 << 1,
            South = 1 << 2,
            West = 1 << 3
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ToBinary((int)WindDirect.North));
            //Console.WriteLine(ToBinary((int)WindDirect.East));
            //Console.WriteLine(ToBinary((int)WindDirect.South));
            Console.WriteLine(ToBinary((int)WindDirect.West));

            WindDirect wd = WindDirect.North ^ WindDirect.West;
            Console.WriteLine(ToBinary((int)wd));

            Console.ReadKey();
        }

        static string ToBinary(int argument)
        {
            return Convert.ToString(argument, 2).PadLeft(8, '0');
        }
    }
}
