using System;
using System.Collections.Generic;
using System.Text;

namespace MedService.Core
{
    public static class MedServiceMessages
    {
        public static string NewOrder = "Новый заказ";

        public static string NewOrderInputMessage = 
            "Для ввода нового заказа введите обязательные поля. \nНиже пример:";

        public static string prefixInputDate = "Дата и время заказа: ";

        public static string prefixInputServiceItem = "Услуга: ";

        public static string PrefixInputDescription = "Комментарий: ";

        public static string UnCorrectDateMessage = "Некорректный ввод, введите дату:";

        public static string NewOrderIsNullErrorMessage = 
            $"Ошибка. Чтобы создать наряд сначала наберите команду: {NewOrder}";

        public static string Ok = "ОК";

        public static string EnterServiceItemMessage = "Введите по одной список услуг";

        public static string NextServiceItemMessage = 
            "Далее введите следующую услугу или произвольный комментарий. \nНиже пример:";

        public static string ExampleBelowMessage = "Ниже пример:";

        public static string ExampleDate = $"{prefixInputDate}{DateTimeOffset.Now}";

        public static string ExampleServiceItemMessage = 
            $"{prefixInputServiceItem}Поставить капельницу";

        public static string ExampleDescriptionMessage = 
            $"{PrefixInputDescription}Не люблю когда опаздывают";


        public static string GetMessageDistributedOrderInfoToDoctor(Order order)
        {
            return string.Format($"На вас назначен наряд. \nДата: {order.Date}" +
                        $"\nадрес: {order.Sicker.HomeAddress}" +
                        $"\nИмя: {order.Sicker.Name}" +
                        $"\nТелефон: {order.Sicker.Telephone}" +
                        $"\nУслуги: {order.ServiceItems.Count}", order);
        }

        public static string GetMessageSchedulededOrderInfoToDoctor(Order order)
        {
            return string.Format($"На вас запланирован наряд. \nДата: {order.Date}" +
                        $"\nадрес: {order.Sicker.HomeAddress}" +
                        $"\nИмя: {order.Sicker.Name}\nТелефон: {order.Sicker.Telephone}" +
                        $"\nУслуги: {order.ServiceItems.Count}", order);
        }
    }
}
