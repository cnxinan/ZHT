using Autofac;
using ZHT.Data.DbFactory;
using System;

namespace ZHT.Data
{
    public class EntityFrameworkModel : Module
    {
        private bool _perRequest;
        public EntityFrameworkModel(bool supportPerRequest)
        {
            this._perRequest = supportPerRequest;
        }
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");         

            var tt = builder.RegisterType<DataBaseFactory>().As<IDataBaseFactory>();     

            if (this._perRequest)
            {
                tt.InstancePerRequest();
            }
            else
            {
                tt.SingleInstance();
            }
        }
    }
}
