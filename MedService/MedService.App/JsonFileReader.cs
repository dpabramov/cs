using MedService.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MedService.App
{
    public class JsonFileReader
    {
        public static void WriteDoctorsToJsonFile(string fileName, List<ModelDoctorImport> doctors)
        {
            var serializer = new JsonSerializer();

            using (StreamWriter fs = new StreamWriter(fileName))
            {
                using (JsonTextWriter jSonTextWriter = new JsonTextWriter(fs))
                {
                    serializer.Serialize(fs, doctors);
                }
            }
        }

        public static void WriteSickersToJsonFile(string fileName, List<ModelSickerImport> sickers)
        {
            var serializer = new JsonSerializer();

            using (StreamWriter fs = new StreamWriter(fileName))
            {
                using (JsonTextWriter jSonTextWriter = new JsonTextWriter(fs))
                {
                    serializer.Serialize(fs, sickers);
                }
            }
        }

        public static List<ModelDoctorImport> ReadDoctorsFromJsonFile(string fileName)
        {
            var serializer = new JsonSerializer();

            List<ModelDoctorImport> doctors;

            using (StreamReader file = File.OpenText(fileName))
            {
                doctors = (List<ModelDoctorImport>)serializer.Deserialize(file, 
                                                        typeof(List<ModelDoctorImport>));
            }

            return doctors;
        }

        public static List<ModelSickerImport> ReadSickersFromJsonFile(string fileName)
        {
            var serializer = new JsonSerializer();

            List<ModelSickerImport> sickers;

            using (StreamReader file = File.OpenText(fileName))
            {
                sickers = (List<ModelSickerImport>)serializer.Deserialize(file,
                                                       typeof(List<ModelSickerImport>));
            }

            return sickers;
        }
    }
}
