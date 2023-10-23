using MMABooksBusinessClasses;
using MMABooksDBClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksTests
{
    public class ProductDBTests
    {
        [Test]
        public void TestGetProducts()
        {
            Product p = ProductDB.GetProduct(1);
            Assert.AreEqual(1, p.ProductCode);
        }

        [Test]
        public void TestCreateProducts()
        {
            Product p = new Product();
            p.Description = "Test";
            p.UnitPrice = "100.00";
            p.OnHandQuantity = "200";

            int productCode = ProductDB.AddProduct(p);
            p = ProductDB.GetProduct(productCode);
            Assert.AreEqual("Test", p.Description);
        }
    }
}
