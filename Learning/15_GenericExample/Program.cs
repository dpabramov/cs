using System;

namespace _15_GenericExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //string a = "10";
            //string b = "15";
            //Console.WriteLine($"a={a}\tb={b}");
            //Swapper<string>.Swap(ref a, ref b);
            //Console.WriteLine($"a={a}\tb={b}");

            Account<int> account = new Account<int>(1, "Дима");
            account.WriteProperties();

            Account<string> account2 = new Account<string>("scdj", "Дима");
            account2.WriteProperties();

            Account<Guid> account3 = new Account<Guid>(Guid.NewGuid(), "Ната");
            account3.WriteProperties();


            Console.ReadKey();
        }
    }
}
