using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MedService.Core.Tests
{
    [TestClass]
    public class MedServiceCoreTester
    {
        [TestMethod]
        public void OrderConstructorFillInFieldsCorrectly()
        {
            Order order = new Order();

            Assert.IsNotNull(order);
            Assert.IsNotNull(order.ServiceItems);
            Assert.AreEqual(0, order.ServiceItems.Count);
            Assert.AreEqual(Guid.Empty, order.Id);
            Assert.AreEqual(DateTimeOffset.MinValue, order.Date);
            Assert.IsNull(order.Doctor);
            Assert.IsNull(order.Sicker);
            Assert.IsNull(order.Description);
            Assert.AreEqual(MedServiceStatus.Opened, order.Status);
        }
    }
}
