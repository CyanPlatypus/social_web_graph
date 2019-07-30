using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Data.Mappers;
using Data.Models.Contexts;
using Data.Repositories;
using Data.Services;

namespace WebServices
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

            //
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
