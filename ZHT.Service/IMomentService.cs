using System.Collections.Generic;
using ZHT.Data.Models;
using Webdiyer.WebControls.Mvc;

namespace ZHT.Service
{
    public  interface IMomentService
    {
        void Insert(Moment moment);
        void Delete(Moment moment);
        void Update(Moment moment);
        Moment GetModelById(string id);
        List<Moment> GetAllList();
        List<Moment> GetListByExhibitionId(string exhibitionId);
        List<Moment> GetNoViewdMomentList(string exhibitionId, string loginUserId);
        PagedList<Moment> GetListPageByExhibitionId(string exhibitionId, int pageIndex, int pageSize, string searchKey = null);
        int GetNoViewdMomentCount(string exhibitionId, string loginUserId);
    }
}
