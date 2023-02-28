using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoShop.Data.Interfaceses;
using AutoShop.Data.Models;
using AutoShop.Data.Rpository;
using AutoShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AutoShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRepository;

        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRepository, ShopCart shopCart)
        {
            _carRepository = carRepository;

            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();

            //Car car = _carRepository.GetObjectCar(items.)

            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel
            {
                ShopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCartC(int id)
        {
            Car item = _carRepository.Cars.FirstOrDefault(a => a.Id == id);

            _shopCart.AddToCart(item);

            return RedirectToAction("Index");
        }

    }
}
