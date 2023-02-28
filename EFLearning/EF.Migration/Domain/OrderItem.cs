using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFExample.DBMigration.Domain
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public int NumberOfItems { get; set; }
    }
}
