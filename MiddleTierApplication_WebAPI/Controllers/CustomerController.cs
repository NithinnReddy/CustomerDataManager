using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using MiddleTierApplication_WebAPI.Interfaces;
using MiddleTierApplication_WebAPI.Models;

namespace MiddleTierApplication_WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerResource _resource;

        public CustomerController(ICustomerResource customerResource)
        {
            _resource = customerResource;
        }



        [Route("customer/{customerId}")]
        [HttpGet]
        public IHttpActionResult Get(long customerId)
        {
            IHttpActionResult response;
            try
            {
                var customer = _resource.Get(customerId);

                if (customer != null && customer.Id > 0)
                {
                    // Write Log : customer not found for the given id 
                    response = Ok(customer);
                   
                }
                else
                {
                    response = NotFound();
                }
            }
            catch (Exception e)
            {
                //Log the error
                Console.WriteLine(e);
                response = InternalServerError();
            }

            return response;
        }

        [Route("customer")]
        [HttpPost]
        public IHttpActionResult Save(Customer customer)
        {
            IHttpActionResult response;

            try
            {
                //validate customer object
                if (ModelState.IsValid)
                {
                    long customerId = _resource.Save(customer);

                    if (customerId > 0)
                    {
                        customer.Id = customerId;
                        response = Ok(customer);

                    }
                    else
                    {
                        //Write Log "Save is not successful"
                        response = InternalServerError();
                    }
                }
                else
                {
                    //Write Log "Bad input" : customer object
                    response = BadRequest(ModelState);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response = InternalServerError();
            }

            return response;
        }
    }
}
