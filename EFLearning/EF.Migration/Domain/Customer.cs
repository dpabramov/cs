using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFExample.DBMigration.Domain
{
    [Table("Customers", Schema = "dbo")]
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [Column("Name",TypeName ="varchar(50)")]
        public string Name { get; set; }
    }
}
