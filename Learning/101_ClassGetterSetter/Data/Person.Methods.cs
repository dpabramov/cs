using System;
using System.Collections.Generic;
using System.Text;

namespace _101_ClassGetterSetter.Data
{
    public partial class Person
    {
        //пример перегрузки методов
        public void Update(DateTime NewDayOfBirthday)
        {
            DayOfBirthday = NewDayOfBirthday;
        }

        public void Update(PersonSex NewPersonSex)
        {
            Sex = NewPersonSex;
        }

        public void Update(string name, DateTime newDayOfBirthday, PersonSex newPersonSex)
        {
            Name = name;
            DayOfBirthday = newDayOfBirthday;
            Sex = newPersonSex;
        }
    }
}
