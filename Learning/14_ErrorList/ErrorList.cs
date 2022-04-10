using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _14_ErrorList
{
    class ErrorList : IEnumerable<string>, IDisposable
    {
        //формат вывода даты
        public static string DateOutputPreFixFormat { get; set; }

        //формат вывода строки свойств
        public static string PropertiesOutputPreFixFormat { get; set; }

        //инициализация по умолчанию строк форматов вывода
        static ErrorList()
        {
            DateOutputPreFixFormat = "MMMMM d, yyyy (h:mm tt)";
            PropertiesOutputPreFixFormat = "Date: {0}\tCategory: {1}\tError: {2}";
        }

        private List<string> Errors { get; set; }

        public string Category { get; private set; }

        public ErrorList(string category)
        {
            Category = category;
            Errors = new List<string>();
        }

        //для наследования IEnumerable<string>
        public IEnumerator<string> GetEnumerator()
        {
            return Errors.GetEnumerator();
        }

        //для наследования от IEnumerable<string>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Errors.GetEnumerator();
        }

        public void Add(string str)
        {
            Errors.Add(str);
        }

        public void WriteErrorListToConsole()
        {
            string date = DateTime.Now.ToString(DateOutputPreFixFormat);

            foreach (string error in Errors)
            {
                Console.WriteLine(string.Format(PropertiesOutputPreFixFormat,
                    DateTime.Now.ToString(DateOutputPreFixFormat),
                    Category,
                    error));
            }
        }

        //для наследования от IDisposable
        public void Dispose()
        {
            Category = String.Empty;
            Errors.Clear();
        }
    }
}
