using System;

namespace Reminder.StorageSqlServerEF.DbInit
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConnectionStringFactory.GetDbConnectionString();
            Console.WriteLine("Hello World!");
        }
    }
}
