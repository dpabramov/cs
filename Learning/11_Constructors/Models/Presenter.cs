using System;
using System.Collections.Generic;
using System.Text;

namespace _11_Constructors.Models
{
    class Presenter
    {
        private static  string _format = "Имя:{0}\nДата рождения: {1}\nАдресс:{2}";

        public static void WriteOut(Person person)
        {
            Console.WriteLine(_format,
                                person.Name,
                                person.Birthday,
                                person.Address);
        }
    }
}
