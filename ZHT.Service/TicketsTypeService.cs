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
    public class TicketsTypeService : ITicketsTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITicketsTypeRepository _ticketsTypeRepository;
        public TicketsTypeService(IUnitOfWork unitOfWork,ITicketsTypeRepository ticketsTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _ticketsTypeRepository = ticketsTypeRepository;
        }
        public List<TicketsType> GetAllList()
        {
            return _ticketsTypeRepository.Table.ToList();
        }

        public TicketsType GetModelById(string id)
        {
           return _ticketsTypeRepository.GetById(id);
        }

        public void InsertTicketsType(TicketsType _ticketsType)
        {
            _ticketsTypeRepository.Add(_ticketsType);
            _unitOfWork.Commint();
        }

        public void Delete(TicketsType _ticketsType)
        {
            _ticketsTypeRepository.Delete(_ticketsType);
            _unitOfWork.Commint();
        }

        public void Update(TicketsType _ticketsType)
        {
            _ticketsTypeRepository.Update(_ticketsType);
            _unitOfWork.Commint();
        }
    }
}
