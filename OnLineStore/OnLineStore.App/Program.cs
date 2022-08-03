using System;
using System.Collections.Generic;

namespace OnLineStore.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string conectionString = @"data source=DESKTOP-EU10JJA\SQLEXPRESS; Initial catalog=OnLineStore; Integrated Security=true";

            var mssqlRepository = new MssqlRepository(conectionString);

            //int totalProducts = mssqlRepository.GetProductsCount();

            //int newId = mssqlRepository.AddProduct("Свитер новая модель", (float)15.50);

            //var Products = new List<Product>();
            //Products = mssqlRepository.GetAllProducts();

            //var product = mssqlRepository.GetProductById(3);

            //bool isDeleted = mssqlRepository.DeleteProductById(20);

            //var orderCount = mssqlRepository.GetOrderCount();

            //List<OrderDiscount> discountList = mssqlRepository.GetOrderDiscountList();

            List<Tuple<int, int>> tuplListes = new List<Tuple<int, int>> { new Tuple<int, int>(2, 1),
                                                                           new Tuple<int, int>(1, 4),
                                                                           new Tuple<int, int>(9, 1)};

            mssqlRepository.AddOrder(1, DateTimeOffset.Now, 0.04F, tuplListes);

            Console.ReadKey();
        }
    }
}
