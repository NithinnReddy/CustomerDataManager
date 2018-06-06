using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MiddleTierApplication_WebAPI.Interfaces;
using MiddleTierApplication_WebAPI.Models;

namespace MiddleTierApplication_WebAPI.Repositories
{
    public class FlatFileDataRepository : IDataRepository
    {
        #region Customer Methods
        public Customer GetCustomer(long id)
        {
            //Logic to Connect to DB abd get the customer needs to be implemented

            //just hard coding the values for now.

            if (id > 249)
            {
                Customer customer = new Customer();

                customer.Id = id;
                customer.FirstName = "Nithin";
                customer.LastName = "Cirigiri";
                customer.Zip = "46037";
                customer.PhoneNumber = "1234567890";

                return customer;
            }
            else
            {

                return null;
            }
        }

        public List<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public long SaveCustomer(Customer customer)
        {
            if (customer.FirstName.Contains("ni"))
            {
                return 2018;
            }
            else
            {
                return 0;
            }
        }

        public bool DeleteCustomer(long id)
        {
            throw new NotImplementedException();
        }
        #endregion 
    }
}
