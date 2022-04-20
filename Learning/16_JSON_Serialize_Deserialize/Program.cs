using System;
using Newtonsoft.Json;

namespace _16_JSON_Serialize_Deserialize
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Age = 44,
                Name = "Дима"
            };

            Person person2;

            string jsonStr = JsonConvert.SerializeObject(person);

            Console.WriteLine(jsonStr);

            person2 = JsonConvert.DeserializeObject<Person>(jsonStr);

            Console.WriteLine($"{person2.Age}\t{person2.Name}");

            Console.ReadKey();
        }
    }

    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
