using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface IGoods_MaterialService
    {
        void InsertBaseTypes(Goods_Material goods_Material);
        void Update(Goods_Material goods_Material);
        void Delete(Goods_Material goods_Material);
        Goods_Material GetModelById(string id);
        List<Goods_Material> GetAllList();
    }
}
