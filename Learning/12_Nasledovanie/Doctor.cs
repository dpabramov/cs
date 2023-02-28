using System;
using System.Collections.Generic;
using System.Text;

namespace _12_Nasledovanie
{
    class Doctor : Person
    {
        public string Proff { get; set; }

        public override string PropertyString => base.PropertyString + $"\nпрофессия {Proff}";

        public Doctor(string name, string address, string proff) : base(name, address)
        {
            Proff = proff;
        }

        public Doctor()
        {

        }
    }
}
