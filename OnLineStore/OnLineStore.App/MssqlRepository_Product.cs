using System.Collections.Generic;
using System.Data.SqlClient;

namespace OnLineStore.App
{
    public partial class MssqlRepository
    {
        public int GetProductsCount()
        {
            using (var connection = GetOpendSqlConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //sqlCommand.CommandText = @"select count(*) from dbo.Products";
                sqlCommand.CommandText = @"select dbo.GetProductCount()";

                var result = (int)sqlCommand.ExecuteScalar();
                return result;
            }
        }

        public List<Product> GetAllProducts()
        {
            using (var connection = GetOpendSqlConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = @"select Id, Name, Price from Products";

                var result = new List<Product>();

                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return result;

                    int idIndex = reader.GetOrdinal("Id");
                    int nameIndex = reader.GetOrdinal("Name");
                    int priceIndex = reader.GetOrdinal("Price");

                    while (reader.Read())
                    {
                        var id = reader.GetInt32(idIndex);
                        var name = reader.GetString(nameIndex);
                        decimal price = reader.GetDecimal(priceIndex);

                        var product = new Product
                        {
                            Id = id,
                            Name = name,
                            Price = price
                        };

                        result.Add(product);
                    }
                }
                return result;
            }
        }

        public Product GetProductById(int id)
        {
            using (var connection = GetOpendSqlConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = $"select Id, Name, Price from Products where Id = {id}";

                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return null;

                    int nameIndex = reader.GetOrdinal("Name");
                    int priceIndex = reader.GetOrdinal("Price");

                    reader.Read();
                    var name = reader.GetString(nameIndex);
                    decimal price = reader.GetDecimal(priceIndex);

                    return new Product
                    {
                        Id = id,
                        Name = name,
                        Price = price
                    };
                }
            }
        }

        public int AddProduct(string name, float price)
        {
            using (var connection = GetOpendSqlConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "dbo.AddProduct";

                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@price", price);

                var outputIdParameter = new SqlParameter("@id", System.Data.SqlDbType.Int, 1);
                outputIdParameter.Direction = System.Data.ParameterDirection.Output;
                sqlCommand.Parameters.Add(outputIdParameter);

                sqlCommand.ExecuteNonQuery();
                return (int)outputIdParameter.Value;
            }
        }

        public bool DeleteProductById(int id)
        {
            using (var connection = GetOpendSqlConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = $"select * from Products where Id = {id}";
                
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return false;
                }

                sqlCommand.CommandText = $"delete from Products where Id = {id}";
                sqlCommand.ExecuteScalar();
                return true;

            }
        }
    }
}
