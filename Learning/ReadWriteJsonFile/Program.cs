using System;
using System.Collections.Generic;

namespace ReadWriteJsonFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"c:/1/doctors.json";

            Doctor doctor = new Doctor()
            {
                Id = Guid.NewGuid(),

                Name = "Паша"
            };

            var doctors = new List<Doctor>()
            {
                new Doctor{Id = Guid.NewGuid(), Name = "Абрамов"},
                new Doctor{Id = Guid.NewGuid(), Name = "Петров"},
                new Doctor{Id = Guid.NewGuid(), Name = "Иванов"}
            };

            JsonFileReader.WriteDoctorsToJsonFile(fileName, doctors);


            var doctors2 =  JsonFileReader.ReadDoctorsFromJsonFile(fileName);

            Console.ReadKey();
        }
    }
}
