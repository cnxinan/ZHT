using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface ISettlementService
    {
        void Insert(Settlement yxProduct);
        void Delete(Settlement yxProduct);
        void Update(Settlement yxProduct);
        Settlement GetModelById(string id);
        List<Settlement> GetAllList();
        Settlement GetModelByExhibitionAndType(string exhibitonId, int type);
        PagedList<Settlement> GetPagedList(int pageIndex, int pageSize, string exhibitionName, string type);
    }
}
