using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;

namespace Shop.Controller
{
    [Route("car")]
    public class CarController : Microsoft.AspNetCore.Mvc.Controller
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
            IEnumerable<Car> allCars = null;

            string carCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                allCars = _allCars.Cars;

                carCategory = "Все автомобили";
            }
            else if (string.Equals(category, "electro", StringComparison.OrdinalIgnoreCase))
            {
                allCars = _allCars.Cars.Where(c => c.Category.CategoryName == "Электромобили");

                carCategory = "Электромобили";
            }
            else if (string.Equals(category, "fuel", StringComparison.OrdinalIgnoreCase))
            {
                allCars = _allCars.Cars.Where(c => c.Category.CategoryName == "Классические автомобили");

                carCategory = "Классические автомобили";
            }
            
            return View(new ListViewModel { AllCars = allCars , CarCategory = carCategory });
        }
    }
}
