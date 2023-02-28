using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReadWriteJsonFile
{
    public class JsonFileReader
    {
        public static void WriteDoctorsToJsonFile(string fileName, List<Doctor> doctors)
        {
            var serializer = new JsonSerializer(); 

            using(StreamWriter fs = new StreamWriter(fileName))
            {
                using(JsonTextWriter jSonTextWriter = new JsonTextWriter(fs))
                {
                    serializer.Serialize(fs, doctors);
                }
            }
        }

        public static List<Doctor> ReadDoctorsFromJsonFile(string fileName)
        {
            var serializer = new JsonSerializer();

            List<Doctor> doctors = new List<Doctor>();

            using (StreamReader file = File.OpenText(fileName))
            {
                doctors = (List<Doctor>)serializer.Deserialize(file, typeof(List<Doctor>));
            }

            return doctors;
        }

    }
}
