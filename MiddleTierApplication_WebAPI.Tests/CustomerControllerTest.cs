using System;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiddleTierApplication_WebAPI.Controllers;
using MiddleTierApplication_WebAPI.Interfaces;
using MiddleTierApplication_WebAPI.Models;
using Moq;

namespace MiddleTierApplication_WebAPI.Tests
{
    [TestClass]
    public class CustomerControllerTest
    {

        [TestMethod]
        public void GetCustomer_Success_Test()
        {
            //Arange
            Mock<ICustomerResource> mockResource = new Mock<ICustomerResource>();
            var customer = new Customer();
            customer.FirstName = "nith";
            customer.LastName = "raj";
            customer.Id = 22;
            mockResource.Setup(m => m.Get(22)).Returns(customer);
            CustomerController contoller = new CustomerController(mockResource.Object);

            //Act
            var customerResult = (OkNegotiatedContentResult<Customer>)contoller.Get(22);

            //Assert
            Assert.AreEqual(customer.Id, customerResult.Content.Id);
            Assert.AreEqual(customer.FirstName, customerResult.Content.FirstName);
            //LastName
            //Zip


        }

        [TestMethod]
        public void GetCustomer_CustomerNotFound_Test()
        {
            //Arange
            Mock<ICustomerResource> mockResource = new Mock<ICustomerResource>();
            var customer = new Customer();
            customer.FirstName = "nith";
            customer.LastName = "raj";
            customer.Id = 0;
            mockResource.Setup(m => m.Get(22));
            CustomerController contoller = new CustomerController(mockResource.Object);

            //Act
            var customerResult = contoller.Get(22);
            
            //Assert
            Assert.AreEqual(customerResult.GetType(),typeof(NotFoundResult));



        }


        [TestMethod]
        public void SaveCustomer_Success_Test()
        {
            //Arange
            Mock<ICustomerResource> mockResource = new Mock<ICustomerResource>();
            var customer = new Customer();
            customer.FirstName = "nith";
            customer.LastName = "raj";
            customer.Id = 22;
            mockResource.Setup(m => m.Save(customer)).Returns(customer.Id);
            CustomerController contoller = new CustomerController(mockResource.Object);
            //Act
            var customerResult = contoller.Save(customer);

            //Assert
            Assert.AreEqual(customerResult.GetType(), typeof(OkNegotiatedContentResult<Customer>));
            Assert.IsTrue(((OkNegotiatedContentResult<Customer>)customerResult).Content.Id > 0);


        }

        [TestMethod]
        public void SaveCustomer_InternalServerError_Test()
        {
            //Arange
            Mock<ICustomerResource> mockResource = new Mock<ICustomerResource>();
            CustomerController contoller = new CustomerController(mockResource.Object);

            var customer = new Customer();
            customer.Id = 22;
            customer.FirstName = "";
            customer.LastName = "raj";
            customer.Zip = "45632";

            //Act
            var customerResult = contoller.Save(customer);

            //Assert
            Assert.AreEqual(customerResult.GetType(), typeof(InternalServerErrorResult));


        }
    }
}
