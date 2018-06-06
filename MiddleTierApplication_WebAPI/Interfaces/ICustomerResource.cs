using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MiddleTierApplication_WebAPI.Models;

namespace MiddleTierApplication_WebAPI.Interfaces
{
    public interface ICustomerResource
    {
        /// <summary>
        /// Get the customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Customer Get(long id);

        /// <summary>
        /// Gets all the customer details
        /// </summary>
        /// <returns></returns>
        List<Customer> GetCustomers();

        /// <summary>
        /// Saves the customer and returns the customer Id
        /// </summary>
        /// <returns></returns>
        long Save(Customer customer);

        bool Delete(long id);
    }
}
