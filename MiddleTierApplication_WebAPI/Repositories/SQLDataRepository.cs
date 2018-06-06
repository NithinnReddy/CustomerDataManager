using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MiddleTierApplication_WebAPI.Models;
using MiddleTierApplication_WebAPI.Interfaces;

namespace MiddleTierApplication_WebAPI.Repositories
{
    public class SQLDataRepository : IDataRepository
    {
        #region Customer Methods
        public Customer GetCustomer(long id)
        {
            //Logic to Connect to DB abd get the customer needs to be implemented

            //just hard coding the values for now.

            if (id <= 2018)
            {
                var customer = new Customer();

                customer.Id = id;
                customer.FirstName = "Nithin";
                customer.LastName = "Reddy";
                customer.Zip = "07304";
                customer.PhoneNumber = "1234567890";

                return customer;
            }
            else
            {

                return null;
            }
        }

        public long SaveCustomer(Customer customer)
        {
            // logic not implemented

            return customer.FirstName.Contains("i") ? 2018 : 0;
        }


        public List<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        

        public bool DeleteCustomer(long id)
        {
            throw new NotImplementedException();
        }
        #endregion 
    }
}
