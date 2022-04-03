using System;
using _101_ClassGetterSetter.Data;

namespace _101_ClassGetterSetter
{
    class Program
    {
        static void Main(string[] args)
        {
            //определение и инициализация объекта созданного класса
            Person person = new Person(DateTime.Parse("1975-08-02"), "Dim", Person.PersonSex.Man);

            Person person2 = new Person();
            person2.Name = "Nata";
            person2.DayOfBirthday = DateTime.Parse("1975-08-02");
            person2.Sex = Person.PersonSex.Woman;

            Person person3 = new Person(DateTime.Parse("1975-08-02"), "Dim");

            //используем класс presenter для вывода
            PersonPresenter personPresenter = new PersonPresenter();
            personPresenter.WriteShortToConsole(person);
            personPresenter.WriteAllToConsole(person);
            personPresenter.WriteBirthdayInservalYear(person, 3);
            personPresenter.WriteBirthdayInservalYear(person2, 10);
            personPresenter.WriteBirthdayInservalYear(person3);



            Console.ReadKey();
        }
    }
}
