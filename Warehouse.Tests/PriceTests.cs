using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.ClassLibrary;
using Warehouse.ClassLibrary.Exceptions;

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

            Assert.IsTrue(100000 == p.Penny, $"Price.Parse(\"1000\") return {p.Penny}, but 100000 was expected");
            Assert.IsTrue(100010 == p2.Penny, $"Price.Parse(\"1000.1\") return {p.Penny}, but 100010 was expected");
            Assert.IsTrue(100011 == p3.Penny, $"Price.Parse(\"1000.11\") return {p.Penny}, but 100011 was expected");

            Assert.ThrowsException<ArgumentNullException>(() => Price.Parse(null));
            Assert.ThrowsException<ParseException>(() => Price.Parse(""));
            Assert.ThrowsException<ParseException>(() => Price.Parse("a"));
            Assert.ThrowsException<ParseException>(() => Price.Parse("."));
            Assert.ThrowsException<ParseException>(() => Price.Parse("0."));
            Assert.ThrowsException<ParseException>(() => Price.Parse(".11"));
        }

        [TestMethod]
        public void ComparisonTest()
        {
            Price p = new Price(1000);
            Price p1 = new Price(1001);
            Price p2 = new Price(1000);

            Assert.IsTrue(p < p1, "operator< fails");
            Assert.IsTrue(p1 > p, "operator> fails");

            Assert.IsFalse(p2 > p, "operator> fails");
            Assert.IsFalse(p2 < p, "operator> fails");

            Assert.IsTrue(p.Equals(p2), "Equals fails");
            Assert.IsFalse(p.Equals(null), "Equals fails");
            Assert.IsFalse(p.Equals(1), "Equals fails");

            Assert.IsTrue(p.CompareTo(p1) < 0, "CompareTo fails");
            Assert.IsTrue(p.CompareTo(p2) == 0, "CompareTo fails");
            Assert.IsTrue(p1.CompareTo(p2) > 0, "CompareTo fails");

        }
    }
}
