using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;
using Webdiyer.WebControls.Mvc;

namespace ZHT.Service
{
   public interface IOrderService
    {
        void Insert(Order order);
        void Update(Order order);
        void Delete(Order order);
        Order GetModelById(string id);
        List<Order> GetAllList();
        Order GetModelByOrderNo(string orderNo);
        List<Order> GetListByExhibitionId(string exhibitionId, string searchKey = null);
        PagedList<Order> GetListPageByExhibitionId(string exhibitionId, int pageIndex, int pageSize, string orderNo = null, string mobile = null, string status = null);
    }
}
