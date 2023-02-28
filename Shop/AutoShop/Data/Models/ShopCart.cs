using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Data.Models
{
    public class ShopCart
    {
        public string ShopCartId { get; set; }

        public List<ShopCartItem> ListShopItems { get; set; }

        private readonly AppDbContent _appDbContent;

        public ShopCart(AppDbContent appDbContent)
        {
            _appDbContent = appDbContent;
        }

        //возвращает id текущей корзины или id новой корзины
        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = service.GetService<AppDbContent>();

            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        //добавляет товар в корзину
        public void AddToCart(Car car)
        {
            //ShopCartItem shopCartItem = new ShopCartItem();



            _appDbContent
                .ShopCartItems
                .Add(new ShopCartItem
                {
                    CarId = car.Id,
                    Car = car,
                    ShopCartId = ShopCartId,
                    Price = car.Price
                });

            _appDbContent.SaveChanges();
        }

        //возвращает все товары в корзине
        public List<ShopCartItem> GetShopItems()
        {
            List<ShopCartItem> shopCartItems = _appDbContent
                .ShopCartItems
                .Where(item => item.ShopCartId == ShopCartId)
                .ToList();

            foreach(ShopCartItem sh in shopCartItems)
            {
                sh.Car = _appDbContent.Cars.First(c => c.Id == sh.CarId);
            }

            return shopCartItems;
        }
    }
}
