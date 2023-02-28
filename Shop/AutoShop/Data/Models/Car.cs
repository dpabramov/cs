using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoShop.Data.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDescr { get; set; }

        public string LongDescripton { get; set; }

        public string Img { get; set; } //url для картинки

        public ushort Price { get; set; }

        public bool IsFavourite { get; set; } //лучший товар

        public bool IsAvailable { get; set; } //наличие товара на складе

        public int CategoryId { get; set; } // код категории

        public virtual Category Category { get; set; } //категория
    }
}
