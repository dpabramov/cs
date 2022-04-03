using System;

namespace _101_ClassGetterSetter.Data
{
    public partial class Person
    {
        public enum PersonSex { Man, Woman }

        public DateTime DayOfBirthday { get; set; }

        public PersonSex Sex;

        public string Name { get; set; }

        public byte Age
        {
            get
            {
                TimeSpan timeSpan = new TimeSpan();
                timeSpan = DateTime.Now - DayOfBirthday;
                return (byte)(timeSpan.TotalDays / 365);
            }
        }

        public Person()
        {
        }

        public Person(DateTime dayOfBirthday)
        {
            DayOfBirthday = dayOfBirthday;
        }

        public Person(DateTime dayOfBirthday, string name) : this(dayOfBirthday)
        {
            Name = name;
        }

        public Person(DateTime dayOfBirthday, string name, PersonSex sex) : this(dayOfBirthday, name)
        {
            Sex = sex;
        }

        public DateTime GetBirthdayInSevralYears(int years)
        {
            return DayOfBirthday.AddYears(years);
        }
    }
}
