using BasicAuthenticationWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using webAppConsumeWebAPI.MessageHandler;

namespace BasicAuthenticationWEBAPI
    {
    public static class WebApiConfig
        {
        public static void Register(HttpConfiguration config)
            {
            // Web API configuration and services
            //to enable basic authetication for entire web application

            config.MessageHandlers.Add(new MessageHandler1());
            config.MessageHandlers.Add(new MessageHandler2());
            config.Filters.Add(new BasicAuthenticationAttribute());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors();

            }
        }
    }
