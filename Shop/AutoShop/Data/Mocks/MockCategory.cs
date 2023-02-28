using AutoShop.Data.Interfaceses;
using AutoShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category
                    {
                        CategoryName = "Электромобили",
                        Description = "Современный вид транспорта"
                    },
                     new Category
                    {
                        CategoryName = "Классические автомобили",
                        Description = "Автомобили с двигателем внутреннего сгорания"
                    }
                };
            }
        }
    }
}
