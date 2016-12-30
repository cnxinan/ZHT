using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;
using Webdiyer.WebControls.Mvc;


namespace ZHT.Service
{
   public interface ISellerOrderService
    {
        void Insert(SellerOrder sellerOrder);
        void Delete(SellerOrder sellerOrder);
        void Update(SellerOrder sellerOrder);
        SellerOrder GetModelById(string id);
        List<SellerOrder> GetAllList();
        SellerOrder GetModelByOrderNo(string orderNo);
        SellerOrder GetModelBySellerId(string exhibitionId, string sellerId);
        PagedList<SellerOrder> GetListPageByExhibition(string exhibitionId, int pageIndex, int pageSize, string searchKey = null,string status = null);
    }
}
