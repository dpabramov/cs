using AutoShop.Data.Interfaceses;
using AutoShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Data.Rpository
{
    public class CategoryRepository : ICarsCategory
    {
        private AppDbContent _appDbContent;

        public CategoryRepository(AppDbContent appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public IEnumerable<Category> AllCategories => _appDbContent.Categories;
    }
}
