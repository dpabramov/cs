﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MedService.Core
{
    public class ServiceItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
