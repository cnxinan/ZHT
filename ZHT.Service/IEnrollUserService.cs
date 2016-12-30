using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;
using Webdiyer.WebControls.Mvc;

namespace ZHT.Service
{
    public interface IEnrollUserService
    {
        void Insert(EnrollUser enrollUser);
        void Delete(EnrollUser enrollUser);
        void Update(EnrollUser enrollUser);
        EnrollUser GetModelById(string id);
        EnrollUser GetModelByPwdNumber(string pwdNumber);
        EnrollUser GetModelByOrderNo(string orderNo);
        List<EnrollUser> GetAllList();
        PagedList<EnrollUser> GetListPageByExhibitionId(string exhibitionId, int pageIndex, int pageSize, string searchKey = null,string status = null);
    }
}
