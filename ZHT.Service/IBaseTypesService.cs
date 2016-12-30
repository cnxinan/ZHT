using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
    public interface IBaseTypesService
    {
        void InsertBaseTypes(BaseTypes _baseType);
        void Update(BaseTypes baseType);
        void Delete(BaseTypes baseType);
        BaseTypes GetModelById(string id);
        List<BaseTypes> GetBaseTypesList();

    }
}
