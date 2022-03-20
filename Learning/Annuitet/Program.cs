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
                Console.Write("Введите сумму кредита: ");
                if (!float.TryParse(Console.ReadLine(), out kredit))
                    FinishProgram();

                Console.Write("Введите годовую процентную ставку: ");
                if (!float.TryParse(Console.ReadLine(), out yps))
                    FinishProgram();

                Console.Write("Введите срок кредита в месяцах: ");
                if(! int.TryParse(Console.ReadLine(), out pp))
                    FinishProgram();

                mps = yps / 1200;

                annuitet = kredit * mps / (1 - Math.Pow((1 + mps), -pp));
                pereplata = annuitet * pp - kredit;

                Console.WriteLine($"\nЕжемесячный платеж составит: {annuitet:0.00}");
                Console.WriteLine($"Переплата  составит: {pereplata:0.00}");
                Console.WriteLine($"Для повтора нажмите любую клавишу, а для выхода - ESC...");
                cki = Console.ReadKey();
            }
            while (cki.Key != ConsoleKey.Escape);

        }

        static void FinishProgram()
        {
            Console.WriteLine($"Невозможно преобразовать в число." +
                                        $"\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
            Environment.Exit(12);
        }
    }
}
