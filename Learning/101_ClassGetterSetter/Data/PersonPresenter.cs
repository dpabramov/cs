using System;
using System.Collections.Generic;
using System.Text;

namespace _101_ClassGetterSetter.Data
{
    public class PersonPresenter
    {
        private string _format = $"Person name {0}, birthday {1}, age {2}, sex {3}";
        private string _shortFormat = $"Person name {0}, age {1}";

        public void WriteAllToConsole(Person person)
        {
            Console.WriteLine(_format,
                person.Name,
                person.DayOfBirthday,
                person.Age,
                person.Sex);
        }

        public void WriteShortToConsole(Person person)
        {
            Console.WriteLine(_shortFormat,
                person.Name,
                person.Age);
        }

        public void WriteBirthdayInservalYear(Person person, int year = 3)
        {
            Console.WriteLine(person.GetBirthdayInSevralYears(year));
        }
    }
}
