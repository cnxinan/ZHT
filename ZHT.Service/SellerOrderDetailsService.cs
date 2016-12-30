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
    public class SellerOrderDetailsService : ISellerOrderDetailsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISellerOrderDetailsRepository _sellerOrderDetailsRepository;
        public SellerOrderDetailsService(IUnitOfWork unitOfWork, ISellerOrderDetailsRepository sellerOrderDetailsRepository )
        {
            _unitOfWork = unitOfWork;
            _sellerOrderDetailsRepository = sellerOrderDetailsRepository;
        }
        public void Delete(SellerOrderDetails sellerOrderDetails)
        {
            _sellerOrderDetailsRepository.Delete(sellerOrderDetails);
            _unitOfWork.Commint();
        }

        public List<SellerOrderDetails> GetAllList()
        {
            return _sellerOrderDetailsRepository.Table.ToList();
        }

        public SellerOrderDetails GetModelById(string id)
        {
            return _sellerOrderDetailsRepository.GetById(id);
        }

        public void Insert(SellerOrderDetails sellerOrderDetails)
        {
            _sellerOrderDetailsRepository.Add(sellerOrderDetails);
            _unitOfWork.Commint();
        }

        public void Update(SellerOrderDetails sellerOrderDetails)
        {
            _sellerOrderDetailsRepository.Update(sellerOrderDetails);
            _unitOfWork.Commint();
        }

        public SellerOrderDetails GetModelBySeatNoCode(string seatNoCode)
        {
            return _sellerOrderDetailsRepository.Table.Where(t=>t.seatnocode == seatNoCode).FirstOrDefault();
        }
    }
}
