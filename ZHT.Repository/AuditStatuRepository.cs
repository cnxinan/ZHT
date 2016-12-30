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
    public class AuditStatuRepository : BaseRepository<AuditStatu>, IAuditStatuRepository
    {
        public AuditStatuRepository(IDataBaseFactory auditStatuRepository) :base(auditStatuRepository)
        {

        }
    }
}
