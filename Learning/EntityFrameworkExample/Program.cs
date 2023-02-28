using EntityFrameworkExample.AdditionalSource;
using EntityFrameworkExample.Context;
using System;

namespace EntityFrameworkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var storage = new EntityFrameworkReminderStorage(
                @"Data Source=DESKTOP-EU10JJA\SQLEXPRESS;
                    Initial Catalog=RemindersEF;Integrated Security=True;
                    Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                    ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            storage.Add(
                DateTimeOffset.Now,
                "Позвонить жене",
                "123456",
                Domain.ReminderItemStatus.Awaiting);

            Console.WriteLine(ConnectionStringFactory.GetDbConnectionString());
        }
    }
}
