using MedService.Core;
using System;

namespace MedService.Domain
{
    public class ToScheduleEventArgs : EventArgs
    {
        public Guid OrderGuid;

        public Doctor doctor;

        public MedServiceStatus status;
    }
}