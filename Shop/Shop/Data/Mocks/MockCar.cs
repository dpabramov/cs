using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockCar : IAllCars
    {
        private readonly ICarsCategory _categoriesCar = new MockCategory();

        public IEnumerable<Car> Cars
        { get
            {
                return new List<Car>
                {
                    new Car
                    {
                        Name = "Tesla Model S",
                        ShortDescr = "Быстрый автомобиль",
                        LongDescripton = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
                        Img = "/img/Tesla Model S.jpg",
                        Price = 45000,
                        IsFavourite = true,
                        IsAvailable = true,
                        Category = _categoriesCar.AllCategories.First()
                    },
                    new Car
                    {
                        Name = "Ford Fiesta",
                        ShortDescr = "Тихий и спокойный",
                        LongDescripton = "Удобный автомобиль для городской жизни",
                        Img = "/img/Ford Fiesta.jpg",
                        Price = 11000,
                        IsFavourite = false,
                        IsAvailable = true,
                        Category = _categoriesCar.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "BMV M3",
                        ShortDescr = "Дерзкий и стильный",
                        LongDescripton = "Удобный автомобиль для городской жизни",
                        Img = "/img/bmv_m4.jpg",
                        Price = 65000,
                        IsFavourite = true,
                        IsAvailable = true,
                        Category = _categoriesCar.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "Mersedec C class",
                        ShortDescr = "Уютный и большой",
                        LongDescripton = "Удобный автомобиль для городской жизни",
                        Img = "/img/Mercedes2.jpg",
                        Price = 40000,
                        IsFavourite = false,
                        IsAvailable = false,
                        Category = _categoriesCar.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "Nissan Leaf",
                        ShortDescr = "Бесшумный и экономный",
                        LongDescripton = "Удобный автомобиль для городской жизни",
                        Img = "/img/nissan_leaf.jpg",
                        Price = 14000,
                        IsFavourite = true,
                        IsAvailable = true,
                        Category = _categoriesCar.AllCategories.First()
                    }
                };
            }
        }

        public IEnumerable<Car> GetFavCars { get ; set ; }

        public Car GetObjectCar(int CarId)
        {
            throw new NotImplementedException();
        }
    }
}
