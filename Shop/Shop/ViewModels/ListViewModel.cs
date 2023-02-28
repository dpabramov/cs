using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{ 
    public class ListViewModel
    {
        public IEnumerable<Car> AllCars { get; set; }

        public string CarCategory { get; set; }
    }
}
