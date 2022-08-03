using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace OnLineStore.App
{
    public partial class MssqlRepository : IProductRepository, IOrderRepository
    {
        private string _connectionString;

        public MssqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MssqlRepository()
        {
        }

        private SqlConnection GetOpendSqlConnection()
        {
            var opendSqlConnection = new SqlConnection(_connectionString);
            opendSqlConnection.Open();
            return opendSqlConnection;
        }
    }
}
