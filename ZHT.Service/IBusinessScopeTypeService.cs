using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface IBusinessScopeTypeService
    {
        void InsertBaseTypes(BusinessScopeType businessScopeType);
        void Update(BusinessScopeType businessScopeType);
        void Delete(BusinessScopeType businessScopeType);
        BusinessScopeType GetModelById(string id);
        List<BusinessScopeType> GetAllList();
    }
}
