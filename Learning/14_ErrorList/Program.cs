using System;

namespace _14_ErrorList
{
    class Program
    {
        static void Main(string[] args)
        {

            ErrorList errorList = new ErrorList("Info")
            {
                "Установка выполнена успешно",
                "Чтение выполнено успешно",
                "Удаление выполнено успешно"
            };

            //проверим работу форматирования даты
            //для начала выводим в старом формате
            Console.WriteLine(ErrorList.DateOutputPreFixFormat);
            errorList.WriteErrorListToConsole();

            //изменяем формат вывода и выводим
            ErrorList.DateOutputPreFixFormat = "yy-MM-dd (h:mm tt)";
            Console.WriteLine(ErrorList.DateOutputPreFixFormat);
            errorList.WriteErrorListToConsole();

            //наследование от IEnumerable<string> было выполнено
            //чтобы работал следующий foreach
            foreach (string error in errorList)
            {
                Console.WriteLine(string.Format(ErrorList.PropertiesOutputPreFixFormat,
                    DateTime.Now.ToString(ErrorList.DateOutputPreFixFormat),
                    errorList.Category,
                    error));
            }
            //очистка объекта, 
            //чтобы так работало необходимо наследоваться от IDisposable
            errorList.Dispose();

            //ноый объект и инициализация
            ErrorList errorList2 = new ErrorList("Warning")
            {
                "Установка выполнена успешно",
                "Чтение выполнено успешно",
                "Удаление выполнено успешно"
            };

            //кроме того, наследование от IDisposable дает
            //возможность работы следующего using
            //Для начала изменим формат вывода
            ErrorList.PropertiesOutputPreFixFormat = "Category: {0}\tDate: {1}\tError: {2}";
            using (errorList2)
            {
                foreach (string str in errorList2)
                {
                    Console.WriteLine(string.Format(ErrorList.PropertiesOutputPreFixFormat,
                        errorList2.Category,
                        DateTime.Now.ToString(ErrorList.DateOutputPreFixFormat),
                        str));
                }
            }
            
            Console.ReadKey();
        }
    }
}
