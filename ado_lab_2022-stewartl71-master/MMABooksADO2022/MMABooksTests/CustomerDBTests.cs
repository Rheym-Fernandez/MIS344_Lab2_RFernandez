using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;
using MySqlX.XDevAPI.Relational;

namespace MMABooksTests
{
    public class CustomerDBTests
    {

        [Test]
        public void TestGetCustomer()
        {
            Customer c = CustomerDB.GetCustomer(2);
            Assert.AreEqual(2, c.CustomerID);
        }

        [Test]
        public void TestCreateCustomer()
        {
            Customer c = new Customer();
            c.Name = "Goofy";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";

            int customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);
            Assert.AreEqual("Goofy", c.Name);
        }

        [Test]
        public void TestUpdateCustomer()
        {
            Customer c = new Customer();
            
            c.Name = "Test";
            c.Address = "Test";
            c.City = "Test";
            c.State = "Test";
            c.ZipCode = "12345";

            //Need to ask how to implement an update and then save it

            //CustomerDB.UpdateCustomer();
            //CustomerDB.SaveChanges();
            c = CustomerDB.GetCustomer(2);
            Assert.AreEqual("Test", c.Address);

        }
       
        [Test]
        public void TestDeleteCustomer()
         {
            //Get the Customer first?
             Customer c = CustomerDB.GetCustomer(1);

            //Why is DeleteCustomer not working in this context?
            // Assert.True(CustomerDB.DeleteCustomer(1));
             Assert.Throws<Exception>(() => CustomerDB.GetCustomer(1));
         }

        }
    }
    