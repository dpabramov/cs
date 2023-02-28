using System;
using System.Collections.Generic;
using System.Text;

namespace MedService.Core
{
    public abstract class BotCreator
    {
        public abstract IMedServiceBot FactoryMethod(string token);
    }
}
