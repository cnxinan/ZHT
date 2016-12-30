using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface IBusinessScopeService
    {
        void InsertBaseTypes(BusinessScope businessScope);
        void Update(BusinessScope businessScope);
        void Delete(BusinessScope businessScope);
        BusinessScope GetModelById(string id);
        List<BusinessScope> GetAllList();
    }
}
