using System;

namespace _032_table_pifagor
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] tp = new int[5, 15];
            Console.WriteLine("                                Таблица Пифагора");
            
            //инициализация первого стролбца
            for (int i = 0; i < tp.GetLength(0); i++)
                tp[i, 0] = i;

            //инициализация первои строки
            for (int i = 0; i < tp.GetLength(1); i++)
                tp[0, i] = i;

            //расчет остальных полей таблицы
            for (int i = 1; i < tp.GetLength(0); i++)
            {
                for (int j = 1; j < tp.GetLength(1); j++)
                    tp[i, j] = tp[i, 0] * tp[0, j];
            }

            //вывод
            for (int i = 0; i < tp.GetLength(0); i++)
            {
                for (int j = 0; j < tp.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                        Console.Write($"\t");
                    else
                        Console.Write($"{tp[i, j]}\t");
                }
                Console.WriteLine();
            }

            //Console.WriteLine(tp.Length);
            //Console.WriteLine(tp.Rank);
            //Console.WriteLine(tp.GetLength(0));
            //Console.WriteLine(tp.GetLength(1));

            Console.ReadKey();
        }
    }
}
