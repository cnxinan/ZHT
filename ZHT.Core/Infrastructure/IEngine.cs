using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ZHT.Core.Infrastructure.DependencyManagement;

namespace ZHT.Core.Infrastructure
{
   public interface IEngine
    {
       ContainerBuilder ContainerBuilder { get; }
       //ContainerManager ContainerManager { get; }
    }
}
