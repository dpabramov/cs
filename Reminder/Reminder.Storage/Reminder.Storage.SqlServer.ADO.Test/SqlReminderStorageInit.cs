using Reminder.Storage.SqlServer.ADO.Test.Properties;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Reminder.Storage.SqlServer.ADO.Test
{
    //вспомогательный класс для упрощения тестирования методов работающих с mssql
    //который прогоняет все скрипты по созданию БД с тестовыми данными
    public class SqlReminderStorageInit
    {
        private readonly string _connectionString;

        public SqlReminderStorageInit(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetOpenedConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        //запускаем скрипт, внутри разбиваем его на коллекцию скриптов без 
        // оператора go
        private void RunSqlScript(string script)
        {
            using (SqlConnection conection = GetOpenedConnection())
            {
                var command = conection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;

                string[] instructions = SplitSqlInstructions(script);

                foreach (var instruction in instructions)
                {
                    if (string.IsNullOrWhiteSpace(instruction))
                        continue;

                    command.CommandText = instruction;
                    command.ExecuteNonQuery();
                }
            }
        }

        //решаем проблему с итструкциями go 
        private string[] SplitSqlInstructions(string script)
        {
            return Regex.Split(script, @"\bgo\b");
        }

        //предварительно написали скрипты и положили
        //их в качестве ресурсов
        public void InitializeDatabase()
        {
            RunSqlScript(Resources.Schema);
            RunSqlScript(Resources.Stored_procedures);
            RunSqlScript(Resources.Data);
        }
    }
}
