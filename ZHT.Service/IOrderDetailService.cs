using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
    public interface IOrderDetailService
    {
        void InsertBaseTypes(OrderDetail orderDetail);
        void Update(OrderDetail orderDetail);
        void Delete(OrderDetail orderDetail);
        OrderDetail GetModelById(string id);
        List<OrderDetail> GetAllList();
    }
}
