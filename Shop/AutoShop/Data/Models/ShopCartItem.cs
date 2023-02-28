using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Data.Models
{
    public class ShopCartItem
    {
        //идентификатор записи
        public string Id { get; set; }
        //идентификатор автомобиля в корзине
        public int CarId { get; set; }
        //идентификатор корзины
        public string ShopCartId { get; set; }
        //приобретаемый автомобиль
        public Car Car { get; set; }
        //цена автомобиля
        public int Price { get; set; }

    }
}
