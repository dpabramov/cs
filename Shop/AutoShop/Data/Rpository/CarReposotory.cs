using AutoShop.Data.Interfaceses;
using AutoShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Data.Rpository
{
    public class CarReposotory : IAllCars
    {
        private AppDbContent _appDbContent;

        public CarReposotory(AppDbContent appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public IEnumerable<Car> Cars => _appDbContent.Cars;

        public IEnumerable<Car> GetFavCars => _appDbContent.Cars.Where(c => c.IsAvailable);

        public Car GetObjectCar(int carId)
        {
            return _appDbContent.Cars.First(c => c.Id == carId);
        }
    }
}
