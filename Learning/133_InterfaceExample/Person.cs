using System;
using System.Collections.Generic;
using System.Text;

namespace _133_InterfaceExample
{
    class Person : IInterface1, IInterface2
    {
        //одна реализация на оба интерфейса
        //public void Action()
        //{
        //    Console.WriteLine("Супер Action");
        //}

        //В случае если нам нужны разные реализации под интерфейсы,
        //то явно реализуют каждый интерфейс
        //проставить public не получится, т.к. непонятно какой метод 
        //вызывать для переменной типа класса снаружи.
        //но возможность вызывать эти методы снаружи есть используя 
        //явное приведение к интерфейсу, см. код main
        void IInterface1.Action()
        {
            Console.WriteLine("IInterface1\tСупер Action");
        }

        void IInterface2.Action()
        {
            Console.WriteLine("IInterface2\tСупер Action");
        }

    }
}
