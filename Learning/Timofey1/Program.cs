using System;

namespace Timofey1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Hi Tim");
            //string data = "88888888888888888888888888888888888888888888888888888888888888888888888888888888888888";

            string data = "8";
            for (int i = 0; i < 85; i++)
                data = data + "8";

            Console.WriteLine($"Data = {data}");

            while (data.Contains("1111") || data.Contains("8888"))
            {
                if (data.Contains("1111"))
                    ReplaceFirstSubstrEntrance(ref data, "1111", "88");
                else
                    ReplaceFirstSubstrEntrance(ref data, "8888", "1");
                Console.WriteLine($"Data = {data}");
            }

            Console.ReadKey();
        }

        public static void ReplaceFirstSubstrEntrance(ref string data, string subStr1, string subStr2)
        {
            int position = data.IndexOf(subStr1);
            string data1 = data.Substring(0, position);
            string data2 = data.Substring(position + subStr1.Length);
            data =  data1 + subStr2 + data2;
        }
    }
}
