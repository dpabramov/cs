using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Controller
{
    public class OrderController : Microsoft.AspNetCore.Mvc.Controller
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

            return View(_shopCart);
        }

    }
}
