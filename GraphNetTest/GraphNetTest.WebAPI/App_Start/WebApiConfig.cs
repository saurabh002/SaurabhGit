using GraphNetTest.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Unity;

namespace GraphNetTest.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<PatientServices, PatientServices>();
            config.DependencyResolver = new UnityResolver(container);
            //config.Formatters.Remove(config.Formatters.JsonFormatter);
            config.Formatters.XmlFormatter.UseXmlSerializer = true;
            // config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            //config.DependencyResolver = new UnityResolver(container);
            // Web API configuration and services
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
