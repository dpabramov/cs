using AutoShop.Data.Interfaceses;
using AutoShop.Data.Models;
using AutoShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Controllers
{
    [Route("car")]
    public class CarController : Controller
    {
        private readonly IAllCars _allCars;

        private readonly ICarsCategory _carsCategory;

        public CarController(IAllCars allCars, ICarsCategory carsCategory)
        {
            _allCars = allCars;

            _carsCategory = carsCategory;
        }

        [Route("list/{category?}")]
        public ViewResult List(string category)
        {
            ViewBag.Title = "Магазин автомобилей";

            List<Car> cars = null;

            string categ = string.Empty;

            if (string.IsNullOrWhiteSpace(category))
            {
                cars = _allCars.Cars.ToList();

                categ = "Автомобили";
            }
            else if (string.Equals(category, "electro", StringComparison.InvariantCultureIgnoreCase))
            {
                cars = _allCars
                                .Cars
                                .Where(c => c.CategoryId == 1)
                                .ToList();
                categ = "Электромобили";
            }
            else if (string.Equals(category, "fuel", StringComparison.InvariantCultureIgnoreCase))
            {
                cars = _allCars
                                .Cars
                                .Where(c => c.CategoryId == 2)
                                .ToList();
                categ = "Классические автомобили";
            }
            else
                throw new Exception("проблемы с логикой у программера...");

            return View(new ListViewModel { Cars = cars, Category = categ});
        }
    }
}
