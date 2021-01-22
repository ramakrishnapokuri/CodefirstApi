using Autofac.Integration.WebApi;
using FluentValidation.WebApi;
using log4net;
using log4net.Config;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using PrasadCodeFirst.Data.EntityFramework.DbContexts;
using PrasadCodeFirst.Data.EntityFramework.Migrations;
using PrasadCodeFirst.Web;
using System.Data.Entity;
using System.Web.Http;

[assembly: OwinStartup(typeof (Startup))]

namespace PrasadCodeFirst.Web
{
    public class Startup
    {
        protected ILog Logger
        {
            get { return LogManager.GetLogger(typeof (Startup)); }
        }

        public void Configuration(IAppBuilder app)
        {
            XmlConfigurator.Configure();
            Logger.Info("WebApi service starting...");

            var config = new HttpConfiguration();

            var container = AutofacConfig.Configure();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);

            AutoMapperConfig.Configure();

            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PrasadCodeFirstDbContext, Configuration>());
            FluentValidationModelValidatorProvider.Configure(config);

            Logger.Info("WebApi service started...");
        }
    }
}