using ZHT.Data.DbFactory;
using ZHT.Data.Models;
using ZHT.Repository.Base;

namespace ZHT.Repository
{
    public class BusinessTypeRepository : BaseRepository<BusinessType>, IBusinessTypeRepository
    {
        public BusinessTypeRepository(IDataBaseFactory businessTypeRepository) :base(businessTypeRepository)
        {

        }
    }
}
