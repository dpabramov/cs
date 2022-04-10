using System;
using System.Collections.Generic;
using System.Text;

namespace _143_SingltonExample
{
    public class Person
    {
        //Для реализации синглтона создаем переменную типа класса
        private static Person person;

        public string name;

        public UriHostNameType age;

        //Для реализации синглтона запрещаем создавать объекты через конструктор
        private Person()
        {
        }

        //Для реализации синглтона. Получаем единственный  
        //объект типа класса только через этот метод
        public static Person GetInstance()
        {
            if (person == null)
                person = new Person();

            return person;
        }
    }
}
