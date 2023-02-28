using AutoShop.Data.Interfaceses;
using AutoShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AutoShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRepository;

        public HomeController(IAllCars carRepository)
        {
            _carRepository = carRepository;
        }

        public ViewResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                Favouritecars = _carRepository.GetFavCars
            };

            return View(homeViewModel);
        }
    }
}
