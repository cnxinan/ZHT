using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.DbFactory;
using ZHT.Data.Models;
using ZHT.Repository.Base;

namespace ZHT.Repository
{
    public class Goods_MaterialRepository : BaseRepository<Goods_Material>, IGoods_MaterialRepository
    {
        public Goods_MaterialRepository(IDataBaseFactory goods_MaterialRepository) : base(goods_MaterialRepository)
        {

        }
    }
}
