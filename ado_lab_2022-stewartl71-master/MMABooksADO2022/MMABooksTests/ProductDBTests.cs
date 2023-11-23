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
            Product p = ProductDB.GetProduct("A4CS");
            Assert.AreEqual(1, p.ProductCode);
        }

        [Test]
        public void TestCreateProducts()
        {
            Product p = new Product();
            p.Description = "Test";
            p.UnitPrice = "100.00";
            p.OnHandQuantity = "200";

            string productCode = ProductDB.AddProduct(p).ToString();
            p = ProductDB.GetProduct(productCode);
            Assert.AreEqual("Test", p.Description);
        }

        [Test]
        public void UpdateTest()
        {
            //Need to identify code that allows me to update and save product changes
            Product p = ProductDB.GetProduct("A4CS");
            p.Description = "Test";
            //ProductDB.UpdateProduct(p);
            //ProductDB.SaveChanges();
            p = ProductDB.GetProduct("A4CS");
            Assert.AreEqual("Test", p.Description);

        }
        [Test]
        public void TestDeleteProducts()
        {   // Need to Save Delete Changes First?
            Product p = ProductDB.GetProduct("A4VB");
            ProductDB.DeleteProduct(p);
            Assert.IsNotNull(ProductDB.GetProduct("A4VB"));
        }
    }
}
