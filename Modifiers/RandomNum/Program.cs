using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomNum
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            List<PersonModel> persons = new List<PersonModel>
            {
                new PersonModel{FirstName = "Tom"},
                new PersonModel{FirstName = "Jerry"},
                new PersonModel{FirstName = "Cat"},
                new PersonModel{FirstName = "Dog"},
                new PersonModel{FirstName = "Mouse"},
                new PersonModel{FirstName = "Bird"},
                new PersonModel{FirstName = "Line"},
                new PersonModel{FirstName = "Hourse"}
            };

            //отсортировано по имени
            List<PersonModel> sortedPersons = persons.OrderBy(x => x.FirstName).ToList();

            foreach(var p in sortedPersons)
            {
                Console.WriteLine(p.FirstName);
            }
            Console.WriteLine("");

            //случайный порядок в листе
            List<PersonModel> randomPersons = sortedPersons
                        .OrderBy(x => random.Next())
                        .ToList();

            foreach (var p in randomPersons)
            {
                Console.WriteLine(p.FirstName);
            }

            Console.ReadKey();
        }
    }

    class PersonModel
    {
        public string FirstName { get; set; }
    }
}
