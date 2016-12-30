using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface IGoodsUnitService
    {
        void InsertBaseTypes(GoodsUnit goodsUnit);
        void Update(GoodsUnit goodsUnit);
        void Delete(GoodsUnit goodsUnit);
        GoodsUnit GetModelById(string id);
        List<GoodsUnit> GetAllList();
    }
}
