using AutoShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Data.Interfaceses
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
