using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MiddleTierApplication_WebAPI.Interfaces;
using MiddleTierApplication_WebAPI.Models;

namespace MiddleTierApplication_WebAPI.ResourceLayer
{
    public class CustomerResource : BaseResource, ICustomerResource
    {
        public CustomerResource(IDataRepository dataRepo) : base(dataRepo)
        {
        }

        public Customer Get(long id)
        {
            return dataRepository.GetCustomer(id);
        }
       
        public long Save(Customer customer)
        {
            return dataRepository.SaveCustomer(customer);
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

    }
}
