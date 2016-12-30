using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Core.UnitOfWork;
using ZHT.Data.Models;
using ZHT.Repository;

namespace ZHT.Service
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService(IUnitOfWork unitOfWork, IOrderDetailRepository orderDetailRepository)
        {
            _unitOfWork = unitOfWork;
            _orderDetailRepository = orderDetailRepository;
        }
        public void Delete(OrderDetail orderDetail)
        {
            _orderDetailRepository.Delete(orderDetail);
            _unitOfWork.Commint();
        }


        public OrderDetail GetModelById(string id)
        {
            return _orderDetailRepository.GetById(id);
        }

        public void InsertBaseTypes(OrderDetail orderDetail)
        {
            _orderDetailRepository.Add(orderDetail);
            _unitOfWork.Commint();
        }

        public void Update(OrderDetail orderDetail)
        {
            _orderDetailRepository.Update(orderDetail);
            _unitOfWork.Commint();
        }

        public List<OrderDetail> GetAllList()
        {
            return _orderDetailRepository.Table.ToList();
        }        
    }
}
