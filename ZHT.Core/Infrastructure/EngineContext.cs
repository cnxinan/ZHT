using System.Runtime.CompilerServices;
using Autofac;
using Autofac.Integration.Mvc;

namespace ZHT.Core.Infrastructure
{

    public class EngineContext
    {
         [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize()
        {
            if (Singleton<IEngine>.Instance == null)
            {
               
                Singleton<IEngine>.Instance = CreateEngineInstance();
                
            }
            return Singleton<IEngine>.Instance;
        }

        public static IEngine CreateEngineInstance()
        {
            return new EasyEngine();
        }

        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Singleton<IEngine>.Instance = CreateEngineInstance();
                }
                return Singleton<IEngine>.Instance;
            }
        }

        public static ILifetimeScope ApplicationContainer
        {
            get
            {
                return AutofacDependencyResolver.Current.ApplicationContainer;
            }
        }

        public static ILifetimeScope RequestLifetime
        {
            get
            {
                return AutofacDependencyResolver.Current.RequestLifetimeScope;
            }
        }
    }
}
