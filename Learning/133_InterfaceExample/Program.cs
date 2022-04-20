using System;

namespace _133_InterfaceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            IInterface1 interface1 = person;
            IInterface2 interface2 = person;
            interface1.Action();
            interface2.Action();

            Person person2 = new Person();
            //явно преобразуем к нужному интерфейсу
            //и вызываем свою реализацию метода
            ((IInterface1)person2).Action();
            ((IInterface2)person2).Action();

            //а так компиляция пройдет успешно,
            //но будет ошибка при выполнении
            //т.к. привести тип object к IInterface1 не получится
            //из-за того что object не наследует IInterface1 
            //object obj = new object();
            //((IInterface1)obj).Action();

            //можно с предварительной проверкой
            //на наследование объекта от интерфейса
            Person person3 = new Person();

            if (person3 is IInterface1)
            {
                ((IInterface1)person3).Action();
            }

            if (person3 is IInterface2)
            {
                ((IInterface2)person3).Action();
            }

            //а так вызов метода Action не произойдет
            //т.к. Object не наследует IInterface2
            Object obj2 = new object();
            if (obj2 is IInterface2)
            {
                ((IInterface2)obj2).Action();
            }

            //person3 будет приведена к нужному интерфейсу
            Foo(person3);
            Bar(person3);

            Console.ReadKey();
        }

        static void Foo(IInterface1 interface1)
        {
            Console.WriteLine("IInterface1\tСупер Action");
        }

        static void Bar(IInterface1 interface1)
        {
            Console.WriteLine("IInterface2\tСупер Action");
        }
    }
}
