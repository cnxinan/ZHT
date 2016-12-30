using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Autofac;
using ZHT.Core.Infrastructure;
using ZHT.Core.Infrastructure.DependencyManagement;

namespace ZHT.Core.Infrastructure
{
    public class EasyEngine : IEngine
    {
      
        private ContainerBuilder _containerBuilder;
        //private ContainerManager _containerManager;
        public ContainerBuilder ContainerBuilder
        {
            get { return _containerBuilder; }
        }
        //public ContainerManager ContainerManager
        //{
        //    get { return _containerManager; }
        //}

        #region Ctor

        public EasyEngine()
        {

            InitializeContainer();
        }

        #endregion

        #region Utilities

        private void InitializeContainer()
        {
            var builder = new ContainerBuilder();

            _containerBuilder = builder;

            //this._containerManager = new ContainerManager(builder.Build());
        }

        #endregion

    }
}
