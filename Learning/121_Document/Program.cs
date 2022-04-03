using System;

namespace _121_Document
{
    class Program
    {
        static void Main(string[] args)
        {
            //BaseDocument baseDocument = new BaseDocument("Свидетельство",
            //    "A001",
            //    DateTimeOffset.Parse("2015-02-28"));

            //Pasport pasport = new Pasport("P0001", 
            //    DateTimeOffset.Parse("2020-01-13"), 
            //    "Россия", 
            //    "Нектов Некто Нектович");

            //baseDocument.WriteProperties();
            //pasport.WriteProperties();

            //Object e1 = new BaseDocument("Diplom", "013", DateTimeOffset.Parse("02-04-2022"));
            //Object e2 = new Pasport("013", DateTimeOffset.Parse("02-04-2022"), "Россия", "Иванов Иван");

            //((BaseDocument)e1).WriteProperties();
            //((Pasport)e2).WriteProperties();

            BaseDocument[] bd = new BaseDocument[3];
            bd[0] = new BaseDocument("Diplom", "113", DateTimeOffset.Parse("23-12-2018"));
            bd[1] = new Pasport("223", DateTimeOffset.Parse("23-04-2020"), "Россия", "Петров Петр");
            bd[2] = new Pasport("224", DateTimeOffset.Parse("23-04-2020"), "Россия", "Сидоров Сидр");

            foreach (BaseDocument bdoc in bd)
            {
                //if(bdoc is Pasport)
                //{
                    ((Pasport)bdoc).ChangeIssueDate(DateTimeOffset.Parse("17-12-2018"));
                    bdoc.WriteProperties();
                //}
                //else if (bdoc is BaseDocument)
                //    bdoc.WriteProperties();
            }

            Console.ReadKey();
        }
    }
}
