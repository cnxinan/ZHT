using ZHT.Data.DbFactory;
using ZHT.Data.Models;
using ZHT.Repository.Base;

namespace ZHT.Repository
{
    public class ContentTypeRepository : BaseRepository<ContentType>, IContentTypeRepository
    {
        public ContentTypeRepository(IDataBaseFactory contentTypeRepository) :base(contentTypeRepository)
        {

        }
    }
}
