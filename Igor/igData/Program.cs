using Ig.Core;
using System;



namespace igData
{
    class Program
    {
        static void Main(string[] args)
        {
            Churns churns = new Churns();

            churns.LoadFromCsv(
                @"C:\Users\admin\source\repos\Igor\Ig.Core\Import\churn.csv");

            ////доли ушедших клиентов
            //foreach(Churn churn in churns)
            //{

            //}

            Console.ReadKey();
        }
    }
}
