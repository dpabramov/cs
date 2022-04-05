using System;
using System.Collections.Generic;
using System.Text;

namespace _013_AbstractClass.Interfaces
{
    public interface IHelicopter : IFlyer
    {
        byte BladeCount { get;  set; }
    }
}
