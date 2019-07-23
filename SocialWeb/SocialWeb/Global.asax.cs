using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using SocialWeb.Models.Contexts;
using SocialWeb.Repositories;
using SocialWeb.Services;
using WebSocialWeb.Mappers;

namespace SocialWeb
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            
            var config = GlobalConfiguration.Configuration;
            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            //for automapper
            builder.RegisterType<Profiles>().SingleInstance();
            builder.Register(c => new MapperConfiguration(cfg =>cfg.AddProfile(c.Resolve<Profiles>()))).AsSelf().SingleInstance();
            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialContext, Migrations.Configuration>(useSuppliedContext: true));
            builder.RegisterType<SocialContext>().InstancePerRequest();
            builder.RegisterType<UserRepository>().InstancePerRequest();
            builder.RegisterType<UserService>().InstancePerRequest();
            
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //GlobalConfiguration.Configuration.Filters.Add(new CustomExceptionFilterAttribute());

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
