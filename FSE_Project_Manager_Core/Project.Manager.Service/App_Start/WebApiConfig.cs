using Project.Manager.BusinessAccess;
using Project.Manager.DataAccess;
using Project.Manager.DataAccess.interfaces;
using Project.Manager.Entities;
using Project.Manager.Service.App_Start;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Unity;

namespace Project.Manager.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            UnityContainer container = new UnityContainer();

            container.RegisterType<bUser>();
            container.RegisterType<IUser>();
            container.RegisterType<IUser, dUser>();

            container.RegisterType<bProjects>();
            container.RegisterType<IProjects>();
            container.RegisterType<IProjects, dProjects>();

            container.RegisterType<bProjectsTask>();
            container.RegisterType<IProjectsTask>();
            container.RegisterType<IProjectsTask, dProjectsTask>();

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
