using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        //список товаров данной категории
        public List<Car> Cars { get; set; }
    }
}
