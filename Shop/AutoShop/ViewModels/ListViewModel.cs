using AutoShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.ViewModels
{
    public class ListViewModel
    {
        public IEnumerable<Car> Cars { get; set; }

        public string Category { get; set; }
    }
}
