using System;
using System.Collections.Generic;
using System.Text;

namespace MedService.Core
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTimeOffset Date { get; set; }

        public Doctor Doctor { get; set; }

        public Sicker Sicker { get; set; }

        public MedServiceStatus Status { get; set; }

        public string Description { get; set; }

        public List<ServiceItem> ServiceItems { get; set; }

        public Order()
        {
            ServiceItems = new List<ServiceItem>();
        }
    }
}
