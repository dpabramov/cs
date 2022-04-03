using System;

namespace _102_ReminderItem
{
    class Program
    {
        static void Main(string[] args)
        {
            ReminderItem reminderItem = new ReminderItem(
                DateTimeOffset.Parse("2022-04-02 17:55"),
                "Пора вставать!");

            ReminderItem reminderItem2 = new ReminderItem(
                DateTimeOffset.Parse("2022-04-02 18:55"),
                "Пора на футбол!");

            reminderItem.WriteProperties();
            reminderItem2.WriteProperties();

            Console.ReadKey();
        }
    }
}
