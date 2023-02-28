using System;
using System.Collections.Generic;
using System.Linq;
using EFExample.DBMigration.Data;
using EFExample.DBMigration.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFExample.DBMigration
{
    class Program
    {
        //Для второго способа работы с контекстом
        public static OnLineStoreContext onLineStoreContext = new OnLineStoreContext();

        static void Main(string[] args)
        {
            //InsertCustomers();

            //InsertProduct();

            //var custs = GetCustomers();

            //var customers = MoreContext();

            //var products = GetSomeProducts();

            //foreach(Product product in products)
            //{
            //    Console.WriteLine($"{product.Name} ({product.Id}): {product.Price}");
            //}

            //UpdateCustomers();

            //UpdateProductsDiscounted();

            DeleteCustomers();

            Console.ReadKey();
        }

        private static void DeleteCustomers()
        {
            var customer = onLineStoreContext
                        .Customers
                        .First(c => c.Name == "Иванов2");

            onLineStoreContext.Customers.Remove(customer);
            onLineStoreContext.SaveChanges();
        }

        private static void UpdateProductsDiscounted()
        {
            var product = onLineStoreContext.Products.First();
            product.Price += product.Price * 0.1m;

            using (var newContext = new OnLineStoreContext())
            {
                newContext.Products.Update(product);
                newContext.SaveChanges();
            }
        }

        private static void UpdateCustomers()
        {
            Customer customer = onLineStoreContext
                .Customers
                .Where(c => c.Name == "Иванов")
                .First();

            customer.Name = "Mr. " + customer.Name;

            onLineStoreContext.SaveChanges();
        }

        private static List<Product> GetSomeProducts()
        {
              return  onLineStoreContext
                .Products
                .Where(p => p.Price > 20)
                .ToList();
        }

        private static List<Customer> MoreContext()
        {
            //return onLineStoreContext.Customers.Where(customer => customer
            //                    .Name
            //                    .StartsWith("Петров"))
            //                    .ToList();

            //return onLineStoreContext.Customers.First();

            //return onLineStoreContext
            //    .Customers
            //    .Where(c => c.Name.StartsWith('d'))
            //    .First();

            //return onLineStoreContext
            //    .Customers
            //    .Where(c => c.Name.StartsWith('d'))
            //    .FirstOrDefault();

            //return onLineStoreContext
            //    .Customers
            //    .Where(c => c.Name.StartsWith('А'))
            //    .FirstOrDefault();

            //return onLineStoreContext
            //    .Customers
            //    .OrderBy(c => c.Name)                
            //    .FirstOrDefault();

            //return onLineStoreContext
            //    .Customers
            //    .OrderBy(c => c.Name)
            //    .Last();

            //return onLineStoreContext
            //    .Customers
            //    .OrderBy(c => c.Id)
            //    .Last(c => c.Name.Length > 6);

            var a = onLineStoreContext
                .Customers
                .Where(c => EF.Functions.Like(c.Name, "%ов2%"))
                .ToList();

            return a;
        }

        private static List<Customer> GetCustomers()
        {
            List<Customer> customers;// = new List<Customer>();

            using (var context = new OnLineStoreContext())
            {
                customers = context
                    .Customers
                    .Where(customer => customer.Name.Equals("Иванов"))
                    .ToList();
            }

            return customers;
        }

        private static void InsertProduct()
        {
            var products = new List<Product>()
            {
                new Product(){Name = "Яблоки", Price = 10.5m },
                new Product(){Name = "Груши", Price = 15.1m},
                new Product(){Name = "Виноград", Price = 12.1m},
                new Product(){Name = "Сосиски", Price = 12.4m}
            };

            using(var context = new OnLineStoreContext())
            {
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }

        private static void InsertCustomers()
        {
            var customer = new Customer() { Name = "Абрамов Д" };

            var customers = new List<Customer>()
            {
                new Customer(){Name = "Иванов"},
                new Customer(){Name = "Петров"}
            };

            using (var context = new OnLineStoreContext())
            {
                context.Customers.Add(customer);

                context.Customers.AddRange(customers);

                context.SaveChanges();
            }
        }
    }
}
