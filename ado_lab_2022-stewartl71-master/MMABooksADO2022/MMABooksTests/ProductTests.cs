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
            Assert.AreEqual(null, def.Description);
            Assert.AreEqual(null, def.UnitPrice);
            Assert.AreEqual(null, def.OnHandQuantity);

            Assert.IsNotNull(c);
            Assert.AreNotEqual(null, c.Description);
            Assert.AreNotEqual(null, c.UnitPrice);
            Assert.AreNotEqual(null, c.OnHandQuantity);

        }

        [Test]

        public void TestDescriptionSetter()
        {
            c.Description = "Test Item 2";
            Assert.AreNotEqual("Test Item", c.Description);
            Assert.AreEqual("Test Item 2", c.Description);
        }

        [Test]

        public void TestDescriptionLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Description = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789");
        }


    }
}
