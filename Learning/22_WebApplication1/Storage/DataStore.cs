using _22_WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _22_WebApplication1.Storage
{
    public class DataStore
    {
        private static DataStore dataStore;

        public List<City> Cities;

        private DataStore()
        {
            Cities = new List<City>
            {
                new City
                {
                    Id = 1,
                    Name = "Волгоград",
                    Description = "Малая Родина",
                    NumberOfPointsOfInterest = 10
                },
                new City
                {
                    Id = 2,
                    Name = "Михайловка",
                    Description = "Вообще все",
                    NumberOfPointsOfInterest = 3
                }
            };
        }

        public static DataStore GetInstance()
        {
            if (dataStore == null)
                dataStore = new DataStore();

            return dataStore;
        }
    }
}
