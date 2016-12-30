using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;
using ZHT.Data.Models;

namespace ZHT.Service
{
    public interface IExhibitionService
    {
        void InsertExhibition(Exhibition exhibition);
        void Update(Exhibition exhibition);
        void Delete(Exhibition exhibition);

        Exhibition GetModelById(string id);
        List<Exhibition> GetAllList();

        List<Exhibition> GetExhibitionListByStatus(int status);
        PagedList<Exhibition> GetExhibitionListByStatusPage(int status, int pageIndex, int pageSize, string searchKey = null);
    }
}
