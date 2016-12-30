using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface IExhibitionProductClassService
    {
        void Insert(ExhibitionProductClass exhibitionProductClass);
        void Delete(ExhibitionProductClass exhibitionProductClass);
        void Update(ExhibitionProductClass exhibitionProductClass);
        ExhibitionProductClass GetModelById(string id);
        List<ExhibitionProductClass> GetAllList();
        PagedList<ExhibitionProductClass> GetListPageByExhibitionId(string exhibitionId, int pageIndex, int pageSize, string searchKey = null);
    }
}
