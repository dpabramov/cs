using CitiesDataStore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _22_WebApplication1.Models
{
    public class CityGetModel
    {
        public int Id;

        public string Name;

        public string Description;

        public int NumberOfPointsOfInterest;

        public CityGetModel()
        {
        }

        public CityGetModel(City city)
        {
            Id = city.Id;
            Name = city.Name;
            Description = city.Description;
            NumberOfPointsOfInterest = city.NumberOfPointsOfInterest;
        }
    }
}
