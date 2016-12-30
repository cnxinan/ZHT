using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZHT.Repository.Base;
using ZHT.Core.Repository;
using ZHT.Core.UnitOfWork;

namespace ZHT.Repository
{
    public class RepositoryModel : Module
    {
        private bool _perRequest;
        public RepositoryModel(bool supportPerRequest)
        {
            this._perRequest = supportPerRequest;
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");     

            var tt = builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces();

            if (this._perRequest)
            {
                builder.RegisterGeneric(typeof(BaseRepository<>))
                    .As(typeof(IRepositoryAsync<>))
                    .InstancePerRequest();
                builder.RegisterType<BaseUnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
                tt.InstancePerRequest();
            }
            else
            {
                builder.RegisterGeneric(typeof(BaseRepository<>))
                    .As(typeof(IRepositoryAsync<>))
                    .InstancePerRequest();
                builder.RegisterType<BaseUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

                tt.InstancePerLifetimeScope();
            }
        }
    }

}
