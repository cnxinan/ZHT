using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;
using ZHT.Core.UnitOfWork;
using ZHT.Data.Models;
using ZHT.Repository;

namespace ZHT.Service
{
    public class SellerOrderService : ISellerOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISellerOrderRepository _sellerOrderRepository;
        public SellerOrderService(IUnitOfWork unitOfWork, ISellerOrderRepository sellerOrderRepository)
        {
            _unitOfWork = unitOfWork;
            _sellerOrderRepository = sellerOrderRepository;
        }
        public void Delete(SellerOrder sellerOrder)
        {
            _sellerOrderRepository.Delete(sellerOrder);
            _unitOfWork.Commint();
        }

        public List<SellerOrder> GetAllList()
        {
            return _sellerOrderRepository.Table.ToList();
        }

        public SellerOrder GetModelById(string id)
        {
            return _sellerOrderRepository.GetById(id);
        }

        public void Insert(SellerOrder sellerOrder)
        {
            _sellerOrderRepository.Add(sellerOrder);
            _unitOfWork.Commint();
        }

        public void Update(SellerOrder sellerOrder)
        {
            _sellerOrderRepository.Update(sellerOrder);
            _unitOfWork.Commint();
        }

        public SellerOrder GetModelByOrderNo(string orderNo)
        {
            return _sellerOrderRepository.Table.Where(t => t.orderno == orderNo).FirstOrDefault();
        }

        public SellerOrder GetModelBySellerId(string exhibitionId, string sellerId)
        {
            return _sellerOrderRepository.Table.Where(t => t.exhibitionid == exhibitionId && t.sellerid == sellerId).FirstOrDefault();
        }

        public PagedList<SellerOrder> GetListPageByExhibition(string exhibitionId, int pageIndex, int pageSize, string searchKey = null, string status = null)
        {
            var query = _sellerOrderRepository.Table.Where(t => t.exhibitionid == exhibitionId && t.isdel == 0 && t.orderstatus != -1);

            if (!string.IsNullOrWhiteSpace(searchKey))
            {
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                int s = int.Parse(status);
                query = query.Where(t => t.orderstatus == s);
            }

            query = query.OrderByDescending(t=>t.creattime);

            return query.ToPagedList(pageIndex,pageSize);
        }

    }
}
