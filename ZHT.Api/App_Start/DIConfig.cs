using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using ZHT.Core.WebHelper;
using ZHT.Data;
using ZHT.Repository;
using ZHT.Service;

namespace ZHT.Api
{
    public class DIConfig
    {
        public static void Register()
        {
            
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new EntityFrameworkModel(false));
            builder.RegisterModule(new RepositoryModel(false));
            builder.RegisterModule(new ServiceModel(false));
            //builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerLifetimeScope();
            //builder.RegisterType<GenerateHelper>().As<IGenerateHelper>().InstancePerLifetimeScope();
            var container = builder.Build();
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
          
        }
    }
}
