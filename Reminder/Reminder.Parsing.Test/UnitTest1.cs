using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Reminder.Parsing.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Method_Parse_Does_Everything_Correctly()
        {
            //prepare
            string message = "2022-04-25T21:00:01 Закапать капли";

            //do test
            ParsedMessage res = MessageParser.Parse(message);

            //check
            Assert.AreEqual(DateTimeOffset.Parse("2022-04-25T21:00:01"), res.Date);
            Assert.AreEqual("Закапать капли", res.Message);
        }
    }
}
