using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace OnLineStore.App
{
    public partial class MssqlRepository
    {
        public int GetOrderCount()
        {
            using (var connection = GetOpendSqlConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = @"select count(*) from dbo.Orders";

                var result = (int)sqlCommand.ExecuteScalar();
                return result;
            }
        }

        public List<OrderDiscount> GetOrderDiscountList()
        {
            using (var connection = GetOpendSqlConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = @"select Id, Discount from dbo.Orders
                                                where Discount is not null";

                var result = new List<OrderDiscount>();

                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return result;

                    int idIndex = reader.GetOrdinal("Id");
                    int discountIndex = reader.GetOrdinal("Discount");


                    while (reader.Read())
                    {
                        var id = reader.GetInt32(idIndex);

                        var discount = float.Parse(reader.
                                                    GetDouble(discountIndex).
                                                    ToString());

                        var orderDiscount = new OrderDiscount
                        {
                            OrderId = id,

                            Discount = discount
                        };

                        result.Add(orderDiscount);
                    }
                }
                return result;
            }
        }

        public int AddOrder(int customerId,
                        DateTimeOffset orderDate,
                        float? discount,
                        List<Tuple<int, int>> productIdCountList)
        {
            int orderId = -1;

            using (var sqlConnection = GetOpendSqlConnection())
            using (var transaction = sqlConnection.BeginTransaction())
            {
                try
                {
                    var sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.Transaction = transaction;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = "dbo.AddOrder";

                    sqlCommand.Parameters.AddWithValue("@customerId", customerId);
                    sqlCommand.Parameters.AddWithValue("@orderDate", orderDate);

                    if (discount.HasValue)
                        sqlCommand.Parameters.AddWithValue("@discount", discount);

                    var outputParameter = new SqlParameter("@id", System.Data.SqlDbType.Int, 1);
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    sqlCommand.Parameters.Add(outputParameter);

                    sqlCommand.ExecuteNonQuery();

                    orderId = (int)outputParameter.Value;

                    sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.Transaction = transaction;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = "dbo.AddOrderItem";

                    foreach(var productIdCount in productIdCountList)
                    {
                        sqlCommand.Parameters.Clear();
                        sqlCommand.Parameters.AddWithValue("@orderId", orderId);
                        sqlCommand.Parameters.AddWithValue("@productId", productIdCount.Item1);
                        sqlCommand.Parameters.AddWithValue("@numberOfItems", productIdCount.Item2);

                        sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (SqlException)
                {
                    transaction.Rollback();
                    throw;
                }
                transaction.Commit();
            }
            return orderId;
        }
    }
}
