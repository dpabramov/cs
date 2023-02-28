using System;
using System.Collections.Generic;

namespace MedService.Core
{
    public class OrderCreatedEventArgs
    {
        public DateTimeOffset Date { get; set; }

        public string  ContactId { get; set; }

        public MedServiceStatus Status { get; set; }

        public string Description { get; set; }

        public List<ServiceItem> ServiceItems { get; set; }

        public OrderCreatedEventArgs()
        {
            ServiceItems = new List<ServiceItem>();
        }

    }
}