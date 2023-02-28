using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDbContent _appDbContent;

        public string ShopCartId { get; set; }

        public List<ShopCartItem> ListShopItems { get; set; }

        public ShopCart(AppDbContent appDbContent)
        {
            _appDbContent = appDbContent;
        }

        //возвращает текущую корзину если она есть
        //или новую корзину если ее еще нет (первый товар в корзине)
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
            //Car newCar = new Car
            //{
            //    Id = car.Id,
            //    Category = car.Category,
            //    CategoryId = car.CategoryId,
            //    Img = car.Img,
            //    IsAvailable = car.IsAvailable,
            //    IsFavourite = car.IsFavourite,
            //    LongDescripton = car.LongDescripton,
            //    Name = car.Name,
            //    Price = car.Price,
            //    ShortDescr = car.ShortDescr
            //};

            _appDbContent.ShopCartItems.Add(new ShopCartItem
            {
                CarId = car.Id,
                Car = car,
                ShopCartId = ShopCartId
            });

            _appDbContent.SaveChanges();
        }

        //возвращает все товары корзины
        public List<ShopCartItem> GetShopItms()
        {
            return _appDbContent.ShopCartItems.Where(i => i.ShopCartId == ShopCartId).ToList(); 
        }

    }
}
