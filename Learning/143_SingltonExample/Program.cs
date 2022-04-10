using System;

namespace _143_SingltonExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //проверим работу синглтона
            //Создаем и инициализируем объект
            Person person = Person.GetInstance();
            person.name = "Дима";

            //создаем второй объект того же класса
            Person person2 = Person.GetInstance();

            //убеждаемся что второй объект 
            //это тот же самый что и первый объект
            Console.WriteLine(person2.name);

            Console.ReadKey();
        }
    }
}
