using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controller
{
    public class ShopCartController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IAllCars _carRepository;

        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRepository, ShopCart shopCart)
        {
            _carRepository = carRepository;

            _shopCart = shopCart;
        }

        //возвращает список товаров в корзине
        public ViewResult Index()
        {
            var items = _shopCart.GetShopItms();

            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel() { ShopCart = _shopCart };

            return View(obj);
        }

        //добавляет товар в корзину и переадресует на другую страницу
        public RedirectToActionResult AddToCartById(int id)
        {
            Car item = _carRepository.Cars.FirstOrDefault(i => i.Id == id);

            _shopCart.AddToCart(item);

            return RedirectToAction("Index");
        }

    }
}
