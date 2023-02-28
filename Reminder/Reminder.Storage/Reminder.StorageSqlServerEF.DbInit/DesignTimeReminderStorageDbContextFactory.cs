using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Reminder.Storage.SqlServer.EF.Context;

namespace Reminder.StorageSqlServerEF.DbInit
{
    public class DesignTimeReminderStorageDbContextFactory
        : IDesignTimeDbContextFactory<ReminderStorageContext>
    {
        public ReminderStorageContext CreateDbContext(string[] args)
        {
            string connectionString = ConnectionStringFactory.GetDbConnectionString();

            var builder = new DbContextOptionsBuilder<ReminderStorageContext>();

            builder.UseSqlServer(connectionString);

            return new ReminderStorageContext(builder.Options);
        }
    }
}
