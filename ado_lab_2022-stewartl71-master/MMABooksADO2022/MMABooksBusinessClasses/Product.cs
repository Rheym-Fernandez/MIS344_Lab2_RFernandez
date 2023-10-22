using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksBusinessClasses
{
    public class Product
    {
        // there are several warnings in this file related to nullable properties and return values.
        // you can ignore them
        public Product() { }

        public Product(int code, string description, string price, string quantity)
        {
            ProductCode = code;
            Description = description;
            UnitPrice = price;
            OnHandQuantity = quantity;
        }

        //instance variables
        private int code;
        private string description;
        private string price;
        private string quantity;


        public int ProductCode
        {
            get
            {
                return code;
            }

            set
            {
                if (value > 0)
                    code = value;
                else
                    throw new ArgumentOutOfRangeException("Product Code must be a positive integer.");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 100)
                    description = value;
                else throw new ArgumentOutOfRangeException("The description must be at least one character and no more than 100 characters.");
            }
        }


        public string UnitPrice
        {
            get
            {
                return price;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 100)
                    price = value;
                else throw new ArgumentOutOfRangeException("The price must be at least one character and no more than 100 characters.");
            }
        }

        public string OnHandQuantity
        {
            get
            {
                return quantity;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 100)
                    quantity = value;
                else throw new ArgumentOutOfRangeException("On Hand Quantity must be at least one character and no more than 100 characters.");
            }
        }

     
    }
}
