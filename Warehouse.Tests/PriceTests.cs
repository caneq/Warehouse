using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.ClassLibrary;

namespace Warehouse.Tests
{
    [TestClass()]
    public class PriceTests
    {
        [TestMethod]
        public void ParseTest()
        {
            Price p = Price.Parse("1000");
            Price p2 = Price.Parse("1000.1");
            Price p3 = Price.Parse("1000.11");

            Assert.IsTrue(100000 == p.Penny, $"Price.Parse(\"1000\") return {p.Penny}, but must 100000");
            Assert.IsTrue(100010 == p2.Penny, $"Price.Parse(\"1000.1\") return {p.Penny}, but must 100010");
            Assert.IsTrue(100011 == p3.Penny, $"Price.Parse(\"1000.11\") return {p.Penny}, but must 100011");
        }
    }
}
