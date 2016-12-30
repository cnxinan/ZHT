using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface ISellerOrderDetailsService
    {
        void Insert(SellerOrderDetails sellerOrderDetails);
        void Delete(SellerOrderDetails sellerOrderDetails);
        void Update(SellerOrderDetails sellerOrderDetails);
        SellerOrderDetails GetModelById(string id);
        List<SellerOrderDetails> GetAllList();
        SellerOrderDetails GetModelBySeatNoCode(string seatNoCode);
    }
}
