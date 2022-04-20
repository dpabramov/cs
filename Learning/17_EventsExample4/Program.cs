using System;

namespace _17_EventsExample4
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = "random_data.dat";

            Random random = new Random();

            byte[] array = new byte[1000];

            FileWriterWithProgress fileWriterWithProgress = new FileWriterWithProgress();

            fileWriterWithProgress.WritingPerformed += OnWritingPerformed;

            fileWriterWithProgress.WritingCompleted += OnWritingCompleted;

            for (int i = 0; i< array.Length; i++)
            {
                array[i] = (byte)random.Next(0x11111111);
            }
            
            fileWriterWithProgress.WriteBites(filename, array, 10);

            Console.ReadKey();
        }

        private static void OnWritingPerformed(object sender, WritingPerformedEventArgs e)
        {
            Console.WriteLine($"Записано {e.percentageWritten}%");
        }

        private static void OnWritingCompleted(object sender, EventArgs e)
        {
            Console.WriteLine($"Все записано успешно");
        }
    }
}
