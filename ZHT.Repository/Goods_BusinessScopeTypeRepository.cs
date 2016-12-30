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
    public class Goods_BusinessScopeTypeRepository : BaseRepository<Goods_BusinessScopeType>, IGoods_BusinessScopeTypeRepository
    {
        public Goods_BusinessScopeTypeRepository(IDataBaseFactory goods_BusinessScopeTypeFactory) : base(goods_BusinessScopeTypeFactory)
        {

        }
    }
}
