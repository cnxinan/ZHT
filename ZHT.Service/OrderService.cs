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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        public OrderService(IUnitOfWork unitOfWork, IOrderRepository orderRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
        }
        public void Delete(Order order)
        {
            _orderRepository.Delete(order);
            _unitOfWork.Commint();
        }

        public Order GetModelById(string id)
        {
            return _orderRepository.GetById(id);
        }

        public void Insert(Order order)
        {
            _orderRepository.Add(order);
            _unitOfWork.Commint();
        }
        public void Update(Order order)
        {
            _orderRepository.Update(order);
            _unitOfWork.Commint();
        }

        public List<Order> GetAllList()
        {
            return _orderRepository.Table.ToList();
        }

        public Order GetModelByOrderNo(string orderNo)
        {
            return _orderRepository.Table.Where(t => t.orderNumber == orderNo).FirstOrDefault();
        }

        public List<Order> GetListByExhibitionId(string exhibitionId, string searchKey = null)
        {
            var query = _orderRepository.TableAsNoTracking.Where(t => t.sellerNumber == exhibitionId);

            query = query.OrderByDescending(t => t.createTime);

            return query.ToList();
        }

        public PagedList<Order> GetListPageByExhibitionId(string exhibitionId, int pageIndex, int pageSize, string orderNo = null, string mobile = null, string status = null)
        {
            var query = _orderRepository.TableAsNoTracking.Where(t => t.sellerNumber == exhibitionId && t.status != -1);

            if(!string.IsNullOrWhiteSpace(orderNo))
            {
                query = query.Where(t => t.orderNumber == orderNo);
            }

            if (!string.IsNullOrWhiteSpace(mobile))
            {
                query = query.Where(t=>t.telephone == mobile);
            }
            if (!string.IsNullOrWhiteSpace(status))
            {
                int s = int.Parse(status);
                query = query.Where(t=>t.status == s);
            }

            query = query.OrderByDescending(t=>t.createTime);

            return query.ToPagedList(pageIndex, pageSize);
        }
    }
}
