using AutoShop.Data.Interfaceses;
using AutoShop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;

        private readonly ShopCart _shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            _allOrders = allOrders;

            _shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.ListShopItems = _shopCart.GetShopItems();

            if (_shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары в корзине!");
            }

            if (ModelState.IsValid)
            {
                _allOrders.CreateOrder(order);

                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public ViewResult Complete()
        {
            ViewBag.Text("Заказ успешно обработан");

            return View();
        }


    }
}
