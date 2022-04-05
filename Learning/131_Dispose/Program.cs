using System;
using System.IO;
using System.Text;

namespace _131_Dispose
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @"abr.log";
            string text = "В лесу поспела бузина. English text = 100₽";
            string text2 = "\nHe Who lafghts last laghts best";
            FileWriter fileWriter = new FileWriter(filename);
            fileWriter.CreateNewFile();
            fileWriter.WriteToFile(text);
            fileWriter.Dispose();

            fileWriter.OpenExistingFile();
            fileWriter.WriteToFile(text2);

            fileWriter.Dispose();

            //а теперь так
            using(FileWriter fr = new FileWriter(@"abr2.log"))
            {
                fr.CreateNewFile();

                fr.WriteToFile("Запись 2 в лог используя using");
            }


            Console.ReadKey();
        }
    }
}
