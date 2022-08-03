using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineStore.App
{
    public interface IProductRepository
    {
        int GetProductsCount();

        List<Product> GetAllProducts();

        Product GetProductById(int id);

        int AddProduct(string name, float price);

        bool DeleteProductById(int id);
    }
}
