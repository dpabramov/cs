using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class AppDbContent : DbContext
    {
        public DbSet<Car> Car { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<ShopCartItem> ShopCartItems { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public AppDbContent(DbContextOptions<AppDbContent> dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
