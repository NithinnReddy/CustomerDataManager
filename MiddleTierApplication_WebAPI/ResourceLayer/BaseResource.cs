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
    public class BaseResource
    {
        public IDataRepository dataRepository;
        public BaseResource(IDataRepository dataRepo)
        {
            dataRepository = dataRepo;
        }

        public BaseResource()
        {
          
        }
    }
}
