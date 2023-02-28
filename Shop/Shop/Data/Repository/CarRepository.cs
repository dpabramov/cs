using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDbContent _appDbContent;

        public CarRepository(AppDbContent appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public IEnumerable<Car> Cars => _appDbContent.Car.Include(c => c.Category);
        //так тоже работает
        //public IEnumerable<Car> Cars => _appDbContent.Car;

        public IEnumerable<Car> GetFavCars  => _appDbContent.Car.Where(c => c.IsFavourite).Include(c => c.Category);

        //так тоже работает
        //public IEnumerable<Car> GetFavCars => _appDbContent.Car.Where(c => c.IsFavourite);

        public Car GetObjectCar(int carId)
        {
            return _appDbContent.Car.FirstOrDefault(c => c.Id == carId);
        }
    }
}
