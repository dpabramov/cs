using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Reminder.Storage.SqlServer.ADO
{
    public class SqlServerReminderStorage : IReminderStorage
    {
        private string _connectionString;

        public SqlServerReminderStorage(string connectionString = 
            @"Data source =DESKTOP-EU10JJA\SQLEXPRESS; Initial catalog =Reminders; Integrated security = true")
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetOpenedSqlConnection()
        {
            var sqlConnection = new SqlConnection(_connectionString);

            sqlConnection.Open();

            return sqlConnection;
        }

        public Guid Add(DateTimeOffset date, string message, string contactId, ReminderItemStatus status)
        {
            using (SqlConnection SqlConection = GetOpenedSqlConnection())
            {
                //Guid guid = Guid.NewGuid();
                
                SqlCommand command = SqlConection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "dbo.AddReminder";

                //command.Parameters.AddWithValue("@id", guid);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@message", message);
                command.Parameters.AddWithValue("@contactId", contactId);
                command.Parameters.AddWithValue("@status", (int)status);

                //command.ExecuteNonQuery();

                //return guid;
                return (Guid)command.ExecuteScalar();
            }
        }

        public ReminderItem Get(Guid guid)
        {
            using (var sqlConection = GetOpenedSqlConnection())
            {
                var sqlCommand = sqlConection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = $"select id, date, message, contact_id, status " +
                                         $"from Reminder " +
                                         $"where id = '{guid}'";

                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return null;

                    int idColumnIndex = reader.GetOrdinal("id");
                    int dateColumnIndex = reader.GetOrdinal("date");
                    int messageColumnIndex = reader.GetOrdinal("message");
                    int contactIdColumnIndex = reader.GetOrdinal("contact_id");
                    int statusColumnIndex = reader.GetOrdinal("status");

                    reader.Read();

                    var id = reader.GetGuid(idColumnIndex);
                    var date = reader.GetDateTimeOffset(dateColumnIndex);
                    var message = reader.GetString(messageColumnIndex);
                    var contact = reader.GetString(contactIdColumnIndex);
                    var status = reader.GetInt32(statusColumnIndex);

                    var result = new ReminderItem(id, date, message, contact, (ReminderItemStatus)status);
                    return result;
                }
            }
        }

        public List<ReminderItem> Get(ReminderItemStatus status)
        {
            List<ReminderItem> Reminders = new List<ReminderItem>();

            using (var sqlConection = GetOpenedSqlConnection())
            {
                var sqlCommand = sqlConection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = $"select id, date, message, contact_id, [status] " +
                                        $"from Reminder where status = {(int)status}";

                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return Reminders;

                    int idColumnIndex = reader.GetOrdinal("id");
                    int dateColumnIndex = reader.GetOrdinal("date");
                    int messageColumnIndex = reader.GetOrdinal("message");
                    int contactIdColumnIndex = reader.GetOrdinal("contact_id");
                    int statusColumnIndex = reader.GetOrdinal("status");

                    while (reader.Read())
                    {
                        var id = reader.GetGuid(idColumnIndex);
                        var date = reader.GetDateTimeOffset(dateColumnIndex);
                        var message = reader.GetString(messageColumnIndex);
                        var contact = reader.GetString(contactIdColumnIndex);
                        var status_ = reader.GetInt32(statusColumnIndex);

                        Reminders.Add(new ReminderItem(id, date, message, contact, (ReminderItemStatus)status_)) ;
                    }

                    return Reminders;
                }
            }
        }

        public void Update(Guid guid, ReminderItemStatus status)
        {
            using (var sqlConection = GetOpenedSqlConnection())
            {
                var sqlCommand = sqlConection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = $"update Reminder " +
                                         $"set Status = {(int)status} " +
                                         $"where id = '{guid}'";

                sqlCommand.ExecuteNonQuery();
                
            }
        }
    }
}
