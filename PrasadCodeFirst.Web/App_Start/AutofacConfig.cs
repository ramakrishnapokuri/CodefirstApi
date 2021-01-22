using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using log4net;
using PrasadCodeFirst.Services.Models;
using System.Reflection;

namespace PrasadCodeFirst.Web
{
    public class AutofacConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            var logger = LogManager.GetLogger(typeof (AutofacConfig));
            builder.RegisterInstance(logger).As<ILog>().SingleInstance();
            builder.Register(c => Mapper.Engine).As<IMappingEngine>().InstancePerLifetimeScope().PropertiesAutowired().PreserveExistingDefaults();

            builder.RegisterAssemblyTypes(Assembly.Load("PrasadCodeFirst.Data.CommandQuery")).Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope().PropertiesAutowired().PreserveExistingDefaults();

            builder.RegisterAssemblyTypes(Assembly.Load("PrasadCodeFirst.Services")).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<ModelFactory>().InstancePerLifetimeScope().PropertiesAutowired().PreserveExistingDefaults();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            return builder.Build();
        }
    }
}