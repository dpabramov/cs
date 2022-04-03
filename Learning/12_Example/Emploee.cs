using System;
using System.Collections.Generic;
using System.Text;

namespace _12_Example
{
    class Emploee : Person
    {
        public string EmploeeCode { get; set; }
        public DateTimeOffset HireDate { get; set; }

        public override string ShortDescription
        {
            //вначале выводится название типа данных (имя класса)
            get
            {
                return base.ShortDescription +
                    $"\nEmploeeCode: {EmploeeCode}" +
                    $"\nHireDate: {HireDate:dd-MM-yyyy}";
            }
        }

        public Emploee(string name, DateTimeOffset date) : base(name, date)
        {
        }
    }
}
