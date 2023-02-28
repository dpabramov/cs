using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly AppDbContent _appDbContent;

        private readonly ShopCart _shopCart;

        public OrderRepository(AppDbContent appDbContent, ShopCart shopCart)
        {
            _appDbContent = appDbContent;

            _shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;

            _appDbContent.Order.Add(order);

            var items = _shopCart.ListShopItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = el.Id,
                    OrderId = order.Id,
                    Price = el.Car.Price
                };
                _appDbContent.OrderDetails.Add(orderDetail);
            }
            _appDbContent.SaveChanges();
        }
    }
}
