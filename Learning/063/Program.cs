using System;

namespace _033
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] marks = new[]
            {
                        new int[] {2, 3, 3, 2, 3},
                        new int[] { 2, 4, 5, 3},
                        null,
                        new int[] { 5, 5, 5, 5},
                        new int[] { 4 }
            };

            float weekSumma = 0.0f;  //сумма всех оценок за неделю
            int weekCount = 0; //количество оценок за неделю
            int numDay = 0; //номер дня

            foreach (int[] i in marks)
            {
                int dayCount = 0;
                float daySumma = 0.0f;
                numDay++;

                if (i == null)
                {
                    Console.WriteLine($"Средняя оценка за {numDay} день: N/A");
                    
                    continue;
                }

                foreach (int j in i)
                {
                    daySumma += j; // сумма оценок за день
                    dayCount += 1; //количество оценок за день
                }

                Console.WriteLine($"Средняя оценка за {numDay} день: {daySumma / dayCount}");
                weekSumma += daySumma;
                weekCount += dayCount;
  
            }
            Console.WriteLine($"Средняя оценка за неделю: {weekSumma / weekCount}");
            Console.ReadKey();
        }
    }
}
