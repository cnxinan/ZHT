using ZHT.Data.DbFactory;
using ZHT.Data.Models;
using ZHT.Repository.Base;

namespace ZHT.Repository
{
    public class ContentInfoRepository : BaseRepository<ContentInfo>, IContentInfoRepository
    {
        public ContentInfoRepository(IDataBaseFactory contentInfoRepository) :base(contentInfoRepository)
        {

        }
    }
}
