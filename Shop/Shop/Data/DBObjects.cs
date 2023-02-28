using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObjects
    {
        private static Dictionary<string, Category> _category;

        //возвращает некоторый словарь категорий
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_category == null)
                {
                    var list = new List<Category>
                    {
                        new Category { CategoryName = "Электромобили", Description = "Современный вид транспорта"},
                        new Category { CategoryName = "Классические автомобили", Description = "Машины с двигателем внутреннего сгорания"}
                    };

                    _category = new Dictionary<string, Category>();

                    foreach (var el in list)
                    {
                        _category.Add(el.CategoryName, el);
                    }
                }

                return _category;
            }
        }


        //добавляет в БД первоначальные данные если в там  ничего нет
        public static void Initial(AppDbContent content)
        {
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Car.Any())
            {
                content.AddRange(
                   new Car
                   {
                       Name = "Tesla Model S",
                       ShortDescr = "Быстрый автомобиль",
                       LongDescripton = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
                       Img = "/img/Tesla Model S.jpg",
                       Price = 45000,
                       IsFavourite = true,
                       IsAvailable = true,
                       Category = Categories["Электромобили"]
                   },
                    new Car
                    {
                        Name = "Ford Fiesta",
                        ShortDescr = "Тихий и спокойный",
                        LongDescripton = "Удобный автомобиль для городской жизни",
                        Img = "/img/Ford Fiesta.jpg",
                        Price = 11000,
                        IsFavourite = false,
                        IsAvailable = true,
                        Category = Categories["Классические автомобили"]
                    },
                    new Car
                    {
                        Name = "BMV M3",
                        ShortDescr = "Дерзкий и стильный",
                        LongDescripton = "Удобный автомобиль для городской жизни",
                        Img = "/img/bmv_m4.jpg",
                        Price = 65000,
                        IsFavourite = true,
                        IsAvailable = true,
                        Category = Categories["Классические автомобили"]
                    },
                    new Car
                    {
                        Name = "Mersedec C class",
                        ShortDescr = "Уютный и большой",
                        LongDescripton = "Удобный автомобиль для городской жизни",
                        Img = "/img/Mercedes2.jpg",
                        Price = 40000,
                        IsFavourite = false,
                        IsAvailable = false,
                        Category = Categories["Классические автомобили"]
                    },
                    new Car
                    {
                        Name = "Nissan Leaf",
                        ShortDescr = "Бесшумный и экономный",
                        LongDescripton = "Удобный автомобиль для городской жизни",
                        Img = "/img/nissan_leaf.jpg",
                        Price = 14000,
                        IsFavourite = true,
                        IsAvailable = true,
                        Category = Categories["Электромобили"]
                    });
            }
            content.SaveChanges();
        }
    }
}
