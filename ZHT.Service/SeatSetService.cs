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
    public class SeatSetService : ISeatSetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISeatSetRepository _seatSetRepository;
        public SeatSetService(IUnitOfWork unitOfWork,ISeatSetRepository seatSetRepository)
        {
            _unitOfWork = unitOfWork;
            _seatSetRepository = seatSetRepository;
        }
        public List<SeatSet> GetAllList()
        {
            return _seatSetRepository.Table.ToList();
        }

        public void InsertSeatSet(SeatSet _seatSet)
        {
            _seatSetRepository.Add(_seatSet);
            _unitOfWork.Commint();
        }

        public void Delete(SeatSet _seatSet)
        {
            _seatSetRepository.Delete(_seatSet);
            _unitOfWork.Commint();
        }

        public void Update(SeatSet _seatSet)
        {
            _seatSetRepository.Update(_seatSet);
            _unitOfWork.Commint();
        }

        public SeatSet GetModelById(string id)
        {
            return _seatSetRepository.GetById(id);
        }
    }
}
