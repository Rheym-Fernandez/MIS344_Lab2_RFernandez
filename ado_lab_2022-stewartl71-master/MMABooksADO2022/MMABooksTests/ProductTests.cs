using MMABooksBusinessClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        private Product def;
        private Product c;

        [SetUp]

        public void SetUp()
        {
            def = new Product();
            c = new Product(1, "Test Item", "50.00", "100");
        }

        [Test]

        public void TestConstructor()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.Name);
            Assert.AreEqual(null, def.Address);
            Assert.AreEqual(null, def.City);
            Assert.AreEqual(null, def.State);
            Assert.AreEqual(null, def.ZipCode);

            Assert.IsNotNull(c);
            Assert.AreNotEqual(null, c.Name);
            Assert.AreNotEqual(null, c.Name);
            Assert.AreNotEqual(null, c.Address);
            Assert.AreNotEqual(null, c.City);
            Assert.AreNotEqual(null, c.State);
            Assert.AreNotEqual(null, c.ZipCode);

        }

        [Test]

        public void TestNameSetter()
        {
            c.Name = "Minnie, Mouse";
            Assert.AreNotEqual("Mickey, Mouse", c.Name);
            Assert.AreEqual("Minnie, Mouse", c.Name);
        }

        [Test]

        public void TestNameLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789");
        }


    }
}
