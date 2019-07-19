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

            builder.RegisterType<UserService>().InstancePerRequest();
            builder.RegisterType<UserRepository>().InstancePerRequest();
            builder.RegisterType<SocialContext>().As<DbContext>().InstancePerRequest();

            // OPTIONAL: Register the Autofac filter provider.
            //builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            //builder.RegisterWebApiModelBinderProvider();
            
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
