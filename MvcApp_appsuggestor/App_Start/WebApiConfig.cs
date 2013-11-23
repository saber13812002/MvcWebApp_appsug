using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MvcWebApp_appsug
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "esl/{controller}/{Id}/{Id2}",
                defaults: new { Id = RouteParameter.Optional ,Id2 = RouteParameter.Optional}
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiesl",
                routeTemplate: "esl/{controller}/{Id}/{Id2}/{Id3}",
                defaults: new { Id = RouteParameter.Optional, Id2 = RouteParameter.Optional, Id3 = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
