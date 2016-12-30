using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ZHT.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commint();
        void CommintTransaction();
        void Rollback();

    }
}
