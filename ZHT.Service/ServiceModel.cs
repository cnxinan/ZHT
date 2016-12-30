using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Service
{
    public class ServiceModel : Module
    {
        private bool _perRequest;
        public ServiceModel(bool supportPerRequest)
        {
            this._perRequest = supportPerRequest;
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");
            
          var tt= builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();

            if (this._perRequest)
            {
                tt.InstancePerRequest();
            }
            else
            {
                tt.InstancePerLifetimeScope();
            }
        }
    }
}
