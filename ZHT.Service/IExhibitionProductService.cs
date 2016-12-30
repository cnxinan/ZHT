using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;
using Webdiyer.WebControls.Mvc;

namespace ZHT.Service
{
   public interface IExhibitionProductService
    {
        void Insert(ExhibitionProduct exhibitionProduct);
        void Delete(ExhibitionProduct exhibitionProduct);
        void Update(ExhibitionProduct exhibitionProduct);
        ExhibitionProduct GetModelById(string id);
        ExhibitionProduct GetModelByExhibitionIdAndPId(string exhibitionId, string yxProductCode);
        List<ExhibitionProduct> GetAllList();
        PagedList<ExhibitionProduct> GetListPageByExhibitionId(string exhibitionId, int pageIndex, int pageSize, string searchKey = null);
    }
}
