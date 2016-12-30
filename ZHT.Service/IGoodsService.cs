using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface IGoodsService
    {
        void InsertBaseTypes(Goods goods);
        void Update(Goods goods);
        void Delete(Goods goods);
        Goods GetModelById(string id);
        List<Goods> GetAllList();
        List<Goods> GetGoodsByCreator(string creator);
        string GetGoodHeadImg(string goodsCode, string serviceUrl);
        List<string> GetGoodsImgs(string goodsCode, string serviceUrl);
    }
}
