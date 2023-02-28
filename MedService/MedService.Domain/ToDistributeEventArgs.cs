using MedService.Core;
using System;

namespace MedService.Domain
{
    public class ToDistributeEventArgs : EventArgs
    {
        public Guid OrderGuid;

        public MedServiceStatus status;
    }
}