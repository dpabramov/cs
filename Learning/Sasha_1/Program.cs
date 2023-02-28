using System;

namespace Sasha_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shasha Hi");

            string data = "8";

            for (int i = 0; i < 85; i++)
            {
                data = data + "8";
            }

            while (data.Contains("1111") || data.Contains("8888"))
            {
                if (data.Contains("1111"))
                    data = ReplaceFirst(data, "1111", "88");
                if (data.Contains("8888"))
                    data = ReplaceFirst(data, "8888", "1");
                Console.WriteLine($"data = {data}");
            }


            Console.ReadKey();
        }

        private static string ReplaceFirst(string data, string v1, string v2)
        {
            int index = data.IndexOf(v1);
            string data1 = data.Substring(0, index);
            string data3 = data.Substring(index + 4);

            return data1 + v2 + data3;
        }
    }
}
