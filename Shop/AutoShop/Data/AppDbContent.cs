using AutoShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Data
{
    public class AppDbContent : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ShopCartItem> ShopCartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public AppDbContent(DbContextOptions<AppDbContent> dbContextOptions) : base(dbContextOptions)
        {
        }

    }
}
