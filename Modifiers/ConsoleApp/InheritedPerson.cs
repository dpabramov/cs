using ALib;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class InheritedPerson : Person
    {
        public void Method()
        {
            ProtectedMethod();
        }
    }
}
