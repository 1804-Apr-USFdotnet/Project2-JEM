﻿using System.Web.Http;
using System.Web.UI.WebControls;
using RouteParameter = System.Web.Http.RouteParameter;
using System.Web.Http.Cors;

namespace FTV.SL
{
    public static class WebApiConfig
    {
        public static string AuthenticationType = "AuthCookie";
        public static string CookieName = "AuthCookie";

        public static void Register(HttpConfiguration config)
        {


            // Web API configuration and services
            var cors = new EnableCorsAttribute("*","*","*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
        }
    }
}