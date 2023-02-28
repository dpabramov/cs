using EFExample.DBMigration.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace EFExample.DBMigration.Data
{
    public class OnLineStoreContext : DbContext
    {
        private string _connectionString;

        public static readonly LoggerFactory MyConsoleLoggingFactory =
            new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider(
                    (category,level)=>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information,
                    true)
            });

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public OnLineStoreContext()
        {
            _connectionString = @"Data Source=DESKTOP-EU10JJA\SQLEXPRESS;Initial Catalog=OnLineStore_EF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

            optionsBuilder.UseLoggerFactory(MyConsoleLoggingFactory)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ограничение на уникальность имени по объекту Customer
            //так делать не надо
            //modelBuilder.Entity<Customer>()
            //    .HasAlternateKey(c => c.Name)
            //    .HasName("UQ_Customers_Name");
            //надо так
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Name)
                .IsUnique();

            //избавляемся от формального поля id
            //для этого делаем новый первичный ключ
            //modelBuilder.Entity<OrderItem>()
            //    .HasKey("OrderId", "Product")
            //    .HasName("PK_OrderItem");
        }
    }
}
