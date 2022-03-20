using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            //значения по умолчанию для разных типов данных 
            Console.WriteLine($"default(int) = {default(int)}");
            Console.WriteLine($"default(float) = {default(float)}");
            Console.WriteLine($"default(double) = {default(double)}");
            Console.WriteLine($"default(decimal) = {default(decimal)}");
            Console.WriteLine($"default(bool) = {default(bool)}");
            Console.WriteLine($"default(DateTime) = {default(DateTime)}");
            Console.WriteLine($"default(char) = {default(char)}");
            Console.WriteLine($"default(string) = {default(string)}");
            Console.WriteLine($"default(object) = {default(object)}");
            Console.WriteLine($"default(dynamic) = {default(dynamic)}");

            //нулабельному инту можно присваивать значение типа null
            int? i;
            i = null;
            Console.WriteLine(i.HasValue);
            //будет ошибка
            //Console.WriteLine(i.Value);


            Console.ReadKey();
        }
    }
}
