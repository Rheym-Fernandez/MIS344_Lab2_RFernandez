using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer def;
        private Customer c;

        [SetUp]
        
        public void SetUp()
        {
            def = new Customer();
            c = new Customer(1, "Mickey, Mouse", "Disneyland Dr.", "Anaheim", "CA", "12345");
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

        public void TestAddressSetter()
        {
            c.Address = "Disney Street";
            Assert.AreNotEqual("Disneyland Dr.", c.Address);
            Assert.AreEqual("Disney Street", c.Address);
        }

        [Test]

        public void TestAddressLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Address = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789");
        }

        [Test]
        public void TestCitySetter()
        {
            c.City = "Universal City";
            Assert.AreNotEqual("Anaheim", c.City);
            Assert.AreEqual("Universal City", c.City);
        }

        [Test]

        public void TestCityLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.City = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789");
        }

        [Test]

        public void TestStateSetter()
        {
            c.State = "OR";
            Assert.AreNotEqual("CA", c.State);
            Assert.AreEqual("OR", c.State);
        }

        [Test]

        public void TestStateLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.State = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789");
        }

        [Test]
        public void TestZipCodeSetter()
        {
            c.ZipCode = "23456";
            Assert.AreNotEqual("12345", c.ZipCode);
            Assert.AreEqual("23456", c.ZipCode);
        }

        [Test]

        public void TestZipCodeLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ZipCode = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789");
        }

    }
}
