using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MiddleTierApplication_WebAPI.App_Start;
using MiddleTierApplication_WebAPI.Interfaces;
using MiddleTierApplication_WebAPI.Repositories;
using MiddleTierApplication_WebAPI.ResourceLayer;
using Unity;
using Unity.Lifetime;

namespace MiddleTierApplication_WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            
            //Dependencies
            var container = new UnityContainer();
            container.RegisterType<ICustomerResource, CustomerResource>(new HierarchicalLifetimeManager());
            container.RegisterType<IDataRepository, SQLDataRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
