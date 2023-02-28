using System;
using System.Collections.Generic;
using System.Text;

namespace MedService.Core
{
    public enum MedServiceStatus
    {
        Opened,  //новый
        Scheduled, //запланирована
        Distributed, //назначена
        ExecutionCompleted, //завершено исполнение
        Completed,  //выполнено
        NotCompleted,  //не выполнено
        Canceled   //отменена
    }
}
