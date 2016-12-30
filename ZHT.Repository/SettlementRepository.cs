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
    public class SettlementRepository : BaseRepository<Settlement>, ISettlementRepository
    {
        public SettlementRepository(IDataBaseFactory SettlementRepository) :base(SettlementRepository)
        {

        }
    }
}
