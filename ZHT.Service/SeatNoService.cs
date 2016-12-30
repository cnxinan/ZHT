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
    public class SeatNoService : ISeatNoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISeatNoRepository _seatNoRepository;
        public SeatNoService(IUnitOfWork unitOfWork, ISeatNoRepository seatNoRepository)
        {
            _unitOfWork = unitOfWork;
            _seatNoRepository = seatNoRepository;
        }
        public void Delete(SeatNo seatNo)
        {
            _seatNoRepository.Delete(seatNo);
            _unitOfWork.Commint();
        }

        public List<SeatNo> GetAllList()
        {
            return _seatNoRepository.Table.ToList();
        }

        public SeatNo GetModelById(string id)
        {
            return _seatNoRepository.GetById(id);
        }

        public void Insert(SeatNo seatNo)
        {
            _seatNoRepository.Add(seatNo);
            _unitOfWork.Commint();
        }

        public void Update(SeatNo seatNo)
        {
            _seatNoRepository.Update(seatNo);
            _unitOfWork.Commint();
        }
    }
}
