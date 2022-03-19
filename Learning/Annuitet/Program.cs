using System;


namespace Annuitet
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            Console.WriteLine("Расчет ануитетного платежа по кредиту.");
            float kredit;  //сумма кредита
            float yps;    //годовая процентная ставка по кредиту
            float mps;   //месячная процентная ставка
            int pp; // количество месяцев кредита
            double annuitet; //ежемесячный платеж по кредиту
            double pereplata; //переплата по кредиту

            do
            {
                Console.WriteLine("Введите сумму кредита:");
                kredit = float.Parse(Console.ReadLine());

                Console.WriteLine("Введите годовую процентную ставку:");
                yps = float.Parse(Console.ReadLine());

                Console.WriteLine("Введите срок кредита в месяцах:");
                pp = int.Parse(Console.ReadLine());

                mps = yps / 1200;

                annuitet = kredit * mps / (1 - Math.Pow((1 + mps), -pp));
                pereplata = annuitet * pp - kredit;

                Console.WriteLine($"Ежемесячный платеж составит: {annuitet:0.00}");
                Console.WriteLine($"Переплата  составит: {pereplata:0.00}");
                Console.WriteLine($"Для повтора нажмите любую клавишу.Для выхода нажмите ESC...");
                cki = Console.ReadKey();
            }
            while (cki.Key != ConsoleKey.Escape);
            
        }
    }
}
