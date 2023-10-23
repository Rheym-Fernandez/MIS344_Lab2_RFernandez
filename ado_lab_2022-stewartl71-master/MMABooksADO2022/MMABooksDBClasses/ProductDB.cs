using MMABooksBusinessClasses;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MMABooksDBClasses
{
    public static class ProductDB
    {
        public static Product GetProduct(int productCode)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity"
                + "FROM Products "
                + "WHERE ProductCode = @ProductCode";
            MySqlCommand selectCommand =
                new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", productCode);

            try
            {
                connection.Open();
                MySqlDataReader prodReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (prodReader.Read())
                {
                    Product ID = new Product();
                    ID.ProductCode = (int)prodReader["ProductCode"];
                    ID.Description = prodReader["Description"].ToString();
                    ID.UnitPrice = prodReader["UnitPrice"].ToString();
                    ID.OnHandQuantity = prodReader["OnHandQuantity"].ToString();
                
                    return ID;
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static int AddCustomer(Customer customer)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT Customers " +
                "(Name, Address, City, State, ZipCode) " +
                "VALUES (@Name, @Address, @City, @State, @ZipCode)";
            MySqlCommand insertCommand =
                new MySqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@Name", customer.Name);
            insertCommand.Parameters.AddWithValue(
                "@Address", customer.Address);
            insertCommand.Parameters.AddWithValue(
                "@City", customer.City);
            insertCommand.Parameters.AddWithValue(
                "@State", customer.State);
            insertCommand.Parameters.AddWithValue(
                "@ZipCode", customer.ZipCode);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                // MySQL specific code for getting last pk value
                string selectStatement =
                    "SELECT LAST_INSERT_ID()";
                MySqlCommand selectCommand =
                    new MySqlCommand(selectStatement, connection);
                int customerID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return customerID;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool DeleteCustomer(Customer customer)
        {

            // get a connection to the database
            MySqlConnection connection = MMABooksDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Customers " +
                "WHERE CustomerID = @CustomerID " +
                "AND Name = @Name " +
                "AND Address = @Address " +
                "AND City = @City " +
                "AND State = @State " +
                "AND ZipCode = @ZipCode";
            // set up the command object
            MySqlCommand deleteCommand =
                new MySqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue(
                "@Name", customer.Name);
            deleteCommand.Parameters.AddWithValue(
                "@Address", customer.Address);
            deleteCommand.Parameters.AddWithValue(
                "@City", customer.City);
            deleteCommand.Parameters.AddWithValue(
                "@State", customer.State);
            deleteCommand.Parameters.AddWithValue(
                "@ZipCode", customer.ZipCode);
            try
            {
                // open the connection
                connection.Open();
                // execute the command.ExecuteNonQuery();
                int rows = deleteCommand.ExecuteNonQuery();
                // if the number of records returned = 1, return true otherwise return false
                if (rows == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                // throw the exception
                throw ex;
            }
            finally
            {
                // close the connection
                connection.Close();
            }
        }

        public static bool UpdateCustomer(Customer oldCustomer,
            Customer newCustomer)
        {
            // create a connection
            MySqlConnection connection = MMABooksDB.GetConnection();
            string updateStatement =
                "UPDATE Customers SET " +
                "Name = @NewName, " +
                "Address = @NewAddress, " +
                "City = @NewCity, " +
                "State = @NewState, " +
                "ZipCode = @NewZipCode " +
                "WHERE CustomerID = @OldCustomerID " +
                "AND Name = @OldName " +
                "AND Address = @OldAddress " +
                "AND City = @OldCity " +
                "AND State = @OldState " +
                "AND ZipCode = @OldZipCode";
            // setup the command object
            MySqlCommand updateCommand = new MySqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue(
                "@Name", oldCustomer.Name);
            updateCommand.Parameters.AddWithValue(
                "@Address", oldCustomer.Address);
            updateCommand.Parameters.AddWithValue(
                "@City", oldCustomer.City);
            updateCommand.Parameters.AddWithValue(
                "@State", oldCustomer.State);
            updateCommand.Parameters.AddWithValue(
                "@ZipCode", oldCustomer.ZipCode);

            updateCommand.Parameters.AddWithValue(
             "@Name", newCustomer.Name);
            updateCommand.Parameters.AddWithValue(
                "@Address", newCustomer.Address);
            updateCommand.Parameters.AddWithValue(
                "@City", newCustomer.City);
            updateCommand.Parameters.AddWithValue(
                "@State", newCustomer.State);
            updateCommand.Parameters.AddWithValue(
                "@ZipCode", newCustomer.ZipCode);

            try
            {
                // open the connection
                connection.Open();
                // execute the command
                int rows = updateCommand.ExecuteNonQuery();
                // if the number of records returned = 1, return true otherwise return false
                if (rows == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                // throw the exception
                throw ex;
            }
            finally
            {
                // close the connection
                connection.Close();
            }

        }
    }
}
}
