using System.Collections.Generic;
using System.Linq;
using CitiesDataStore.Core;

namespace CitiesDataStore.InMemory
{
    public class InMemoryDataStore : ICitiesDataStore
    {
        private Dictionary<int, City> Cities;

        public InMemoryDataStore()
        {
            Cities = new Dictionary<int, City>
            {
                {
                    1,
                    new City
                    {
                        Id = 1,
                        Name = "Волгоград",
                        Description = "Малая Родина",
                        NumberOfPointsOfInterest = 10
                    }
                },
                {
                    2,
                    new City
                    {
                        Id = 2,
                        Name = "Михайловка",
                        Description = "Вообще все",
                        NumberOfPointsOfInterest = 3
                    }
                }
            };
        }

        //public static InMemoryDataStore GetInstance()
        //{
        //    if (dataStore == null)
        //        dataStore = new InMemoryDataStore();

        //    return dataStore;
        //}

        public int AddCity(string name, string description, int numberOfPointsOfInterest)
        {
            int id = GetNewKey();

            Cities.Add(id, new City(id, name, description, numberOfPointsOfInterest));

            return id;
        }

        public bool DeleteCity(int id)
        {
            if (Cities.ContainsKey(id))
            {
                Cities.Remove(id);
                return true;
            }

            return false;
        }

        public City GetCity(int id)
        {
            if (Cities.ContainsKey(id))
                return Cities[id];

            return null;
        }

        public List<City> GetCity()
        {
            return Cities.Values.ToList();
        }

        public City UpdateCity(int id, string name, string description, int numberOfPointsOfInterest)
        {
            if (Cities.ContainsKey(id))
            {
                Cities[id].Name = name;
                Cities[id].Description = description;
                Cities[id].NumberOfPointsOfInterest = numberOfPointsOfInterest;

                return Cities[id];
            }

            return null;
        }

        private int GetNewKey()
        {
            if (Cities.Keys.Count == 0)
                return 1;

            return Cities.Keys.Max() + 1;
        }
    }
}
