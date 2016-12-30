using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface IGoods_BusinessScopeTypeService
    {
        void InsertBaseTypes(Goods_BusinessScopeType goods_BusinessScopeType);
        void Update(Goods_BusinessScopeType goods_BusinessScopeType);
        void Delete(Goods_BusinessScopeType goods_BusinessScopeType);
        Goods_BusinessScopeType GetModelById(string id);
        List<Goods_BusinessScopeType> GetAllList();
    }
}
