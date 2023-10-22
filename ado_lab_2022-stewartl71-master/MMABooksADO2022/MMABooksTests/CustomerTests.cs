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
            c = new Customer(1, "Mickey Mouse", "Disneyland Dr.", "Anaheim", "CA", "12345");
        }


    }
}
