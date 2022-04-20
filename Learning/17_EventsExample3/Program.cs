using System;
using System.IO;
using System.IO.Compression;

namespace _17_EventsExample3
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "Generated.data";
            const string zipFileName = fileName + ".zip";

            RandomDataGenerator randomDataGenerator = new RandomDataGenerator();

            randomDataGenerator.RandomDataGenerated += OnRandomDataGenerated;

            randomDataGenerator.RandomDataGenerationDone += OnRandomDataGenerationDone;

            byte[] Arr = randomDataGenerator.GetRandomData(4096*4, 1024);

            //вывод на экран
            //Console.WriteLine(Convert.ToBase64String(Arr));

            //запись в файл
            File.WriteAllBytes(fileName, Arr);

            //добавим файл в zip-архив
            if (File.Exists(zipFileName))
                File.Delete(zipFileName);

            using(var zip = ZipFile.Open(zipFileName, ZipArchiveMode.Create))
            {
                //здесь первый параметр имя файла откуда брать данные,
                // а второй - как будет называться файл внутри архива
                zip.CreateEntryFromFile(fileName, fileName);
            }
            Console.ReadKey();
        }

        private static void OnRandomDataGenerated(object sender, RandomDataEventArgs e)
        {
            Console.WriteLine($"Сгенерировано {e.bytesDone} байт из {e.totalBytes}"); ;
        }

        private static void OnRandomDataGenerationDone(object sender, RandomDataGenerationDoneEventArgs e)
        {
            Console.WriteLine($"Данные успешно сгенерированы: {Convert.ToBase64String(e.arr)}");
        }

    }
}
