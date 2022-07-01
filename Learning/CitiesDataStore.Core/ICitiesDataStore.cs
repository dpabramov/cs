using System;
using System.Collections.Generic;
using System.Text;

namespace CitiesDataStore.Core
{
    public interface ICitiesDataStore
    {
        City GetCity(int id);

        List<City> GetCity();

        int AddCity(string Name, string Description, int NumberOfPointsOfInterest);

        City UpdateCity(int id, string Name, string Description, int NumberOfPointsOfInterest);

        bool DeleteCity(int id);
    }
}
